#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0002
* [test-scenario] - Assert, Attribute, Equal, CSS Selector
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {ul > li:nth-child(1) > a} from {class} using {css selector} equal {nav-link text-dark}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0002 : TestCase
    {
        public override string ApplicationUnderTest => HomePage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "text-dark nav-link" : "nav-link text-dark";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --attribute --eq:" + expected + "}}",
                    OnElement = "ul > li:nth-child(1) > a",
                    OnAttribute = "class",
                    Locator = LocatorsList.CssSelector
                }
            };
        }
    }
}