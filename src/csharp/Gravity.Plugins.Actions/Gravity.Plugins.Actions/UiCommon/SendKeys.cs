/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-19
 *    -    fix: bug - default action did not send keys from arguments[Keystrokes]
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-31
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 *    - modify: code cleaning
 * 
 * online resources
 * http://appium.io/docs/en/writing-running-appium/android/android-shell/
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.send_keys.json",
        Name = Contracts.PluginsList.SendKeys)]
    public class SendKeys : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Clears the element value, before typing into it.
        /// </summary>
        public const string Clear = "clear";

        /// <summary>
        /// Clears the element value using <backspace> key, performing the clearing using real keyboard actions.
        /// This action is not supported on [mobile-native] applications.
        /// </summary>
        public const string ForceClear = "force_clear";

        /// <summary>
        /// The interval time between each character typing.
        /// </summary>
        public const string Interval = "interval";

        /// <summary>
        /// The text to type into the element.
        /// </summary>
        public const string Keystrokes = "keys";

        /// <summary>
        /// Array of keys to press down while sending keys (use for simulate [control]+a, [control]+[shift]+[delete], etc.
        /// </summary>
        public const string Down = "down";
        #endregion

        // members: state
        private IDictionary<string, string> arguments;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SendKeys(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // setup            
            arguments = SetArguments(action);
            var conditions = SetConditions().Where(i => i.Value);
            var regex = conditions.Any() ? string.Join("|", conditions.Select(i => i.Key)) : string.Empty;
            var onElement = this.ConditionalGetElement(element, action);

            // execute: default
            if (string.IsNullOrEmpty(regex))
            {
                onElement.SendKeys(arguments[Keystrokes]);
                return;
            }

            foreach (var method in GetType().GetMethodsByDescription(regex))
            {
                DoActionIteration(method, element: onElement);
            }
        }

        // populate action arguments based on action rule or CLI
        private IDictionary<string, string> SetArguments(ActionRule action)
        {
            // initialize CLI factory
            var args = CliFactory.Parse(action.Argument);

            // setup conditions
            if (!CliFactory.CliCompliant)
            {
                args[Keystrokes] = action.Argument;
                return args;
            }

            // setup keys
            args[Keystrokes] = args.ContainsKey(Keystrokes) ? args[Keystrokes] : string.Empty;
            return args;
        }

        // setup the different conditions for invoking SendKeys scenarios
        private IDictionary<string, bool> SetConditions()
        {
            // setup
            var driverParams = Automation.DriverParams ?? new Dictionary<string, object>();

            // setup conditions
            var isClear = arguments.ContainsKey(Clear);
            var isForceClear = !isClear && arguments.ContainsKey(ForceClear);
            var isDown = arguments.ContainsKey(Down);
            var isInterval = !isDown && arguments.ContainsKey(Interval);
            var isUiautomator2 = driverParams.Values.Any(i => !Regex.IsMatch($"{i}", "uiautomator1", RegexOptions.IgnoreCase));
            var isAndroid = isUiautomator2 && (WebDriver.IsAppiumDriver());
            var isKeys = !isAndroid && !isInterval && arguments.ContainsKey(Keystrokes);

            return new Dictionary<string, bool>
            {
                [nameof(isClear)] = isClear,
                [nameof(isForceClear)] = isForceClear,
                [nameof(isDown)] = isDown,
                [nameof(isInterval)] = isInterval,
                [nameof(isAndroid)] = isAndroid,
                [nameof(isKeys)] = isKeys
            };
        }

        // executes a single send keys method
        private void DoActionIteration(MethodInfo method, IWebElement element)
        {
            if (method.GetParameters().Length == 0)
            {
                method.Invoke(obj: this, parameters: null);
                return;
            }
            method.Invoke(obj: this, parameters: new object[] { element });
        }

        // CONDITIONS REPOSITORY
#pragma warning disable S1144, RCS1213, IDE0051
        [Description("isClear")]
        private void DoClear(IWebElement element) => element.Clear();

        [Description("isForceClear")]
        private void DoForceClear(IWebElement element)
        {
            // exit conditions
            if (WebDriver.IsAppiumDriver())
            {
                return;
            }

            // force clear
            try
            {
                var attribute = element.GetAttribute("value");
                element.SendKeys(Keys.End);
                for (int i = 0; i < attribute.Length; i++)
                {
                    element.SendKeys(Keys.Backspace);
                    Thread.Sleep(50);
                }
            }
            catch (Exception e) when (e is NullReferenceException || e is WebDriverException)
            {
                // ignore exceptions
            }
        }

        [Description("isInterval")]
        private void DoInterval(IWebElement element)
        {
            // parse typing interval
            int.TryParse(arguments[Interval], out int intervalOut);

            // execute action
            element.DelayedSendKeys(arguments[Keystrokes], intervalOut);
        }

        [Description("isDown")]
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
            var actions = new SeleniumActions(WebDriver);

            // down-keys
            foreach (var i in keysDown)
            {
                actions.KeyDown(GetKeyboardKey(i));
            }

            // send keys
            actions.SendKeys(arguments[Keystrokes]);

            // up-keys
            foreach (var i in keysDown)
            {
                actions.KeyUp(GetKeyboardKey(i));
            }

            // complete pipeline
            actions.Build().Perform();
        }

        [Description("isAndroid")]
        private void DoAndroid(IWebElement element)
        {
            try
            {
                element.SendKeys(arguments[Keystrokes]);
            }
            catch (Exception e) when (e is InvalidElementStateException)
            {
                // focus on the element
                new SeleniumActions(WebDriver).MoveToElement(element).Click().Perform();

                // get the focused element
                var focusedElement = WebDriver.FindElement(By.XPath("//*[@focused='true']"));

                // send keystrokes
                focusedElement.SendKeys(arguments[Keystrokes]);
            }
        }

        [Description("isKeys")]
        private void DoKeys(IWebElement element) => element?.SendKeys(arguments["keys"]);
#pragma warning restore
    }
}