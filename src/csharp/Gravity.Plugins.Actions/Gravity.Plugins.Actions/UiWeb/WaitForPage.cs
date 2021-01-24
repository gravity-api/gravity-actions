/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * https://www.w3schools.com/jsref/prop_doc_readystate.asp
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Extensions;
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
        resource: "Gravity.Plugins.Actions.Documentation.wait_for_page.json",
        Name = Contracts.PluginsList.WaitForPage)]
    public class WaitForPage : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Timeout to wait before throwing [TimeoutException], value can be TimeSpan [hh:mm:ss] or in millisecond [3000].
        /// If not provided, default will be [PageLoadTimeout].
        /// </summary>
        public const string Timeout = "timeout";

        /// <summary>
        /// Page condition to meet. Available values ['complete', 'interactive', 'loaded', 'loading', 'uninitialized'].
        /// </summary>
        public const string Until = "until";
        #endregion

        // members: state
        private TimeSpan timeout;
        private string until;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public WaitForPage(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.LoadTimeout);
            until = PageStateFactory.Complete;
        }
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
            // setup
            SetArguments(action.Argument);
            var factory = new PageStateFactory();
            var wait = new WebDriverWait(WebDriver, timeout);
            wait.IgnoreExceptionTypes(new[]
            {
                typeof(WebDriverException)
            });

            // wait
            wait.Until(driver
                => factory.Factor(until, new object[] { driver }));
        }

        private void SetArguments(string cli)
        {
            // setup
            var arguments = CliFactory.Parse(cli);

            // timeout
            if (arguments.ContainsKey(Timeout))
            {
                timeout = arguments[Timeout].AsTimeSpan();
            }

            // until
            if (arguments.ContainsKey(Until))
            {
                until = arguments[Until];
            }
        }
    }
}