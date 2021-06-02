/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using System.Linq;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.WaitForElement.json",
        Name = GravityPlugins.WaitForElement)]
    public class WaitForElement : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Element condition to meet. Available values [\"exists\", \"visible\", \"stale\", \"enabled\", \"attribute\", \"text\", \"hidden\"].
        /// </summary>
        public const string Until = "until";

        /// <summary>
        /// Timeout to wait before throwing [TimeoutException], value can be TimeSpan [hh:mm:ss] or in millisecond [3000].
        /// If not provided, default will be [PageLoadTimeout].
        /// </summary>
        public const string Timeout = "timeout";

        /// <summary>
        /// Default wait method, if no other method was selected.
        /// </summary>
        public const string DefaultWaitMethod = "exists";
        #endregion

        // members: state
        private TimeSpan timeout;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public WaitForElement(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout);
        }
        #endregion

        /// <summary>
        /// Wait until the provided element conditions are met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action, element: default);
        }

        /// <summary>
        /// Wait until the provided element conditions are met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action, element);
        }

        // executes Wait routine
        private void InvokeAction(ActionRule action, IWebElement element)
        {
            // setup
            var cli = GetCli(action);
            var factory = new ConditionsFactory(driver: WebDriver, types: Types);
            var wait = new WebDriverWait(WebDriver, timeout);

            // wait
            var isWait = wait.Until(_
                => (bool)factory.Factor(cli, new object[] { action, element })["evaluation"]);

            // results
            if (isWait)
            {
                return;
            }
            throw new WebDriverTimeoutException();
        }

        private string GetCli(ActionRule action)
        {
            var arguments = CliFactory.Parse(action.Argument);

            // default until
            if (!arguments.ContainsKey(Until))
            {
                arguments[Until] = DefaultWaitMethod;
            }

            // default timeout
            if (arguments.ContainsKey(Timeout))
            {
                timeout = arguments[Timeout].ToTimeSpan();
            }

            // compose
            var inner = string.Join(" ", arguments.Select(i => $"--{i.Key}:{i.Value}"));
            return "{{$ " + inner + "}}";
        }
    }
}