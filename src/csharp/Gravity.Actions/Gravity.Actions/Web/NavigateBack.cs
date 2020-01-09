/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override action-name using ActionType constant
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

namespace Gravity.Services.ActionPlugins.Web
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.navigate-back.json",
        Name = ActionType.NavigateBack)]
    public class NavigateBack : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public NavigateBack(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public NavigateBack(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Move back a single entry in the browser's history.
        /// The action will be completed when page readyState='complete' or until page loading timeout reached.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoNavigateBack(actionRule);
        }

        /// <summary>
        /// Move back a single entry in the browser's history.
        /// The action will be completed when page readyState='complete' or until page loading timeout reached.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoNavigateBack(actionRule);
        }

        // executes NavigateBack routine
        private void DoNavigateBack(ActionRule actionRule)
        {
            // set default value
            var iterations = 1;

            // normalize iterations
            iterations = int.TryParse(actionRule.Argument, out int iterationsOut) ? iterationsOut : iterations;

            // navigate
            for (int i = 0; i < iterations; i++)
            {
                WebDriver.Navigate().Back();
                if (i >= iterations - 1)
                {
                    break;
                }
                WaitForState("complete", 200);
            }
        }
    }
}