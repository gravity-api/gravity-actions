﻿/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0061
 * [test-scenario] - Assert, Windows Count, Lower or Equal
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
 * 2. close browser
 * 
 * [test-expected-results]
 * [1] verify {windows_count} lower or equal {1}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0061 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "0" : "1";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --windows_count --le:" + expected + "}}"
                }
            };
        }
    }
}
