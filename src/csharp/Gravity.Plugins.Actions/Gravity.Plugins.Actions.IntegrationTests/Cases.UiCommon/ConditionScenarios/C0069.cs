#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0069
* [test-scenario] - Condition, Attribute, Not Equal, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --attribute --ne:btn-default btn}} on {SearchButton} from {class} using {id}
*     3. type {Carson} into {SearchString} using {id}
*     4. click on {SearchButton} using {id}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {count} on {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0069 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "btn btn-default" : "btn-default btn";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Condition,
                    Argument = "{{$ --attribute --ne:" + condition + "}}",
                    OnElement = "SearchButton",
                    OnAttribute = "class",
                    Locator = Locators.Id,
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}