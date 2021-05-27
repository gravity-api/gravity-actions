/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0218
 * [test-scenario] - Send Keys, Default
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. move to element on {input_enabled} using {id}
 * 3. send keys {Lorem ipsum} into {input_enabled} using {id}
 * 4. close browser
 * 
 * [test-expected-results]
 * [3] verify {attribute} on {input_enabled} using {id} from {value} match {(?i)^Lorem ipsum$}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.SendKeysScenarios
{
    public class C0218 : TestCase
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
                    Action = GravityPlugins.MoveToElement,
                    OnElement = "input_enabled",
                    Locator = Locators.Id
                },
                new ActionRule
                {
                    Action = GravityPlugins.SendKeys,
                    Argument = "Lorem ipsum",
                    OnElement = "input_enabled",
                    Locator = Locators.Id
                },
                SharedSteps.AssertInputTextValue(expectedPattern: "(?i)^Lorem ipsum$")
            };
        }
    }
}