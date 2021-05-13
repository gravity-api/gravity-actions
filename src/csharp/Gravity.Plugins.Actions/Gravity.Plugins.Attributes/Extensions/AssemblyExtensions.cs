using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Gravity.Plugins.Attributes.Extensions
{
    /// <summary>
    /// <see cref="Assembly" /> extensions package.
    /// </summary>
    internal static class AssemblyExtensions
    {
        /// <summary>
        /// Loads the specified manifest resource from this assembly.
        /// </summary>
        /// <param name="resource">The case-sensitive name of the manifest resource being requested.</param>
        /// <returns>The manifest resource; or null if no resources were specified during compilation as <see cref="PluginAttribute"/>.</returns>
        public static PluginAttribute GetEmbeddedPluginManifest(this Assembly assembly, string resource)
        {
            try
            {
                // get JSON embedded resource
                var stream = assembly.GetManifestResourceStream(resource);

                // read resource
                using var reader = new StreamReader(stream, Encoding.UTF8);
                var data = reader.ReadToEnd();

                // deserialize to PluginAttribute
                return JsonSerializer.Deserialize<PluginAttribute>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
            catch (Exception e) when (e != null)
            {
                return default;
            }
        }
    }
}
