﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0076
* [test-scenario] - Condition, Count, Equal, XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --count --eq:3}} on {//tr[./td[@id]]}
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
    public class C0076 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "1" : "3";

            // execute if condition is met
            var conditionActions = new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.SendKeys,
                    Argument = "Carson",
                    ElementToActOn = "SearchString",
                    Locator = LocatorType.Id
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Click,
                    ElementToActOn = "SearchButton",
                    Locator = LocatorType.Id
                }
            };

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Condition,
                    Argument = "{{$ --count --eq:" + condition + "}}",
                    ElementToActOn = "//tr[./td[@id]]",
                    Actions = conditionActions
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --count --eq:1}}",
                    ElementToActOn = "//tr[./td[@id]]"
                }
            };
        }
    }
}