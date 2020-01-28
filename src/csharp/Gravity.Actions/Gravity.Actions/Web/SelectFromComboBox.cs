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

            // execute action routine
            SelectFactory(selectElement: new SelectElement(element), actionRule);
        }

        // execute relevant select method based on action rule on the given select element
        private void SelectFactory(SelectElement selectElement, ActionRule actionRule)
        {
            // exit conditions
            var isSelectAll = SelectOptions(selectElement, actionRule);
            if (isSelectAll)
            {
                return;
            }

            // factory
            switch (actionRule.ElementAttributeToActOn.ToUpper())
            {
                default:
                {
                    selectElement.SelectByText(actionRule.Argument);
                    break;
                }
                case "INDEX":
                {
                    var index = int.TryParse(actionRule.Argument, out int indexOut) ? indexOut : 0;
                    selectElement.SelectByIndex(index);
                    break;
                }
                case "VALUE":
                {
                    selectElement.SelectByValue(actionRule.Argument);
                    break;
                }
            }
        }

        // select all options which their text match to the action-rule regular-expression
        private bool SelectOptions(SelectElement selectElement, ActionRule actionRule)
        {
            // load arguments
            var arguments = new CliFactory(actionRule.Argument).Parse();

            // exit conditions
            if (!arguments.ContainsKey(All))
            {
                return false;
            }

            // iterate
            foreach (var option in selectElement.Options)
            {
                SelectOption(option, actionRule.RegularExpression);
            }
            return true;
        }

        // select a single option which their text match to the action-rule regular-expression
        private void SelectOption(IWebElement option, string regex)
        {
            if (!Regex.IsMatch(option.Text, regex))
            {
                return;
            }
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].selected=true;", option);
        }
    }
}