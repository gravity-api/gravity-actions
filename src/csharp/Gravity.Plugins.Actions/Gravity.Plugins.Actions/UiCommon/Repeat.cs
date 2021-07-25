/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-29
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Repeat.json",
        Name = GravityPlugins.Repeat)]
    public class Repeat : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Repeats the nested actions until a condition is met. Available conditions are: [\"visible\",\"hidden\",\"exists\",\"not_exists\"].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private IDictionary<string, string> arguments;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Repeat(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action, element: default);
        }

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action, element);
        }

        // executes Repeat routine
        private void InvokeAction(ActionRule action, IWebElement element)
        {
            // setup
            SetArguments(action);
            action.ExecuteSubActions(doExecute: false);

            // setup conditions
            var isCondition = arguments.ContainsKey(Until) && !string.IsNullOrEmpty(arguments[Until]);

            // execute
            if (isCondition)
            {
                ExecuteByCondition(action, element);
            }
            else
            {
                _ = int.TryParse(action.Argument, out int iterations);
                ExecuteByIteration(action, element, iterations);
            }
        }

        // populate action arguments based on action rule or CLI
        private void SetArguments(ActionRule action)
        {
            // load from CliFactory
            arguments = CliFactory.Parse(action.Argument);

            // exit condition
            if (arguments.ContainsKey(Until))
            {
                return;
            }

            // set until argument
            arguments[Until] = string.Empty;
        }

        // execute actions based on the given conditions
        private void ExecuteByCondition(ActionRule action, IWebElement element)
        {
            // setup
            var factory = new ConditionsFactory(Environment, driver: WebDriver, types: Types);

            // initialize
            var repeatReference = 0;
            var conditionMet = factory.Factor(action.Argument, new object[] { action, element });

            // iterate            
            while (!(bool)conditionMet["evaluation"])
            {
                // execute actions
                Execute(element, action.Actions, repeatReference++);

                // update state
                conditionMet = factory.Factor(action.Argument, new object[] { action, element });
            }
        }

        // execute actions based on given number of iterations
        private void ExecuteByIteration(ActionRule action, IWebElement element, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Execute(element, action.Actions, i);
            }
        }

        // update environment >> executes actions under the given action rule
        private void Execute(IWebElement element, IEnumerable<ActionRule> actions, int reference)
        {
            // setup
            var session = WebDriver.GetSession().ToString();
            var referenceKey = $"rptpos_{session}";

            // iterate
            foreach (var action in actions)
            {
                // update environment
                EnvironmentContext.ApplicationParams[referenceKey] = reference;
                action.RepeatReference = reference;

                // execute actions
                Executor.Execute(Automation, action, new object[] { element });
            }
        }
    }
}