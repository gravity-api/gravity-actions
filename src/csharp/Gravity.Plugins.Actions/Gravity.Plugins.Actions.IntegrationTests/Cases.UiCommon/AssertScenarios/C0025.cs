﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0025
* [test-scenario] - Assert, Hidden, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {hidden} on {input_hidden} using {id}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0025 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var onElement = (bool)environment.TestParams["negative"] 
                ? "input_enabled" 
                : "input_hidden";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --hidden}}",
                    ElementToActOn = onElement,
                    Locator = LocatorType.Id
                }
            };
        }
    }
}