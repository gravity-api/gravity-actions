#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0048
* [test-scenario] - Assert, URL, Not Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} match {^course/}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0048 : TestCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var expected = (bool)environment.TestParams["negative"]
                ? "course/$"
                : "^course/";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --url --not_match:" + expected + "}}"
                }
            };
        }
    }
}
