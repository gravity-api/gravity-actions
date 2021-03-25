#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0050
* [test-scenario] - Assert, URL, Lower Than, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/edit/1045}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} filter {\d+} lower than {2000}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0050 : TestCase
    {
        public override string ApplicationUnderTest => $"{CoursesPage}/edit/1045";

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "1000" : "2000";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --url --lt:" + expected + "}}",
                    RegularExpression = "\\d+"
                }
            };
        }
    }
}
