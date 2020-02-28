﻿/*
 * CHANGE LOG - keep only last 5 threads
 *
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
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
        assmebly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch-to-alert.json",
        Name = WebPlugins.SwitchToAlert)]
    public class SwitchToAlert : ActionPlugin
    {
        #region *** constants: arguments  ***
        /// <summary>
        /// User name in an alert prompting for credentials.
        /// </summary>
        public const string User = "user";

        /// <summary>
        /// Password in an alert prompting for credentials.
        /// </summary>
        public const string Password = "pass";

        /// <summary>
        /// Keys to send to the alert.
        /// </summary>
        public const string Keys = "keys";
        #endregion

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

            // arguments
            arguments = new CliFactory(actionRule.Argument).Parse();

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
        private void Credentials()
        {
            // parameters
            var user = arguments.ContainsKey(User) ? arguments[User] : string.Empty;
            var pass = arguments.ContainsKey(Password) ? arguments[Password] : string.Empty;

            // set user
            WebDriver
                .SwitchTo()
                .Alert()
                .SetAuthenticationCredentials(userName: user, password: pass);
        }

        [Description("--keys:[^(--)]*")]
        private void SendKeys()
        {
            if (!arguments.ContainsKey(Keys))
            {
                return;
            }

            // set keys
            WebDriver.SwitchTo().Alert().SendKeys(arguments[Keys]);
        }
#pragma warning restore
    }
}