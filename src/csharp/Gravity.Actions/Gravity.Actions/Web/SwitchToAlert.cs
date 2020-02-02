/*
 * CHANGE LOG - keep only last 5 threads
 *
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Gravity.Plugins.Actions.Web
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch-to-alert.json",
        Name = ActionPlugins.SwitchToAlert)]
    public class SwitchToAlert : ActionPlugin
    {
        // members: state
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public SwitchToAlert(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public SwitchToAlert(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Switches to the currently active modal dialog for this particular driver instance.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule);
        }

        /// <summary>
        /// Switches to the currently active modal dialog for this particular driver instance.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(actionRule);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule)
        {
            // exit conditions
            if (!WebDriver.HasAlert())
            {
                return;
            }

            // execute
            foreach (var method in GetType().GetMethodsByDescription(regex: actionRule.Argument))
            {
                DoMethod(method, actionRule);
            }
        }

        // executes a single method routine
        private void DoMethod(MethodInfo method, ActionRule actionRule)
        {
            if (method.GetParameters().Length == 0)
            {
                method.Invoke(obj: this, parameters: null);
                return;
            }
            method.Invoke(obj: this, parameters: new object[] { actionRule });
        }

        // FACTORY
#pragma warning disable S1144, RCS1213, IDE0051
        [Description("^dismiss$")]
        private void Dismiss() => WebDriver.SwitchTo().Alert().Dismiss();

        [Description("^accept$")]
        private void Accept() => WebDriver.SwitchTo().Alert().Accept();

        [Description("--user:[^(--)]*|--pass:[^(--)]*")]
        private void Credentials(ActionRule actionRule) { }

        [Description("--keys:[^(--)]*")]
        private void SendKeys(ActionRule actionRule) { }
#pragma warning restore
    }
}