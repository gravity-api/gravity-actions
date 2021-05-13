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
using System.Threading;
using System.Xml;

namespace Gravity.Plugins.Actions.Providers
{
    public class XmlDataProvider : DataProvidersBase
    {
        // members
        private static readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public XmlDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.XML)]
        public override DataTable From()
        {
            // setup
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter)) ? string.Empty : DataProvider.Filter;

            // if source is a file, load from file
            if (File.Exists($"{DataProvider.Source}"))
            {
                DataProvider.Source = ReadFile($"{DataProvider.Source}");
            }

            // exit condition
            if (!$"{DataProvider.Source}".IsXml())
            {
                throw new ArgumentException("The XML provided is not a valid XML schema.");
            }

            // populate data-table
            using var xmlReader = XmlReader.Create(new StringReader($"{DataProvider.Source}"));
            using var dataSet = new DataSet();

            // load XML as data-table
            dataSet.ReadXml(xmlReader);

            // return populated data-table
            var dataTable = string.IsNullOrEmpty(DataProvider.Repository)
                ? dataSet.Tables[0]
                : dataSet.Tables[DataProvider.Repository];

            // get
            return dataTable.Filter(DataProvider.Filter);
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.XML)]
        public override void To(Extraction extraction)
        {
            try
            {
                // lock
                readWriteLock.EnterWriteLock();

                // setup
                var dataTable = extraction.ToDataTable();

                // set table name
                if (string.IsNullOrEmpty(DataProvider.Repository))
                {
                    DataProvider.Repository = "Table" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                }

                dataTable.TableName = string.IsNullOrEmpty(dataTable.TableName)
                    ? DataProvider.Repository
                    : dataTable.TableName;

                // if no repository
                if (!File.Exists($"{DataProvider.Source}"))
                {
                    Directory.CreateDirectory(path: Path.GetDirectoryName($"{DataProvider.Source}"));
                    File.WriteAllText(path: $"{DataProvider.Source}", contents: $"{dataTable.ToXml()}", encoding: Encoding.UTF8);
                    return;
                }

                // load
                var xmlTable = new DataTable();
                xmlTable.ReadXml(fileName: $"{DataProvider.Source}");

                // merge >> save
                dataTable.Merge(table: xmlTable, preserveChanges: false, MissingSchemaAction.Add);
                File.WriteAllText(path: $"{DataProvider.Source}", contents: $"{dataTable.ToXml()}", encoding: Encoding.UTF8);
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
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