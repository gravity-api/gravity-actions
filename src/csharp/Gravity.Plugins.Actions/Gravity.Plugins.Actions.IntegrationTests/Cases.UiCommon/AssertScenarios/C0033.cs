#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0033
* [test-scenario] - Assert, Text, Greater Than, Name
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {text} on {number for testing} using {name} greater than {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0033 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "100" : "1";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = "{{$ --text --gt:" + expected + "}}",
                    OnElement = "number for testing",
                    Locator = Locators.Name
                }
            };
        }
    }
}
