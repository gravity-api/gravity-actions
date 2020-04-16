﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0102
* [test-scenario] - Condition, Text, Lower or Equal, Name
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --text --le:10}} on {number for testing} using {name}
*     3. type {20} into {number_of_alerts} using {id}
* 4. close browser
* 
* [test-expected-results]
* [3] verify {attribute} on {number_of_alerts} from {value} greater than {10}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0102 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "1" : "10";

            // execute if condition is met
            var conditionActions = new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.SendKeys,
                    Argument = "20",
                    ElementToActOn = "number_of_alerts",
                    Locator = LocatorType.Id
                }
            };

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --text --le:" + condition + "}}",
                    ElementToActOn = "number for testing",
                    Locator = LocatorType.Name,
                    Actions = conditionActions
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --attribute --gt:10}}",
                    ElementToActOn = "number_of_alerts",
                    Locator = LocatorType.Id,
                    ElementAttributeToActOn = "value"
                }
            };
        }
    }
}