#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0059
* [test-scenario] - Assert, Windows Count, Lower Than
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {windows_count} lower than {10}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0059 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "0" : "10";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --windows_count --lt:" + expected + "}}"
                }
            };
        }
    }
}
