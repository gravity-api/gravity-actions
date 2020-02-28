/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-31
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.try-click.json",
        Name = WebPlugins.TryClick)]
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
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public TryClick(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
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
            var milliseconds = WebAutomation.EngineConfiguration.ElementSearchingTimeout;
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));
            wait.IgnoreExceptionTypes(ignoreList);
        }
        #endregion

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(element: default, actionRule);
        }

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(element, actionRule);
        }

        // executes action routine
        private void DoAction(IWebElement element, ActionRule actionRule)
        {
            wait.Until(_ =>
            {
                // get element to act on
                var onElement = this.ConditionalGetElement(element, actionRule);

                // execute script
                ((IJavaScriptExecutor)WebDriver).ExecuteScript(Script, onElement);

                // for waiter condition
                return WebDriver;
            });
        }
    }
}