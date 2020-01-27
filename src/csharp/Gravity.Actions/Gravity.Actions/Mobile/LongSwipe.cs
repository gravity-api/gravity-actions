/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * 
 * work items
 * TODO: implement new IHidesKeyboard functionality when ready
 */
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gravity.Services.ActionPlugins.Mobile
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.hide-keyboard.json",
        Name = ActionType.LongSwipe)]
    public class LongSwipe : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public LongSwipe(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public LongSwipe(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Swipes the screen by a given coordinates or elements.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(webElement: default, actionRule);
        }

        /// <summary>
        /// Swipes the screen by a given coordinates or elements.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule);
        }

        // sets the current GEO location
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // constants: messages
            const string Warn = "Action [LongSwipe] was skipped. This action is not supported by [{0}] driver.";

            // exit conditions
            if (!(WebDriver is IPerformsTouchActions))
            {
                Logger.LogWarning(string.Format(Warn, WebDriver.GetType().FullName));
                return;
            }

            // set action
            var touchAction = new TouchAction((IPerformsTouchActions)WebDriver);

            // process options
            var methods = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("OPTION", StringComparison.OrdinalIgnoreCase));

            // iterate
            foreach (var method in methods)
            {
                if (ExecuteOption(method, actionRule))
                {
                    return;
                }
            }
        }

        private bool ExecuteOption(MethodInfo m, ActionRule a)
        {
            return default;
        }
    }
}
