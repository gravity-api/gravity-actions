﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0027
* [test-scenario] - Assert, Selected, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {selected} on {input_selected} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0027 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var onElement = (bool)environment.TestParams["negative"]
                ? "input_not_selected"
                : "input_selected";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --selected}}",
                    OnElement = onElement,
                    Locator = Locators.Id
                }
            };
        }
    }
}
