#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0035
* [test-scenario] - Assert, Text, Greater or Equal, Name
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {text} on {number for testing} using {name} greater or equal {10}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0035 : AssertCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var expected = isNegative ? "100" : "10";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --text --ge:" + expected + "}}",
                    ElementToActOn = "number for testing",
                    Locator = LocatorType.Name
                }
            };
        }
    }
}
