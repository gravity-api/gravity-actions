/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0063
 * [test-scenario] - Click Element Until No Alert, ID
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. click {{$ --until:no_alert}} on {pop_alert} using {id}
 * 3. close browser
 * 
 * [test-expected-results]
 * [2] verify {attribute} on {pop_alert} from {value} using {id} greater than {1}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0063 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.Click,
                    Argument = "{{$ --until:no_alert}}",
                    OnElement = "pop_alert",
                    Locator = Locators.Id
                },
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --attribute --gt:1}}",
                    OnElement = "pop_alert",
                    OnAttribute = "value",
                    Locator = Locators.Id
                }
            };
        }
    }
}