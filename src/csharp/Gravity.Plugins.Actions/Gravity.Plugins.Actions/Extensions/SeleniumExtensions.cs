/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * 
 * work items
 * TODO: merge GetElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule, TimeSpan timeout)
 *         and FindElementByActionRule(this IWebElement e, ByFactory byFactory, ActionRule actionRule)
 */
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Gravity.Plugins.Utilities.Selenium;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Contracts;
using System.Reflection;
using OpenQA.Selenium.Remote;
using System.Net.Http;
using System.Text;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class SeleniumExtensions
    {
        private static readonly HttpClient client = new HttpClient();

        #region *** Element: Exists ***
        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="action">Action rule by which to perform search and build conditions.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition (element exists).</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        /// <remarks>This method waits until the elements exists in the DOM.</remarks>
        public static IWebElement GetElement(this IWebDriver d, ActionRule action, TimeSpan timeout)
        {
            return DoGetFromDriver(
                d,
                byFactory: new ByFactory(Misc.Types),
                action,
                timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="action">Action rule by which to perform search and build conditions.</param>
        /// <param name="timeout">The timeout value indicating how long to wait for the condition (element exists).</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        /// <remarks>This method waits until the elements exists in the DOM.</remarks>
        public static IWebElement GetElement(this IWebDriver d, ByFactory byFactory, ActionRule action, TimeSpan timeout)
        {
            return DoGetFromDriver(d, byFactory, action, timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="action">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement GetElement(this IWebElement e, ActionRule action, TimeSpan timeout)
        {
            return DoGetFromElement(
                e,
                byFactory: new ByFactory(Misc.Types),
                action,
                timeout);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="action">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement GetElement(this IWebElement e, ByFactory byFactory, ActionRule action, TimeSpan timeout)
        {
            return DoGetFromElement(e, byFactory, action, timeout);
        }

        private static IWebElement DoGetFromDriver(IWebDriver d, ByFactory byFactory, ActionRule action, TimeSpan timeout)
        {
            // get locator
            var by = byFactory.Get(action.Locator, action.OnElement);

            // get elements
            return d.GetElement(by, timeout);
        }

        private static IWebElement DoGetFromElement(IWebElement e, ByFactory byFactory, ActionRule action, TimeSpan timeout)
        {
            // on-element conditions
            var isOnElement = e != default && string.IsNullOrEmpty(action.OnElement);
            if (isOnElement)
            {
                return e;
            }

            // get locator
            var by = byFactory.Get(action.Locator, action.OnElement);

            // setup conditions
            var isAbsolutePath = action.Locator == LocatorsList.Xpath && action.OnElement.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.GetElement(by, timeout);
            }

            // on element level
            return e?.FindElement(by);
        }
        #endregion

        #region *** Element: Find   ***
        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElement(this IWebDriver d, ActionRule actionRule)
        {
            return DoFindFromDriver(
                d,
                byFactory: new ByFactory(Misc.Types),
                actionRule);
        }

        /// <summary>
        /// Finds the first <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement FindElement(this IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            return DoFindFromDriver(d, byFactory, actionRule);
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
                byFactory: new ByFactory(Misc.Types),
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
            return DoFindFromElement(e, byFactory, actionRule);
        }

        private static IWebElement DoFindFromDriver(IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.OnElement);

            // get elements
            return d.FindElement(by);
        }

        private static IWebElement DoFindFromElement(IWebElement e, ByFactory byFactory, ActionRule actionRule)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.OnElement);

            // setup conditions
            var isAbsolutePath = actionRule.Locator == LocatorsList.Xpath && actionRule.OnElement.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.FindElement(by);
            }

            // on element level
            return e?.FindElement(by);
        }
        #endregion

        #region *** Elements: Find  ***
        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver d, ActionRule actionRule)
        {
            return DoFindsFromDriver(
                d,
                byFactory: new ByFactory(Misc.Types),
                actionRule);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="d">This <see cref="IWebDriver"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            return DoFindsFromDriver(d, byFactory, actionRule);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebElement e, ActionRule actionRule)
        {
            return DoFindsFromElement(
                e,
                byFactory: new ByFactory(Misc.Types),
                actionRule);
        }

        /// <summary>
        /// Finds all <see cref="IWebElement"/> within the current context using the given mechanism.
        /// </summary>
        /// <param name="e">This <see cref="IWebElement"/> under which to find the elements.</param>
        /// <param name="byFactory"><see cref="ByFactory"/> instance by which to create locator from <see cref="ActionRule"/></param>
        /// <param name="actionRule">Action rule by which to perform search and build conditions.</param>
        /// <returns>A collection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebElement e, ByFactory byFactory, ActionRule actionRule)
        {
            return DoFindsFromElement(e, byFactory, actionRule);
        }

        private static ReadOnlyCollection<IWebElement> DoFindsFromDriver(IWebDriver d, ByFactory byFactory, ActionRule actionRule)
        {
            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.OnElement);

            // get elements
            return d.FindElements(by);
        }

        private static ReadOnlyCollection<IWebElement> DoFindsFromElement(IWebElement e, ByFactory byFactory, ActionRule actionRule)
        {
            // on-element conditions
            var isOnElement = e != default && !string.IsNullOrEmpty(actionRule.OnElement);
            if (isOnElement)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement> { e });
            }

            // get locator
            var by = byFactory.Get(actionRule.Locator, actionRule.OnElement);

            // setup conditions
            var isAbsolutePath = actionRule.Locator == LocatorsList.Xpath && actionRule.OnElement.StartsWith("/");

            // find on page level
            if (isAbsolutePath)
            {
                return ((IWrapsDriver)e).WrappedDriver.FindElements(by);
            }

            // on element level
            return e?.FindElements(by);
        }
        #endregion

        #region *** Driver: Switch  ***
        /// <summary>
        /// Switches the focus of future commands for this driver to the window with the given name.
        /// </summary>
        /// <param name="driver">This <see cref="IWebDriver"/> instance.</param>
        /// <param name="windowName">The handle of the window to select.</param>
        /// <returns>Self <see cref="IWebDriver"/> reference.</returns>
        public static IWebDriver SwitchTo(this IWebDriver driver, string windowName)
        {
            // setup
            var endpoint = GetEndpoint(driver);
            var session = DoGetSession(driver);

            // commands
            var command = $"{endpoint}session/{session}/window";

            // switch window parameters
            var body = @"{""handle"":""" + windowName + @"""}";
            var content = new StringContent(body, Encoding.UTF8, mediaType: "application/json");

            // executes
            client.PostAsync(command, content).GetAwaiter().GetResult();

            // results
            return driver;
        }

        private static SessionId DoGetSession(IWebDriver driver)
        {
            if (driver is IHasSessionId id)
            {
                return id.SessionId;
            }
            return new SessionId($"gravity-{Guid.NewGuid()}");
        }

        private static string GetEndpoint(IWebDriver driver)
        {
            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

            // get RemoteWebDriver type
            var remoteWebDriver = GetRemoteWebDriver(driver.GetType());

            // get this instance executor > get this instance internalExecutor
            var executor = remoteWebDriver.GetField("executor", Flags).GetValue(driver) as ICommandExecutor;

            // get URL
            var uri = driver.IsAppiumDriver()
                ? executor.GetType().GetField("URL", Flags).GetValue(executor) as Uri
                : executor.GetType().GetField("remoteServerUri", Flags).GetValue(executor) as Uri;

            // result
            return uri.AbsoluteUri;
        }

        private static Type GetRemoteWebDriver(Type type)
        {
            if (!typeof(RemoteWebDriver).IsAssignableFrom(type))
            {
                return type;
            }

            while (type != typeof(RemoteWebDriver))
            {
                type = type.BaseType;
            }

            return type;
        }
        #endregion

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

        /// <summary>
        /// Scrolls the specified element into the visible area of the browser window.
        /// </summary>
        /// <param name="onElement"><see cref="IWebElement"/> to scroll into view.</param>
        /// <returns>An <see cref="IWebElement"/> interface through which the user controls elements on the page.</returns>
        public static IWebElement TryScrollIntoView(this IWebElement onElement)
        {
            // exit conditions
            if(!(onElement is IWrapsDriver))
            {
                return onElement;
            }

            // extract driver
            var driver = ((IWrapsDriver)onElement).WrappedDriver;

            // check for irrelevant drivers
            if (driver.IsAppiumDriver())
            {
                return onElement;
            }

            // try scroll into view
            try
            {
                ((IJavaScriptExecutor)driver)
                    .ExecuteScript("arguments[0].scrollIntoView(false);", onElement);
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }
            return onElement;
        }
    }
}