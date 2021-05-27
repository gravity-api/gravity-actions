#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0203
* [test-scenario] - Scroll, Left, Element, JS Argument
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. scroll {{$ --top:1000}} on {e_scroll_x_outcome} using {id}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {scroll_x_outcome} from {value} using {id} equal {0}
* [2] verify {attribute} on {scroll_x_outcome} from {value} using {id} greater than {0}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ScrollScenarios
{
    public class C0203 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertElementScrollOutcome(offset: "x", expectedPattern: "^$" ),
                new ActionRule
                {
                    Action = GravityPlugins.Scroll,
                    Argument = "{{$ --left:1000}}",
                    OnElement = "text_area_enabled",
                    Locator = Locators.Id
                },
                SharedSteps.AssertElementScrollOutcome(offset: "x", greaterThan: 0 ),
            };
        }
    }
}