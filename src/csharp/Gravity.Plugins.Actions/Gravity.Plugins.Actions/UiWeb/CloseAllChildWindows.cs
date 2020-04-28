/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * 2019-12-23
 *    - modify: add on element override to allow calling from extraction rules
 *
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-01-03
 *    - modify: use JSON resources
 *    - modify: improve XML comments
 *
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using System.Threading;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.close_all_child_windows.json",
        Name = WebPlugins.CloseAllChildWindows)]
    public class CloseAllChildWindows : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public CloseAllChildWindows(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Close all open tabs/windows and switch to the main (first) window.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction();
        }

        /// <summary>
        /// Close all open tabs/windows and switch to the main (first) window.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction();
        }

        private void DoAction()
        {
            // exit conditions
            if (WebDriver.WindowHandles.Count == 1)
            {
                return;
            }

            // action routine: close each > switch back to main window
            var mainWindow = WebDriver.WindowHandles[0];

            foreach (var window in WebDriver.WindowHandles)
            {
                if (window == mainWindow)
                {
                    continue;
                }
                WebDriver.SwitchTo().Window(window).Close();
                Thread.Sleep(100);
            }

            // focus on main windows
            WebDriver.SwitchTo().Window(windowName: mainWindow);
        }
    }
}