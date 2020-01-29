/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Gravity.Services.ActionPlugins.Web
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.select-from-combo-box.json",
        Name = ActionType.SelectFromComboBox)]
    public class SelectFromComboBox : ActionPlugin
    {
        #region *** constants: arguments  ***
        /// <summary>
        /// Tells the engine to select all options (if this is a multi selection box).
        /// </summary>
        public const string All = "all";
        #endregion

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public SelectFromComboBox(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public SelectFromComboBox(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(webElement: default, actionRule);
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule);
        }

        // execute action routine
        private void DoAction(IWebElement webElement, ActionRule actionRule)
        {
            // get element to act on
            var timeout = TimeSpan.FromMilliseconds(ElementSearchTimeout);
            var element = webElement != default
                ? webElement.GetElementByActionRule(ByFactory, actionRule, timeout)
                : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

            var selectElement = new SelectElement(element);

            // execute action routine
            SelectFactory(selectElement, actionRule);
        }

        // execute relevant select method based on action rule on the given select element
        private void SelectFactory(SelectElement selectElement, ActionRule actionRule)
        {
            // load arguments
            var arguments = new CliFactory(actionRule.Argument).Parse();

            // get description
            var description = arguments.ContainsKey(All)
                ? "ALL"
                : actionRule.ElementAttributeToActOn.ToUpper();

            description = string.IsNullOrEmpty(description) ? "DEFAULT" : description;

            // get select method > align description
            var method = GetType().GetMethodByDescription(description);

            // execute
            method.Invoke(this, new object[] { selectElement, actionRule });
        }

#pragma warning disable S1144, RCS1213, IDE0051
        // select all options by the text displayed
        [Description("DEFAULT")]
        private void Select00(SelectElement selectElement, ActionRule actionRule)
        {
            selectElement.SelectByText(actionRule.Argument);
        }

        // select the option by the index, as determined by the "index" attribute of the element
        [Description("INDEX")]
        private void Select01(SelectElement selectElement, ActionRule actionRule)
        {
            var index = int.TryParse(actionRule.Argument, out int indexOut) ? indexOut : 0;
            selectElement.SelectByIndex(index);
        }

        // select an option by the value
        [Description("VALUE")]
        private void Select02(SelectElement selectElement, ActionRule actionRule)
        {
            selectElement.SelectByValue(actionRule.Argument);
        }

        // select all options which their text match to the action-rule regular-expression
        [Description("ALL")]
        private void Select03(SelectElement selectElement, ActionRule actionRule)
        {
            foreach (var option in selectElement.Options)
            {
                if (!Regex.IsMatch(option.Text, actionRule.RegularExpression))
                {
                    return;
                }
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].selected=true;", option);
            }
        }
#pragma warning restore
    }
}