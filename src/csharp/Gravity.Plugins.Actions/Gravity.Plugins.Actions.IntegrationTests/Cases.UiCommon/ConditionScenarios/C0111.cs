#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0111
* [test-scenario] - Condition, URL, Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --url --eq:https://gravitymvctestapplication.azurewebsites.net/student/}}
*     3. type {Carson} into {SearchString} using {id}
*     4. click on {SearchButton} using {id}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {count} on {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0111 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"]
                ? "https://gravitymvctestapplication.azurewebsites.net/"
                : "https://gravitymvctestapplication.azurewebsites.net/student/";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Condition,
                    Argument = "{{$ --url --eq:" + condition + "}}",
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}