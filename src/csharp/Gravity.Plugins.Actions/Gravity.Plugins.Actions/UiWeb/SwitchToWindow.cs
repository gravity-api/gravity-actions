/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch-to-window.json",
        Name = WebPlugins.SwitchToWindow)]
    public class SwitchToWindow : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SwitchToWindow(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Selects either the first frame on the page or the main document when a page contains frames.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule);
        }

        /// <summary>
        /// Selects either the first frame on the page or the main document when a page contains frames.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule);
        }

        // execute action routine
        private void DoAction(ActionRule actionRule)
        {
            // constants
            const string W1 = "Browser does not have any open tabs/windows. Action [SwitchToWindow] was skipped.";
            const string W2 = "The provided index is greater then browsers tabs/windows count. Switching to the last tab/window.";
            const string W3 = "The provided index is lower then browsers tabs/windows count. Switching to the first tab/window.";

            // exit condition
            if (WebDriver.WindowHandles.Count == 1)
            {
                Logger.LogWarning(W1);
                return;
            }

            // parse window index
            int.TryParse(actionRule.Argument, out int indexOut);

            // last tab/window conditions
            if (WebDriver.WindowHandles.Count < indexOut + 1)
            {
                Logger.LogInformation(W2);
                indexOut = WebDriver.WindowHandles.Count - 1;
            }

            // main window conditions
            if (indexOut < 0)
            {
                Logger.LogInformation(W3);
                indexOut = 0;
            }

            // switch to the given window (by index)
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[indexOut]);
        }
    }
}