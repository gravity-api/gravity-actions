/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch_to_window.json",
        Name = Contracts.PluginsList.SwitchToWindow)]
    public class SwitchToWindow : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SwitchToWindow(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Selects either the first frame on the page or the main document when a page contains frames.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Selects either the first frame on the page or the main document when a page contains frames.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action);
        }

        // execute action routine
        private void DoAction(ActionRule action)
        {
            // exit condition
            if (WebDriver.WindowHandles.Count == 1)
            {
                return;
            }

            // parse window index
            int.TryParse(action.Argument, out int indexOut);

            // last tab/window conditions
            if (WebDriver.WindowHandles.Count < indexOut + 1)
            {
                indexOut = WebDriver.WindowHandles.Count - 1;
            }

            // main window conditions
            if (indexOut < 0)
            {
                indexOut = 0;
            }

            // switch to the given window (by index)
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles[indexOut]);
        }
    }
}