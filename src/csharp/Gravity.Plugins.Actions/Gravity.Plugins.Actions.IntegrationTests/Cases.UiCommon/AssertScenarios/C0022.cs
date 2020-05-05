#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0022
* [test-scenario] - Assert, Driver, Not Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {driver} not match {ChromeDriver}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0022 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var onDriver = (bool)environment.TestParams["negative"]
                ? GetDriverFullName($"{environment.TestParams["driver"]}")
                : "not_a_driver";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --driver --not_match:" + onDriver + "}}"
                }
            };
        }
    }
}