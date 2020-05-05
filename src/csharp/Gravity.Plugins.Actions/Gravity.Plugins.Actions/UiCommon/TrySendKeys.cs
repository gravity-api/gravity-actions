/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.try_send_keys.json",
        Name = Contracts.PluginsList.TrySendKeys)]
    public class TrySendKeys : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public TrySendKeys(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // setup
            var wait = new WebDriverWait(
                WebDriver, TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout));

            // persist send keys
            var sendKeys = new SendKeys(automation: Automation, driver: WebDriver);
            wait.Until(_ => SendKeys(plugin: sendKeys, action, element));
        }

        // performs a click and return the clicked element
        private bool SendKeys(SendKeys plugin, ActionRule action, IWebElement element)
        {
            try
            {
                // get element to act on
                var onElement = this.ConditionalGetElement(element, action);

                // execute SendKeys action (reuse of existing action)
                plugin.Perform(action, onElement);
                return true;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }
    }
}