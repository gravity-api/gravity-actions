/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.IntegrationTests.Base
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
                ActionType = CommonPlugins.SendKeys,
                Argument = searchFor,
                OnElement = "SearchString",
                Locator = LocatorType.Id
            },
            new ActionRule
            {
                ActionType = CommonPlugins.Click,
                OnElement = "SearchButton",
                Locator = LocatorType.Id
            }
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
                ActionType = CommonPlugins.SendKeys,
                Argument = $"{numberOfAlerts}",
                OnElement = "number_of_alerts",
                Locator = LocatorType.Id
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
                ActionType = CommonPlugins.Click,
                OnElement = "Back to List",
                Locator = LocatorType.LinkText
            }
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for students count (on students page).
        /// </summary>
        /// <param name="count">Count expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertStudentsCount(int count) => new ActionRule
        {
            ActionType = CommonPlugins.Assert,
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
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = "number_of_alerts",
            Locator = LocatorType.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for number of alerts (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertUrl(string expectedPattern) => new ActionRule
        {
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --url --match:" + expectedPattern + "}}"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertClickOutcome(string expectedPattern) => new ActionRule
        {
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "click_outcome",
            OnAttribute = "value",
            Locator = LocatorType.Id
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="greaterThan">Greater than expected result.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertListenerOutcome(int greaterThan) => new ActionRule
        {
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = "dismissed_elements",
            Locator = LocatorType.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Gets an assert <see cref="ActionRule"/> for click outcome results (on UiControls page).
        /// </summary>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert against.</param>
        /// <returns>Assert <see cref="ActionRule"/>.</returns>
        public static ActionRule AssertInputEnabledValue(string expectedPattern) => new ActionRule
        {
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --attribute --match:" + expectedPattern + "}}",
            OnElement = "input_enabled",
            Locator = LocatorType.Id,
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
            ActionType = CommonPlugins.Assert,
            Argument = "{{$ --attribute --gt:" + $"{greaterThan}" + "}}",
            OnElement = $"scroll_{offset.ToLower()}_outcome",
            Locator = LocatorType.Id,
            OnAttribute = "value"
        };

        /// <summary>
        /// Assert extractions count and values (not null or empty).
        /// </summary>
        /// <param name="responses"><see cref="OrbitResponse"/> from which to fetch entities.</param>
        /// <param name="fieldsCount">Expected number of fields per entity.</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assertion results.</returns>
        public static bool AssertEntitiesValues(IEnumerable<OrbitResponse> responses, int fieldsCount, string expectedPattern)
        {
            // setup
            var excluded = new[] { "EntityIndex" };

            // get all entities
            var entities = responses.SelectMany(i=>i.Extractions).SelectMany(i => i.Entities);
            var entries = entities.SelectMany(i => i.EntityContent).Where(i => !excluded.Contains(i.Key));

            // assertion, add +1 to fields count to normalize automatic fields.
            var isCount = entities.All(i => i.EntityContent.Count == fieldsCount + excluded.Length);
            var isValues = entries
                .All(i => !string.IsNullOrEmpty(i.Key) && Regex.IsMatch(input: $"{i.Value}", pattern: expectedPattern));

            // results
            return isCount && isValues;
        }

        /// <summary>
        /// Assert extractions count and values (not null or empty).
        /// </summary>
        /// <param name="responses"><see cref="OrbitResponse"/> from which to fetch entities.</param>
        /// <param name="fieldsCount">Expected number of fields per entity.</param>
        /// <param name="expectedPattern">Expected pattern (regular expression) to assert content value against.</param>
        /// <returns>Assertion results.</returns>
        public static bool AssertEntitiesKeys(IEnumerable<OrbitResponse> responses, int fieldsCount, string expectedPattern)
        {
            // setup
            var excluded = new[] { "EntityIndex" };

            // get all entities
            var entities = responses.SelectMany(i=>i.Extractions).SelectMany(i => i.Entities);
            var entries = entities.SelectMany(i => i.EntityContent).Where(i => !excluded.Contains(i.Key));

            // assertion, add +1 to fields count to normalize automatic fields.
            var isCount = entities.All(i => i.EntityContent.Count == fieldsCount + excluded.Length);
            var isKeys = entries
                .All(i => !string.IsNullOrEmpty(i.Key) && Regex.IsMatch(input: $"{i.Key}", pattern: expectedPattern));

            // results
            return isCount && isKeys;
        }
    }
}