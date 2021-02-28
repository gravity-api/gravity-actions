/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Extensions
{
    public static class TypeExtensions
    {
        #region *** By Description  ***
        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex)
        {
            return GetByDescription(
                t,
                regex,
                flags: BindingFlags.Instance | BindingFlags.NonPublic,
                comparison: RegexOptions.IgnoreCase).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex, BindingFlags flags)
        {
            return GetByDescription(t, regex, flags, comparison: RegexOptions.IgnoreCase).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            return GetByDescription(t, regex, flags, comparison).FirstOrDefault();
        }

        /// <summary>
        /// Gets all methods in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByDescription(this Type t, string regex)
        {
            return GetByDescription(
                t,
                regex,
                flags: BindingFlags.Instance | BindingFlags.NonPublic,
                comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets all methods in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByDescription(this Type t, string regex, BindingFlags flags)
        {
            return GetByDescription(t, regex, flags, comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets all methods in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByDescription(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            return GetByDescription(t, regex, flags, comparison);
        }

        // get all methods with matching description
        private static IEnumerable<MethodInfo> GetByDescription(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            // shortcuts
            var d = regex;
            var c = comparison;

            // get method
            var methods = t.GetMethods(flags).Where(i => i.GetCustomAttribute<DescriptionAttribute>() != null);
            methods = methods.Where(i => Regex.IsMatch(i.GetCustomAttribute<DescriptionAttribute>().Description, d, c));

            // exit conditions
            if (methods.Count() <= 1)
            {
                return methods;
            }

            // assert
            return methods.Where(i => Regex.IsMatch($"^{d}$", i.GetCustomAttribute<DescriptionAttribute>().Description, c));
        }
        #endregion

        #region *** By Name         ***
        /// <summary>
        /// Gets the first method in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByName(this Type t, string regex)
        {
            return GetByName(
                t,
                regex,
                flags: BindingFlags.Instance | BindingFlags.NonPublic,
                comparison: RegexOptions.IgnoreCase).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first method in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByName(this Type t, string regex, BindingFlags flags)
        {
            return GetByName(t, regex, flags, comparison: RegexOptions.IgnoreCase).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first method in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns><see cref="MethodInfo"/> instance if found or null if not.</returns>
        public static MethodInfo GetMethodByName(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            return GetByName(t, regex, flags, comparison).FirstOrDefault();
        }

        /// <summary>
        /// Gets all methods in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> if found or an empty collection if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByName(this Type t, string regex)
        {
            return GetByName(
                t,
                regex,
                flags: BindingFlags.Instance | BindingFlags.NonPublic,
                comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets all methods in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> if found or an empty collection if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByName(this Type t, string regex, BindingFlags flags)
        {
            return GetByName(t, regex, flags, comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets all methods in this type with the specified method name.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> if found or an empty collection if not.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByName(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            return GetByName(t, regex, flags, comparison);
        }

        // get all methods with matching names
        private static IEnumerable<MethodInfo> GetByName(Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            // shortcuts
            var d = regex;
            var c = comparison;

            // get method
            return t.GetMethods(flags).Where(i => Regex.IsMatch(input: i.Name, pattern: d, options: c));
        }
        #endregion

        #region *** Plugin          ***
        /// <summary>
        /// Assert if this <see cref="Type"/> is a valid <see cref="Base.Plugin"/> object.
        /// </summary>
        /// <param name="type">This <see cref="Type"/> instance.</param>
        /// <param name="pluginName">The <see cref="PluginAttribute.Name"/> of the <see cref="Plugin"/>.</param>
        /// <returns><see cref="true"/> if this is a valid <see cref="Base.Plugin'"/> or <see cref="false"/> if not.</returns>
        public static bool IsPlugin(this Type type, string pluginName)
        {
            // constants
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

            // setup conditions
            var isPlugin = typeof(Plugin).IsAssignableFrom(type);
            var isAttribute = isPlugin && type.GetCustomAttribute<PluginAttribute>() != null;
            var isName = !string.IsNullOrEmpty(pluginName);

            // exit conditions
            if (!isAttribute || !isName)
            {
                return false;
            }

            // collect assertion data
            var pluginAttribute = type.GetCustomAttribute<PluginAttribute>();
            pluginAttribute.Aliases ??= Array.Empty<string>();

            var pluginAttributeName = string.IsNullOrEmpty(pluginAttribute.Name)
                ? string.Empty
                : type.GetCustomAttribute<PluginAttribute>().Name;

            // setup conditions
            var isFromAttribute = pluginAttributeName.Equals(pluginName, Compare);
            var isFromName = type.Name.Equals(pluginName, Compare);
            var isFromKeywords = pluginAttribute.Aliases.Any(i => i.Equals(pluginName, Compare));

            // assert
            return isFromAttribute || isFromName || isFromKeywords;
        }
        #endregion
    }
}