#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0104
* [test-scenario] - Condition, Title, Not Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --title --ne:Contoso University - Students}}
*     3. type {Carson} into {SearchString} using {id}
*     4. click on {SearchButton} using {id}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {count} on {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0104 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"]
                ? "Students - Contoso University"
                : "Contoso University - Students";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --title --ne:" + condition + "}}",
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}
