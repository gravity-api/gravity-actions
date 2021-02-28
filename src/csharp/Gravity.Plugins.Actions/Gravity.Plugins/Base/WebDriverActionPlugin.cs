/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-02-03
 *    - modify: refactoring
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Utilities.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gravity.Plugins.Base
{
    public abstract class WebDriverActionPlugin : Plugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new <see cref="WebDriverActionPlugin"/> instance.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        protected WebDriverActionPlugin(WebAutomation automation, IWebDriver driver)
            : base(automation)
        {
            // setup
            WebDriver = driver;
            ByFactory ??= new ByFactory(Types);
            Executor ??= new Engine.AutomationExecutor(automation);

            // default: engine configuration
            automation.EngineConfiguration ??= new EngineConfiguration
            {
                SearchTimeout = 15000,
                LoadTimeout = 60000
            };
            automation.DriverParams = automation.DriverParams == default || automation.DriverParams.Keys.Count == 0
                ? new Dictionary<string, object> { ["driver"] = "MockWebDriver" }
                : automation.DriverParams;
        }
        #endregion

        #region *** properties   ***
        /// <summary>
        /// Gets or sets the <see cref="IWebDriver"/> implementation of this <see cref="WebDriverActionPlugin"/>.
        /// </summary>
        public IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets a Selenium locator factory instance.
        /// </summary>
        public ByFactory ByFactory { get; set; }
        #endregion

        #region *** plugins      ***
        /// <summary>
        /// Override to implement action execution based on <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public virtual void OnPerform(ActionRule action)
        {
            Console.WriteLine(
                $"Invoke-Plugin -Name {GetType().Name} -Action {action.Action} = NotImplemented");
        }

        /// <summary>
        /// Override to implement action execution based on <see cref="ActionRule"/>. and <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public virtual void OnPerform(ActionRule action, IWebElement element)
        {
            Console.WriteLine(
                $"Invoke-Plugin -Name {GetType().Name} -Action {action.Action} -Element = NotImplemented");
        }

        /// <summary>
        /// Performs an action based on <see cref="ActionRule"/> and <see cref="IWebElement"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public void Perform(ActionRule action, IWebElement element)
        {
            // trace log
            Console.WriteLine("Invoke-Plugin -Name {0} = Start", GetType().Name);

            // execute sequence
            if (element == default)
            {
                OnPerform(action);
            }
            else
            {
                OnPerform(action, element);
            }

            // information log
            Console.WriteLine("Invoke-Plugin -Name {0} = Ok", GetType().Name);
        }
        #endregion

        #region *** utilities    ***
        /// <summary>
        /// Gets key from selenium keys map.
        /// </summary>
        /// <param name="key">Key name to find (i.e. enter, backspace, etc.) full list: https://github.com/SeleniumHQ/selenium/blob/master/dotnet/src/webdriver/Keys.cs</param>
        /// <returns>The value found under this key.</returns>
        public static string GetKeyboardKey(string key)
        {
            // constants
            const BindingFlags BINDINGS = BindingFlags.Public | BindingFlags.Static;
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase;

            // get key filed
            var k = Array.Find(typeof(Keys).GetFields(BINDINGS), i => i.Name.Equals(key, COMPARE));
            if (k == null)
            {
                return string.Empty;
            }

            // return value
            return (string)k.GetValue(null);
        }
        #endregion
    }
}
