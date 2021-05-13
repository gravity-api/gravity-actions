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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Gravity.Plugins.Actions.Providers
{
    public class MarkdownDataProvider : DataProvidersBase
    {
        // members
        private static readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public MarkdownDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.MarkDown)]
        public override DataTable From()
        {
            // setup
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter))
                ? string.Empty
                : DataProvider.Filter;

            // if source is a file, load from file
            if (File.Exists($"{DataProvider.Source}"))
            {
                DataProvider.Source = ReadFile($"{DataProvider.Source}");
            }

            // get
            var dataTable = GetByMarkDown($"{DataProvider.Source}");
            return dataTable.Filter(DataProvider.Filter);
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.MarkDown)]
        public override void To(Extraction extraction)
        {
            // setup
            var dataTable = extraction.ToDataTable();
            var headers = dataTable.Columns.Cast<DataColumn>().Select(i => i.ColumnName);
            var separators = headers.Select(i => new string('-', i.Length));

            // build: rows
            var dataRows = new List<string>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var _dataRowMarkdown = "|" + string.Join("|", dataRow.ItemArray) + "|";
                dataRows.Add(_dataRowMarkdown);
            }

            // build: markdown
            var headersMarkdown = "|" + string.Join("|", headers) + "|\n";
            var separatorsMarkdown = "|" + string.Join("|", separators) + "|\n";
            var dataRowsMarkdown = string.Join("\n", dataRows);
            var content = headersMarkdown + separatorsMarkdown + dataRowsMarkdown;

            // create
            WriteFile(path: $"{DataProvider.Source}", content);
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

        private static void WriteFile(string path, string content)
        {
            // lock
            readWriteLock.EnterWriteLock();

            // read
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, content, Encoding.UTF8);
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

        private static DataTable GetByMarkDown(string source)
        {
            // split into lines            
            var lines = source
                .SplitByLines()
                .Where(i => !Regex.IsMatch(input: i, pattern: @"^(\|-+)+\|?$") && !string.IsNullOrEmpty(i))
                .ToArray();

            // exit conditions
            if (lines.Length == 1)
            {
                return new DataTable();
            }

            // get headers
            var headers = GetRows(lines[0]);

            // get lines
            var rows = new List<IEnumerable<string>> { headers };
            for (int i = 1; i < lines.Length; i++)
            {
                var row = GetRows(lines[i]);
                rows.Add(row);
            }

            // table
            return GetTable(rows);
        }

        private static IEnumerable<string> GetRows(string markdown)
            => Regex.Split(markdown, @"\|+(:)?").Where(i => Regex.IsMatch(i, @"\w+")).Select(i => i.Trim());

        private static DataTable GetTable(IEnumerable<IEnumerable<string>> rows)
        {
            var dataTable = new DataTable();

            // add headers
            foreach (var header in rows.ElementAt(0))
            {
                dataTable.Columns.Add(header);
            }
            // add rows
            for (int i = 1; i < rows.Count(); i++)
            {
                var dataRow = dataTable.NewRow();
                for (int j = 0; j < rows.ElementAt(i).Count(); j++)
                {
                    dataRow[j] = rows.ElementAt(i).ElementAt(j);
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
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