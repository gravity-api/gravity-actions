#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0013
* [test-scenario] - Assert, Count, Not Match, XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {count} on {//tbody/tr} not match {^1\d+$}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0013 : AssertCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var expected = isNegative ? @"^\d{1}$" : @"^1\d+$";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --count --not_match:" + expected + "}}",
                    ElementToActOn = "//tbody/tr"
                }
            };
        }
    }
}