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
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0020 : TestCase
    {
        public override string ApplicationUnderTest => HomePage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onDriver = (bool)environment.TestParams["negative"]
                ? "OpenQA.Selenium.Remote.RemoteWebDriver"
                : "not_a_driver";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --driver --ne:" + onDriver + "}}"
                }
            };
        }
    }
}
