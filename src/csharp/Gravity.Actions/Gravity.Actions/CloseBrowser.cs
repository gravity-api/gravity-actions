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
 * 2019-02-18
 *    - modify: fix a bug where close throws an exception when not implemented on server side
 *
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *
 * on-line resources
 */
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.close-browser.json",
        Name = ActionType.CLOSE_BROWSER)]
    public class CloseBrowser : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public CloseBrowser(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories</param>
        public CloseBrowser(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(ActionRule actionRule)
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
