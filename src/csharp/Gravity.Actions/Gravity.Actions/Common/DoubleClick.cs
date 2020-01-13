/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-25
 *    - modify: add constructor to override base class types
 *
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-01-03
 *    - modify: add support for double-click without specified element (flat action)
 *    - modify: improve XML comments
 *
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.double-click.json",
        Name = ActionType.DoubleClick)]
    public class DoubleClick : ActionPlugin
    {
        // members: state
        private readonly Actions actions;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public DoubleClick(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public DoubleClick(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            actions = new Actions(webDriver);
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(default, actionRule);
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule);
        }

        // executes action routine
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // flat conditions
            if (PluginUtilities.IsFlatAction(webElement, actionRule))
            {
                actions.DoubleClick().Build().Perform();
                return;
            }

            // setup
            var timeout = TimeSpan.FromMilliseconds(ElementSearchTimeout);

            // on element action
            var element = webElement != default
                ? webElement.GetElementByActionRule(ByFactory, actionRule, timeout)
                : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

            actions.DoubleClick(element).Build().Perform();
        }
    }
}