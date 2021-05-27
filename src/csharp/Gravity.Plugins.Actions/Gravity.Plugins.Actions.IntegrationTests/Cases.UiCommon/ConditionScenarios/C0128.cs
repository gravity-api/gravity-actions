#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0128
* [test-scenario] - Condition, Nested Condition, 2 levels
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/students}
* 2. condition {{$ --windows_count --eq:1}}
*     3. condition {{$ --url --match:students$}}
*         4. type {Carson} into {SearchString} using {id}
*         5. click on {SearchButton} using {id}
* 6. close browser
* 
* [test-expected-results]
* [5] verify {count} on {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0128 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "^(?i)student(/?)" : "(?i)student(/?)$";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Condition,
                    Argument = "{{$ --windows_count --eq:1}}",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            Action = GravityPlugins.Condition,
                            Argument = "{{$ --url --match:" + condition + "}}",
                            Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                        }
                    }
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}