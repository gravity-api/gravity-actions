﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0132
* [test-scenario] - Right Click
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. right click
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {click_outcome} from {value} using {id} not equal {context on element}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiWeb.ContextClickScenarios
{
    public class C0132 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    ActionType = WebPlugins.ContextClick
                },
                SharedSteps.AssertClickOutcome(expectedPattern: "^$")
            };
        }
    }
}