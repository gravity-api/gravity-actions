﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0140
* [test-scenario] - Execute Script, Arguments
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. execute script {{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, 100]}}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {scroll_y_outcome} using {id} match {^1\d+$}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExecuteScriptScenarios
{
    public class C0140 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? 0 : 100;

            // setup
            return new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.ExecuteScript,
                    Argument = "{{$ --src:window.scrollTo(arguments[0], arguments[1]); --args:[0, "+ $"{condition}" +"]}}"
                },
                SharedSteps.AssertScrollOutcome(offset: "y", greaterThan: condition - 1)
            };
        }
    }
}