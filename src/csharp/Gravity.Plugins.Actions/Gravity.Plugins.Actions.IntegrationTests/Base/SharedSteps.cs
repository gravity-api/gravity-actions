/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.IntegrationTests.Base
{
    public static class SharedSteps
    {
        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to perform "Search Student" sequence.
        /// </summary>
        /// <param name="searchFor">Value to search student by.</param>
        /// <returns>A collection of <see cref="ActionRule"/>.</returns>
        public static IEnumerable<ActionRule> SearchStudent(string searchFor) => new[]
        {
            new ActionRule
            {
                Action = PluginsList.SendKeys,
                Argument = searchFor,
                OnElement = "SearchString",
                Locator = Locators.Id
            },
            new ActionRule
            {
                Action = PluginsList.Click,
                OnElement = "SearchButton",
                Locator = Locators.Id
            }
        };

        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to assert "Register Parameter" value.
        /// </summary>
        /// <param name="equal">The parameter value (the key is "integration_parameter").</param>
        /// <returns>A collection of <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertParameter(string equal) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --parameter --eq:" + equal + "}}",
            OnElement = "integration_parameter"
        };

        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to perform "Set Number of Alerts" sequence.
        /// </summary>
        /// <param name="numberOfAlerts">Value to set.</param>
        /// <returns>A collection of <see cref="ActionRule"/>.</returns>
        public static IEnumerable<ActionRule> SetNumberOfAlerts(int numberOfAlerts) => new[]
        {
            new ActionRule
            {
                Action = PluginsList.SendKeys,
                Argument = $"{numberOfAlerts}",
                OnElement = "number_of_alerts",
                Locator = Locators.Id
            }
        };

        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to perform "Back to List" sequence.
        /// </summary>
        /// <returns>A collection of <see cref="ActionRule"/>.</returns>
        public static IEnumerable<ActionRule> BackToList() => new[]
        {
            new ActionRule
            {
                Action = PluginsList.Click,
                OnElement = "Back to List",
                Locator = Locators.LinkText
            }
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for students count (on students page).
        /// </summary>
        /// <param name="count">Count expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertStudentsCount(int count) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --count --eq:" + $"{count}" + "}}",
            OnElement = "//tr[./td[@id]]"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for number of alerts (on UiControls page).
        /// </summary>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertNumberOfAlerts(int greaterThan) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = "number_of_alerts",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for number of alerts (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertUrl(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --url --match:" + expectedPattern + "}}"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for number of windows.
        /// </summary>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertWindowsCount(int greaterThan) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --windows_count --gt:" + greaterThan + "}}"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertClickOutcome(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "click_outcome",
            OnAttribute = "value",
            Locator = Locators.Id
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertListenerOutcome(int greaterThan) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = "dismissed_elements",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for stale element class (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertStaleElementClass(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + $"{expectedPattern}" + "}}",
            OnElement = "for_stale_element",
            Locator = Locators.Id,
            OnAttribute = "class"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertInputEnabledValue(string expectedPattern, string id = "input_enabled") => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = id,
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for text area value (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertTextAreaValue(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "input_enabled",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="offset">X or Y</param>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertScrollOutcome(string offset, int greaterThan) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = $"scroll_{offset.ToLower()}_outcome",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="offset">X or Y</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertScrollOutcome(string offset, string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + $"{expectedPattern}" + "}}",
            OnElement = $"scroll_{offset.ToLower()}_outcome",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for asserting that <see cref="OpenQA.Selenium.IAlert"/> presence.
        /// </summary>
        /// <param name="exists"><see cref="true"/> for exists <see cref="false"/> if not.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertAlert(bool exists) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = exists ? "{{$ --alert_exists}}" : "{{$ --no_alert}}"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="offset">X or Y</param>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertElementScrollOutcome(string offset, int greaterThan) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = $"e_scroll_{offset.ToLower()}_outcome",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="offset">X or Y</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertElementScrollOutcome(string offset, string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + $"{expectedPattern}" + "}}",
            OnElement = $"e_scroll_{offset.ToLower()}_outcome",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Assert extractions count and values (not null or empty).
        /// </summary>
        /// <param name="responses">OrbitResponse from which to fetch entities.</param>
        /// <param name="fieldsCount">Expected number of fields per entity.</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assertion results.</returns>
        public static bool AssertEntitiesValues(IEnumerable<OrbitResponse> responses, int fieldsCount, string expectedPattern)
        {
            // setup
            var excluded = new[] { "entityIndex" };

            // get all entities
            var entities = responses.SelectMany(i => i.Extractions).SelectMany(i => i.Entities);
            var entries = entities.SelectMany(i => i.Content).Where(i => !excluded.Contains(i.Key));

            // assertion, add +1 to fields count to normalize automatic fields.
            var isCount = entities.All(i => i.Content.Count == fieldsCount + excluded.Length);
            var isValues = entries
                .All(i => !string.IsNullOrEmpty(i.Key) && Regex.IsMatch(input: $"{i.Value}", pattern: expectedPattern));

            // results
            return isCount && isValues;
        }

        /// <summary>
        /// Assert extractions count and values (not null or empty).
        /// </summary>
        /// <param name="responses">OrbitResponse from which to fetch entities.</param>
        /// <param name="fieldsCount">Expected number of fields per entity.</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assertion results.</returns>
        public static bool AssertEntitiesKeys(IEnumerable<OrbitResponse> responses, int fieldsCount, string expectedPattern)
        {
            // setup
            var excluded = new[] { "entityIndex" };

            // get all entities
            var entities = responses.SelectMany(i => i.Extractions).SelectMany(i => i.Entities);
            var entries = entities.SelectMany(i => i.Content).Where(i => !excluded.Contains(i.Key));

            // assertion, add +1 to fields count to normalize automatic fields.
            var isCount = entities.All(i => i.Content.Count == fieldsCount + excluded.Length);
            var isKeys = entries
                .All(i => !string.IsNullOrEmpty(i.Key) && Regex.IsMatch(input: $"{i.Key}", pattern: expectedPattern));

            // results
            return isCount && isKeys;
        }

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for over outcome value (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertOverOutcomeValue(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "over_outcome",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for combo box (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertComboBox(string expectedPattern) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "select_menu",
            Locator = Locators.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for combo box (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <param name="option">Selected option index to assert against</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertMultipleComboBox(string expectedPattern, int option) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = $"#select_menu_multiple > option:checked:nth-child({option})",
            Locator = Locators.CssSelector,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for combo box (on UiControls page).
        /// </summary>
        /// <param name="count">Count expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertMultipleComboBoxSelectedCount(int count) => new ActionRule
        {
            Action = PluginsList.Assert,
            Argument = "{{$ --count --eq:" + count + "}}",
            OnElement = "#select_menu_multiple > option:checked",
            Locator = Locators.CssSelector
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for selectable element (find by id).
        /// </summary>
        /// <param name="id">Element id to find by.</param>
        /// <param name="selected"><see cref="true"/> to assert if element is selected; <see cref="false"/> if not.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertSelectable(string id, bool selected)
        {
            // setup
            var assertions = selected ? "selected" : "not_selected";

            return new ActionRule
            {
                Action = PluginsList.Assert,
                Argument = "{{$ --" + assertions + "}}",
                OnElement = id,
                Locator = Locators.Id
            };
        }
    }
}