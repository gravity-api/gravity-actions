#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0053
* [test-scenario] - Assert, Visible, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {visible} on {input_enabled} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0053 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onElement = (bool)environment.TestParams["negative"]
                ? "input_hidden"
                : "input_enabled";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --visible}}",
                    OnElement = onElement,
                    Locator = LocatorsList.Id
                }
            };
        }
    }
}
