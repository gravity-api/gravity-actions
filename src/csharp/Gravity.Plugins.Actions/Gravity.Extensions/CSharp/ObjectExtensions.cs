/*
 * CHANGE LOG - keep only last 5 threads
 */
using System.Collections;
using System.Text.Json;

namespace Gravity.Extensions
{
    /// <summary>
    /// Extensions for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Gets the underline object if the <see cref="object"/> is <see cref="JsonElement"/>
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to get underline data from.</param>
        /// <returns>The underline value as <see cref="object"/>.</returns>
        public static object GetUnderline(this object obj)
        {
            if (obj is not JsonElement element || obj is IEnumerable)
            {
                return obj;
            }

            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString(),
                JsonValueKind.Number => element.GetDouble(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Null => default,
                _ => element
            };
        }

        #region *** To JSON ***
        /// <summary>
        /// Serializes the specified <see cref="object"/> into a JSON string.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        /// <remarks>This method use <see cref="CamelCaseNamingStrategy"/>.</remarks>
        public static string ToJson(this object obj)
        {
            return DoToJson(obj, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
        }

        /// <summary>
        /// Serializes the specified <see cref="object"/> into a JSON string.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to serialize.</param>
        /// <param name="settings">Specifies the settings on a <see cref="JsonSerializer"/> object.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string ToJson(this object obj, JsonSerializerOptions settings)
        {
            return JsonSerializer.Serialize(obj, settings);
        }

        private static string DoToJson(object obj, JsonSerializerOptions settings)
        {
            return JsonSerializer.Serialize(obj, settings);
        }
        #endregion

        /// <summary>
        /// Creates a new copy of this <see cref="object"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="object"/> type to clone.</typeparam>
        /// <param name="obj"><see cref="object"/> to clone.</param>
        /// <returns>A new <see cref="object"/> copy (with a different memory address).</returns>
        public static T Clone<T>(this T obj)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(obj));
        }
    }
}