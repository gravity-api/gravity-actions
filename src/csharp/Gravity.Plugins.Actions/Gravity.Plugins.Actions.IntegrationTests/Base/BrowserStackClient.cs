using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gravity.Plugins.Actions.IntegrationTests.Base
{
    public class BrowserStackClient
    {
        // members: state
        private static readonly HttpClient client = new HttpClient();

        public BrowserStackClient()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        /// <summary>
        /// Rest API endpoint format (replace with session id)
        /// </summary>
        public const string BrowserStackApiFormat = "https://api.browserstack.com/automate/sessions/{0}.json";

        /// <summary>
        /// Base 64 basic authorization token for API requests.
        /// </summary>
        public string BasicAuthorization { get; set; }

        /// <summary>
        /// Grid endpoint i.e. https://[user]:[access-token]@hub-cloud.browserstack.com/wd/hub
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the timeout when sending unsuccessful requests.
        /// </summary>
        public TimeSpan AttemptsTimeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Gets or sets the contract <see cref="JsonSerializerSettings"/> for this client requests.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// You can mark tests as passed or failed, using PUT. You can also pass a reason for failure.
        /// </summary>
        /// <param name="session">Session id to update.</param>
        /// <param name="requestBody">Session information to update.</param>
        public Task PutAsync(string session, object requestBody)
        {
            // setup
            var body = JsonConvert.SerializeObject(requestBody, settings: SerializerSettings);
            var content = new StringContent(content: body, Encoding.UTF8, mediaType: "application/json");
            var requestUri = string.Format(format: BrowserStackApiFormat, session);

            // execute
            return SendAsync(() => client.PutAsync(requestUri, content));
        }

        /// <summary>
        /// You can delete a session on the server, using DELETE.
        /// </summary>
        /// <param name="session">Session id to delete</param>
        public Task DeleteAsync(string session)
        {
            // setup
            var requestUri = string.Format(format: BrowserStackApiFormat, session);

            // execute
            return SendAsync(() => client.DeleteAsync(requestUri));
        }

        private async Task SendAsync(Func<Task<HttpResponseMessage>> factory)
        {
            // setup
            var timeout = AttemptsTimeout.TotalSeconds;
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Basic", parameter: BasicAuthorization);

            // send to server
            var interval = 0;
            while (interval < timeout)
            {
                var response = await factory.Invoke().ConfigureAwait(false);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }
                interval += 1000;
                await Task.Delay(millisecondsDelay: 1000).ConfigureAwait(false);
            }
        }
    }
}