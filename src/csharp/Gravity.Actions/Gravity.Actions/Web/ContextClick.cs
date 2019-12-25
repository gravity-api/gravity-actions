/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-11
 *    - modify: improve XML comments
 *    
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Web
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.context-click.json",
        Name = ActionType.CONTEXT_CLICK)]
    public class ContextClick : ActionPlugin
    {
        // members: state
        private readonly Actions actions;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public ContextClick(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories</param>
        public ContextClick(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            actions = new Actions(webDriver);
        }

        /// <summary>
        /// Right clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            // exit conditions
            if (Flat(actionRule))
            {
                return;
            }

            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // execute action
            var element = WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout));
            actions.ContextClick(element).Build().Perform();
        }

        /// <summary>
        /// right-clicks the mouse at the last known mouse coordinates or on the specified element
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            // exit conditions
            if (Flat(actionRule))
            {
                return;
            }

            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // execute action
            var element = IsAbsoluteXPath(actionRule)
                ? WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout))
                : webElement.FindElement(by);
            actions.ContextClick(element).Build().Perform();
        }

        // execute flat action
        private bool Flat(ActionRule actionRule) => WasFlatAction(actionRule, () =>
        {
            actions.ContextClick().Build().Perform();
            return true;
        });
    }
}
