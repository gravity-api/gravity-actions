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
 * online resources
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.repeat.json",
        Name = Contracts.PluginsList.Repeat)]
    public class Repeat : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Repeats the nested actions until a condition is met. Available conditions are: ['visible','hidden','exists','not_exists'].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private IDictionary<string, string> arguments;
        private readonly PluginFactory pluginFactory;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Repeat(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            pluginFactory = new PluginFactory(automation, parameters: new object[] { driver });
        }
        #endregion

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // executes Repeat routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // setup
            SetArguments(action);

            // setup conditions
            var isCondition = arguments.ContainsKey(Until) && !string.IsNullOrEmpty(arguments[Until]);

            // execute
            if (isCondition)
            {
                ExecuteByCondition(action, element);
            }
            else
            {
                int.TryParse(action.Argument, out int iterations);
                ExecuteByIteration(element, action, iterations);
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
            var factory = new ConditionsFactory(driver: WebDriver, types: Types);

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
        private void ExecuteByIteration(IWebElement element, ActionRule action, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Execute(element, action.Actions, i);
            }
        }

        // update environment >> executes actions under the given action rule
        private void Execute(IWebElement element, IEnumerable<ActionRule> action, int reference)
        {
            // setup
            var session = WebDriver.GetSession().ToString();
            var referenceKey = $"rptpos_{session}";

            // iterate
            foreach (var actionRule in action)
            {
                // update environment
                EnvironmentContext.ApplicationParams[referenceKey] = reference;
                actionRule.RepeatReference = reference;

                // execute actions
                pluginFactory.Execute(actionRule, new object[] { element });
            }
        }
    }
}