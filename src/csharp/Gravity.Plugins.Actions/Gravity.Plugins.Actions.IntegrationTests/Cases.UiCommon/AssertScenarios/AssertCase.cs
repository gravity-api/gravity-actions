/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public abstract class AssertCase : TestCase
    {
        /// <summary>
        /// Gets or sets the application under test for this <see cref="TestCase"/>
        /// </summary>
        public virtual string ApplicationUnderTest { get; set; } = UiControlsPage;

        /// <summary>
        /// Automation test to execute against a single applied <see cref="AutomationEnvironment"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public override bool AutomationTest(AutomationEnvironment environment)
        {
            // setup
            var driver = $"{environment.TestParams["driver"]}";
            var capabilities = $"{environment.TestParams["capabilities"]}";
            var isNegative = (bool)environment.TestParams["negative"];

            // web automation
            var actions = GetActions(isNegative);
            var webAutomation = GetWebAutomation(driver, capabilities);
            webAutomation = AddWebActions(
                webAutomation, actions, extractions: default, ApplicationUnderTest);

            // execute
            var response = ExecuteWebAutomation(webAutomation, environment);
            var actual = GetActual<bool>(response, key: "evaluation");

            // assertion
            return isNegative ? !actual : actual;
        }

        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to execute under this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="isNegative"><see cref="true"/> for negative scenario.</param>
        /// <returns>A collection of <see cref="ActionRule"/> to execute</returns>
        public virtual IEnumerable<ActionRule> GetActions(bool isNegative) => Array.Empty<ActionRule>();
    }
}
