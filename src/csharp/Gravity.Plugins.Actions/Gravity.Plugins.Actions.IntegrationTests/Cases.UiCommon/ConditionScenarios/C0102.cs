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
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0102 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var condition = (bool)environment.TestParams["negative"] ? "1" : "10";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Condition,
                    Argument = "{{$ --text --le:" + condition + "}}",
                    OnElement = "number for testing",
                    Locator = Locators.Name,
                    Actions = SharedSteps.SetNumberOfAlerts(numberOfAlerts: 20)
                },
                SharedSteps.AssertNumberOfAlerts(greaterThan: 10)
            };
        }
    }
}