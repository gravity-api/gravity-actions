/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-03
 *    - modify: use JSON resources
 *    - modify: improve XML comments
 * 
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * on-line resources
 */
using OpenQA.Selenium.Extensions;
using Gravity.Plugins.Actions.Contracts;
using OpenQA.Selenium;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.close_browser.json",
        Name = WebPlugins.CloseWindow)]
    public class CloseWindow : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public CloseWindow(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoCloseWindow(actionRule);
        }

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoCloseWindow(actionRule);
        }

        // executes CloseWindow routine
        private void DoCloseWindow(ActionRule actionRule)
        {
            // exit conditions
            if (!int.TryParse(actionRule.Argument, out int indexOut))
            {
                return;
            }
            WebDriver.CloseWindow(indexOut);
        }
    }
}
