/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-03
 *    - modify: add support for click without specified element (flat action)
 *    - modify: improve XML comments
 *    - modify: change to JSON resource
 *    
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    - modify: improve element-level action
 *    -    fix: on element action always takes absolute XPath
 *    
 * 2019-08-22
 *    - modify: add support for special cases - for action only, NOT for extraction
 * 
 * 2019-12-24
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.click.json",
        Name = ActionType.Click)]
    public class Click : ActionPlugin
    {
        #region *** constants: conditions ***
        /// <summary>
        /// Constant for calling "no-alert" condition.
        /// </summary>
        public const string NoAlert = "no-alert";
        #endregion

        // constants: arguments
        private const string UNTIL = "until";

        // members: state
        private readonly Actions actions;
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
            actions = new Actions(webDriver);
            wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(PageLoadTimeout));
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

            // execute special action
            arguments = new CliFactory(actionRule.Argument).Parse();
            if (arguments.ContainsKey(UNTIL))
            {
                ConditionsFactory(actionRule);
                return;
            }

            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // execute action
            WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout)).Click();
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
            element.Click();
        }

        // execute flat action
        private bool Flat(ActionRule actionRule) => WasFlatAction(actionRule, () =>
        {
            actions.Click().Build().Perform();
            return true;
        });

        // special actions factory
        private void ConditionsFactory(ActionRule actionRule)
        {
            // get method
            var method = GetType().GetMethodByDescription(arguments[UNTIL]);

            // invoke
            method.Invoke(this, new object[] { actionRule });
        }

#pragma warning disable S1144, RCS1213, IDE0051
        [Description(NoAlert)]
        private void Alert(ActionRule actionRule)
        {
            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // click until condition met or timeout reached
            wait.Until(webDriver =>
            {
                webDriver.GetElement(by).Click();
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