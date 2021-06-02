/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-03
 *    - modify: use JSON resources
 *    - modify: improve XML comments
 * 
 * 2019-01-11
 *    - modify: override action-name using action constant
 *    
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * RESOURCES
 * 
 * work items
 * TODO: remove "EDGE WORKAROUND - UNTIL SELENIUM 4" region when close extension method is available on Gravity.Core 
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Remote;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.CloseWindow.json",
        Name = GravityPlugins.CloseWindow)]
    public class CloseWindow : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public CloseWindow(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action);
        }

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action);
        }

        // executes CloseWindow routine
        private void InvokeAction(ActionRule action)
        {
            // exit conditions
            if (!int.TryParse(action.Argument, out int indexOut))
            {
                return;
            }

            // selenium client
            if (!IsEdge())
            {
                WebDriver.Close(indexOut);
                return;
            }

            // EDGE WORKAROUND - UNTIL SELENIUM 4
            // if index is out of bound, take no action
            if (indexOut > (WebDriver.WindowHandles.Count - 1))
            {
                return;
            }

            // setup
            var mainWindow = WebDriver.WindowHandles[0];
            var window = WebDriver.WindowHandles[indexOut];

            // action routine: close > switch back to main window
            WebDriver.SwitchTo(windowName: window).Close();
            if (WebDriver.WindowHandles?.Count > 0)
            {
                WebDriver.SwitchTo(windowName: mainWindow);
            }
        }

        private bool IsEdge()
        {
            // exit conditions
            if (WebDriver is not RemoteWebDriver rDriver)
            {
                return false;
            }

            // is edge
            return $"{rDriver.Capabilities["browserName"]}" == "msedge";
        }
    }
}