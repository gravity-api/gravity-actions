/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using System;

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
            if(element == default && string.IsNullOrEmpty(actionRule.ElementToActOn))
            {
                return default;
            }

            // setup
            var searchTimeout = plugin.WebAutomation.EngineConfiguration.ElementSearchingTimeout;
            var timeout = TimeSpan.FromMilliseconds(searchTimeout);

            // get element
            return element != default
                ? element.GetElementByActionRule(plugin.ByFactory, actionRule, timeout)
                : plugin.WebDriver.GetElementByActionRule(plugin.ByFactory, actionRule, timeout);
        }
    }
}