#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0224
* [test-scenario] - Send Keys, Combination, Control+A
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. move to element on {text_area_enabled} using {id}
* 3. send keys {{$ --down:control --keys:a}} into {text_area_enabled} using {id}
* 4. close browser
* 
* [test-expected-results]
* [3] [1] verify {selected} on {e_text_area_selected} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.SendKeysScenarios
{
    public class C0224 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var downKey = environment.TestParams["downKey"];
            var key = environment.TestParams["key"];

            return new[]
            {
                // handles some Safari cases where element which is not in port view
                // cannot be interacted
                new ActionRule
                {
                    Action = PluginsList.MoveToElement,
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertSelectable(id: "e_text_area_selected", selected: false),
                new ActionRule
                {
                    Action = PluginsList.SendKeys,
                    Argument = "{{$ --down:" + downKey + " --keys:" + key + "}}",
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertSelectable(id: "e_text_area_selected", selected: true)
            };
        }
    }
}
