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
using System.Text.Json;
using System.Threading;

namespace Gravity.Plugins.Actions.Providers
{
    public class JsonDataProvider : DataProvidersBase
    {
        // members
        private static readonly ReaderWriterLockSlim readWriteLock = new();

        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public JsonDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.JSON)]
        public override DataTable From()
        {
            // normalize filter
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter)) ? string.Empty : DataProvider.Filter;

            // if source is a file, load from file
            if (File.Exists($"{DataProvider.Source}"))
            {
                DataProvider.Source = ReadFile($"{DataProvider.Source}");
            }

            // setup
            var dataTable = JsonSerializer
                .Deserialize<IEnumerable<IDictionary<string, object>>>($"{DataProvider.Source}")
                .ToDataTable();

            // get
            return dataTable.Filter(DataProvider.Filter);
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.JSON)]
        public override void To(Extraction extraction)
        {
            // setup
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var dataTable = extraction.ToDataTable();

            // if no repository
            if (!File.Exists($"{DataProvider.Source}"))
            {
                var data = JsonSerializer.Serialize(dataTable.ToDictionary(), options);
                WriteFile($"{DataProvider.Source}", contents: data);
                return;
            }

            // setup
            var jsonData = ReadFile(path: $"{DataProvider.Source}");

            // validation
            AssertJson(jsonData);

            // normalize data table
            var sDataTable = JsonSerializer.Serialize(dataTable.ToDictionary(), options);
            var nDataTable = JsonSerializer
                .Deserialize<IEnumerable<IDictionary<string, object>>>(sDataTable, options)
                .ToDataTable();

            // load >> merge
            var jsonTable = JsonSerializer
                .Deserialize<IEnumerable<IDictionary<string, object>>>(jsonData, options)
                .ToDataTable();
            jsonTable.Merge(nDataTable);

            // save
            WriteFile($"{DataProvider.Source}", contents: JsonSerializer.Serialize(jsonTable.ToDictionary(), options));
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

        private static void WriteFile(string path, string contents)
        {
            // lock
            readWriteLock.EnterWriteLock();

            // read
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                File.WriteAllText(path, contents, Encoding.UTF8);
            }
            finally
            {
                readWriteLock.ExitWriteLock();
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

        private static void AssertJson(string jsonData)
        {
            // setup
            string message;

            // not a JSON
            if (!jsonData.IsJson())
            {
                message = "The data in the source provided is not a valid JSON schema.";
                throw new ArgumentException(message, paramName: nameof(jsonData));
            }

            // not a table (JSON array)
            var isTable = jsonData.StartsWith("[") && jsonData.EndsWith("]");
            if (!isTable)
            {
                message = "The data in the source provided is not a valid Table schema (an array of objects).";
                throw new ArgumentException(message, paramName: nameof(jsonData));
            }
        }
    }
}
