/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.SelectFromComboBox.json",
        Name = GravityPlugins.SelectFromComboBox)]
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
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
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
            InvokeAction(action, element: default);
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="webElement">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action, element);
        }

        // execute action routine
        private void InvokeAction(ActionRule action, IWebElement element)
        {
            // setup
            var _element = this.ConditionalGetElement(action, element);
            var selectElement = new SelectElement(_element);

            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
            var arguments = CliFactory.Parse(action.Argument);
            var input = arguments.ContainsKey(All) ? "ALL" : action.OnAttribute.ToUpper();
            input = string.IsNullOrEmpty(input) ? "DEFAULT" : input;

            // build
            var _method = GetType().GetMethods(Flags).FirstOrDefault(i => Search(i, input));
            _method = _method == default ? GetType().GetMethod("", Flags) : _method;

            // execute
            try
            {
                var instance = _method.IsStatic ? null : this;
                _method.Invoke(obj: instance, parameters: new object[] { action, selectElement });
            }
            catch (Exception e) when (e != null)
            {
                JavaScriptSelect(action, selectElement);
            }
        }

        private static bool Search(MethodInfo method, string input)
        {
            // setup
            var attribute = method.GetCustomAttribute<SelectOptionAttribute>();

            // not found
            if (attribute == default)
            {
                return false;
            }

            // get
            return attribute.Name.Equals(input, StringComparison.OrdinalIgnoreCase);
        }

        // select all options by the text displayed
        [SelectOption("DEFAULT")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void SelectByText(ActionRule action, SelectElement selectElement)
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
        [SelectOption("INDEX")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void SelectByIndex(ActionRule action, SelectElement selectElement)
        {
            // local funtion
            static void InvokeSelect(string option, SelectElement selectElement)
            {
                var index = int.TryParse(option, out int indexOut) ? indexOut : 0;
                selectElement.SelectByIndex(index);
            }

            // single
            if (!selectElement.IsMultiple)
            {
                InvokeSelect(action.Argument, selectElement);
                return;
            }

            // multiple
            foreach (var option in GetOptions(options: action.Argument))
            {
                InvokeSelect(option, selectElement);
            }
        }

        // select an option by the value
        [SelectOption("VALUE")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void SelectByValue(ActionRule action, SelectElement selectElement)
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
        [SelectOption("ALL")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private void SelectAll(ActionRule action, SelectElement selectElement)
        {
            foreach (var option in selectElement.Options)
            {
                if (!Regex.IsMatch(option.Text, action.RegularExpression))
                {
                    continue;
                }
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].selected=true;", option);
            }
        }

        // Utilities
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

        private static IEnumerable<string> GetOptions(string options)
        {
            // single value
            if (!options.IsJson())
            {
                return new[] { options };
            }

            // multiple values
            return JsonSerializer.Deserialize<IEnumerable<string>>(json: options);
        }

        // Attributes
        [AttributeUsage(AttributeTargets.Method)]
        private class SelectOptionAttribute : Attribute
        {
            public SelectOptionAttribute(string name)
            {
                Name = name;
            }

            public string Name { get; }
        }
    }
}