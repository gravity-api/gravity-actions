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
 *    - modify: override ActionName using ActionType constant
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
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Gravity.Plugins.Actions.Common
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.repeat.json",
        Name = CommonPlugins.Repeat)]
    public class Repeat : ActionPlugin
    {
        #region *** constants: conditions ***
        /// <summary>
        /// Constant for calling "exists" condition.
        /// </summary>
        public const string ConditionExists = "exists";

        /// <summary>
        /// Constant for calling "not-exists" condition.
        /// </summary>
        public const string ConditionNotExists = "not-exists";

        /// <summary>
        /// Constant for calling "visible" condition.
        /// </summary>
        public const string ConditionVisible = "visible";

        /// <summary>
        /// Constant for calling "not-visible" condition.
        /// </summary>
        public const string ConditionNotVisible = "not-visible";
        #endregion

        #region *** constants: arguments  ***
        /// <summary>
        /// Repeats the nested actions until a condition is met. Available conditions are: ['visible','not-visible','exists','not-exists'].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public Repeat(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public Repeat(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            ActionFactory ??= GravityUtilities.GetActionFactory(webDriver, webAutomation, types);
        }

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(webElement: default, actionRule: actionRule);
        }

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule);
        }

        // executes Repeat routine
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            arguments = SetArguments(actionRule);

            // setup conditions
            var isCondition = arguments.ContainsKey(Until) && !string.IsNullOrEmpty(arguments[Until]);

            // execute
            if (isCondition)
            {
                ExecuteByCondition(webElement, actionRule, arguments[Until]);
            }
            else
            {
                int.TryParse(actionRule.Argument, out int iterations);
                ExecuteByIteration(webElement, actionRule, iterations);
            }
        }

        // populate action arguments based on action rule or CLI
        private static IDictionary<string, string> SetArguments(ActionRule actionRule)
        {
            var cliFactory = new CliFactory(actionRule.Argument);
            if (cliFactory.CliCompliant)
            {
                return cliFactory.Parse();
            }

            return new Dictionary<string, string>
            {
                [Until] = string.Empty
            };
        }

        // execute actions based on the given conditions
        private void ExecuteByCondition(IWebElement webElement, ActionRule actionRule, string condition)
        {
            // constants: logging
            const string E = "Method for [{0}] condition was not found.";

            // get method
            var method = GetType().GetMethodByDescription(condition);

            // exit conditions
            if (method == null)
            {
                throw new InvalidOperationException(string.Format(E, condition));
            }

            // initialize
            var repeatReference = 0;
            var conditionMet = (bool)method.Invoke(this, new object[] { webElement, actionRule });

            // iterate            
            while (!conditionMet)
            {
                // execute actions
                Execute(webElement, actionRule.Actions, repeatReference++);

                // update state
                conditionMet = (bool)method.Invoke(this, new object[] { webElement, actionRule });
            }
        }

        // execute actions based on given number of iterations
        private void ExecuteByIteration(IWebElement webElement, ActionRule actionRule, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                Execute(webElement, actionRule.Actions, i);
            }
        }

        // update environment >> executes actions under the given action rule
        private void Execute(IWebElement webElement, IEnumerable<ActionRule> actionRules, int repeatReference)
        {
            // setup
            var session = WebDriver.GetSession().ToString();
            var repeatReferenceKey = $"{AutomationEnvironment.REPEATER_POSITION_PARAM}-{session}";

            // iterate
            foreach (var actionRule in actionRules)
            {
                // update environment
                AutomationEnvironment.SessionParams[repeatReferenceKey] = repeatReference;
                actionRule.RepeatReference = repeatReference;

                // execute actions
                ActionFactory.Execute(actionRule, webElement);
            }
        }

        // UTILITIES
        private ReadOnlyCollection<IWebElement> GetElements(IWebElement webElement, ActionRule actionRule) => webElement == default
            ? WebDriver.FindElementsByActionRule(ByFactory, actionRule)
            : webElement.FindElementsByActionRule(ByFactory, actionRule);

        // CONDITIONS REPOSITORY
#pragma warning disable S1144, RCS1213, IDE0051
        [Description(ConditionExists)]
        private bool ElementExists(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.Count > 0;
        }

        [Description(ConditionNotExists)]
        private bool ElementNotExists(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.Count == 0;
        }

        [Description(ConditionVisible)]
        private bool ElementVisible(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.All(i => i.Displayed);
        }

        [Description(ConditionNotVisible)]
        private bool ElementNotVisible(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.All(i => !i.Displayed);
        }
#pragma warning restore
    }
}