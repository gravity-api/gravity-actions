/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace Gravity.Plugins.Extensions
{
    public static class DataTableExtensions
    {
        private static readonly ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Populates a <see cref="DataTable"/> to a given <see cref="SqlConnection"/>.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="sqlConnection"><see cref="SqlConnection"/> by which to populate this <see cref="DataTable"/>.</param>
        public static void WriteToServer(this DataTable dataTable, SqlConnection sqlConnection)
        {
            DoWriteToServer(dataTable, sqlConnection);
        }

        /// <summary>
        /// Populates a <see cref="DataTable"/> from a given <see cref="DataSource"/>.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="dataSource"><see cref="DataSource"/> by which to load into this <see cref="DataTable"/>.</param>
        /// <returns><see cref="DataTable"/> object that match the filter criteria.</returns>
        public static DataTable Load(this DataTable dataTable, DataSource dataSource)
        {
            return Get(dataTable, dataSource, prefix: "From");
        }

        /// <summary>
        /// Populates a <see cref="DataTable"/> to a given <see cref="DataSource"/>.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="dataSource"><see cref="DataSource"/> by which to save this <see cref="DataTable"/>.</param>
        public static void Save(this DataTable dataTable, DataSource dataSource)
        {
            Get(dataTable, dataSource, prefix: "To");
        }

        private static DataTable Get(DataTable dataTable, DataSource dataSource, string prefix)
        {
            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;

            // get execution method
            var method = typeof(DataTableExtensions)
                .GetMethodsByDescription(dataSource.Type, Flags)
                .FirstOrDefault(i => i.Name.StartsWith(prefix, StringComparison.Ordinal));

            // validation
            if (method == default)
            {
                throw new NotSupportedException($"Save method for [{dataSource.Type}] is not implemented yet.");
            }

            // invoke
            try
            {
                var invokeResults = method.Invoke(obj: null, parameters: new object[] { dataTable, dataSource });
                return invokeResults == null ? new DataTable() : (DataTable)invokeResults;
            }
            catch (Exception e) when (e != null)
            {
                throw e.InnerException ?? e;
            }
        }

        /// <summary>
        /// Gets a new <see cref="DataTable"/> object that match the filter criteria.
        /// </summary>
        /// <param name="dataTable">This <see cref="DataTable"/> object.</param>
        /// <param name="filterExpression">The criteria to use to filter the rows. For examples on how to filter rows, see DataView RowFilter Syntax [C#]</param>
        /// <returns><see cref="DataTable"/> object that match the filter criteria.</returns>
        public static DataTable Filter(this DataTable dataTable, string filterExpression)
        {
            return DoFilter(dataTable, filterExpression);
        }

#pragma warning disable IDE0051
        #region *** From Data Source ***
        // populates a <see cref="DataTable"/> from a given CSV (file or string)
        [Description(DataSourcesList.CSV)]
        private static DataTable FromCsv(DataTable dataTable, DataSource dataSource)
        {
            // exit conditions
            DataSourceCompliance($"{dataSource.Source}", needRepository: false, repository: string.Empty);

            // normalize filter
            dataSource.Filter = (string.IsNullOrEmpty(dataSource.Filter)) ? string.Empty : dataSource.Filter;

            // if source is a file, load from file
            if (File.Exists($"{dataSource.Source}"))
            {
                dataSource.Source = ReadFile($"{dataSource.Source}");
            }

            // add comma-delimited data to data-table
            using (var stringReader = new StringReader($"{dataSource.Source}"))
            {
                AddData(dataTable, stringReader);
            }

            // return populated table
            return DoFilter(dataTable, dataSource.Filter);
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
            const string SPLITTER = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
            var csvRow = Regex.Split(line, SPLITTER);

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
                double.TryParse(s: value, result: out double doubleOut);
                return doubleOut;
            }
            if (isNumeric)
            {
                long.TryParse(s: value, result: out long longOut);
                return longOut;
            }
            if (isBoolean)
            {
                bool.TryParse(value, result: out bool boolOut);
                return boolOut;
            }
            if (DateTime.TryParse(s: value, result: out DateTime dateTimeOut))
            {
                return dateTimeOut;
            }

            // no changes
            return value;
        }

        // Populates a <see cref="DataTable"/> from a given SQL Table.
        [Description(DataSourcesList.SQLServer)]
        private static DataTable FromSqlDatabase(DataTable dataTable, DataSource dataSource)
        {
            // exit conditions
            DataSourceCompliance(source: $"{dataSource.Source}", needRepository: true, repository: dataSource.Repository);

            // normalize filter
            dataSource.Filter = (string.IsNullOrEmpty(dataSource.Filter)) ? string.Empty : dataSource.Filter;

            try
            {
                // setup connection
                using var connection = new SqlConnection($"{dataSource.Source}");
                connection.Open();

                // setup SQL command
                var script = $"SELECT * FROM [{dataSource.Repository}]";
                var sqlCommand = new SqlCommand(cmdText: "EXEC sp_executesql @script", connection);
                sqlCommand.Parameters.AddWithValue(parameterName: "script", value: script);

                // apply data
                using var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);

                // return populated data
                return DoFilter(dataTable, dataSource.Filter);
            }
            catch (Exception e) when (e != null)
            {
                return new DataTable();
            }
        }

        // Populates a <see cref="DataTable"/> from a given XML (file or string).
        [Description(DataSourcesList.XML)]
        private static DataTable FromXml(DataTable dataTable, DataSource dataSource)
        {
            // exit conditions
            DataSourceCompliance($"{dataSource.Source}", needRepository: false, dataSource.Repository);

            // setup
            _ = dataTable;
            dataSource.Filter = (string.IsNullOrEmpty(dataSource.Filter)) ? string.Empty : dataSource.Filter;

            // if source is a file, load from file
            if (File.Exists($"{dataSource.Source}"))
            {
                dataSource.Source = ReadFile($"{dataSource.Source}");
            }

            // exit condition
            if (!$"{dataSource.Source}".IsXml())
            {
                throw new ArgumentException("The XML provided is not a valid XML schema.", nameof(dataSource));
            }

            // populate data-table
            using var xmlReader = XmlReader.Create(new StringReader($"{dataSource.Source}"));
            using var dataSet = new DataSet();

            // load XML as data-table
            dataSet.ReadXml(xmlReader);

            // return populated data-table
            dataTable = string.IsNullOrEmpty(dataSource.Repository)
                ? dataSet.Tables[0]
                : dataSet.Tables[dataSource.Repository];

            return DoFilter(dataTable, dataSource.Filter);
        }

        // Populates a <see cref="DataTable"/> from a given JSON (file or string).
        [Description(DataSourcesList.JSON)]
        private static DataTable FromJson(DataTable dataTable, DataSource dataSource)
        {
            // exit conditions
            DataSourceCompliance($"{dataSource.Source}", needRepository: false, repository: string.Empty);

            // normalize filter
            dataSource.Filter = (string.IsNullOrEmpty(dataSource.Filter)) ? string.Empty : dataSource.Filter;

            // if source is a file, load from file
            if (File.Exists($"{dataSource.Source}"))
            {
                dataSource.Source = ReadFile($"{dataSource.Source}");
            }

            // load JToken
            var token = JToken.Parse($"{dataSource.Source}");

            // exit conditions
            if (!(token is JArray))
            {
                return dataTable;
            }
            if (((JArray)token).Count == 0)
            {
                return dataTable;
            }

            // get data-table
            dataTable = JsonConvert.DeserializeObject<DataTable>($"{dataSource.Source}");
            return DoFilter(dataTable, dataSource.Filter);
        }

        // Populates a <see cref="DataTable"/> from a GET request (Rest API).
        [Description(DataSourcesList.RestApi)]
        private static DataTable FromRestApi(DataTable dataTable, DataSource dataSource)
        {
            // exit conditions
            DataSourceCompliance($"{dataSource.Source}", needRepository: false, repository: string.Empty);

            // normalize filter
            dataSource.Filter = (string.IsNullOrEmpty(dataSource.Filter)) ? string.Empty : dataSource.Filter;

            // get
            dataSource.Source = GetFromApi(dataSource);
            if (string.IsNullOrEmpty($"{dataSource.Source}"))
            {
                return dataTable;
            }

            // load JToken
            var token = JToken.Parse($"{dataSource.Source}");

            // exit conditions
            if (!(token is JArray))
            {
                return dataTable;
            }
            if (((JArray)token).Count == 0)
            {
                return dataTable;
            }

            // get data-table
            dataTable = JsonConvert.DeserializeObject<DataTable>($"{dataSource.Source}");
            return DoFilter(dataTable, dataSource.Filter);
        }

        private static string GetFromApi(DataSource dataSource)
        {
            // setup authorization
            var authorization = GetAuthorization(dataSource);
            if (authorization != default)
            {
                httpClient.DefaultRequestHeaders.Authorization = authorization;
            }

            // get response
            var response = httpClient
                .GetAsync($"{dataSource.Source}".Replace(oldValue: "@", newValue: string.Empty))
                .GetAwaiter()
                .GetResult();

            // response failure
            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            // results
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        #endregion

        #region *** To Data Source   ***
        // populates a <see cref="DataTable"/> from a given XML (file or string)
        [Description(DataSourcesList.CSV)]
        private static void ToCsv(DataTable dataTable, DataSource dataSource)
        {
            // setup
            var csvData = new List<string> { GetHeadersLine(dataTable) };

            // add rows
            csvData.AddRange(GetRows(dataTable));

            // save to file: setup
            Directory.CreateDirectory(Path.GetDirectoryName($"{dataSource.Source}"));
            if (File.Exists($"{dataSource.Source}"))
            {
                csvData.RemoveAt(0);
            }

            // save to file: write CSV
            try
            {
                readWriteLock.EnterWriteLock();
                using var writer = new StreamWriter(path: $"{dataSource.Source}", append: true, Encoding.UTF8);
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

        // Populates a <see cref="DataTable"/> to a given SQL Table
        [Description(DataSourcesList.SQLServer)]
        private static void ToSqlServer(this DataTable dataTable, DataSource dataSource)
        {
            // setup
            CreateDatabase(dataSource);

            // setup connection
            using var connection = new SqlConnection(connectionString: $"{dataSource.Source}");
            connection.Open();

            // set table name
            dataTable.TableName = string.IsNullOrEmpty(dataTable.TableName) ? dataSource.Repository : dataTable.TableName;

            // write
            DoWriteToServer(dataTable, connection);
        }

        private static void CreateDatabase(DataSource dataSource)
        {
            // setup
            var connectionString = new string($"{dataSource.Source}".Select(i => i).ToArray());
            var builder = new SqlConnectionStringBuilder(connectionString);
            var command =
                $"IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE [name] = '{builder.InitialCatalog}')" +
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

        // populates a <see cref="DataTable"/> to a given XML (file or string)
        [Description(DataSourcesList.XML)]
        private static void ToXml(this DataTable dataTable, DataSource dataSource)
        {
            try
            {
                // lock
                readWriteLock.EnterWriteLock();

                // set table name
                if (string.IsNullOrEmpty(dataSource.Repository))
                {
                    dataSource.Repository = "Table" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                }

                dataTable.TableName = string.IsNullOrEmpty(dataTable.TableName)
                    ? dataSource.Repository
                    : dataTable.TableName;

                // if no repository
                if (!File.Exists($"{dataSource.Source}"))
                {
                    Directory.CreateDirectory(path: Path.GetDirectoryName($"{dataSource.Source}"));
                    File.WriteAllText(path: $"{dataSource.Source}", contents: $"{AsXml(dataTable)}", encoding: Encoding.UTF8);
                    return;
                }

                // load
                var xmlTable = new DataTable();
                xmlTable.ReadXml(fileName: $"{dataSource.Source}");

                // merge >> save
                dataTable.Merge(table: xmlTable, preserveChanges: false, MissingSchemaAction.Add);
                File.WriteAllText(path: $"{dataSource.Source}", contents: $"{AsXml(dataTable)}", encoding: Encoding.UTF8);
            }
            finally
            {
                readWriteLock.ExitWriteLock();
            }
        }

        // populates a <see cref="DataTable"/> to a given JSON (file or string)
        [Description(DataSourcesList.JSON)]
        private static void ToJson(this DataTable dataTable, DataSource dataSource)
        {
            // setup
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            // if no repository
            if (!File.Exists($"{dataSource.Source}"))
            {
                var data = JsonConvert.SerializeObject(dataTable, settings);
                WriteFile($"{dataSource.Source}", contents: data);
                return;
            }

            // setup
            var jsonData = ReadFile(path: $"{dataSource.Source}");

            // validation
            JsonValidation(jsonData);

            // normalize data table
            var sDataTable = JsonConvert.SerializeObject(dataTable, settings);
            var nDataTable = JsonConvert.DeserializeObject<DataTable>(sDataTable, settings);

            // load >> merge
            var jsonTable = JsonConvert.DeserializeObject<DataTable>(jsonData, settings);
            jsonTable.Merge(nDataTable);

            // save
            WriteFile($"{dataSource.Source}", contents: JsonConvert.SerializeObject(jsonTable, settings));
        }

        // populates a <see cref="DataTable"/> to a Web API using POST request (Rest API).
        [Description(DataSourcesList.RestApi)]
        private static void ToRestApi(this DataTable dataTable, DataSource dataSource)
        {
            // setup
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            // setup
            var jsonData = JsonConvert.SerializeObject(value: dataTable, settings);

            // validation
            JsonValidation(jsonData);

            // setup authorization
            var authorization = GetAuthorization(dataSource);
            if (authorization != default)
            {
                httpClient.DefaultRequestHeaders.Authorization = authorization;
            }

            // post
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            httpClient
                .PostAsync($"{dataSource.Source}".Replace(oldValue: "@", newValue: string.Empty), content)
                .GetAwaiter()
                .GetResult();
        }

        private static void JsonValidation(string jsonData)
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
        #endregion

        #region *** Utilities        ***
        // filter data table
        private static DataTable DoFilter(DataTable dataTable, string filterExpression)
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

        // throws if data-source is not valid
        private static void DataSourceCompliance(string source, bool needRepository, string repository)
        {
            // exit conditions
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("You must provide a valid data source.", nameof(source));
            }

            // exit conditions
            if (string.IsNullOrEmpty(repository) && needRepository)
            {
                throw new ArgumentException("You must provide a valid repository.", nameof(repository));
            }
        }

        // thread safe read file
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

        // thread safe write file
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

        // get the data table as XML document
        private static XDocument AsXml(DataTable dataTable)
        {
            // write XML
            using var stream = new MemoryStream();
            dataTable.WriteXml(stream, mode: XmlWriteMode.WriteSchema);
            var xml = Encoding.ASCII.GetString(stream.ToArray());

            // results
            return XDocument.Parse(xml);
        }

        // get AuthenticationHeaderValue for HTTP request
        private static AuthenticationHeaderValue GetAuthorization(DataSource dataSource)
        {
            // constants
            const string Pattern = @"(?<=https?:\/\/(www\.)?)[^w][^@]*(?=@)";

            // setup
            var isMatch = Regex.IsMatch(input: $"{dataSource.Source}", Pattern);
            if (!isMatch)
            {
                return default;
            }

            // extract
            var credentials = Regex.Match(input: $"{dataSource.Source}", Pattern).Value.Split(':');

            // validation
            if (credentials.Length != 2)
            {
                return default;
            }

            // results
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{credentials[0]}:{credentials[1]}"));
            return new AuthenticationHeaderValue(scheme: "Basic", parameter: base64);
        }
        #endregion

        #region *** Create on DB     ***
        // creates a SQL table out of DataTable object
        private static void DoWriteToServer(DataTable dataTable, SqlConnection connection)
        {
            // setup
            var script = GetCreateScript(dataTable);
            var sqlCommand = new SqlCommand(cmdText: "EXEC sp_executesql @script", connection);
            sqlCommand.Parameters.AddWithValue(parameterName: "script", value: script);

            // execute
            sqlCommand.ExecuteNonQuery();

            // copy data
            using var bulkCopy = new SqlBulkCopy(connection);
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
                $"IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = N'{dataTable.TableName}'){Environment.NewLine}" +
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

            // compose
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
#pragma warning restore
    }
}