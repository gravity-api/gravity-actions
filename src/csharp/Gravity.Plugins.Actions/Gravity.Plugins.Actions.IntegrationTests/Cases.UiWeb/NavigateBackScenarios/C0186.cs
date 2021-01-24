#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0186
* [test-scenario] - Navigate Back, Multiple Times
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 3. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 4. navigate back {2}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {url} match {(?i)uicontrols/?$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.NavigateBackScenarios
{
    public class C0186 : TestCase
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
                    Action = PluginsList.GoToUrl,
                    Argument = "https://gravitymvctestapplication.azurewebsites.net/student"
                },
                new ActionRule
                {
                    Action = PluginsList.NavigateBack,
                    Argument = "2"
                },
                SharedSteps.AssertUrl(expectedPattern: "(?i)uicontrols/?$"),
            };
        }
    }
}