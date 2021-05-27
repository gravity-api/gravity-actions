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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Extensions;
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

        // TODO: reuse with other factories in similar actions to remove redundancy
        // execute relevant select method based on action rule on the given select element
        [SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "Factory for using private methods which are already allows in this scope.")]
        private void SelectFactory(ActionRule action, SelectElement selectElement)
        {
            // constants
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;

            // load arguments
            var arguments = CliFactory.Parse(cli: action.Argument);

            // get description
            var description = arguments.ContainsKey(All)
                ? "ALL"
                : action.OnAttribute.ToUpper();

            description = string.IsNullOrEmpty(description) ? "DEFAULT" : description;

            // get select method > align description
            var method = GetType()
                .GetMethodsByAttribute<DescriptionAttribute>(Flags)
                .FirstOrDefault(i => i.GetCustomAttribute<DescriptionAttribute>().Description.Equals(description, Compare));

            // invoke
            try
            {
                var instance = method.IsStatic ? null : this;
                method.Invoke(instance, new object[] { action, selectElement });
            }
            catch (Exception e) when (e != null)
            {
                JavaScriptSelect(action, selectElement);
            }
        }

        // select all options by the text displayed
        [Description("DEFAULT")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void Select00(ActionRule action, SelectElement selectElement)
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
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void Select01(ActionRule action, SelectElement selectElement)
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

        private static void DoSelect01(string option, SelectElement selectElement)
        {
            var index = int.TryParse(option, out int indexOut) ? indexOut : 0;
            selectElement.SelectByIndex(index);
        }

        // select an option by the value
        [Description("VALUE")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private static void Select02(ActionRule action, SelectElement selectElement)
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
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection")]
        private void Select03(ActionRule action, SelectElement selectElement)
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

        // JavaScript execution of select functionality for unsupported drivers.
        private void JavaScriptSelect(ActionRule action, SelectElement selectElement)
        {
            // constants
            var script =
                "" + // setup preconditions and global values
                $"var onAttribute = \"{action.OnAttribute ?? string.Empty}\";" +
                $"var onValue = \"{action.Argument ?? string.Empty}\";" +
                " var options = arguments[0].getElementsByTagName(\"option\");" +
                $"var isMultiple = {selectElement.IsMultiple.ToString().ToLower()};" +
                "" + // set values for iteration
                "var values = isMultiple ? onValue : [onValue];" +
                "" + // by index
                "if(onAttribute.toLowerCase() === \"index\") {" +
                "    for(i = 0; i < values.length; i++) {" +
                "        index = parseInt(values[i]);" +
                "        options[index].selected = true;" +
                "    }" +
                "}" +
                "" + // by inner text
                "if(onAttribute === \"\") {" +
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
                "if(onAttribute.toLowerCase() === \"value\") {" +
                "    for(i = 0; i < values.length; i++) {" +
                "        for(j = 0; j < options.length; j++) {" +
                "            if(options[j].getAttribute(\"value\") !== values[i]) {" +
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
    }
}