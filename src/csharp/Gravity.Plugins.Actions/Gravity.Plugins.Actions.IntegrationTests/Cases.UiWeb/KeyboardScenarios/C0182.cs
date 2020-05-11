#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0182
* [test-scenario] - Keyboard, Sequence, Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. keyboard {Control,a} into {text_area_enabled} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify that {attribute} of {text_area_enabled} from {value} match {^$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.KeyboardScenarios
{
    public class C0182 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Keyboard,
                    Argument = "Control,a",
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Keyboard,
                    Argument = "Delete",
                    OnElement = "text_area_enabled",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertTextAreaValue(expectedPattern: "^$")
            };
        }
    }
}