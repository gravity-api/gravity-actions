﻿/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0235
 * [test-scenario] - Switch to Alert, Accept
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
 * 2. click on {pop_alert} using {id}
 * 3. switch to alert {accept}
 * 4. close browser
 * 
 * [test-expected-results]
 * [2] verify that {alert_exists}
 * [3] vertiy that {no_alert}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SwitchToAlertScenarios
{
    public class C0235 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.Click,
                    OnElement = "pop_alert",
                    Locator = Locators.Id
                },
                SharedSteps.AssertAlert(exists: true),
                new ActionRule
                {
                    Action = GravityPlugins.SwitchToAlert,
                    Argument = "accept"
                },
                SharedSteps.AssertAlert(exists: false)
            };
        }
    }
}