﻿/*
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
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.WaitForUrl.json",
        Name = GravityPlugins.WaitForUrl)]
    public class WaitForUrl : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Timeout to wait before throwing [TimeoutException], value can be TimeSpan [hh:mm:ss] or in millisecond [3000].
        /// If not provided, default will be [PageLoadTimeout].
        /// </summary>
        public const string Timeout = "timeout";
        #endregion

        // members: state
        private TimeSpan timeout;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public WaitForUrl(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.LoadTimeout);
        }
        #endregion

        /// <summary>
        /// Wait until the provided URL conditions are met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action);
        }

        /// <summary>
        /// Wait until the provided URL conditions are met.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action);
        }

        // execute action routine
        private void InvokeAction(ActionRule action)
        {
            // setup
            var arguments = CliFactory.Parse(action.Argument);
            if (arguments.ContainsKey(Timeout))
            {
                timeout = arguments[Timeout].ToTimeSpan();
            }
            var wait = new WebDriverWait(WebDriver, timeout);

            // wait
            wait.Until(driver => Regex.IsMatch(driver.Url, action.RegularExpression));
        }
    }
}