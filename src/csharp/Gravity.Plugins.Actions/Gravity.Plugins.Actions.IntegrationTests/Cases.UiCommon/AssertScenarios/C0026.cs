#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0026
* [test-scenario] - Assert, Not Exists, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {not_exists} on {no_element} using {id}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0026 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var onElement = (bool)environment.TestParams["negative"] ? "input_enabled" : "no_element";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --not_exists}}",
                    OnElement = onElement,
                    Locator = LocatorType.Id
                }
            };
        }
    }
}
