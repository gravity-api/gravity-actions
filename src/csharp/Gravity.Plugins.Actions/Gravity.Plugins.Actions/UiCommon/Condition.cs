/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.condition.json",
        Name = CommonPlugins.Condition)]
    public class Condition : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Condition(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // executes Wait routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // execute condition
            var factory = new ConditionsFactory(WebDriver, Types);
            var results = factory.Factor(action.Argument, new object[] { action, element });

            // apply to context
            action.ExecuteSubActions(doExecute: (bool)results["evaluation"]);
        }
    }
}