#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0189
* [test-scenario] - Refresh, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. click on {for_stale_element} using {id}
* 3. refresh
* 4. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {for_stale_element} from {class} using {id} match {alert-danger}
* [3] verify {attribute} on {for_stale_element} from {class} using {id} match {alert-success}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.RefreshScenarios
{
    public class C0189 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "for_stale_element",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertStaleElementClass(expectedPattern: "alert-danger"),
                new ActionRule
                {
                    Action = PluginsList.Refresh
                },
                SharedSteps.AssertStaleElementClass(expectedPattern: "alert-success")
            };
        }
    }
}