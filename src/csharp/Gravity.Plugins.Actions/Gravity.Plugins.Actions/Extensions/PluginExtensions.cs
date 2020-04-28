/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using System;
using System.Linq;
using System.Reflection;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class PluginExtensions
    {
        /// <summary>
        /// Conditionally get an <see cref="IWebElement"/> based on values from <see cref="ActionRule"/> and <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="plugin">This <see cref="WebDriverActionPlugin"/> instance.</param>
        /// <param name="element">An <see cref="IWebElement"/> instance to evaluate rather to get an element from.</param>
        /// <param name="actionRule">An <see cref="ActionRule"/> by which to evaluate how to get an element.</param>
        /// <returns>The first matching <see cref="IWebElement"/> on the current context.</returns>
        public static IWebElement ConditionalGetElement(this WebDriverActionPlugin plugin, IWebElement element, ActionRule actionRule)
        {
            // exit conditions
            if(element == default && string.IsNullOrEmpty(actionRule.OnElement))
            {
                return default;
            }

            // setup
            var searchTimeout = plugin.Automation.EngineConfiguration.ElementSearchingTimeout;
            var timeout = TimeSpan.FromMilliseconds(searchTimeout);

            // get element
            return element != default
                ? element.GetElement(plugin.ByFactory, actionRule, timeout)
                : plugin.WebDriver.GetElement(plugin.ByFactory, actionRule, timeout);
        }

        /// <summary>
        /// Gets a <see cref="MemberInfo"/> based on a given <see cref="Plugin"/> and when the method [element]
        /// parameter type is the same as T type.
        /// </summary>
        /// <typeparam name="T">The [element] parameter type to find.</typeparam>
        /// <param name="plugin">This <see cref="Plugin"/> under which to find the method.</param>
        /// <param name="attribute">The special attribute method description.</param>
        /// <returns><see cref="MemberInfo"/> based on a given <see cref="Plugin"/>.</returns>
        public static MethodInfo GetSpecialAttributeMethod<T>(this Plugin plugin, string attribute)
        {
            // get methods
            var methods = plugin.GetType().GetMethodsByDescription(regex: attribute);

            // exit conditions
            if (!methods.Any())
            {
                return default;
            }

            // find method by element type
            return methods
                .FirstOrDefault(i => i.GetParameters().First(p => p.Name == "element").ParameterType == typeof(T));
        }
    }
}