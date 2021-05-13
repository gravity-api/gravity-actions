#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0023
* [test-scenario] - Assert, Enabled, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {enabled} on {input_enabled} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0023 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onElement = (bool)environment.TestParams["negative"]
                ? "input_disabled"
                : "input_enabled";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --enabled}}",
                    OnElement = onElement,
                    Locator = Locators.Id
                }
            };
        }
    }
}
