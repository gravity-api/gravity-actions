#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0183
* [test-scenario] - Move To Element, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. move to element on {over_outcome} using {id}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {over_outcome} using {id} from {value} match {^no mouse over$}
* [2] verify {attribute} on {over_outcome} using {id} from {value} match {^mouse over$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.MoveToElementScenarios
{
    public class C0184 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertOverOutcomeValue(expectedPattern: "^no mouse over$"),
                new ActionRule
                {
                    Action = PluginsList.MoveToElement,
                    OnElement = "over_outcome",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertOverOutcomeValue(expectedPattern: "^mouse over$"),
            };
        }
    }
}