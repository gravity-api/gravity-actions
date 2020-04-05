#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0020
* [test-scenario] - Assert, Driver, Not Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {driver} not equal {OpenQA.Selenium.Remote.RemoteWebDriver}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0020 : TestCase
    {
        public override bool AutomationTest(AutomationEnvironment environment)
        {
            // setup
            var driver = $"{environment.TestParams["driver"]}";
            var capabilities = $"{environment.TestParams["capabilities"]}";
            var isNegative = (bool)environment.TestParams["negative"];

            // web automation
            var actions = GetActions(isNegative);
            var webAutomation = GetWebAutomation(driver, capabilities);
            webAutomation = AddWebActions(webAutomation, actions, extractions: default);

            // execute
            var response = ExecuteWebAutomation(webAutomation, environment);
            var actual = GetActual<bool>(response, key: "evaluation");

            // assertion
            return isNegative ? !actual : actual;
        }

        // gets the actions collection of this test
        private IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var onDriver = isNegative ? "OpenQA.Selenium.Remote.RemoteWebDriver" : "not_a_driver";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --driver --ne:" + onDriver + "}}"
                }
            };
        }
    }
}
