#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0188
* [test-scenario] - Navigate Forward, Multiple Times
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 3. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 4. navigate back {2}
* 5. navigate forward {2}
* 6. close browser
* 
* [test-expected-results]
* [5] verify {url} match {.net/?$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.NavigateForwardScenarios
{
    public class C0188 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.GoToUrl,
                    Argument = "https://gravitymvctestapplication.azurewebsites.net/student"
                },
                new ActionRule
                {
                    Action = GravityPlugins.GoToUrl,
                    Argument = "https://gravitymvctestapplication.azurewebsites.net/"
                },
                new ActionRule
                {
                    Action = GravityPlugins.NavigateBack,
                    Argument = "2"
                },
                new ActionRule
                {
                    Action = GravityPlugins.NavigateForward,
                    Argument = "2"
                },
                SharedSteps.AssertUrl(expectedPattern: ".net/?$"),
            };
        }
    }
}
