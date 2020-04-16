﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0067
* [test-scenario] - Close Window, No Child Windows
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close window {2}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {windows_count} equal {1}
* [2] verify {windows_count} equal {1}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiWeb.CloseWindowScenarios
{
    public class C0067 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --windows_count --eq:1}}"
                },
                new ActionRule
                {
                    ActionType = WebPlugins.CloseWindow,
                    Argument = "2"
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --windows_count --eq:1}}"
                },
            };
        }
    }
}