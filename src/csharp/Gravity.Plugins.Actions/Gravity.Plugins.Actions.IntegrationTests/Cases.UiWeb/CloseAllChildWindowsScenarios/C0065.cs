﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0065
* [test-scenario] - Close All Child Windows, No Child Windows
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. close all child windows
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

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiWeb.CloseAllChildWindowsScenarios
{
    public class C0065 : TestCase
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
                    ActionType = WebPlugins.CloseAllChildWindows
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