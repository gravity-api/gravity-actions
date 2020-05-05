/*
 * CHANGE LOG - keep only last 5 threads
 *
 * online resources
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch_to_alert.json",
        Name = Contracts.PluginsList.SwitchToAlert)]
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
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
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

            // arguments
            arguments = CliFactory.Parse(action.Argument);

            // execute
            foreach (var method in GetType().GetMethodsByDescription(regex: action.Argument))
            {
                DoMethod(action, method);
            }
        }

        // executes a single method routine
        private void DoMethod(ActionRule action, MethodInfo method)
        {
            if (method.GetParameters().Length == 0)
            {
                method.Invoke(obj: this, parameters: null);
                return;
            }
            method.Invoke(obj: this, parameters: new object[] { action });
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