/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 * 
 * work items
 * TODO: improve JavaScriptSelect for better readability and code reuse.
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.select_from_combo_box.json",
        Name = Contracts.PluginsList.SelectFromComboBox)]
    public class SelectFromComboBox : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Tells the engine to select all options (if this is a multi selection box).
        /// </summary>
        public const string All = "all";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SelectFromComboBox(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // get element to act on
            var timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout);
            var webElement = element != default
                ? element.GetElement(ByFactory, action, timeout)
                : WebDriver.GetElement(ByFactory, action, timeout);

            var selectElement = new SelectElement(webElement);

            // execute action routine
            SelectFactory(action, selectElement);
        }

        // execute relevant select method based on action rule on the given select element
        private void SelectFactory(ActionRule action, SelectElement selectElement)
        {
            // load arguments
            var arguments = CliFactory.Parse(cli: action.Argument);

            // get description
            var description = arguments.ContainsKey(All)
                ? "ALL"
                : action.OnAttribute.ToUpper();

            description = string.IsNullOrEmpty(description) ? "DEFAULT" : description;

            // get select method > align description
            var method = GetType().GetMethodByDescription(description);

            // execute
            try
            {
                method.Invoke(this, new object[] { action, selectElement });
            }
            catch (Exception e) when (e != null)
            {
                JavaScriptSelect(action, selectElement);
            }
        }

#pragma warning disable S1144, RCS1213, IDE0051
        // select all options by the text displayed
        [Description("DEFAULT")]
        private void Select00(ActionRule action, SelectElement selectElement)
        {
            // single
            if (!selectElement.IsMultiple)
            {
                selectElement.SelectByText(action.Argument);
                return;
            }

            // multiple
            foreach (var option in GetOptions(options: action.Argument))
            {
                selectElement.SelectByText(option);
            }
        }

        // select the option by the index, as determined by the "index" attribute of the element
        [Description("INDEX")]
        private void Select01(ActionRule action, SelectElement selectElement)
        {
            // single
            if (!selectElement.IsMultiple)
            {
                DoSelect01(action.Argument, selectElement);
                return;
            }

            // multiple
            foreach (var option in GetOptions(options: action.Argument))
            {
                DoSelect01(option, selectElement);
            }
        }

        private void DoSelect01(string option, SelectElement selectElement)
        {
            var index = int.TryParse(option, out int indexOut) ? indexOut : 0;
            selectElement.SelectByIndex(index);
        }

        // select an option by the value
        [Description("VALUE")]
        private void Select02(ActionRule action, SelectElement selectElement)
        {
            // single
            if (!selectElement.IsMultiple)
            {
                selectElement.SelectByValue(action.Argument);
                return;
            }

            // multiple
            foreach (var option in GetOptions(options: action.Argument))
            {
                selectElement.SelectByValue(option);
            }
        }

        // select all options which their text match to the action-rule regular-expression
        [Description("ALL")]
        private void Select03(ActionRule action, SelectElement selectElement)
        {
            foreach (var option in selectElement.Options)
            {
                if (!Regex.IsMatch(option.Text, action.RegularExpression))
                {
                    return;
                }
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].selected=true;", option);
            }
        }
#pragma warning restore

        // JavaScript execution of select functionality for unsupported drivers.
        private void JavaScriptSelect(ActionRule action, SelectElement selectElement)
        {
            // constants
            var script =
                "" + // setup preconditions and global values
                $"var onAttribute = '{action.OnAttribute ?? string.Empty}';" +
                $"var onValue = '{action.Argument ?? string.Empty}';" +
                " var options = arguments[0].getElementsByTagName('option');" +
                $"var isMultiple = {selectElement.IsMultiple.ToString().ToLower()};" +
                "" + // set values for iteration
                "var values = isMultiple ? onValue : [onValue];" +
                "" + // by index
                "if(onAttribute.toLowerCase() === 'index') {" +
                "    for(i = 0; i < values.length; i++) {" +
                "        index = parseInt(values[i]);" +
                "        options[index].selected = true;" +
                "    }" +
                "}" +
                "" + // by inner text
                "if(onAttribute === '') {" +
                "    for(i = 0; i < values.length; i++) {" +
                "        for(j = 0; j < options.length; j++) {" +
                "            if(options[j].innerText !== values[i]) {" +
                "                continue;" +
                "            }" +
                "            options[j].selected = true;" +
                "            break;" +
                "        }" +
                "    }" +
                "}" +
                "" + // by options values
                "if(onAttribute.toLowerCase() === 'value') {" +
                "    for(i = 0; i < values.length; i++) {" +
                "        for(j = 0; j < options.length; j++) {" +
                "            if(options[j].getAttribute('value') !== values[i]) {" +
                "                continue;" +
                "            }" +
                "            options[j].selected = true;" +
                "            break;" +
                "         }" +
                "    }" +
                "}";

            // web element to act on
            var onElement = selectElement.WrappedElement;

            // execute
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(script, onElement);
        }

        // gets options array from argument
        private IEnumerable<string> GetOptions(string options)
        {
            // single value
            if (!options.IsJson())
            {
                return new[] { options };
            }

            // multiple values
            return JsonConvert.DeserializeObject<string[]>(value: options);
        }
    }
}