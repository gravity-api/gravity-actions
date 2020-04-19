#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0084
* [test-scenario] - Condition, Disabled, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --disabled}} on {input_disabled} using {id}
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
    public class C0084 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setups
            var condition = (bool)environment.TestParams["negative"]
                ? "input_enabled"
                : "input_disabled";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --disabled}}",
                    ElementToActOn = condition,
                    Locator = LocatorType.Id,
                    Actions = SharedSteps.SetNumberOfAlerts(numberOfAlerts: 20)
                },
                SharedSteps.AssertNumberOfAlerts(greaterThan: 10)
            };
        }
    }
}