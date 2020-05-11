#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0106
* [test-scenario] - Condition, Title, Not Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --title --not_match:^Contoso University - Students$}}
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
    public class C0106 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"]
                ? "^Students - Contoso University$"
                : "^Contoso University - Students$";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Condition,
                    Argument = "{{$ --title --not_match:" + condition + "}}",
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}