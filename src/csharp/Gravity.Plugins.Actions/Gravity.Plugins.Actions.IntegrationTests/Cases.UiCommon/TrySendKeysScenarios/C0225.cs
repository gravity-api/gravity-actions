/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0225
 * [test-scenario] - Send Keys, Default
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. move to element on {input_enabled} using {id}
 * 3. try send keys {Lorem ipsum} into {input_enabled} using {id}
 * 4. close browser
 * 
 * [test-expected-results]
 * [3] verify {attribute} on {input_enabled} using {id} from {value} match {(?i)^Lorem ipsum$}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.TrySendKeysScenarios
{
    public class C0225 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            return new[]
            {
                // handles some Safari cases where element which is not in port view
                // cannot be interacted
                new ActionRule
                {
                    Action = GravityPlugin.MoveToElement,
                    OnElement = "input_enabled",
                    Locator = Locators.Id
                },
                new ActionRule
                {
                    Action = GravityPlugin.TrySendKeys,
                    Argument = "Lorem ipsum",
                    OnElement = "input_enabled",
                    Locator = Locators.Id
                },
                SharedSteps.AssertInputEnabledValue(expectedPattern: "(?i)^Lorem ipsum$")
            };
        }
    }
}