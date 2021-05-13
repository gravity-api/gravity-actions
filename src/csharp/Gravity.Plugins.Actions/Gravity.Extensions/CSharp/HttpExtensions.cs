/*
 * CHANGE LOG - keep only last 5 threads
 */
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Gravity.Extensions
{
    /// <summary>
    /// Extensions for <see cref="HttpResponseMessage"/> and <see cref="System.Net"/> objects.
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// Reads the body from <see cref="WebResponse"/> object.
        /// </summary>
        /// <param name="response"><see cref="WebResponse"/> object to read from.</param>
        /// <returns><see cref="WebResponse"/> content as string.</returns>
        public static string ReadBody(this WebResponse response)
        {
            using (response)
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Deserialize <see cref="HttpResponseMessage.Content"/> into a given object type.
        /// </summary>
        /// <typeparam name="T">Expected object type</typeparam>
        /// <param name="message"><see cref="HttpResponseMessage"/> to deserialize body from.</param>
        /// <returns>Data Transfer Object of the provided type.</returns>
        public static T ToObject<T>(this HttpResponseMessage message)
        {
            // get response body
            var responseBody = GetBody(message);

            // deserialize
            return JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        /// <summary>
        /// Deserialize <see cref="HttpResponseMessage.Content"/> into a <see cref="JObject"/>.
        /// </summary>
        /// <param name="message"><see cref="HttpResponseMessage"/> to deserialize body from.</param>
        /// <returns><see cref="JsonDocument"/> instance.</returns>
        public static JsonDocument ToObject(this HttpResponseMessage message)
        {
            // get response body
            var responseBody = GetBody(message);

            // deserialize
            return JsonDocument.Parse(responseBody);
        }

        private static string GetBody(HttpResponseMessage message)
        {
            // exit conditions
            if (message == default)
            {
                return default;
            }

            // get response body
            return message.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}