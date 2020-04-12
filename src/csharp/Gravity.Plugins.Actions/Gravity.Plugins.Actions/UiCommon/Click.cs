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
using Gravity.Plugins.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;

using SeleniumActions = OpenQA.Selenium.Interactions.Actions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Contracts;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.click.json",
        Name = CommonPlugins.Click)]
    public class Click : WebDriverActionPlugin
    {
        #region *** constants: conditions ***
        /// <summary>
        /// Constant for calling "no-alert" condition.
        /// </summary>
        public const string NoAlert = "no_alert";
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

        #region *** constructors          ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Click(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        {
            actions = new SeleniumActions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout));
        }
        #endregion

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(element: default, actionRule);
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
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
            // parse arguments
            var arguments = CliFactory.Parse(actionRule?.Argument);

            // flat conditions
            if (PluginUtilities.IsFlatAction(element, actionRule))
            {
                actions.Click().Build().Perform();
                return;
            }

            // special actions conditions
            if (arguments.ContainsKey(Until))
            {
                ConditionsFactory(element, actionRule, arguments[Until]);
                return;
            }

            // on element action
            var timeout = TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout);
            if (element != default)
            {
                element.GetElementByActionRule(ByFactory, actionRule, timeout).Click();
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
        private void Alert(IWebElement element, ActionRule actionRule)
        {
            wait.Until(webDriver =>
            {
                // click (supposed to trigger alert)
                this.ConditionalGetElement(element, actionRule).Click();

                // dismiss if exists
                if (webDriver.HasAlert())
                {
                    webDriver.SwitchTo().Alert().Dismiss();
                    return null;
                }

                // results
                return webDriver;
            });
        }
#pragma warning restore
    }
}