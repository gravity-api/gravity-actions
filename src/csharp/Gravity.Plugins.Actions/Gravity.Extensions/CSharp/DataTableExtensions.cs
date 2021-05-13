/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * 
 * TODO: extract data source factory to be expandable and public.
 */
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace Gravity.Extensions
{
    public static class DataTableExtensions
    {
        #region *** Get Value      ***
        /// <summary>
        /// Get a value for a row by column name. If column does not exists, return null;
        /// </summary>
        /// <param name="row"><see cref="DataRow"/> to get from.</param>
        /// <param name="column"><see cref="DataColumn.ColumnName"/> to get from.</param>
        /// <returns>Data value or null if not found.</returns>
        public static object GetValue(this DataRow row, string column) => row.Table.Columns.Contains(column)
            ? row[column]
            : null;

        /// <summary>
        /// Get a value for a row by column name. If column does not exists, return null;
        /// </summary>
        /// <typeparam name="T">The type of the request value.</typeparam>
        /// <param name="row"><see cref="DataRow"/> to get from.</param>
        /// <param name="column"><see cref="DataColumn.ColumnName"/> to get from.</param>
        /// <returns>Data value or null if not found.</returns>
        public static object GetValue<T>(this DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column))
            {
                return (T)row[column];
            }
            return null;
        }
        #endregion

        #region *** To Dictionary  ***
        /// <summary>
        /// Gets a <see cref="IDictionary{TKey, TValue}"/> representation of <see cref="DataTable"/> object.
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/> to populate from.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> representation of <see cref="DataTable"/> object.</returns>
        public static IEnumerable<IDictionary<string, object>> ToDictionary(this DataTable dataTable)
        {
            return dataTable.Rows.Cast<DataRow>().Select(DoToDictionary);
        }

        /// <summary>
        /// Gets a <see cref="IDictionary{TKey, TValue}"/> representation of <see cref="DataRow"/> object.
        /// </summary>
        /// <param name="dataRow"><see cref="DataTable"/> to populate from.</param>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> representation of <see cref="DataRow"/> object.</returns>
        public static IDictionary<string, object> ToDictionary(this DataRow dataRow)
        {
            return dataRow.DoToDictionary();
        }

        private static IDictionary<string, object> DoToDictionary(this DataRow dataRow) => dataRow
            .Table
            .Columns
            .Cast<DataColumn>()
            .ToDictionary(key => key.ColumnName, str => dataRow[str.ColumnName]);
        #endregion

        #region *** To SQL Server  ***
        /// <summary>
        /// Populates a <see cref="DataTable"/> to a given <see cref="SqlConnection"/>.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="sqlConnection"><see cref="SqlConnection"/> by which to populate this <see cref="DataTable"/>.</param>
        public static void ToSqlServer(this DataTable dataTable, SqlConnection sqlConnection)
        {
            // setup
            var script = GetCreateScript(dataTable);
            var sqlCommand = new SqlCommand(cmdText: "EXEC sp_executesql @script", sqlConnection);
            sqlCommand.Parameters.AddWithValue(parameterName: "script", value: script);

            // execute
            sqlCommand.ExecuteNonQuery();

            // copy data
            using var bulkCopy = new SqlBulkCopy(sqlConnection);
            foreach (DataColumn c in dataTable.Columns)
            {
                bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
            }

            // setup >> write
            bulkCopy.DestinationTableName = dataTable.TableName;
            bulkCopy.WriteToServer(table: dataTable);
        }

        // creates a SQL script that creates a table where the columns matches that of the specified DataTable
        private static string GetCreateScript(DataTable dataTable)
        {
            // setup
            var src = new StringBuilder()
                .AppendFormat("CREATE TABLE [{1}] ({0}    ", Environment.NewLine, dataTable.TableName);
            var isFirstTime = true;

            // iterate (compose script)
            foreach (DataColumn column in dataTable.Columns.OfType<DataColumn>())
            {
                if (isFirstTime)
                {
                    isFirstTime = false;
                }
                else
                {
                    src.Append("   ,");
                }

                src.AppendFormat("[{0}] {1} {2} {3}",
                    column.ColumnName,
                    GetSqlType(column.DataType),
                    column.AllowDBNull ? "NULL" : "NOT NULL",
                    Environment.NewLine);
            }
            src.AppendFormat(") ON [PRIMARY];{0}", Environment.NewLine);

            // build an ALTER TABLE script that adds keys to a table that already exists
            if (dataTable.PrimaryKey.Length > 0)
            {
                src.Append(GetKeysScript(dataTable));
            }

            // results
            return
                $"IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = N\"{dataTable.TableName}\"){Environment.NewLine}" +
                $"BEGIN{Environment.NewLine}" +
                $"{src}" +
                 "END;";
        }

        // builds an ALTER TABLE script that adds a primary or composite key to a table that already exists
        private static string GetKeysScript(DataTable Table)
        {
            // exit conditions
            if (Table.PrimaryKey.Length < 1)
            {
                return string.Empty;
            }

            // build
            var src = new StringBuilder();
            if (Table.PrimaryKey.Length == 1)
            {
                src.AppendFormat("ALTER TABLE {1};{0}ADD PRIMARY KEY ({2});{0}",
                    Environment.NewLine, Table.TableName, Table.PrimaryKey[0].ColumnName);
            }
            else
            {
                var compositeKeys = Table.PrimaryKey.Select(dc => dc.ColumnName).ToList();
                var keyName = compositeKeys.Aggregate((a, b) => a + b);
                var keys = compositeKeys.Aggregate((a, b) => string.Format("{0}, {1}", a, b));
                src.AppendFormat("ALTER TABLE {1};{0}ADD CONSTRAINT pk_{3} PRIMARY KEY ({2});{0}",
                    Environment.NewLine, Table.TableName, keys, keyName);
            }

            // results
            return src.ToString();
        }

        // returns the SQL data type equivalent, as a string for use in SQL script generation methods
        private static string GetSqlType(Type DataType) => DataType.Name switch
        {
            "Boolean" => "[bit]",
            "Char" => "[char]",
            "SByte" => "[tinyint]",
            "Int16" => "[smallint]",
            "Int32" => "[int]",
            "Int64" => "[bigint]",
            "Byte" => "[tinyint] UNSIGNED",
            "UInt16" => "[smallint] UNSIGNED",
            "UInt32" => "[int] UNSIGNED",
            "UInt64" => "[bigint] UNSIGNED",
            "Single" => "[float]",
            "Double" => "[double]",
            "Decimal" => "[decimal]",
            "DateTime" => "[datetime]",
            "Guid" => "[uniqueidentifier]",
            "Object" => "[variant]",
            "String" => "[nvarchar](250)",
            _ => "[nvarchar](MAX)",
        };
        #endregion

        /// <summary>
        /// Merge a collection of <see cref="DataTable"/> into a single <see cref="DataTable"/> object.
        /// </summary>
        /// <param name="tables">A collection of <see cref="DataTable"/> to merge from</param>
        /// <returns>A single, merged <see cref="DataTable"/> object.</returns>
        public static DataTable Merge(this IEnumerable<DataTable> tables)
        {
            // exit conditions
            if (!tables.Any())
            {
                return default;
            }

            // extract all columns
            var onTables = new List<DataTable>();
            onTables.AddRange(tables);
            var columns = onTables.SelectMany(i => i.Columns.Cast<DataColumn>()).Select(i => i.ColumnName);

            // create new table and apply aggregated columns
            var dataTable = new DataTable();
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            // apply rows from all tables (will apply only if column is valid)
            foreach (var table in onTables)
            {
                var index = 0;
                foreach (DataRow i in table.Rows)
                {
                    // new row conditions
                    if (index > dataTable.Rows.Count - 1)
                    {
                        var mergedRow = dataTable.NewRow();
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            mergedRow[table.Columns[j].ColumnName] = $"{table.Rows[index][j]}";
                        }
                        dataTable.Rows.Add(mergedRow);
                    }
                    // have row
                    else
                    {
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            dataTable.Rows[index][table.Columns[j].ColumnName] = $"{table.Rows[index][j]}";
                        }
                    }
                    index++;
                }
            }

            // complete pipeline
            return dataTable;
        }

        /// <summary>
        /// Converts a <see cref="DataTable"/> object into <see cref="XDocument"/>.
        /// </summary>
        /// <param name="dataTable"><see cref="DataTable"/> to convert.</param>
        /// <returns><see cref="XDocument"/> representation of the <see cref="DataTable"/>.</returns>
        public static XDocument ToXml(this DataTable dataTable)
        {
            // write XML
            using var stream = new MemoryStream();
            dataTable.WriteXml(stream, mode: XmlWriteMode.WriteSchema);
            var xml = Encoding.ASCII.GetString(stream.ToArray());

            // results
            return XDocument.Parse(xml);
        }

        ///// <summary>
        ///// Populates a <see cref="DataTable"/> from a given <see cref="GravityDataProvider"/>.
        ///// </summary>
        ///// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        ///// <param name="dataProvider"><see cref="GravityDataProvider"/> by which to load into this <see cref="DataTable"/>.</param>
        ///// <returns><see cref="DataTable"/> object that match the filter criteria.</returns>
        //public static DataTable Load(this DataTable dataTable, GravityDataProvider dataSource)
        //{
        //    return Get(dataTable, dataSource, prefix: "From");
        //}

        ///// <summary>
        ///// Populates a <see cref="DataTable"/> to a given <see cref="GravityDataProvider"/>.
        ///// </summary>
        ///// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        ///// <param name="dataProvider"><see cref="GravityDataProvider"/> by which to save this <see cref="DataTable"/>.</param>
        //public static void Save(this DataTable dataTable, GravityDataProvider dataSource)
        //{
        //    Get(dataTable, dataSource, prefix: "To");
        //}

        //[SuppressMessage("Major Code Smell", "S3011:Reflection should not be used to increase accessibility of classes, methods, or fields", Justification = "As designed, the factory is private.")]
        //private static DataTable Get(DataTable dataTable, GravityDataProvider dataSource, string prefix)
        //{
        //    // setup
        //    const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;

        //    // get execution method
        //    var method = typeof(DataTableExtensions)
        //        .GetMethodsByAttribute<DescriptionAttribute>(Flags)
        //        .FirstOrDefault(i => i.GetCustomAttribute<DescriptionAttribute>().Description.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));

        //    // validation
        //    if (method == default)
        //    {
        //        throw new NotSupportedException($"Save method for [{dataSource.Type}] is not implemented yet.");
        //    }

        //    // invoke
        //    try
        //    {
        //        var invokeResults = method.Invoke(obj: null, parameters: new object[] { dataTable, dataSource });
        //        return invokeResults == null ? new DataTable() : (DataTable)invokeResults;
        //    }
        //    catch (Exception e) when (e != null)
        //    {
        //        throw e.InnerException ?? e;
        //    }
        //}

        /// <summary>
        /// Gets a new <see cref="DataTable"/> object that match the filter criteria.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="filterExpression">The criteria to use to filter the rows. For examples on how to filter rows, see DataView RowFilter Syntax [C#]</param>
        /// <returns><see cref="DataTable"/> object that match the filter criteria.</returns>
        public static DataTable Filter(this DataTable dataTable, string filterExpression)
        {
            // exit conditions
            if (string.IsNullOrEmpty(filterExpression))
            {
                return dataTable;
            }

            // filter data-table
            var rows = dataTable.Select(filterExpression);

            // create new data-table instance
            var fDataTable = dataTable.Clone();

            // add filtered rows
            foreach (DataRow row in rows)
            {
                fDataTable.ImportRow(row);
            }

            // return new data-table
            return fDataTable;
        }
    }
}