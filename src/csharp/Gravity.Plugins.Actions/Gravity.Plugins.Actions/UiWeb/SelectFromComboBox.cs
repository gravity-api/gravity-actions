/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.select_from_combo_box.json",
        Name = WebPlugins.SelectFromComboBox)]
    public class SelectFromComboBox : WebDriverActionPlugin
    {
        #region *** constants: arguments  ***
        /// <summary>
        /// Tells the engine to select all options (if this is a multi selection box).
        /// </summary>
        public const string All = "all";
        #endregion

        #region *** constructors          ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SelectFromComboBox(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        #region *** plugins               ***
        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(element: default, actionRule);
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(element, actionRule);
        }

        // execute action routine
        private void DoAction(IWebElement element, ActionRule actionRule)
        {
            // get element to act on
            var timeout = TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout);
            var webElement = element != default
                ? element.GetElementByActionRule(ByFactory, actionRule, timeout)
                : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

            var selectElement = new SelectElement(webElement);

            // execute action routine
            SelectFactory(selectElement, actionRule);
        }

        // execute relevant select method based on action rule on the given select element
        private void SelectFactory(SelectElement selectElement, ActionRule actionRule)
        {
            // load arguments
            var arguments = CliFactory.Parse(cli: actionRule.Argument);

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
        #endregion

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