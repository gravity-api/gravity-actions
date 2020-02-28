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
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Attributes;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.execute-script.json",
        Name = CommonPlugins.ExecuteScript)]
    public class ExecuteScript : WebDriverActionPlugin
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

        #region *** constructors          ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExecuteScript(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Executes JavaScript in the context of the currently selected element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <remarks>This action assumes that the element is already found and selected. You need to provide the code after the ".".</remarks>
        /// <example>{ "argument": ".checked = true" } The element will be injected before the ".".</example>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            var cliArgs = CliFactory.Parse(actionRule.Argument);
            var srcArgs = GetArguments(element, actionRule);
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
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(jscript, srcArgs.ToArray());
        }

        // parse script arguments from action-rule
        private List<object> GetArguments(IWebElement element, ActionRule actionRule)
        {
            // exit condition
            var isElement = element != default;
            var isFromAction = !string.IsNullOrEmpty(actionRule.ElementToActOn);

            // empty arguments collection
            if (!(isElement || isFromAction))
            {
                return new List<object>();
            }

            // get element by actionRule
            var onElement = this.ConditionalGetElement(element, actionRule);

            // return arguments
            return new List<object> { onElement };
        }
    }
}