/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-12-28
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Refresh.json",
        Name = PluginsList.Refresh)]
    public class Refresh : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Refresh(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action);
        }

        // execute action routine
        private void DoAction(ActionRule action)
        {
            // setup
            var iterations = 1;
            var factory = new PageStateFactory();
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
                WebDriver.Navigate().Refresh();
                if (i >= iterations - 1)
                {
                    break;
                }
                // wait
                wait.Until(driver
                    => factory.Factor("complete", new object[] { driver }));
            }
        }
    }
}