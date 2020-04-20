﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0118
* [test-scenario] - Condition, URL, Lower or Equal, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/edit/1}
* 2. condition {{$ --url --le:1}} filter {\d+}
*     3. click on {Back to List} using {link text}
* 4. close browser
* 
* [test-expected-results]
* [3] verify {url} equal {https://gravitymvctestapplication.azurewebsites.net/student/}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0118 : TestCase
    {
        public override string ApplicationUnderTest => $"{StudentsPage}/edit/1";

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "0" : "1";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --url --le:" + condition + "}}",
                    RegularExpression = "\\d+",
                    Actions = SharedSteps.BackToList()
                },
                SharedSteps.AssertUrl(expectedPattern: "Student$")
            };
        }
    }
}