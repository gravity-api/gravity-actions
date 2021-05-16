/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-07-01
 *    - modify: re-factor
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
 * RESOURCES
 * http://appium.io/docs/en/writing-running-appium/android/android-shell/
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.SendKeys.json",
        Name = GravityPlugin.SendKeys)]
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

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
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
            var onElement = ConditionalGetElement(element, action);
            var arguments = GetArguments(action);

            // clear (will only clear if needed)
            DoClear(onElement, arguments);

            // send keys routine
            DoSendKeys(element: onElement, arguments);
        }

        private IDictionary<string, string> GetArguments(ActionRule action)
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

        private void DoClear(IWebElement element, IDictionary<string, string> arguments)
        {
            // exit conditions
            if (element == default)
            {
                return;
            }
            if (!arguments.ContainsKey(Clear) && !arguments.ContainsKey(ForceClear))
            {
                return;
            }

            // clear conditions
            if (arguments.ContainsKey(Clear) && !arguments.ContainsKey(ForceClear))
            {
                element.Clear();
                return;
            }

            // exit conditions
            if (IsMobileNative())
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

        private void DoSendKeys(IWebElement element, IDictionary<string, string> arguments)
        {
            // setup conditions
            var isElement = element != default;
            var isCombination = arguments.ContainsKey(Down);

            // no element
            if (!isElement)
            {
                DoKeysNoElement(arguments);
                return;
            }

            // combination
            if (isCombination)
            {
                DoKeysCombination(arguments);
                return;
            }

            // send keys
            DoKeysOnElement(element, arguments);
        }

        private void DoKeysNoElement(IDictionary<string, string> arguments)
        {
            new SeleniumActions(WebDriver)
                .SendKeys(keysToSend: arguments[Keystrokes])
                .Build()
                .Perform();
        }

        private void DoKeysCombination(IDictionary<string, string> arguments)
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

        private void DoKeysOnElement(IWebElement element, IDictionary<string, string> arguments)
        {
            // setup conditions
            var isDelayed = arguments.ContainsKey(Interval);

            // execute
            try
            {
                var keysAction = isDelayed ? DoInterval(element, arguments) : DoKeys(element, arguments);
                keysAction.Invoke();
            }
            catch (Exception e) when (e is InvalidElementStateException)
            {
                //exit conditions
                if (!WebDriver.IsAppiumDriver() && !IsMobileNative())
                {
                    throw;
                }

                // setup
                var actions = new SeleniumActions(WebDriver);

                // focus on the element
                element.Click();

                // send keys
                actions.SendKeys(keysToSend: arguments[Keystrokes]).Build().Perform();
            }
        }

        private static Action DoKeys(IWebElement element, IDictionary<string, string> arguments)
        {
            return new Action(() => element?.SendKeys(text: arguments[Keystrokes]));
        }

        private static Action DoInterval(IWebElement element, IDictionary<string, string> arguments)
        {
            return new Action(() =>
            {
                // parse typing interval
                _ = int.TryParse(arguments[Interval], out int intervalOut);

                // execute action
                element?.DelayedSendKeys(arguments[Keystrokes], intervalOut);
            });
        }

        private bool IsMobileNative()
        {
            // setup
            var driverParams = JsonSerializer.Serialize(Automation.DriverParams);

            // conditions
            return Regex.IsMatch(input: driverParams, pattern: "(?i)\"app\"(\\s+)?:(\\s+)?\".+?\"");
        }
    }
}