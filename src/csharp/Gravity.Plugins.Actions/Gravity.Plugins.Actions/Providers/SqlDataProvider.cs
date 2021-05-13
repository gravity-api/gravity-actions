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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravity.Plugins.Actions.Providers
{    
    public class SqlDataProvider : DataProvidersBase
    {
        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public SqlDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.SQLServer)]
        public override DataTable From()
        {
            // setup
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter))
                ? string.Empty
                : DataProvider.Filter;
            var dataTable = new DataTable();

            try
            {
                // setup connection
                using var connection = new SqlConnection($"{DataProvider.Source}");
                connection.Open();

                // setup SQL command
                var script = $"SELECT * FROM [{DataProvider.Repository}]";
                var sqlCommand = new SqlCommand(cmdText: "EXEC sp_executesql @script", connection);
                sqlCommand.Parameters.AddWithValue(parameterName: "script", value: script);

                // apply data
                using var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                // return populated data
                return dataTable.Filter(DataProvider.Filter);
            }
            catch (Exception e) when (e != null)
            {
                return new DataTable();
            }
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.SQLServer)]
        public override void To(Extraction extraction)
        {
            // setup
            CreateDatabase(DataProvider);
            var dataTable = extraction.ToDataTable();

            // setup connection
            using var sqlConnection = new SqlConnection(connectionString: $"{DataProvider.Source}");
            sqlConnection.Open();

            // set table name
            dataTable.TableName = string.IsNullOrEmpty(dataTable.TableName)
                ? DataProvider.Repository
                : dataTable.TableName;

            // write
            dataTable.ToSqlServer(sqlConnection);
        }
        #endregion

        // Utilities
        private static void CreateDatabase(GravityDataProvider dataProvider)
        {
            // setup
            var connectionString = new string($"{dataProvider.Source}".Select(i => i).ToArray());
            var builder = new SqlConnectionStringBuilder(connectionString);
            var command =
                $"IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE [name] = \"{builder.InitialCatalog}\")" +
                " BEGIN" +
                $"    CREATE DATABASE [{builder.InitialCatalog}]" +
                " END;";

            // clear initial catalog if exists
            builder.Remove("Initial Catalog");

            // setup connection
            using var connection = new SqlConnection(connectionString: builder.ConnectionString);
            connection.Open();

            // setup SQL command
            var sqlCommand = new SqlCommand(cmdText: "EXEC sp_executesql @script", connection);
            sqlCommand.Parameters.AddWithValue(parameterName: "script", value: command);

            // create database if not exists
            sqlCommand.ExecuteNonQuery();
        }

        private void AssertDataProvider()
        {
            // bad request
            if (string.IsNullOrEmpty($"{DataProvider.Source}"))
            {
                throw new ArgumentException("You must provide a valid DataProvider.Source value.");
            }
            if (string.IsNullOrEmpty($"{DataProvider.Repository}"))
            {
                throw new ArgumentException("You must provide a valid DataProvider.Repository value.");
            }
        }
    }
}