/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0219
 * [test-scenario] - Send Keys, Keys, Clear
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. move to element on {input_enabled_with_text} using {id}
 * 3. try send keys {{$ --keys:Lorem ipsum --clear}} into {input_enabled_with_text} using {id}
 * 4. close browser
 * 
 * [test-expected-results]
 * [3] verify {attribute} on {input_enabled} using {id} from {value} match {^Lorem ipsum$}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.TrySendKeysScenarios
{
    public class C0226 : TestCase
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
                    Action = PluginsList.MoveToElement,
                    OnElement = "input_enabled",
                    Locator = Locators.Id
                },
                new ActionRule
                {
                    Action = PluginsList.TrySendKeys,
                    Argument = "{{$ --keys:Lorem ipsum --clear}}",
                    OnElement = "input_enabled_with_text",
                    Locator = Locators.Id
                },
                SharedSteps.AssertInputEnabledValue(expectedPattern: "(?i)^Lorem ipsum$", id: "input_enabled_with_text")
            };
        }
    }
}