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

namespace OpenQA.Selenium.Mock.Extensions
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="actual">A value to assert against the description (description will be matched against this value).</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string actual)
        {
            return GetMethodByDescription(
                t: t,
                actual: actual,
                flags: BindingFlags.Instance | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="actual">A value to assert against the description (description will be matched against this value).</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string actual, BindingFlags flags)
        {
            return GetMethodByDescription(
                t: t,
                actual: actual,
                flags: flags,
                comparison: RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Gets the first method in this type with the specified <see cref="DescriptionAttribute"/> description.
        /// </summary>
        /// <param name="t">This <see cref="Type"/> instance.</param>
        /// <param name="actual">A value to assert against the description (description will be matched against this value).</param>
        /// <param name="flags">Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</param>
        /// <param name="comparison">Specifies the culture, case, and sort rules to be used by this search.</param>
        /// <returns>MethodInfo instance if found or null if not.</returns>
        public static MethodInfo GetMethodByDescription(this Type t, string actual, BindingFlags flags, RegexOptions comparison)
        {
            // shortcuts
            var d = actual;
            var c = comparison;

            // get method
            var methods = t.GetMethods(flags).Where(i => i.GetCustomAttribute<DescriptionAttribute>() != null);
            return methods.FirstOrDefault(i => Regex.IsMatch(d, i.GetCustomAttribute<DescriptionAttribute>().Description, c));
        }
    }
}
