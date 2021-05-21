/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * ONLINE RESOURCES
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gravity.Extensions
{
    /// <summary>
    /// Utilities class for various tasks and simplification of complicated operations.
    /// </summary>
    public static class PluginUtilities
    {
        private static readonly IList<Assembly> assemblies = new List<Assembly>();

        /// <summary>
        /// Gets the types loaded into the domain.
        /// </summary>
        public static IEnumerable<Type> Types => DoGetTypes().SelectMany(i => i.Types).Distinct();

        #region *** Assemblies  ***
        /// <summary>
        /// gets a collection of all assemblies where the executing assembly is currently located
        /// </summary>
        /// <returns>assemblies collection</returns>
        public static IEnumerable<(Assembly Assembly, IEnumerable<Type> Types)> GetTypes()
        {
            return DoGetTypes();
        }

        private static IEnumerable<(Assembly Assembly, IEnumerable<Type> Types)> DoGetTypes()
        {
            // reset
            assemblies.Clear();

            // setup
            var mainLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var rootLocations = new[]
            {
                mainLocation
            };
            var pluginsLocation = Array.Empty<string>();
            var locations = pluginsLocation
                .Where(i => Directory.Exists(i))
                .SelectMany(i => Directory.GetDirectories(i))
                .Concat(rootLocations);

            // build files
            var files = locations
                .Where(i => Directory.Exists(i))
                .SelectMany(i => Directory.GetFiles(i))
                .Where(i => i.EndsWith(".DLL") || i.EndsWith(".dll"));

            // build
            foreach (var assemblyFile in files)
            {
                GetAssemblies(assemblyFile);
            }

            // get
            return assemblies.Select(i => GetPair(i)).Where(i => i.Assembly != null);
        }

        [SuppressMessage("Major Code Smell", "S3885:\"Assembly.Load\" should be used", Justification = "A special case when need to load by file path.")]
        [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "False positive with S3885")]
        private static void GetAssemblies(string assemblyFile)
        {
            // load main assembly
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load(AssemblyName.GetAssemblyName(assemblyFile));
                assembly.GetTypes();
            }
            catch (FileNotFoundException)
            {
                assembly = Assembly.LoadFile(assemblyFile);
                try
                {
                    assembly.GetTypes();
                }
                catch (Exception e) when (e != null)
                {
                    // ignore exceptions
                    return;
                }
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
                return;
            }

            // build
            assemblies.Add(assembly);
            foreach (var item in assembly.GetReferencedAssemblies())
            {
                try
                {
                    var names = assemblies.Select(i => i.FullName).Any(i => i == item.FullName);
                    if (names)
                    {
                        continue;
                    }
                    var referenced = Assembly.Load(item);
                    GetAssemblies(referenced.Location);
                }
                catch (Exception e) when (e != null)
                {
                    // ignore exceptions
                }
            }
        }

        private static (Assembly Assembly, IEnumerable<Type> Types) GetPair(Assembly assembly)
        {
            try
            {
                // setup
                var types = assembly.GetTypes();

                // get
                return (assembly, types);
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }
            return (null, null);
        }
        #endregion

        #region *** Copy Files  ***
        /// <summary>
        /// Copy a folder from source location into target location.
        /// </summary>
        /// <param name="sourceDirectory">Source directory to copy.</param>
        /// <param name="targetDirectory">Target directory to copy.</param>
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            // setup
            var source = new DirectoryInfo(sourceDirectory);
            var target = new DirectoryInfo(targetDirectory);

            // copy
            DoCopyAll(source, target);
        }

        /// <summary>
        /// copy folder from source into target
        /// </summary>
        /// <param name="source">source directory to copy</param>
        /// <param name="target">target directory to copy</param>
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            DoCopyAll(source, target);
        }

        private static void DoCopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // copy each file into the new directory.
            foreach (FileInfo f in source.GetFiles())
            {
                f.CopyTo(Path.Combine(target.FullName, f.Name), true);
            }

            // copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                DoCopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        #endregion

        /// <summary>
        /// Gets the local IP address of the host machine.
        /// </summary>
        /// <returns>Local IP address if exists.</returns>
        public static string GetLocalEndpoint()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
                {
                    if (string.IsNullOrEmpty(ip.ToString()))
                    {
                        continue;
                    }
                    return ip.ToString();
                }
                throw new KeyNotFoundException("local IPvP address not found");
            }
            catch (Exception e) when (e != null)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets <see cref="JsonSerializerOptions"/> based on <see cref="JsonNamingPolicy"/>.
        /// </summary>
        /// <typeparam name="T"><see cref="JsonNamingPolicy"/> strategy type.</typeparam>
        /// <returns>The <see cref="JsonSerializerOptions"/> applied on a <see cref="JsonSerializer"/> object.</returns>
        public static JsonSerializerOptions GetJsonSettings<T>(params JsonConverter[] converters)
            where T : JsonNamingPolicy, new()
        {
            // setup
            var settings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new T(),
                WriteIndented = true
            };

            // build
            foreach (var converter in converters)
            {
                settings.Converters.Add(converter);
            }

            // get
            return settings;
        }

        /// <summary>
        /// Gets <see cref="JsonSerializerOptions"/> based on <see cref="JsonNamingPolicy.CamelCase"/>.
        /// </summary>
        /// <returns>The <see cref="JsonSerializerOptions"/> applied on a <see cref="JsonSerializer"/> object.</returns>
        public static JsonSerializerOptions GetJsonSettings(params JsonConverter[] converters)
        {
            // setup
            var settings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            // build
            foreach (var converter in converters)
            {
                settings.Converters.Add(converter);
            }

            // get
            return settings;
        }
    }
}