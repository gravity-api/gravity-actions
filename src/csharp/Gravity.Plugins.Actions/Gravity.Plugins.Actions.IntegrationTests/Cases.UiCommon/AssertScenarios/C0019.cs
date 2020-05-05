#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0019
* [test-scenario] - Assert, Driver, Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {driver} equal {OpenQA.Selenium.Remote.RemoteWebDriver}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0019 : TestCase
    {
        public override string ApplicationUnderTest => HomePage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var onDriver = (bool)environment.TestParams["negative"]
                ? "not_a_driver"
                : "OpenQA.Selenium.Remote.RemoteWebDriver";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --driver --eq:" + onDriver + "}}"
                }
            };
        }
    }
}
