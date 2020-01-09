/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gravity.Services.ActionPlugins.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex)
        {
            return GetMethodByDescription(
                t,
                regex,
                flags: BindingFlags.Instance | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex, BindingFlags flags)
        {
            return GetMethodByDescription(t, regex, flags, comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="regex">A pattern by which to find the method.</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string regex, BindingFlags flags, RegexOptions comparison)
        {
            // shortcuts
            var d = regex;
            var c = comparison;

            // get method
            var methods = t.GetMethods(flags).Where(i => i.GetCustomAttribute<DescriptionAttribute>() != null);
            return methods.FirstOrDefault(i => Regex.IsMatch(i.GetCustomAttribute<DescriptionAttribute>().Description, d, c));
        }
    }
}