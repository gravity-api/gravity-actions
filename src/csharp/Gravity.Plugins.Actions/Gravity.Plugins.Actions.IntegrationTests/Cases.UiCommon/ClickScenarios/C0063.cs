#pragma warning disable S125
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
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0063 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Click,
                    Argument = "{{$ --until:no_alert}}",
                    OnElement = "pop_alert",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --attribute --gt:1}}",
                    OnElement = "pop_alert",
                    OnAttribute = "value",
                    Locator = LocatorsList.Id
                }
            };
        }
    }
}