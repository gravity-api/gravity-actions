/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Gravity.Plugins.Actions.Extensions
{
    internal static class MethodInfoExtensions
    {
        /// <summary>
        /// invoke method with action
        /// </summary>
        /// <param name="method">method to invoke</param>
        /// <param name="instance">instance under which to invoke this method</param>
        /// <param name="action">action-rule to pass to the invoked method</param>
        public static void InvokeAction(this MethodInfo method, object instance, ActionRule action)
        {
            // exit conditions: base-type
            if (instance.GetType().BaseType != typeof(WebDriverActionPlugin))
            {
                return;
            }

            // exit conditions: signature
            if (method.GetParameters().Length != 1)
            {
                return;
            }

            // exit conditions: parameter type
            if (!method.GetParameters().All(p => p.ParameterType == typeof(ActionRule)))
            {
                return;
            }

            // verify
            LoadAssemblies(instance);

            // invoke against the gravity-action instance
            method.Invoke(instance, new object[] { action });
        }

        /// <summary>
        /// invoke method with action & element
        /// </summary>
        /// <param name="method">method to invoke</param>
        /// <param name="instance">instance under which to invoke this method</param>
        /// <param name="action">action-rule to pass to the invoked method</param>
        /// <param name="element">web-element to pass to the invoked method</param>
        public static void InvokeAction(this MethodInfo method, object instance, ActionRule action, IWebElement element)
        {
            // exit conditions: base-type
            if (instance.GetType().BaseType != typeof(WebDriverActionPlugin))
            {
                return;
            }

            // exit conditions: parameter type
            var isAction = method.GetParameters().Any(p => p.ParameterType == typeof(ActionRule));
            var isElement = method.GetParameters().Any(p => p.ParameterType == typeof(IWebElement));
            if (!isAction && !isElement)
            {
                return;
            }

            // verify
            LoadAssemblies(instance);

            // invoke action
            if (isAction && !isElement)
            {
                method.Invoke(instance, new object[] { action });
                return;
            }

            // invoke element/action
            method.Invoke(instance, new object[] { element, action });
        }

        /// <summary>
        /// invoke method with no arguments
        /// </summary>
        /// <param name="method">method to invoke</param>
        /// <param name="instance">instance under which to invoke this method</param>
        public static void InvokeAction(this MethodInfo method, object instance)
        {
            // exit conditions: base-type
            if (instance.GetType().BaseType != typeof(WebDriverActionPlugin))
            {
                return;
            }

            // exit conditions: signature
            if (method.GetParameters().Length > 0)
            {
                return;
            }

            // verify
            LoadAssemblies(instance);

            // invoke against the gravity-action instance
            method.Invoke(instance, Array.Empty<object>());
        }

        /// <summary>
        /// invoke method with no arguments
        /// </summary>
        /// <param name="method">method to invoke</param>
        /// <param name="instance">instance under which to invoke this method</param>
        public static T InvokeAction<T>(this MethodInfo method, object instance, IEnumerable<object> parameters)
        {
            // verify
            LoadAssemblies(instance);

            // invoke against the gravity-action instance
            return (T)method.Invoke(instance, parameters.ToArray());
        }

        [SuppressMessage("Major Code Smell", "S3885:\"Assembly.Load\" should be used", Justification = "A special case when need to load by file path.")]
        private static void LoadAssemblies(object instance)
        {
            // setup
            var location = Path.GetDirectoryName(instance.GetType().Assembly.Location);
            var files = Directory.GetFiles(location);
            var assemblies = instance.GetType().Assembly.GetReferencedAssemblies();
            var subDomain = new List<(AssemblyName Name, string AssemblyFile)>();

            // build
            foreach (var assembly in assemblies)
            {
                var assemblyFile = Array.Find(files, i => i.Contains(assembly.Name, StringComparison.OrdinalIgnoreCase));
                subDomain.Add((assembly, assemblyFile));
            }

            // load
            foreach (var (assembly, file) in subDomain)
            {
                try
                {
                    Assembly.Load(assembly);
                }
                catch (FileNotFoundException)
                {
                    Assembly.LoadFrom(file);
                }
                catch (Exception e) when (e != null)
                {
                    // ignore exceptions
                }
            }
        }
    }
}
