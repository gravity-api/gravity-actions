/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.wait-for-element.json",
        Name = CommonPlugins.WaitForElement)]
    public class WaitForElement : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Element condition to meet. Available values ['exists', 'visible', 'stale', 'enabled', 'attribute', 'text', 'hidden'].
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
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public WaitForElement(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        {
            timeout = TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout);
        }
        #endregion

        /// <summary>
        /// Wait until the provided element conditions are met.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Wait until the provided element conditions are met.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes Wait routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            var cli = GetCli(actionRule);
            var factory = new WebDriverStateFactory(driver: WebDriver, types: Types);
            var wait = new WebDriverWait(WebDriver, timeout);

            // wait
            var isWait = wait.Until(_
                => (bool)factory.Factor(cli, new object[] { actionRule, element })["evaluation"]);

            // results
            if (isWait)
            {
                return;
            }
            throw new WebDriverTimeoutException();
        }

        private string GetCli(ActionRule actionRule)
        {
            var arguments = CliFactory.Parse(actionRule.Argument);

            // default until
            if (!arguments.ContainsKey(Until))
            {
                arguments[Until] = DefaultWaitMethod;
            }

            // default timeout
            if (arguments.ContainsKey(Timeout))
            {
                timeout = arguments[Timeout].AsTimeSpan();
            }

            // compose
            var inner = string.Join(" ", arguments.Select(i => $"--{i.Key}:{i.Value}"));
            return "{{$ " + inner + "}}";
        }
    }
}