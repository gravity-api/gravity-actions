/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gravity.Extensions
{
    public static class TypeExtensions
    {
        #region *** Type   ***
        /// <summary>
        /// Gets a collection of <see cref="MethodInfo"/> with a specific <see cref="Attribute"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Attribute"/> type.</typeparam>
        /// <param name="type">A <see cref="Type"/> to search.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> with a specific <see cref="Attribute"/>.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByAttribute<T>(this Type type) where T : Attribute
        {
            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;

            // get
            return DoGetMethodsByAttribute<T>(type, Flags);
        }

        /// <summary>
        /// Gets a collection of <see cref="MethodInfo"/> with a specific <see cref="Attribute"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Attribute"/> type.</typeparam>
        /// <param name="type">A <see cref="Type"/> to search.</param>
        /// <returns>A collection of <see cref="MethodInfo"/> with a specific <see cref="Attribute"/>.</returns>
        public static IEnumerable<MethodInfo> GetMethodsByAttribute<T>(this Type type, BindingFlags flags) where T : Attribute
        {
            return DoGetMethodsByAttribute<T>(type, flags);
        }

        private static IEnumerable<MethodInfo> DoGetMethodsByAttribute<T>(this Type type, BindingFlags flags) where T : Attribute
        {
            return type.GetMethods(flags).Where(i => i.GetCustomAttribute<T>() != null);
        }
        #endregion

        #region *** Method ***
        /// <summary>
        /// Get a value indicating if the <see cref="DescriptionAttribute.Description"/> of the method
        /// can be matched to an input.
        /// </summary>
        /// <param name="method">The method to get <see cref="Attribute"/> from.</param>
        /// <param name="input">An input to search.</param>
        /// <returns><see cref="true"/> if match <see cref="false"/> if not.</returns>
        public static bool SearchDescription(this MethodInfo method, string input)
        {
            // setup
            var attribute = method.GetCustomAttribute<DescriptionAttribute>();

            // not found
            if(attribute == default)
            {
                return false;
            }

            // assert
            return Regex.IsMatch(input, pattern: attribute.Description);
        }

        /// <summary>
        /// Gets an <see cref="Attribute"/> from a method.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="Attribute"/> to get.</typeparam>
        /// <param name="method">The method to get <see cref="Attribute"/> from.</param>
        /// <returns>An <see cref="Attribute"/> of a certain type.</returns>
        public static T GetCustomAttribute<T>(this MethodInfo method) where T : Attribute
        {
            // setup
            return method.GetCustomAttributes<T>().FirstOrDefault();
        }

        /// <summary>
        /// Gets an instance for invoke the <see cref="MethodInfo"/>.
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo"/> to invoke.</param>
        /// <param name="args">The instance constructor parameters.</param>
        /// <returns>An instance ready for invoke (<see cref="null"/> if the method is static).</returns>
        public static object GetInstance(this MethodInfo method, IEnumerable<object> args)
        {
            // setup
            var type = method.DeclaringType;

            // exit conditions
            if (type == null || method.IsStatic)
            {
                return null;
            }

            // build
            return Activator.CreateInstance(type, args.ToArray());
        }

        /// <summary>
        /// Gets a value indicating if the methods contains all the parameters from the given collection
        /// </summary>
        /// <param name="method">The <see cref="MethodInfo"/> to invoke.</param>
        /// <param name="parameters">Parameters collection of the state method to execute.</param>
        /// <returns>True if all parameters exists; False if not.</returns>
        public static bool HasParameters(this MethodInfo method, IEnumerable<object> parameters)
        {
            // setup
            var methodParameters = method.GetParameters();
            var types = parameters.Select(i => i.GetType());

            // setup conditions
            var isType = methodParameters.All(m => types.Select(i => i.FullName).Contains(m.ParameterType.FullName));
            var isBase = methodParameters.All(m => types.Any(i => m.ParameterType.IsAssignableFrom(i)));

            // get
            return isType || isBase;
        }
        #endregion
    }
}