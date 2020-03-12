/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.go_to_url.json",
        Name = WebPlugins.GoToUrl)]
    public class GoToUrl : WebDriverActionPlugin
    {
        #region *** conditions   ***
        /// <summary>
        /// "Opens the URL address using [_blank] property (under new tab or window).
        /// </summary>
        public const string Blank = "blank";

        /// <summary>
        /// The URL address to navigate to.
        /// </summary>
        public const string Url = "url";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public GoToUrl(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        // members: state
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Load a new web page in the current browser window.
        /// This is done using an HTTP GET operation and the method will block until the load is complete.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Load a new web page in the current browser window.
        /// This is done using an HTTP GET operation and the method will block until the load is complete.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            arguments = GetArguments(actionRule.Argument);
            var url = GetUrlAddress(actionRule, element);

            // navigate
            if (arguments.ContainsKey(Blank))
            {
                OpenUnderNewTab();
            }
            WebDriver.Url = url;

            // maximize
            if (WebDriver.IsAppiumDriver())
            {
                return;
            }
            WebDriver.Manage().Window.Maximize();
        }

        private IDictionary<string, string> GetArguments(string cli) => Utilities.CliFactory.Compile(cli)
            ? CliFactory.Parse(cli)
            : new Dictionary<string, string>
            {
                [Url] = cli
            };

        private string GetUrlAddress(ActionRule actionRule, IWebElement element)
        {
            // setup
            var onElement = this.ConditionalGetElement(element, actionRule);

            // exit conditions
            if (onElement == default)
            {
                return arguments[Url];
            }

            // result
            return string.IsNullOrEmpty(actionRule.ElementAttributeToActOn)
                ? onElement.Text
                : onElement.GetAttribute(actionRule.ElementAttributeToActOn);
        }

        // UTILITIES
        // generates new window (or tab - depends on your browser) and switch to it
        private void OpenUnderNewTab()
        {
            // get current windows count
            var totalWindows = WebDriver.WindowHandles.Count;

            // open new blank-tab
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("window.open('about:blank', '_blank');");

            // get current windows count
            var totalWindowsNext = WebDriver.WindowHandles.Count;

            // exit condition
            if (totalWindows == totalWindowsNext)
            {
                return;
            }

            // switch to the new tab
            SwitchToNewTab();
        }

        // switches the focus of future commands for this driver to the window with the given name
        private void SwitchToNewTab()
        {
            for (int i = 0; i < WebDriver.WindowHandles.Count; i++)
            {
                // skip existing tabs
                if (WebDriver.CurrentWindowHandle != WebDriver.WindowHandles[i])
                {
                    continue;
                }

                // switch to the relevant tab
                WebDriver.SwitchToWindow(i + 1);
                break;
            }
        }
    }
}