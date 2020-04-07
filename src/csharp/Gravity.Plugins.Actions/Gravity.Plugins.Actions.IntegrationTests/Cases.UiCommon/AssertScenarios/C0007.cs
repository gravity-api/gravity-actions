﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0007
* [test-scenario] - Assert, Attribute, Lower Than, CSS Selector
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/UiControls/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {#attribute_div} from {number} using {css selector} lower than {100}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0007 : AssertCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var expected = isNegative ? "1" : "100";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --attribute --lt:" + expected + "}}",
                    ElementToActOn = "#attribute_div",
                    ElementAttributeToActOn = "number",
                    Locator = LocatorType.CssSelector
                }
            };
        }
    }
}
