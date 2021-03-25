#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0187
* [test-scenario] - Navigate Forward, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 3. navigate back
* 4. navigate forward
* 5. close browser
* 
* [test-expected-results]
* [4] verify {url} match {.net/?$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.NavigateForwardScenarios
{
    public class C0187 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.GoToUrl,
                    Argument = "https://gravitymvctestapplication.azurewebsites.net/"
                },
                new ActionRule
                {
                    Action = PluginsList.NavigateBack
                },
                new ActionRule
                {
                    Action = PluginsList.NavigateForward
                },
                SharedSteps.AssertUrl(expectedPattern: ".net/?$"),
            };
        }
    }
}