/*
 * CHANGE LOG
 * 
 * 2019-01-03
 *    - modify: add support for double-click without specified element (flat action)
 *    - modify: improve XML comments
 *    
 * 2019-01-11
 *    - modify: override action-name using ActionType constant 
 * 
 * 2019-12-25
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
            // exit conditions
            if (Flat(actionRule))
            {
                return;
            }

            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // execute action
            var element = WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout));
            actions.DoubleClick(element).Build().Perform();
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
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

            // get element
            var element = IsAbsoluteXPath(actionRule)
                ? WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout))
                : webElement.FindElement(by);

            // execute action
            actions.DoubleClick(element).Build().Perform();
        }

        // execute flat action
        private bool Flat(ActionRule actionRule) => WasFlatAction(actionRule, () =>
        {
            actions.Click().Build().Perform();
            return true;
        });
    }
}