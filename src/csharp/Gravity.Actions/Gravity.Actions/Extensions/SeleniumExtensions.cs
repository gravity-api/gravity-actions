/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * 
 * work items
 * TODO: merge GetElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule, TimeSpan timeout)
 *         and FindElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule)
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Services.ActionPlugins.Extensions
{
    public static class SeleniumExtensions
    {
        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition (element exists).</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        /// <remarks>This method waits until the elements exists in the DOM.</remarks>
        public static IWebElement GetElementByActionRule(this IWebDriver d, ActionRule actionRule, TimeSpan timeout)
        {
            return GetElementByActionRule(
                d,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule,
                timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition (element exists).</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        /// <remarks>This method waits until the elements exists in the DOM.</remarks>
        public static IWebElement GetElementByActionRule(this IWebDriver d, ByFactory byFactory, ActionRule actionRule, TimeSpan timeout)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // get elements
            return d.GetElement(by, timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement GetElementByActionRule(this IWebElement e, ActionRule actionRule, TimeSpan timeout)
        {
            return GetElementByActionRule(
                e,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule,
                timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement GetElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule, TimeSpan timeout)
        {
            // on-element conditions
            var isOnElement = e != default && string.IsNullOrEmpty(actionRule.ElementToActOn);
            if (isOnElement)
            {
                return e;
            }

            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // setup conditions
            var isAbsolutePath = actionRule.Locator == LocatorType.Xpath && actionRule.ElementToActOn.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.GetElement(by, timeout);
            }

            // on element level
            return e.FindElement(by);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElementByActionRule(this IWebDriver d, ActionRule actionRule)
        {
            return FindElementByActionRule(
                d,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElementByActionRule(this IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // get elements
            return d.FindElement(by);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElementByActionRule(this IWebElement e, ActionRule actionRule)
        {
            return FindElementByActionRule(
                e,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule)
        {
            // on-element conditions
            var isOnElement = e != default && !string.IsNullOrEmpty(actionRule.ElementToActOn);
            if (isOnElement)
            {
                return e;
            }

            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // setup conditions
            var isAbsolutePath = actionRule.Locator == LocatorType.Xpath && actionRule.ElementToActOn.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.FindElement(by);
            }

            // on element level
            return e.FindElement(by);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByActionRule(this IWebDriver d, ActionRule actionRule)
        {
            return FindElementsByActionRule(
                d,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByActionRule(this IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // get elements
            return d.FindElements(by);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByActionRule(this IWebElement e, ActionRule actionRule)
        {
            return FindElementsByActionRule(
                e,
                byFactory: new ByFactory(Utilities.GetTypes()),
                actionRule);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElementsByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule)
        {
            // on-element conditions
            var isOnElement = e != default && !string.IsNullOrEmpty(actionRule.ElementToActOn);
            if (isOnElement)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement> { e });
            }

            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // setup conditions
            var isAbsolutePath = actionRule.Locator == LocatorType.Xpath && actionRule.ElementToActOn.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.FindElements(by);
            }

            // on element level
            return e.FindElements(by);
        }

        /// <summary>
        /// Returns an indication if this <see cref="IWebDriver" /> implementation is
        /// an <see cref="OpenQA.Selenium.Appium.AppiumDriver{W}"/> implementation
        /// </summary>
        /// <param name="d"></param>
        /// <returns>True if <see cref="OpenQA.Selenium.Appium.AppiumDriver{W}"/> or False if not.</returns>
        public static bool IsAppiumDriver(this IWebDriver d)
        {
            // initialize conditions
            var isName = false;
            var isAppium = false;

            // setup name condition            
            var type = d.GetType();
            while (!isName && type != null && type.Name != "RemoteWebDriver" && type.Name != "Object")
            {
                isName = Regex.IsMatch(type.Name, "AppiumDriver`1");
                if (isName)
                {
                    isAppium = typeof(IWebElement).IsAssignableFrom(type?.GenericTypeArguments?.First());
                }
                type = type.BaseType;
            }

            // assertion
            return isAppium;
        }
    }
}