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
 *    - modify: override action-name using action constant
 *    
 * 2019-01-03
 *    - modify: use JSON resources
 *    - modify: improve XML comments
 *
 * online resources
 * 
 * work items
 * TODO: remove "DoSwitch(string windowName)" when available on Gravity.Core 
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.close_all_child_windows.json",
        Name = Contracts.PluginsList.CloseAllChildWindows)]
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
                DoSwitch(window).Close();
                Thread.Sleep(100);
            }

            // focus on main windows
            DoSwitch(windowName: mainWindow);
        }

        private IWebDriver DoSwitch(string windowName)
        {
            // exit conditions
            if (!(WebDriver is RemoteWebDriver rDriver))
            {
                return WebDriver.SwitchTo().Window(windowName);
            }

            // do switch
            if ($"{rDriver.Capabilities["browserName"]}" == "msedge")
            {
                WebDriver.SwitchTo(windowName);
            }
            else
            {
                WebDriver.SwitchTo().Window(windowName);
            }
            return WebDriver;
        }
    }
}