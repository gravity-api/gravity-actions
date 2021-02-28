/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.Plugins.Utilities.Selenium
{
    /// <summary>
    /// Factory for reflecting <see cref="By"/> methods from a given types.
    /// </summary>
    public class ByFactory
    {
        // members: state
        private readonly IEnumerable<Type> types;

        /// <summary>
        /// Creates new <see cref="ByFactory"/> instance
        /// </summary>
        /// <param name="types">types to search for by implementations</param>
        public ByFactory(IEnumerable<Type> types) => this.types = types;

        /// <summary>
        /// gets a valid locator from the assemblies under the deployed location
        /// </summary>
        /// <param name="locator">locator name (i.e. XPath, CssClass, etc.)</param>
        /// <param name="locatorValue">locator value</param>
        /// <returns>a mechanism by which to find elements within a document</returns>
        public By Get(string locator, string locatorValue)
        {
            // constants
            const string Error = "locator method [{0}] cannot be found";
            const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

            // default locator
            if (string.IsNullOrEmpty(locator))
            {
                locator = LocatorsList.Xpath;
            }

            // get relevant by method
            var method = types
                .SelectMany(t => t.GetMethods())
                .FirstOrDefault(m => m.IsStatic && m.ReturnType == typeof(By) && m.Name.Equals(locator, Compare));

            // exit conditions
            if (method == null)
            {
                throw new MissingMethodException(string.Format(Error, locator), nameof(locator));
            }

            // invoke method
            return method.Invoke(null, new object[] { locatorValue }) as By;
        }
    }
}