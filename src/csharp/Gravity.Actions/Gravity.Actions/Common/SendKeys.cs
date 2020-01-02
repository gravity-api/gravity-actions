/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 *    - modify: code cleaning
 *    
 * 2019-12-31
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 * http://appium.io/docs/en/writing-running-appium/android/android-shell/
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.send-keys.json",
        Name = ActionType.SEND_KEYS)]
    public class SendKeys : ActionPlugin
    {
        // constants
        private const string Clear = "clear";
        private const string ForceClear = "forceClear";
        private const string Interval = "interval";
        private const string Keystrokes = "keys";
        private const string Down = "down";

        // members: state
        private readonly WebAutomation webAutomation;
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public SendKeys(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public SendKeys(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            // setup
            this.webAutomation = webAutomation;
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoSendKeys(webElement: default, actionRule);
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoSendKeys(webElement, actionRule);
        }

        // executes SendKeys routine
        private void DoSendKeys(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            arguments = SetArguments(actionRule);
            var conditions = SetConditions();
            var element = GetElement(webElement, actionRule);

            // execute: clear
            if (conditions["isClear"])
            {
                element.Clear();
            }

            // execute: force clear
            if (conditions["isForceClear"])
            {
                DoForceClear(element);
            }

            // execute: send keys with interval
            if (conditions["isInterval"])
            {
                DoInterval(element);
                return;
            }

            // execute: keys combination
            if (conditions["isDown"])
            {
                DoDownCombination();
                return;
            }

            // keys android UIAutomator2
            if (conditions["isAndroid"])
            {
                DoAndroid(element);
                return;
            }

            // execute: default
            element.SendKeys(actionRule.Argument);
        }

        // populate action arguments based on action rule or CLI
        private static IDictionary<string, string> SetArguments(ActionRule actionRule)
        {
            // initialize CLI factory
            var cliFactory = new CliFactory(actionRule.Argument);

            // initialize arguments (if needed)
            return cliFactory.CliCompliant
                ? cliFactory.Parse()
                : new Dictionary<string, string> { [Keystrokes] = actionRule.Argument };
        }

        // setup the different conditions for invoking SendKeys scenarios
        private IDictionary<string, bool> SetConditions()
        {
            // setup
            var driverParams = webAutomation.DriverParams ?? string.Empty;

            // setup conditions
            var isClear = arguments.ContainsKey(Clear);
            var isForceClear = !isClear && arguments.ContainsKey(ForceClear);
            var isDown = arguments.ContainsKey(Down);
            var isKeys = arguments.ContainsKey(Keystrokes);
            var isInterval = isKeys && !isDown && arguments.ContainsKey(Interval);
            var isUiautomator2 = !Regex.IsMatch(driverParams, "uiautomator1", RegexOptions.IgnoreCase);
            var isAndroid = isUiautomator2 && (WebDriver.IsAppiumDriver());

            return new Dictionary<string, bool>
            {
                [nameof(isClear)] = isClear,
                [nameof(isForceClear)] = isForceClear,
                [nameof(isDown)] = isDown,
                [nameof(isKeys)] = isKeys,
                [nameof(isInterval)] = isInterval,
                [nameof(isUiautomator2)] = isUiautomator2,
                [nameof(isAndroid)] = isAndroid
            };
        }

        // gets web element into which to send the keys
        private IWebElement GetElement(IWebElement webElement, ActionRule actionRule)
        {
            // setup locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // get element
            return webElement == default
                ? WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout))
                : webElement.FindElement(by);
        }

        // CONDITIONS REPOSITORY
        // force to clear the element value by sending <Backspace> strokes
        private void DoForceClear(IWebElement webElement)
        {
            // exit conditions
            if (WebDriver.IsAppiumDriver())
            {
                return;
            }

            // constants
            const string M1 = "WebElement does not have a [value] attribute. [ForceClear] action was not executed.";

            // force clear
            try
            {
                var attribute = webElement.GetAttribute("value");
                webElement.SendKeys(Keys.End);
                for (int i = 0; i < attribute.Length; i++)
                {
                    webElement.SendKeys(Keys.Backspace);
                    Thread.Sleep(50);
                }
            }
            catch (Exception e) when (e is NullReferenceException || e is WebDriverException)
            {
                Trace.TraceWarning(M1);
            }
        }

        // simulates typing text into the element with time interval between each keystroke
        private void DoInterval(IWebElement webElement)
        {
            // parse typing interval
            int.TryParse(arguments[Interval], out int intervalOut);

            // execute action
            webElement.SendKeysWithInterval(arguments[Keystrokes], intervalOut);
        }

        // holds down a combination of keys before sending keystrokes
        private void DoDownCombination()
        {
            // exit conditions
            if (WebDriver.IsAppiumDriver())
            {
                return;
            }

            // get keys down
            var keysDown = arguments[Down].Split(',');

            // initialize actions
            var actions = new Actions(WebDriver);

            // down-keys
            foreach (var i in keysDown)
            {
                actions.KeyDown(GetKey(i));
            }

            // send keys
            actions.SendKeys(arguments[Keystrokes]);

            // up-keys
            foreach (var i in keysDown)
            {
                actions.KeyUp(GetKey(i));
            }

            // complete pipeline
            actions.Build().Perform();
        }

        // simulates typing text into the element using ADB shell to bypass some end cases application bugs
        // on UIAutomator2
        private void DoAndroid(IWebElement webElement)
        {
            // focus on the element
            new Actions(WebDriver).MoveToElement(webElement).Click().Perform();

            // get the focused element
            var focusedElement = WebDriver.FindElement(By.XPath("//*[@focused='true']"));

            // send keystrokes
            focusedElement.SendKeys(arguments[Keystrokes]);
        }
    }
}