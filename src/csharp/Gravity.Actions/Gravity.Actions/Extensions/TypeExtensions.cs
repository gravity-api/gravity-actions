/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class TypeExtensions
    {
        #region *** By Description ***
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
            return methods.Where(i => Regex.IsMatch(i.GetCustomAttribute<DescriptionAttribute>().Description, d, c));
        }
        #endregion

        #region *** By Name        ***
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
    }
}