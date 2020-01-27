/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * 
 * work items
 * TODO: implement new IHidesKeyboard functionality when ready
 */
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Mobile
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.hide-keyboard.json",
        Name = ActionType.HideKeyboard)]
    public class HideKeyboard : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public HideKeyboard(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public HideKeyboard(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction();
        }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
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