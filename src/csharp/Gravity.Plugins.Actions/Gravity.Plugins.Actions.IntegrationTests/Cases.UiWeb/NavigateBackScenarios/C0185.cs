#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0185
* [test-scenario] - Navigate Back, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 3. navigate back
* 4. close browser
* 
* [test-expected-results]
* [3] verify {url} match {(?i)uicontrols/?$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.NavigateBackScenarios
{
    public class C0185 : TestCase
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
                SharedSteps.AssertUrl(expectedPattern: "(?i)uicontrols/?$"),
            };
        }
    }
}