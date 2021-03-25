#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0003
* [test-scenario] - Assert, Attribute, Not Equal, CSS Selector
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {p:nth-child(3) > a} from {class} using {css selector} not equal {btn-default btn}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0003 : TestCase
    {
        public override string ApplicationUnderTest => HomePage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "btn btn-default" : "btn-default btn";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --attribute --ne:" + expected + "}}",
                    OnElement = "p:nth-child(3) > a",
                    OnAttribute = "class",
                    Locator = LocatorsList.CssSelector
                }
            };
        }
    }
}