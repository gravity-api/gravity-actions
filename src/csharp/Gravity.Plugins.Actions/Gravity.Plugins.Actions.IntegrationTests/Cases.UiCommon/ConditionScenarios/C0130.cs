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
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0130 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "(?i)student(/?)$" : "^(?i)student(/?)";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Condition,
                    Argument = "{{$ --windows_count --eq:1}}",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            Action = PluginsList.SendKeys,
                            Argument = "Carson",
                            OnElement = "SearchString",
                            Locator = LocatorsList.Id
                        },
                        new ActionRule
                        {
                            Action = PluginsList.Condition,
                            Argument = "{{$ --url --match:" + condition + "}}",
                            Actions = new[]
                            {
                                new ActionRule
                                {
                                    Action = PluginsList.Click,
                                    OnElement = "SearchButton",
                                    Locator = LocatorsList.Id
                                }
                            }
                        }
                    }
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --attribute --eq:Carson}}",
                    OnElement = "SearchString",
                    OnAttribute = "value",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertStudentsCount(count: 3)
            };
        }
    }
}