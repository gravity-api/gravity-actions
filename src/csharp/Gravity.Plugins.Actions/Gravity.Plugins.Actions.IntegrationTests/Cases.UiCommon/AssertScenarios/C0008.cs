#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0008
* [test-scenario] - Assert, Attribute, Greater or Equal, CSS Selector
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/UiControls/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {#attribute_div} from {number} using {css selector} greater or equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0008 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "100" : "10";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = "{{$ --attribute --ge:" + expected + "}}",
                    OnElement = "#attribute_div",
                    OnAttribute = "number",
                    Locator = Locators.CssSelector
                }
            };
        }
    }
}
