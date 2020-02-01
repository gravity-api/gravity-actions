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
using Gravity.Drivers.Selenium;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Web
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.close-browser.json",
        Name = ActionType.CloseWindow)]
    public class CloseWindow : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public CloseWindow(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public CloseWindow(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoCloseWindow(actionRule);
        }

        /// <summary>
        /// Close the given window, quitting the browser if it is the last window currently open.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
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
