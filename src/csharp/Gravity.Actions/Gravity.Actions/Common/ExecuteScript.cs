/*
 * CHANGE LOG
 * 
 * 2019-01-12
 *    - modify: improve xml comments
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-01-31
 *    - modify: fix a bug where element was found by argument and not by element-to-act-on
 *    
 * 2019-09-04
 *    - modify: add support for arguments using cli syntax
 * 
 * 2019-12-26
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.execute-script.json",
        Name = ActionType.ExecuteScript)]
    public class ExecuteScript : ActionPlugin
    {
        // constants
        private const string SRC = "src";
        private const string ARGS = "args";

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public ExecuteScript(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public ExecuteScript(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            // setup
            var srcArgs = GetArguments(actionRule);
            var cliArgs = new CliFactory(actionRule.Argument).Parse();
            var src = cliArgs.ContainsKey(SRC) ? cliArgs[SRC] : actionRule.Argument;

            if (cliArgs.ContainsKey(ARGS))
            {
                var a = JsonConvert.DeserializeObject<object[]>(cliArgs[ARGS]);
                srcArgs.AddRange(a);
            }

            // execute action
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(src, srcArgs.ToArray());
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected element.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        /// <remarks>This action assumes that the element is already found and selected. You need to provide the code after the ".".</remarks>
        /// <example>{ "argument": ".checked = true" } The element will be injected before the ".".</example>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            if (!actionRule.Argument.StartsWith("."))
            {
                actionRule.Argument = $".{actionRule.Argument}";
            }
            if (!actionRule.Argument.EndsWith(";"))
            {
                actionRule.Argument = $"{actionRule.Argument};";
            }
            var src = $"arguments[0]{actionRule.Argument}";

            // execute action
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(src, webElement);
        }

        // parse script arguments from action-rule
        private List<object> GetArguments(ActionRule actionRule)
        {
            // exit condition
            if (string.IsNullOrEmpty(actionRule.ElementToActOn))
            {
                return new List<object>();
            }

            // get locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // execute action
            var webElement = WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout));

            // add web element as first argument
            return new List<object> { webElement };
        }
    }
}