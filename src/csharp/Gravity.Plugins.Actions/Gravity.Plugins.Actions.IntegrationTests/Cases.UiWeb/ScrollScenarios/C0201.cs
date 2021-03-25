#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0201
* [test-scenario] - Scroll, Top, Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. scroll {1000} on {text_area_enabled} using {id}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {e_scroll_y_outcome} from {value} using {id} equal {0}
* [2] verify {attribute} on {e_scroll_y_outcome} from {value} using {id} greater than {0}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ScrollScenarios
{
    public class C0201 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertElementScrollOutcome(offset: "y", expectedPattern: "^$" ),
                new ActionRule
                {
                    Action = PluginsList.Scroll,
                    Argument = "1000",
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertElementScrollOutcome(offset: "y", greaterThan: 0 ),
            };
        }
    }
}