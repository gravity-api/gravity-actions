#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0074
* [test-scenario] - Condition, Attribute, Greater or Equal, Link Text, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --attribute --ge:0}} on {Edit} from {href} using {link text} filter {\d+}
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
    public class C0074 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "1000" : "0";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --attribute --ge:" + condition + "}}",
                    ElementToActOn = "Edit",
                    ElementAttributeToActOn = "href",
                    RegularExpression = "\\d+",
                    Locator = LocatorType.LinkText,
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}