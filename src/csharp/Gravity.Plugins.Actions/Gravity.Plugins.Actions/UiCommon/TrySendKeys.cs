/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * 
 * work items:
 * TODO: better SendKeys - do not create SendKeys instance on every iteration
 */
using Gravity.Plugins.Actions.Contracts;
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
        Name = CommonPlugins.TrySendKeys)]
    public class TrySendKeys : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public TrySendKeys(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            var wait = new WebDriverWait(
                WebDriver, TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout));

            // persist send keys
            wait.Until(d => SendKeys(actionRule, element, driver: d));
        }

        // performs a click and return the clicked element
        private bool SendKeys(ActionRule actionRule, IWebElement element, IWebDriver driver)
        {
            try
            {
                // get element to act on
                var onElement = this.ConditionalGetElement(element, actionRule);

                // execute SendKeys action (reuse of existing action)
                var sendKeys = new SendKeys(WebAutomation, driver);
                sendKeys.Perform(actionRule, onElement);
                return true;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }
    }
}