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
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Assert.json",
        Name = PluginsList.Assert)]
    public class Assert : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Assert(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Allows a sub set of actions execution, based on a given condition.
        /// The sub set actions will be executed if the condition result is <see cref="true"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // executes Wait routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            var wait = new WebDriverWait(
                WebDriver, TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout));
            IDictionary<string, object> assertion = null;

            // execute assertion
            try
            {
                assertion = wait.Until(d
                    => new ConditionsFactory(d, Types).Factor(actionRule.Argument, new object[] { actionRule, element }));
            }
            catch (Exception e) when (e != null)
            {
                assertion ??= new Dictionary<string, object>();
                assertion["evaluation"] = false;
            }
            assertion["reference"] = actionRule.Reference;

            // add to extractions
            var extraction = new Extraction().GetDefault($"{WebDriver?.GetSession()}");
            extraction.Entities = new[]
            {
                new Entity { Content =  assertion}
            };
            Extractions.Add(extraction);
        }
    }
}