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
 *    - modify: override action-name using action constant
 *    - modify: improve element-level action
 *    -    fix: on element action always takes absolute XPath 
 *    
 * 2019-01-03
 *    - modify: add support for click without specified element (flat action)
 *    - modify: improve XML comments
 *    - modify: change to JSON resource
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Support.UI;

using System;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Click.json",
        Name = GravityPlugin.Click)]
    public class Click : WebDriverActionPlugin
    {
        #region *** conditions   ***
        /// <summary>
        /// Constant for calling "no-alert" condition.
        /// </summary>
        public const string NoAlert = "no_alert";
        #endregion

        #region *** arguments    ***
        /// <summary>
        /// Repeats the click action until condition is met. Available conditions are: [\"no-alert\"].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private readonly SeleniumActions actions;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Click(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            // set actions instance
            actions = new SeleniumActions(driver);
        }
        #endregion

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Clicks the mouse at the last known mouse coordinates or on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // parse arguments
            var arguments = CliFactory.Parse(action?.Argument);

            // flat conditions
            if (action.IsFlatAction(element))
            {
                actions.Click().Build().Perform();
                return;
            }

            // special actions conditions
            if (arguments.ContainsKey(Until))
            {
                InvokeConditionalClick(action, element);
                return;
            }

            // invoke
            this.ConditionalGetElement(element, action).TryMoveToElement().Click();
        }

        private void InvokeConditionalClick(ActionRule action, IWebElement element)
        {
            // setup
            var factory = new ConditionsFactory(WebDriver, Types);
            var timeout = TimeSpan.FromSeconds(Automation.EngineConfiguration.LoadTimeout);
            var wait = new WebDriverWait(WebDriver, timeout);
            var ignored = new[]
            {
                 typeof(NoSuchElementException),
                 typeof(StaleElementReferenceException),
                 typeof(WebDriverException),
                 typeof(ElementClickInterceptedException),
                 typeof(ElementNotInteractableException),
                 typeof(ElementNotSelectableException),
                 typeof(ElementNotVisibleException),
                 typeof(InvalidElementStateException)
            };
            wait.IgnoreExceptionTypes(ignored);
            wait.PollingInterval = TimeSpan.FromSeconds(1.5);

            // first action
            this.ConditionalGetElement(element, action).TryMoveToElement().Click();
            var isCondition = GetEvaluation(factory, action, element);

            // exit conditions
            if (isCondition)
            {
                return;
            }

            // click until
            wait.Until(d =>
            {
                // remove page/click blockers
                if (WebDriver.HasAlert())
                {
                    WebDriver.SwitchTo().Alert().Dismiss();
                }
                this.ConditionalGetElement(element, action).TryMoveToElement().Click();
                return GetEvaluation(factory, action, element);
            });
        }

        private static bool GetEvaluation(
            ConditionsFactory factory,ActionRule action, IWebElement element)
        {
            // setup
            var arguments = new object[] { action, element };

            // invoke condition
            var results = factory.Factor(action.Argument, arguments);

            // get
            return (bool)results["evaluation"];
        }
    }
}