#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0115
* [test-scenario] - Condition, URL, Greater Than, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/edit/1}
* 2. condition {{$ --url --gt:0}} filter {\d+}
*     3. click on {Back to List} using {link text}
* 4. close browser
* 
* [test-expected-results]
* [3] verify {url} equal {https://gravitymvctestapplication.azurewebsites.net/Student}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0115 : TestCase
    {
        public override string ApplicationUnderTest => $"{StudentsPage}edit/1";

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "10" : "0";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Condition,
                    Argument = "{{$ --url --gt:" + condition + "}}",
                    RegularExpression = "\\d+",
                    Actions = SharedSteps.BackToList()
                },
                SharedSteps.AssertUrl(expectedPattern: "Student$")
            };
        }
    }
}