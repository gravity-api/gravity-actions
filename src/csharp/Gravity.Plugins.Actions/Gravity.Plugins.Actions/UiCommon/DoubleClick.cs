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
 *    - modify: override action-name using action constant
 *    
 * 2019-01-03
 *    - modify: add support for double_click without specified element (flat action)
 *    - modify: improve XML comments
 *
 * RESOURCES
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;

// consolidate references
using SeleniumActions = OpenQA.Selenium.Interactions.Actions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.double_click.json",
        Name = Contracts.PluginsList.DoubleClick)]
    public class DoubleClick : WebDriverActionPlugin
    {
        // members: state
        private readonly SeleniumActions actions;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public DoubleClick(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
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
            // flat conditions
            if (PluginUtilities.IsFlatAction(action, element))
            {
                actions.DoubleClick().Build().Perform();
                return;
            }

            // on element action
            var onElement = this.ConditionalGetElement(element, action);

            // try to scroll into view
            onElement.TryScrollIntoView();

            // perform action
            actions.DoubleClick(onElement).Build().Perform();
        }
    }
}