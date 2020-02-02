/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * 2019-08-22
 *    - modify: add support for special cases - for action only, NOT for extraction
 *    
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    - modify: improve element-level action
 *    -    fix: on element action always takes absolute XPath 
 *    
 * 2019-01-03
 *    - modify: add support for click without specified element (flat action)
 *    - modify: improve XML comments
 *    - modify: change to JSON resource
 * 
 * on-line resources
 */
using OpenQA.Selenium.Extensions;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.Common
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.click.json",
        Name = CommonPlugins.Click)]
    public class Click : ActionPlugin
    {
        #region *** constants: conditions ***
        /// <summary>
        /// Constant for calling "no-alert" condition.
        /// </summary>
        public const string NoAlert = "no-alert";
        #endregion

        #region *** constants: arguments  ***
        /// <summary>
        /// Repeats the click action until condition is met. Available conditions are: ['no-alert'].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private readonly SeleniumActions actions;
        private readonly WebDriverWait wait;
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public Click(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public Click(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            actions = new SeleniumActions(webDriver);
            wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(PageLoadTimeout));
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(webElement: default, actionRule);
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule);
        }

        // executes action routine
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // parse arguments
            arguments = new CliFactory(actionRule.Argument).Parse();

            // flat conditions
            if (PluginUtilities.IsFlatAction(webElement, actionRule))
            {
                actions.Click().Build().Perform();
                return;
            }

            // special actions conditions
            if (arguments.ContainsKey(Until))
            {
                ConditionsFactory(webElement, actionRule, arguments[Until]);
                return;
            }

            // on element action
            var timeout = TimeSpan.FromMilliseconds(ElementSearchTimeout);
            if (webElement != default)
            {
                webElement.GetElementByActionRule(ByFactory, actionRule, timeout).Click();
                return;
            }

            // default
            WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout).Click();
        }

        // special actions factory
        private void ConditionsFactory(IWebElement webElement, ActionRule actionRule, string condition)
        {
            // get method
            var method = GetType().GetMethodByDescription(condition);

            // invoke
            method.Invoke(this, new object[] { webElement, actionRule });
        }

#pragma warning disable S1144, RCS1213, IDE0051
        [Description(NoAlert)]
        private void Alert(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            var timeout = TimeSpan.FromMilliseconds(ElementSearchTimeout);

            // click until condition met or timeout reached
            wait.Until(webDriver =>
            {
                var element = webElement != default
                    ? webElement.GetElementByActionRule(ByFactory, actionRule, timeout)
                    : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);
                element.Click();

                if (webDriver.HasAlert())
                {
                    webDriver.SwitchTo().Alert().Dismiss();
                    return null;
                }

                return webDriver;
            });
        }
#pragma warning restore
    }
}