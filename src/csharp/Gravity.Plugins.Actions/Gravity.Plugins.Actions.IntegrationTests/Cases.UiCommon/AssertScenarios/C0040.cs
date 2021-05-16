﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0040
* [test-scenario] - Assert, Title, Not Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {title} not match {UI Controls v10$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0040 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"]
                ? "^UI Controls"
                : "UI Controls v10$";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = "{{$ --title --not_match:" + expected + "}}"
                }
            };
        }
    }
}
