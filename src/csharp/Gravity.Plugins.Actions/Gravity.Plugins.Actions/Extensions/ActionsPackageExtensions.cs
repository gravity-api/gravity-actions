/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * ONLINE RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;

namespace Gravity.Extensions
{
    public static class ActionsPackageExtensions
    {
        /// <summary>
        /// Gets an assertion if the action described under this element and/or action rule is
        /// a flat action (non element action)
        /// </summary>
        /// <param name="actionRule"><see cref="ActionRule"/> to assert.</param>
        /// <returns>True if this is a flat action (no element); False if not.</returns>
        public static bool IsFlatAction(this ActionRule actionRule)
        {
            return DoIsFlatAction(actionRule, element: default);
        }

        /// <summary>
        /// Gets an assertion if the action described under this element and/or action rule is
        /// a flat action (non element action)
        /// </summary>
        /// <param name="actionRule"><see cref="ActionRule"/> to assert.</param>
        /// <param name="element"><see cref="IWebElement"/> to assert.</param>
        /// <returns>True if this is a flat action (no element); False if not.</returns>
        public static bool IsFlatAction(this ActionRule actionRule, IWebElement element)
        {
            return DoIsFlatAction(actionRule, element);
        }

        // assert if action is flat
        private static bool DoIsFlatAction(ActionRule actionRule, IWebElement element)
        {
            // setup conditions
            var isElement = element != default;
            var isFromAction = !string.IsNullOrEmpty(actionRule.OnElement);

            // return assertion
            return !(isElement || isFromAction);
        }

        /// <summary>
        /// Conditionally get an <see cref="IWebElement"/> based on values from <see cref="ActionRule"/> and <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="element">An <see cref="IWebElement"/> instance to evaluate rather to get an element from.</param>
        /// <param name="actionRule">An <see cref="ActionRule"/> by which to evaluate how to get an element.</param>
        /// <returns>The first matching <see cref="IWebElement"/> on the current context.</returns>
        public static IWebElement ConditionalGetElement(this WebDriverActionPlugin plugin, ActionRule actionRule, IWebElement element)
        {
            // exit conditions
            if (element == default && string.IsNullOrEmpty(actionRule.OnElement))
            {
                return default;
            }

            // setup
            var searchTimeout = plugin.Automation.EngineConfiguration.SearchTimeout;
            var timeout = TimeSpan.FromMilliseconds(searchTimeout);

            // get element
            return element != default
                ? element.GetElement(plugin.ByFactory, actionRule, timeout)
                : plugin.WebDriver.GetElement(plugin.ByFactory, actionRule, timeout);
        }
    }
}