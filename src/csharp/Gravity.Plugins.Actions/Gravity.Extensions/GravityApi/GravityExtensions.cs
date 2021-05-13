/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

using Rule = Gravity.Plugins.Contracts.Rule;

namespace Gravity.Extensions
{
    /// <summary>
    /// Gravity extensions for OrbitRequest and OrbitResponse objects.
    /// </summary>
    public static class GravityExtensions
    {
        #region *** Rules      ***
        /// <summary>
        /// Gets a value from this <see cref="Rule.Context"/>, indicating if this <see cref="Rule.Actions"/>
        /// will be executed.
        /// </summary>
        /// <param name="rule">This <see cref="Rule"/> instance.</param>
        /// <returns><see cref="true"/> if <see cref="Rule.Actions"/> will be executed, <see cref="false"/> if not.</returns>
        public static bool ExecuteSubActions(this Rule rule)
        {
            return rule.Context.ContainsKey(Rule.ExecuteSubActions) && (bool)rule.Context[Rule.ExecuteSubActions];
        }

        /// <summary>
        /// Sets a value on this <see cref="Rule.Context"/>, indicating if this <see cref="Rule.Actions"/>
        /// will be executed.
        /// </summary>
        /// <param name="rule">This <see cref="Rule"/> instance.</param>
        /// <param name="doExecute"><see cref="true"/> if <see cref="Rule.Actions"/> will be executed, <see cref="false"/> if not.</param>
        public static void ExecuteSubActions(this Rule rule, bool doExecute)
        {
            rule.Context[Rule.ExecuteSubActions] = doExecute;
        }
        #endregion

        #region *** Extraction ***
        /// <summary>
        /// Gets this <see cref="Extraction.Entities"/> as <see cref="DataTable"/> object.
        /// </summary>
        /// <param name="extraction">ExtractionRule by which to create <see cref="DataTable"/> object.</param>
        /// <returns><see cref="DataTable"/> object with all <see cref="Extraction.Entities"/>.</returns>
        public static DataTable ToDataTable(this Extraction extraction)
        {
            // setup
            var dataTable = new DataTable();
            var columns = extraction
                .Entities
                .SelectMany(i => i.Content)
                .Select(i => (columnName: i.Key, type: ParseColumnType($"{i.Value}")))
                .Distinct();
            var rows = extraction.Entities.Select(i => GetDataRow(onTable: dataTable, entity: i));

            // create columns
            foreach (var (columnName, type) in columns)
            {
                dataTable.Columns.Add(columnName, type);
            }

            // create rows
            foreach (var row in rows)
            {
                dataTable.Rows.Add(row);
            }

            // results
            return dataTable;
        }

        private static DataRow GetDataRow(DataTable onTable, Entity entity)
        {
            // setup
            var row = onTable.NewRow();

            // apply
            foreach (var entry in entity.Content)
            {
                row[entry.Key] = entry.Value;
            }

            // result
            return row;
        }

        private static Type ParseColumnType(string value)
        {
            // patterns
            const string Decimal = @"^(-)?(?!00)\d+\.\d+$";
            const string Numeric = @"^(-)?(?!0)\d+$|^0$";
            const string Boolean = "^(?i)true|false$";

            // setup conditions
            var isDecimal = Regex.IsMatch(input: value, pattern: Decimal);
            var isNumeric = Regex.IsMatch(input: value, pattern: Numeric);
            var isBoolean = Regex.IsMatch(input: value, pattern: Boolean);

            // factor
            if (isDecimal && double.TryParse(s: value, result: out _))
            {
                return typeof(double);
            }

            if (isNumeric && long.TryParse(s: value, result: out _))
            {
                return typeof(long);
            }

            if (isBoolean && bool.TryParse(value, result: out _))
            {
                return typeof(bool);
            }

            if (DateTime.TryParse(s: value, result: out _))
            {
                return typeof(DateTime);
            }

            // no changes
            return typeof(string);
        }

        /// <summary>
        /// Generates default values for this <see cref="Extraction"/> object.
        /// </summary>
        /// <param name="extraction">This <see cref="Extraction"/> object instance.</param>
        /// <returns><see cref="Extraction"/> object with default values.</returns>
        public static Extraction GetDefault(this Extraction extraction) => Get(extraction, string.Empty);

        /// <summary>
        /// Generates default values for this <see cref="Extraction"/> object.
        /// </summary>
        /// <param name="extraction">This <see cref="Extraction"/> object instance.</param>
        /// <param name="session">This <see cref="IWebDriver"/> session id.</param>
        /// <returns><see cref="Extraction"/> object with default values.</returns>
        public static Extraction GetDefault(this Extraction extraction, string session) => Get(extraction, session);

        // basic object initialization
        private static Extraction Get(Extraction extraction, string session)
        {
            extraction.OrbitSession = new OrbitSession
            {
                MachineIp = PluginUtilities.GetLocalEndpoint(),
                MachineName = Environment.MachineName,
                SessionsId = session
            };
            return extraction;
        }
        #endregion

        #region *** Automation ***
        /// <summary>
        /// Gets a collection of ExtractionRule from this WebAutomation.
        /// </summary>
        /// <param name="automation">WebAutomation from which to get ExtractionRule collection.</param>
        /// <param name="extractions">ExtractionRule zero-based index to collection to get. Empty to get all.</param>
        /// <returns>A collection of ExtractionRule.</returns>
        public static IEnumerable<ExtractionRule> GetExtractionRules(this WebAutomation automation, IEnumerable<string> extractions)
        {
            // exit conditions
            if (!extractions.Any())
            {
                return automation.Extractions;
            }

            // build extractions list
            var extractionsList = new List<ExtractionRule>();
            foreach (var extraction in extractions)
            {
                var isExtraction = int.TryParse(extraction, out int extractionOut);
                var isRange = extractionOut <= automation.Extractions.Count() - 1;
                var isValidExtraction = isExtraction && isRange;

                if (isValidExtraction)
                {
                    extractionsList.Add(automation.Extractions.ElementAt(extractionOut));
                }
            }
            return extractionsList;
        }
        #endregion
    }
}