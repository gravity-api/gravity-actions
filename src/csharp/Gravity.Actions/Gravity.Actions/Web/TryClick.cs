/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 *    
 * 2019-12-31
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 */
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Web
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.try-click.json",
        Name = ActionType.TryClick)]
    public class TryClick : ActionPlugin
    {
        // constants
        private const string Script = "arguments[0].click();";

        // members: state
        private readonly WebDriverWait wait;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public TryClick(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public TryClick(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
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
            wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(ElementSearchTimeout));
            wait.IgnoreExceptionTypes(ignoreList);
        }

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            wait.Until(_ => DoTryClick(webElement: default, actionRule));
        }

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            wait.Until(_ => DoTryClick(webElement: webElement, actionRule));
        }

        // executes TryClick routine
        private IWebDriver DoTryClick(IWebElement webElement, ActionRule actionRule)
        {
            // fetch locator
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // get element to act on
            var argument = webElement == default
                ? WebDriver.FindElement(by)
                : webElement.FindElement(by);

            // execute script
            ((IJavaScriptExecutor)WebDriver).ExecuteScript(Script, argument);

            // for waiter condition
            return WebDriver;
        }
    }
}