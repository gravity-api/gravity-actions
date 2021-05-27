/*
 * CHANGE LOG - keep only last 5 threads
 *
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;
using Gravity.Extensions;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.SwitchToAlert.json",
        Name = GravityPlugins.SwitchToAlert)]
    public class SwitchToAlert : WebDriverActionPlugin
    {
        #region *** arguments    ***
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

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SwitchToAlert(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Switches to the currently active modal dialog for this particular driver instance.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Switches to the currently active modal dialog for this particular driver instance.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action);
        }

        // execute action routine
        private void DoAction(ActionRule action)
        {
            // exit conditions
            if (!WebDriver.HasAlert())
            {
                return;
            }

            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
            arguments = CliFactory.Parse(action.Argument);

            // build
            var methods = GetType()
                .GetMethods(Flags)
                .Select(i => Search(i, action.Argument))
                .Where(i => i.Priority != -1)
                .OrderBy(i => i.Priority)
                .Select(i => i.Method);

            // execute
            foreach (var method in methods)
            {
                method.Invoke(obj: this, parameters: null);
            }
        }

        private static (MethodInfo Method, int Priority) Search(MethodInfo method, string input)
        {
            // setup
            var attribute = method.GetCustomAttribute<AlertAttribute>();

            // not found
            if (attribute == default)
            {
                return (default, -1);
            }

            // assert
            return Regex.IsMatch(input, attribute.Pattern) ? (method, attribute.Priority) : (default, -1);
        }

        // Factory
        [Alert("--user:[^(--)]*|--pass:[^(--)]*", Priority = 1)]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
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

        [Alert("--keys:[^(--)]*", Priority = 1)]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private void SendKeys()
        {
            if (!arguments.ContainsKey(Keys))
            {
                return;
            }

            // set keys
            WebDriver.SwitchTo().Alert().SendKeys(arguments[Keys]);
        }

        [Alert("^dismiss$|--dismiss", Priority = 2)]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private void Dismiss() => WebDriver.SwitchTo().Alert().Dismiss();

        [Alert("^accept$|--accept", Priority = 2)]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private void Accept() => WebDriver.SwitchTo().Alert().Accept();

        [AttributeUsage(AttributeTargets.Method)]
        private class AlertAttribute : Attribute
        {
            public AlertAttribute(string pattern)
            {
                Pattern = pattern;
            }

            public string Pattern { get; }
            public int Priority { get; set; }
        }
    }
}