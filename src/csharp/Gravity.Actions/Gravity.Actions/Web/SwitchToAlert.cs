/*
 * CHANGE LOG - keep only last 5 threads
 *
 * on-line resources
 */
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Web
{
    public class SwitchToAlert: ActionPlugin
    {
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

            // parse argument
            var alert = WebDriver.SwitchTo().Alert();
            switch (actionRule.Argument.ToUpper())
            {
                // dismiss the alert
                case "DISMISS":
                    alert.Dismiss();
                    break;
                // accept the alert
                case "ACCEPT":
                    alert.Accept();
                    break;
                // default: dismiss the alert
                default:
                    //ProcessCli(alert, actionRule);
                    break;
            }
        }
    }
}
