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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.Providers
{
    public class RestDataProvider : DataProvidersBase
    {
        // members
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Creates a new instance of DataProvider.
        /// </summary>
        /// <param name="dataProvider">GravityDataProvider to use with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public RestDataProvider(GravityDataProvider dataProvider, IEnumerable<Type> types)
            : base(dataProvider, types)
        {
            AssertDataProvider();
        }

        #region *** Data Provider: From ***
        /// <summary>
        /// Gets a <see cref="DataTable"/> object from the DataProvider.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> representation of the DataProvider.</returns>
        [DataProvider(GravityDataProviders.RestApi)]
        public override DataTable From()
        {
            // setup
            DataProvider.Filter = (string.IsNullOrEmpty(DataProvider.Filter))
                ? string.Empty
                : DataProvider.Filter;

            // get
            DataProvider.Source = InvokeWebRequest(DataProvider);
            if (string.IsNullOrEmpty($"{DataProvider.Source}"))
            {
                return new DataTable();
            }

            // get data-table
            return JsonSerializer
                .Deserialize<DataTable>($"{DataProvider.Source}")
                .Filter(DataProvider.Filter);
        }
        #endregion

        #region *** Data Provider: To   ***
        /// <summary>
        /// Saves an Extraction to the DataProvider.
        /// </summary>
        /// <param name="extraction"></param>
        [DataProvider(GravityDataProviders.RestApi)]
        public override void To(Extraction extraction)
        {
            // setup
            var dataTable = extraction.ToDataTable();

            // setup
            var jsonData = JsonSerializer.Serialize(value: dataTable.ToDictionary());

            // validation
            AssertJson(jsonData);

            // setup authorization
            var authorization = GetAuthenticationHeader(DataProvider);
            if (authorization != default)
            {
                httpClient.DefaultRequestHeaders.Authorization = authorization;
            }

            // post
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            httpClient
                .PostAsync($"{DataProvider.Source}".Replace(oldValue: "@", newValue: string.Empty), content)
                .GetAwaiter()
                .GetResult();
        }
        #endregion

        // Utilities
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

        private static string InvokeWebRequest(GravityDataProvider dataSource)
        {
            // setup authorization
            var authorization = GetAuthenticationHeader(dataSource);
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

        private static AuthenticationHeaderValue GetAuthenticationHeader(GravityDataProvider dataSource)
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
    }
}