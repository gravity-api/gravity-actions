#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0021
* [test-scenario] - Assert, Driver, Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {driver} match {RemoteWebDriver}
*/
#pragma warning restore
using Graivty.IntegrationTests.Extensions;
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0021 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onDriver = (bool)environment.TestParams["negative"]
                ? "not_a_driver"
                : environment.GetDriverFullName();

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --driver --match:" + onDriver + "}}"
                }
            };
        }
    }
}