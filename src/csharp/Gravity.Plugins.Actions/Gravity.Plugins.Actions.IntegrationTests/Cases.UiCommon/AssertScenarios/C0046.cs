#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0046
* [test-scenario] - Assert, URL, Not Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} not equal {https://gravitymvctestapplication.azurewebsites.net/}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0046 : TestCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"]
                ? "https://gravitymvctestapplication.azurewebsites.net/course/"
                : "https://gravitymvctestapplication.azurewebsites.net/";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Assert,
                    Argument = "{{$ --url --ne:" + expected + "}}"
                }
            };
        }
    }
}
