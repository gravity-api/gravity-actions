#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0029
* [test-scenario] - Assert, Text, Equal, Name
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {text} on {text for testing} using {name} equal {Foo Bar}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0029 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "Bar Foo" : "Foo Bar";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = "{{$ --text --eq:" + expected + "}}",
                    OnElement = "text for testing",
                    Locator = Locators.Name
                }
            };
        }
    }
}
