﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0001
* [test-scenario] - Click on Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. click on {//a[.='Departments']}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {text} on {//h1[1]} equal {Departments}
*/
#pragma warning restore
using Gravity.Abstraction.Contracts;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0001 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            var actions = new List<ActionRule>();
            var driver = $"{environment.TestParams["driver"]}";

            // setup conditions
            var isMobile = driver == Driver.Android || driver == Driver.iOS;

            // mobile handler
            if (isMobile)
            {
                actions.Add(new ActionRule { ActionType = "Click", OnElement = "//button[@data-toggle]" });
            }

            // common actions
            actions.Add(new ActionRule { ActionType = CommonPlugins.Click, OnElement = "//a[.='Departments']" });
            actions.Add(new ActionRule
            {
                ActionType = CommonPlugins.Assert,
                Argument = "{{$ --text --eq:Departments}}",
                OnElement = "//h1[1]"
            });

            // results
            return actions;
        }
    }
}