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
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0018 : AssertCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var onElement = isNegative ? "input_enabled" : "input_disabled";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --disabled}}",
                    ElementToActOn = onElement,
                    Locator = LocatorType.Id
                }
            };
        }
    }
}
