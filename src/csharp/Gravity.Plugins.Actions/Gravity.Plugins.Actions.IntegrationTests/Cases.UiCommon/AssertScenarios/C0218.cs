﻿#pragma warning disable S125
/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0218
 * [test-scenario] - Assert, Text Length, ID
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. close browser
 * 
 * [test-expected-results]
 * [1] verify {text_length} on {input_enabled} using {id} equal {10}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0218 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = $"{environment.TestParams["argument"]}",
                    OnElement = "attribute_div",
                    Locator = Locators.Id
                }
            };
        }
    }
}