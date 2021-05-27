#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0073
* [test-scenario] - Condition, Attribute, Lower Than, Link Text, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --attribute --lt:1000}} on {Edit} from {href} using {link text} filter {\d+}
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
    public class C0073 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "0" : "1000";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugins.Condition,
                    Argument = "{{$ --attribute --lt:" + condition + "}}",
                    OnElement = "Edit",
                    OnAttribute = "href",
                    RegularExpression = "\\d+",
                    Locator = Locators.LinkText,
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}