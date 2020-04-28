#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0128
* [test-scenario] - Condition, Nested Condition, 2 levels, Split Actions, First Layer
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/students}
* 2. condition {{$ --windows_count --eq:1}}
*     3. type {Carson} into {SearchString} using {id}
*     4. condition {{$ --url --match:^(?i)student(/?)}}
*         5. click on {SearchButton} using {id}
* 6. close browser
* 
* [test-expected-results]
* [5] verify {attribute} on {SearchString} using {id} equal {Carson}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0130 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "(?i)student(/?)$" : "^(?i)student(/?)";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --windows_count --eq:1}}",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            ActionType = CommonPlugins.SendKeys,
                            Argument = "Carson",
                            OnElement = "SearchString",
                            Locator = LocatorType.Id
                        },
                        new ActionRule
                        {
                            ActionType = CommonPlugins.Condition,
                            Argument = "{{$ --url --match:" + condition + "}}",
                            Actions = new[]
                            {
                                new ActionRule
                                {
                                    ActionType = CommonPlugins.Click,
                                    OnElement = "SearchButton",
                                    Locator = LocatorType.Id
                                }
                            }
                        }
                    }
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --attribute --eq:Carson}}",
                    OnElement = "SearchString",
                    OnAttribute = "value",
                    Locator = LocatorType.Id
                },
                SharedSteps.AssertStudentsCount(count: 3)
            };
        }
    }
}