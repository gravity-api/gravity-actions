/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-24
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override action-name using action constant
 *    
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.NavigateBack.json",
        Name = GravityPlugins.NavigateBack)]
    public class NavigateBack : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public NavigateBack(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Move back a single entry in the browser\"s history.
        /// The action will be completed when page readyState=\"complete\" or until page loading timeout reached.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action);
        }

        /// <summary>
        /// Move back a single entry in the browser\"s history.
        /// The action will be completed when page readyState=\"complete\" or until page loading timeout reached.
        /// </summary>
        /// <param name="element">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action);
        }

        // execute action routine
        private void InvokeAction(ActionRule action)
        {
            // setup
            var iterations = 1;
            var factory = new PageStateFactory(WebDriver, Types);
            var timout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.LoadTimeout);
            var wait = new WebDriverWait(WebDriver, timout);
            wait.IgnoreExceptionTypes(new[]
            {
                typeof(WebDriverException)
            });

            // normalize iterations
            iterations = int.TryParse(action.Argument, out int iterationsOut) ? iterationsOut : iterations;

            // navigate
            for (int i = 0; i < iterations; i++)
            {
                WebDriver.Navigate().Back();
                if (i >= iterations - 1)
                {
                    break;
                }
                // wait
                wait.Until(driver
                    => factory.Factor(string.Empty, new object[] { driver }));
            }
        }
    }
}