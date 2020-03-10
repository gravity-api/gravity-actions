/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Components;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.assert.json",
        Name = CommonPlugins.Assert)]
    public class Assert : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Assert(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
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
            var wait = new WebDriverWait(
                WebDriver, TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout));
            var conditionsFactory = new ConditionsFactory(WebDriver, Types);
            IDictionary<string, object> assertion = new Dictionary<string, object>();

            // execute assertion
            try
            {
                assertion = wait.Until(d
                    => new ConditionsFactory(d, Types).Factor(actionRule.Argument, new object[] { actionRule, element }));
            }
            catch (Exception e) when (e != null)
            {
                assertion["evaluation"] = false;
            }

            // add to extractions
            var orbitSession = new OrbitSession
            {
                MachineIp = Misc.GetLocalEndpoint(),
                MachineName = System.Environment.MachineName,
                SessionsId = WebDriver?.GetSession()?.ToString()
            };

            //Extraction
        }
    }
}
