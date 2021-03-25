/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Graivty.IntegrationTests.Converters
{
    /// <summary>
    /// Allows safe serialization and deserialization of <see cref="Exception"/>.
    /// </summary>
    internal class ExceptionConverter : JsonConverter<Exception>
    {
        /// <summary>
        /// Reads and converts the JSON to type T.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override Exception Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a specified value as JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, Exception value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString(nameof(value.Message), value.Message);
            writer.WriteString(nameof(value.StackTrace), value.StackTrace);
            writer.WriteString(nameof(value.HelpLink), value.HelpLink);
            writer.WriteNumber(nameof(value.HResult), value.HResult);
            writer.WriteString(nameof(value.Source), value.Source);
            writer.WriteString(nameof(value.TargetSite), $"{value.TargetSite.DeclaringType.FullName}.{value.TargetSite.Name}");
            writer.WriteEndObject();
        }
    }
}
