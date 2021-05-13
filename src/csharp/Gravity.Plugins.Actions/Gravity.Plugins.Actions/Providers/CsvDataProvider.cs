/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Gravity.Plugins.Actions.Providers
{
    public class CsvDataProvider : DataProvidersBase
    {
        // members
        private static readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public CsvDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.CSV)]
        public override DataTable From()
        {
            // setup
            var dataTable = new DataTable();

            // normalize filter
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter))
                ? string.Empty
                : DataProvider.Filter;

            // if source is a file, load from file
            if (File.Exists($"{DataProvider.Source}"))
            {
                DataProvider.Source = ReadFile($"{DataProvider.Source}");
            }

            // add comma-delimited data to data-table
            using (var stringReader = new StringReader($"{DataProvider.Source}"))
            {
                AddData(dataTable, stringReader);
            }

            // return populated table
            return dataTable.Filter(DataProvider.Filter);
        }

        private static void AddData(DataTable dataTable, StringReader stringReader)
        {
            // process headers
            var headersLine = stringReader.ReadLine();
            var numberOfColumns = AddHeaders(dataTable, headersLine);

            // exit conditions
            if (numberOfColumns == 0)
            {
                return;
            }

            // setup
            const StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
            var splitter = new[] { Environment.NewLine, "\n", "\t", "\r" };
            var lines = stringReader.ReadToEnd().Split(splitter, options);

            // process lines
            for (int i = 0; i < lines.Length; i++)
            {
                AddLine(dataTable, lines[i], numberOfColumns);
            }
        }

        private static int AddHeaders(DataTable dataTable, string headersLins)
        {
            var headers = headersLins?.Split(',');
            if (headers == null)
            {
                return 0;
            }

            foreach (var header in headers)
            {
                dataTable.Columns.Add(columnName: header, type: typeof(object));
            }

            return headers.Length;
        }

        private static void AddLine(DataTable dataTable, string line, int numberOfColumns)
        {
            // split line
            var csvRow = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            // create new table-row into which to populate line
            var dataRow = dataTable.NewRow();

            // populate line
            for (var j = 0; j < numberOfColumns; j++)
            {
                dataRow[j] = ParseCsvColumnType(csvRow[j]);
            }

            // add row
            dataTable.Rows.Add(dataRow);
        }

        private static object ParseCsvColumnType(string value)
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
            if (isDecimal)
            {
                _ = double.TryParse(s: value, result: out double doubleOut);
                return doubleOut;
            }
            if (isNumeric)
            {
                _ = long.TryParse(s: value, result: out long longOut);
                return longOut;
            }
            if (isBoolean)
            {
                _ = bool.TryParse(value, result: out bool boolOut);
                return boolOut;
            }
            if (DateTime.TryParse(s: value, result: out DateTime dateTimeOut))
            {
                return dateTimeOut;
            }

            // no changes
            return value;
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.CSV)]
        public override void To(Extraction extraction)
        {
            // setup
            var dataTable = extraction.ToDataTable();
            var csvData = new List<string> { GetHeadersLine(dataTable) };

            // add rows
            csvData.AddRange(GetRows(dataTable));

            // save to file: setup
            Directory.CreateDirectory(Path.GetDirectoryName($"{DataProvider.Source}"));
            if (File.Exists($"{DataProvider.Source}"))
            {
                csvData.RemoveAt(0);
            }

            // save to file: write CSV
            try
            {
                readWriteLock.EnterWriteLock();
                using var writer = new StreamWriter(path: $"{DataProvider.Source}", append: true, Encoding.UTF8);
                csvData.ForEach(i => writer.WriteLine(i));
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

        private static string GetHeadersLine(DataTable dataTable)
        {
            // setup
            var headers = new List<string>();

            // apply
            foreach (DataColumn column in dataTable.Columns)
            {
                // Normalize CSV Header
                var columnName = column.ColumnName.Replace(",", string.Empty).Replace("\"", string.Empty);

                // Add Header Columns
                headers.Add(columnName);
            }

            // result
            return string.Join(",", headers);
        }

        private static IEnumerable<string> GetRows(DataTable dataTable)
        {
            // setup
            var csvRows = new List<string>();

            // iterate
            foreach (DataRow dataRow in dataTable.Rows)
            {
                csvRows.Add(GetRow(dataRow));
            }

            // result
            return csvRows;
        }

        private static string GetRow(DataRow dataRow)
        {
            // setup
            var csvCells = new List<string>();

            // iterate
            foreach (DataColumn dataColumn in dataRow.Table.Columns)
            {
                var value = $"{dataRow[dataColumn]}".Replace("\"", "\"\"");
                if ($"{dataRow[dataColumn]}".Contains(","))
                {
                    value = $@"""{$"{dataRow[dataColumn]}"}""";
                }
                csvCells.Add(value);
            }

            // result
            return string.Join(",", csvCells);
        }
        #endregion

        // Utilities
        private static string ReadFile(string path)
        {
            // lock
            readWriteLock.EnterReadLock();

            // read
            try
            {
                return File.ReadAllText(path, Encoding.UTF8);
            }
            finally
            {
                readWriteLock.ExitReadLock();
            }
        }

        private void AssertDataProvider()
        {
            // bad request
            if (string.IsNullOrEmpty($"{DataProvider.Source}"))
            {
                throw new ArgumentException("You must provide a valid DataProvider.Source value.");
            }
        }
    }
}