/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 * 
 * 2019-12-31
 *    - modify: add constructor to override base class types
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Gravity.Plugins.Actions.Common
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.wait.json",
        Name = ActionPlugins.Wait)]
    public class Wait : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public Wait(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public Wait(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Suspends the current thread for the specified amount of time.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoWait(actionRule);
        }

        /// <summary>
        /// Suspends the current thread for the specified amount of time.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoWait(actionRule);
        }

        // executes Wait routine
        private void DoWait(ActionRule actionRule)
        {
            // parse waiting time
            var isNumber = int.TryParse(actionRule.Argument, out int numberOut);
            var isTimeSp = TimeSpan.TryParse(actionRule.Argument, out TimeSpan timespanOut);

            // number handling
            if (isNumber)
            {
                Thread.Sleep(numberOut);
            }

            // timespan handling
            if (isTimeSp && !isNumber)
            {
                Thread.Sleep(timespanOut);
            }
        }
    }
}