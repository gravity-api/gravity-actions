/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-26
 *    - modify: add constructor to override base class types
 *    
 * 2019-09-04
 *    - modify: add support for arguments using CLI syntax
 *    
 * 2019-01-31
 *    - modify: fix a bug where element was found by argument and not by element-to-act-on
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override action-name using ActionType constant
 * 
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Extensions;
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
        #region *** constants: arguments  ***
        /// <summary>
        /// The JavaScript code to execute.
        /// </summary>
        public const string Src = "src";

        /// <summary>
        /// "Object array to pass into this script.
        /// </summary>
        public const string Args = "args";
        #endregion

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
            DoAction(default, actionRule);
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
            DoAction(webElement, actionRule);
        }

        // executes action routine
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // setup
            var cliArgs = new CliFactory(actionRule.Argument).Parse();
            var srcArgs = GetArguments(webElement, actionRule);
            var jscript = cliArgs.ContainsKey(Src) ? cliArgs[Src] : actionRule.Argument;

            // add arguments
            if (cliArgs.ContainsKey(Args))
            {
                var a = JsonConvert.DeserializeObject<object[]>(cliArgs[Args]);
                srcArgs.AddRange(a);
            }

            // on element script            
            if (jscript.StartsWith("."))
            {
                jscript = $"arguments[0]{jscript}";
            }

            // execute script
            WebDriver.ExecuteScript(jscript, srcArgs.ToArray());
        }

        // parse script arguments from action-rule
        private List<object> GetArguments(IWebElement webElement, ActionRule actionRule)
        {
            // exit condition
            var isElement = webElement != default;
            var isFromAction = !string.IsNullOrEmpty(actionRule.ElementToActOn);

            // empty arguments collection
            if (!(isElement || isFromAction))
            {
                return new List<object>();
            }

            // setup
            var timeout = TimeSpan.FromMilliseconds(ElementSearchTimeout);

            // get element by actionRule
            var element = isElement
                ? webElement.GetElementByActionRule(ByFactory, actionRule, timeout)
                : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

            // return arguments
            return new List<object> { element };
        }
    }
}