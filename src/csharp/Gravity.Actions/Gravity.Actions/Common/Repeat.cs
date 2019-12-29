﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 *    
 * 2019-12-29
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Extensions;
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

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.repeat.json",
        Name = ActionType.REPEAT)]
    public class Repeat : ActionPlugin
    {
        // constants: arguments
        private const string UNTIL = "until";
        private const string ITERATIONS = "iterations";

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
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoRepeat(webElement: default, actionRule: actionRule);
        }

        /// <summary>
        /// Repeats all actions under repeat action a given number of times or until condition is met.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoRepeat(webElement: webElement, actionRule: actionRule);
        }

        // execute repeat action
        private void DoRepeat(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            SetArguments(actionRule);

            // setup conditions
            var isCondition = !string.IsNullOrEmpty(arguments[UNTIL]);

            // execute
            if (isCondition)
            {
                ExecuteByCondition(webElement, actionRule);
            }
            else
            {
                int.TryParse(arguments[ITERATIONS], out int iterations);
                ExecuteByIteration(webElement, actionRule, iterations);
            }
        }

        // populate action arguments based on action rule or CLI
        private void SetArguments(ActionRule actionRule)
        {
            var cliFactory = new CliFactory(actionRule.Argument);
            if (cliFactory.CliCompliant)
            {
                arguments = cliFactory.Parse();
                return;
            }

            int.TryParse(actionRule.Argument, out int iterations);
            arguments = new Dictionary<string, string>
            {
                [ITERATIONS] = $"{iterations}",
                [UNTIL] = string.Empty
            };
        }

        // execute actions based on the given conditions
        private void ExecuteByCondition(IWebElement webElement, ActionRule actionRule)
        {
            // exit conditions
            if (string.IsNullOrEmpty(arguments[UNTIL]))
            {
                return;
            }

            // get method
            var method = GetType().GetMethodByDescription(arguments[UNTIL]);

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
            foreach (var actionRule in actionRules)
            {
                // update environment
                AutomationEnvironment.SessionParams[AutomationEnvironment.REPEATER_POSITION_PARAM] = repeatReference;
                actionRule.RepeatReference = repeatReference;

                // execute actions
                ActionFactory.Execute(actionRule, webElement);
            }
        }

        // CONDITIONS REPOSITORY
#pragma warning disable S1144, RCS1213, IDE0051
        [Description("exists")]
        private bool ElementExists(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.Count > 0;
        }

        [Description("not-exists")]
        private bool ElementNotExists(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.Count == 0;
        }

        [Description("visible")]
        private bool ElementVisible(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.Any(i => i.Displayed);
        }

        [Description("not-visible")]
        private bool ElementNotVisible(IWebElement webElement, ActionRule actionRule)
        {
            // get elements
            var e = GetElements(webElement, actionRule);

            // assertion
            return e.All(i => !i.Displayed);
        }
#pragma warning restore

        // UTILITIES
        private ReadOnlyCollection<IWebElement> GetElements(IWebElement webElement, ActionRule actionRule) => webElement == default
            ? WebDriver.FindByActionRule(ByFactory, actionRule)
            : webElement.FindByActionRule(ByFactory, actionRule);
    }
}