#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0143
* [test-scenario] - Assert, Not Selected, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {not_selected} on {input_not_selected} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0143 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onElement = (bool)environment.TestParams["negative"]
                ? "input_selected"
                : "input_not_selected";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --not_selected}}",
                    OnElement = onElement,
                    Locator = Locators.Id
                }
            };
        }
    }
}