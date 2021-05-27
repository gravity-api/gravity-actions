#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0047
* [test-scenario] - Assert, URL, Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} match {course/$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0047 : TestCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"]
                ? "^course/"
                : "course/$";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --url --match:" + expected + "}}"
                }
            };
        }
    }
}
