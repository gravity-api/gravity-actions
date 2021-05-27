/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * https://www.w3schools.com/jsref/prop_doc_readystate.asp
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;
using Gravity.Extensions;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.WaitForPage.json",
        Name = GravityPlugins.WaitForPage)]
    public class WaitForPage : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Timeout to wait before throwing [TimeoutException], value can be TimeSpan [hh:mm:ss] or in millisecond [3000].
        /// If not provided, default will be [PageLoadTimeout].
        /// </summary>
        public const string Timeout = "timeout";

        /// <summary>
        /// Page condition to meet. Available values [\"complete\", \"interactive\", \"loaded\", \"loading\", \"uninitialized\"].
        /// </summary>
        public const string Until = "until";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public WaitForPage(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Wait until the provided page state condition is met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Wait until the provided page state condition is met.
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
            // build
            var arguments = CliFactory.Parse(action.Argument);
            var until = arguments.ContainsKey(Until) ? arguments[Until] : PageStates.Complete;
            var timeout = arguments.ContainsKey(Timeout)
                ? arguments[Timeout].ToTimeSpan()
                : TimeSpan.FromSeconds(Automation.EngineConfiguration.LoadTimeout);

            // setup
            var factory = new PageStateFactory(WebDriver, Types);
            var wait = new WebDriverWait(WebDriver, timeout);

            // build
            wait.IgnoreExceptionTypes(new[] { typeof(WebDriverException) });

            // wait
            var conditionCli = "{{$ --until:" + until + "}}";
            wait.Until(driver => factory.Factor(conditionCli, new object[] { driver }));
        }
    }
}