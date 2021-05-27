#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0017
* [test-scenario] - Assert, Count, Lower or Equal, XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {count} on {//tbody/tr} lower or equal {10}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0017 : TestCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "1" : "10";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --count --le:" + expected + "}}",
                    OnElement = "//tbody/tr"
                }
            };
        }
    }
}
