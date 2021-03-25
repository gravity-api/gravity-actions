/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *
 * 2019-02-18
 *    - modify: fix a bug where close throws an exception when not implemented on server side
 *    
 * 2019-01-11
 *    - modify: override action-name using action constant
 *    
 * 2019-01-03
 *    - modify: use JSON resources
 *    - modify: improve XML comments
 *    
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.CloseBrowser.json",
        Name = PluginsList.CloseBrowser)]
    public class CloseBrowser : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public CloseBrowser(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            try
            {
                WebDriver?.Close();
            }
            finally
            {
                WebDriver?.Dispose();
            }
        }
    }
}