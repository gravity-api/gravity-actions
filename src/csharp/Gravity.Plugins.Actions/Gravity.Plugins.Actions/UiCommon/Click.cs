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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Click.json",
        Name = PluginsList.Click)]
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
        private readonly WebDriverWait wait;

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

            // set waiter instance
            var timeout = Automation.EngineConfiguration.SearchTimeout;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
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
            if (PluginUtilities.IsFlatAction(action, element))
            {
                actions.Click().Build().Perform();
                return;
            }

            // special actions conditions
            if (arguments.ContainsKey(Until))
            {
                ConditionsFactory(action, element);
                return;
            }

            // on element action
            var timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout);
            if (element != default)
            {
                element.GetElement(ByFactory, action, timeout).TryMoveToElement().Click();
                return;
            }

            // default
            WebDriver.GetElement(ByFactory, action, timeout).TryMoveToElement().Click();
        }

        // TODO: reuse with other factories in similar actions to remove redundancy
        // special actions factory
        [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Factory for using private methods which are already allows in this scope.")]
        private void ConditionsFactory(ActionRule action, IWebElement element)
        {
            // constants
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;

            // load arguments
            var arguments = CliFactory.Parse(cli: action.Argument);

            // get description
            var description = arguments.ContainsKey(Until)
                ? arguments[Until]
                : string.Empty;

            description = string.IsNullOrEmpty(description) ? "DEFAULT" : description;

            // get select method > align description
            var method = GetType()
                .GetMethodsByAttribute<DescriptionAttribute>(Flags)
                .FirstOrDefault(i => i.GetCustomAttribute<DescriptionAttribute>().Description.Equals(description, Compare));

            // invoke
            var instance = method.IsStatic ? null : this;
            method.Invoke(instance, new object[] { action, element });
        }

        [Description("DEFAULT")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private void Default(ActionRule action, IWebElement element)
        {
            ConditionalGetElement(element, action).TryMoveToElement().Click();
        }

        [Description(NoAlert)]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private void Alert(ActionRule action, IWebElement element) => wait.Until(driver =>
        {
            // click (supposed to trigger alert)
            ConditionalGetElement(element, action).TryMoveToElement().Click();

            // dismiss if exists
            if (driver.HasAlert())
            {
                driver.SwitchTo().Alert().Dismiss();
                return null;
            }

            // results
            return driver;
        });
    }
}