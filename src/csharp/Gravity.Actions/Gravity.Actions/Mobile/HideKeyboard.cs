/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Mobile
{
    [Action(
        assmebly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.hide-keyboard.json",
        Name = ActionPlugins.HideKeyboard)]
    public class HideKeyboard : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="driver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public HideKeyboard(IWebDriver driver, WebAutomation webAutomation)
            : this(driver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="driver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public HideKeyboard(IWebDriver driver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(driver, webAutomation, types)
        { }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction();
        }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction();
        }

        // sets the current GEO location
        private void DoAction()
        {
            // constants: messages
            const string Warn = "Action [HideKeyboard] was skipped. This action is not supported by [{0}] driver.";

            // exit conditions
            if (!(WebDriver is IHidesKeyboard))
            {
                Logger.LogWarning(string.Format(Warn, WebDriver.GetType().FullName));
                return;
            }
            ((IHidesKeyboard)WebDriver).HideKeyboard();
        }
    }
}