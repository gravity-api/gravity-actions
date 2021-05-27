#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0206
* [test-scenario] - Scroll, Top, Behavior, Page, JS Argument
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. scroll {{$ --top:1000 --behavior:smooth}}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {scroll_y_outcome} from {value} using {id} equal {0}
* [2] verify {attribute} on {scroll_y_outcome} from {value} using {id} greater than {0}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ScrollScenarios
{
    public class C0206 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertScrollOutcome(offset: "y", expectedPattern: "^$" ),
                new ActionRule
                {
                    Action = GravityPlugins.Scroll,
                    Argument = "{{$ --top:1000 --behavior:smooth}}"
                },
                SharedSteps.AssertScrollOutcome(offset: "y", greaterThan: 0 ),
            };
        }
    }
}