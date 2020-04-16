﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0063
* [test-scenario] - Click Element Until No Alert, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. click {{$ --until:no_alert}} on {pop_alert} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {pop_alert} from {value} using {id} greater than {1}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0063 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Click,
                    Argument = "{{$ --until:no_alert}}",
                    ElementToActOn = "pop_alert",
                    Locator = LocatorType.Id
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --attribute --gt:1}}",
                    ElementToActOn = "pop_alert",
                    ElementAttributeToActOn = "value",
                    Locator = LocatorType.Id
                }
            };
        }
    }
}