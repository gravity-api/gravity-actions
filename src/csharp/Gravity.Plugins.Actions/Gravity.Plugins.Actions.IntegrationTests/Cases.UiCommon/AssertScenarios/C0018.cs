#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0018
* [test-scenario] - Assert, Disabled, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {disabled} on {input_disabled} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0018 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var onElement = (bool)environment.TestParams["negative"] 
                ? "input_enabled" 
                : "input_disabled";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --disabled}}",
                    OnElement = onElement,
                    Locator = LocatorsList.Id
                }
            };
        }
    }
}
