/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace Gravity.Plugins.Extensions
{
    /// <summary>
    /// Internal miscellaneous tools for executing plugins.
    /// </summary>
    public static class Misc
    {
        #region *** Get Types  ***
        /// <summary>
        /// gets a collection of all assemblies where the executing assembly is currently located
        /// </summary>
        /// <returns>assemblies collection</returns>
        public static IEnumerable<Type> GetTypes()
        {
            // setup
            var assemblies = GetAssemblies();
            var loadedAssemblies = new List<Assembly>();

            // load all sub-references
            foreach (var assembly in assemblies)
            {
                loadedAssemblies.AddRange(LoadReferencedAssemblies(assembly));
            }
            loadedAssemblies.AddRange(assemblies);

            // load all assemblies excluding the executing assembly
            // return only plugins types
            return loadedAssemblies
                .Distinct()
                .SelectMany(a => a.GetTypes());
        }

        // get attached and referenced assemblies
        private static List<Assembly> GetAssemblies()
        {
            // get all referenced assemblies
            var referenced = GetReferencedAssemblies();
            var attached = GetAttachedAssemblies(referenced);

            // build assemblies list
            var assemblies = new List<Assembly>();

            // append assemblies
            assemblies.AddRange(referenced);
            assemblies.AddRange(attached);

            // return populated list
            return assemblies;
        }

        // try to get referenced assemblies for application
        private static IEnumerable<Assembly> LoadReferencedAssemblies(Assembly assembly)
        {
            try
            {
                var referenced = assembly.GetReferencedAssemblies();
                return referenced.Select(Assembly.Load);
            }
            catch (Exception e) when (e != null)
            {
                return Array.Empty<Assembly>();
            }
        }

        // loads all referenced assemblies from: executing, calling & entry
        private static IEnumerable<Assembly> GetReferencedAssemblies()
        {
            // shortcuts
            var executing = Assembly.GetExecutingAssembly();
            var calling = Assembly.GetCallingAssembly();
            var entry = Assembly.GetEntryAssembly();

            // initialize results collection
            var assemblies = new List<Assembly> { executing, calling, entry }.Where(r => r != null).ToList();
            var referenced = new List<AssemblyName>
            {
                executing.GetName(),
                calling.GetName(),
                entry?.GetName()
            }
            .Where(r => r != null).ToList();

            // cache all assemblies references
            referenced.TryAddRange(executing?.GetReferencedAssemblies());
            referenced.TryAddRange(calling?.GetReferencedAssemblies());
            referenced.TryAddRange(entry?.GetReferencedAssemblies());

            // load assemblies            
            assemblies.AddRange(referenced.Select(Assembly.Load));
            return assemblies;
        }

        // loads all attached assemblies from current & working directories
        private static IEnumerable<Assembly> GetAttachedAssemblies(IEnumerable<Assembly> referenced)
        {
            // short-cuts
            var working = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var current = Environment.CurrentDirectory;

            // get all referenced names
            var referencedNames = referenced.Select(r => $"{working}\\{r.GetName().Name}.dll");

            // load assemblies
            var w = Directory.GetFiles(working).Where(f => f.EndsWith(".dll") && !referencedNames.Contains(f));
            var c = Directory.GetFiles(current).Where(f => f.EndsWith(".dll") && !referencedNames.Contains(f));

            // build names
            var attachedAssembliesNames = new List<string>();
            attachedAssembliesNames.TryAddRange(w);
            attachedAssembliesNames.TryAddRange(c);

            // build results
            var assemblies = new List<Assembly>();
            foreach (var assemblyName in attachedAssembliesNames)
            {
                var assembly = GetByAssemblyName(assemblyName);
                if (assembly == default)
                {
                    continue;
                }
                assemblies.Add(assembly);
            }
            return assemblies;
        }

        // gets an assembly by it's string name
        private static Assembly GetByAssemblyName(string assemblyName)
        {
            try
            {
                var name = AssemblyName.GetAssemblyName(assemblyName);
                return Assembly.Load(name);
            }
            catch (Exception e) when (e != null)
            {
                return default;
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
    }
}