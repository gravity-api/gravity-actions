#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0131
* [test-scenario] - Right Click on Element, Alias, RightClick, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. right click on {click_button} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {click_outcome} from {value} using {id} equal {context on element}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiWeb.ContextClickScenarios
{
    public class C0133 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = "RightClick",
                    OnElement = "click_button",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertClickOutcome(expectedPattern: "context on element")
            };
        }
    }
}