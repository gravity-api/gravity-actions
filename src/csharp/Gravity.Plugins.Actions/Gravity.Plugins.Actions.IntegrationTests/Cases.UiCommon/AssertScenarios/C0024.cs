#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0024
* [test-scenario] - Assert, Exists, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {exists} on {input_enabled} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0024 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onElement = (bool)environment.TestParams["negative"]
                ? "no_element"
                : "input_enabled";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --exists}}",
                    OnElement = onElement,
                    Locator = LocatorsList.Id
                }
            };
        }
    }
}
