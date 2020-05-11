#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0172
* [test-scenario] - Go To URL, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} match {uicontrols/$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.GoToUrlScenarios
{
    public class C0172 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertUrl(expectedPattern: "uicontrols/$")
            };
        }
    }
}
