#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0222
* [test-scenario] - Send Keys, Clear, Interval, Force Clear
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. move to element on {input_enabled_with_text} using {id}
* 3. send keys {{$ --clear --interval:200 --force_clear}} into {input_enabled_with_text} using {id}
* 4. close browser
* 
* [test-expected-results]
* [3] verify {attribute} on {input_enabled} using {id} from {value} match {^$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.SendKeysScenarios
{
    public class C0222 : TestCase
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
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.SendKeys,
                    Argument = "{{$ --clear --interval:200 --force_clear}}",
                    OnElement = "input_enabled_with_text",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertInputEnabledValue(expectedPattern: "^$", id: "input_enabled_with_text")
            };
        }
    }
}