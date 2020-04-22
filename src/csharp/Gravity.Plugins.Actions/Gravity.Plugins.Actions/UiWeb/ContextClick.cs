﻿/*
 * CHANGE LOG - keep only last 5 threads
 *
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-11
 *    - modify: improve XML comments
 *
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.context_click.json",
        Name = WebPlugins.ContextClick)]
    public class ContextClick : WebDriverActionPlugin
    {
        // members: state
        private readonly SeleniumActions actions;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ContextClick(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        {
            actions = new SeleniumActions(driver);
        }
        #endregion

        /// <summary>
        /// Right clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(element: default, actionRule);
        }

        /// <summary>
        /// right-clicks the mouse at the last known mouse coordinates or on the specified element
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(element, actionRule);
        }

        // executes action routine
        private void DoAction(IWebElement element, ActionRule actionRule)
        {
            // flat conditions
            if (PluginUtilities.IsFlatAction(actionRule, element))
            {
                actions.ContextClick().Build().Perform();
                return;
            }

            // get element
            var onElement = this.ConditionalGetElement(element, actionRule);

            // on element action
            actions.ContextClick(onElement).Build().Perform();
        }
    }
}