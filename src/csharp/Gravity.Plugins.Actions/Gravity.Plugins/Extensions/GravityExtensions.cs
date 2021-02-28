/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

using Rule = Gravity.Plugins.Contracts.Rule;

namespace Gravity.Plugins.Extensions
{
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
        /// <param name="extraction"><see cref="ExtractionRule"/> by which to create <see cref="DataTable"/> object.</param>
        /// <returns><see cref="DataTable"/> object with all <see cref="Extraction.Entities"/>.</returns>
        public static DataTable ToDataTable(this Extraction extraction) => GetDataTable(extraction);

        /// <summary>
        /// Gets this <see cref="Entity.Content"/> as <see cref="DataTable"/> object.
        /// </summary>
        /// <param name="entity"><see cref="Entity"/> by which to create <see cref="DataTable"/> object.</param>
        /// <returns><see cref="DataTable"/> object with all <see cref="Entity.Content"/>.</returns>
        public static DataTable ToDataTable(this Entity entity)
            => GetDataTable(new Extraction { Entities = new[] { entity } });

        /// <summary>
        /// Populates this <see cref="Extraction"/> based on <see cref="ExtractionRule.DataSource"/> property.
        /// </summary>
        /// <param name="extraction"><see cref="Extraction"/> by which to populate data.</param>
        /// <param name="dataSource">The output <see cref="Contracts.DataSource"/> where the data of this extraction can be populated.</param>
        public static void Populate(this Extraction extraction, DataSource dataSource)
        {
            DoPopulate(extraction, dataSource);
        }

        /// <summary>
        /// Populates this <see cref="Entity"/> based on <see cref="ExtractionRule.DataSource"/> property.
        /// </summary>
        /// <param name="entity"><see cref="Entity"/> by which to populate data.</param>
        /// <param name="dataSource">The output <see cref="DataSource"/> where the data of this extraction can be populated.</param>
        public static void Populate(this Entity entity, DataSource dataSource)
        {
            DoPopulate(new Extraction { Entities = new[] { entity } }, dataSource);
        }

        /// <summary>
        /// Populates this <see cref="Extraction"/> based on <see cref="ExtractionRule.DataSource"/> property.
        /// </summary>
        /// <param name="extraction"><see cref="Extraction"/> by which to populate data.</param>
        /// <param name="dataSource"><see cref="DataSource"/> by which to execute <paramref name="factory"/> middleware.</param>
        /// <param name="factory">A middleware to populate this <see cref="Extraction"/>.</param>
        public static void Populate(this Extraction extraction, DataSource dataSource, Action<Extraction, DataSource> factory)
        {
            factory.Invoke(arg1: extraction, arg2: dataSource);
        }

        // DATA UTILITIES
        private static void DoPopulate(Extraction extraction, DataSource dataSource)
        {
            try
            {
                // get extraction as data table
                var dataTable = GetDataTable(extraction);

                // populate
                dataTable.Save(dataSource);
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }
        }

        private static DataTable GetDataTable(Extraction extraction)
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
        #endregion
    }
}