/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-31
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using Gravity.Extensions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.TryClick.json",
        Name = GravityPlugins.TryClick)]
    public class TryClick : WebDriverActionPlugin
    {
        // constants
        private const string Script = "arguments[0].click();";

        // members: state
        private readonly WebDriverWait wait;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public TryClick(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            // initialize exceptions ignore list
            var ignoreList = new[]
            {
                typeof(NoSuchElementException),
                typeof(StaleElementReferenceException),
                typeof(WebDriverException),
                typeof(NullReferenceException)
            };

            // setup waiter
            var milliseconds = Automation.EngineConfiguration.SearchTimeout;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));
            wait.IgnoreExceptionTypes(ignoreList);
        }
        #endregion

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action, element: default);
        }

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action, element);
        }

        // execute action routine
        private void InvokeAction(ActionRule action, IWebElement element) => wait.Until(_ =>
        {
            // get element to act on
            var onElement = this.ConditionalGetElement(action, element);

            // execute script
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(Script, onElement);

            // for waiter condition
            return WebDriver;
        });
    }
}