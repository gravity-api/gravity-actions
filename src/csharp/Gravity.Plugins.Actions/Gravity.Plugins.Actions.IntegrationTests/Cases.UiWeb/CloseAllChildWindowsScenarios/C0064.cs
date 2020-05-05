#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0064
* [test-scenario] - Close All Child Windows
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. click on {pop_windows} using {id}
* 3. close all child windows
* 4. close browser
* 
* [test-expected-results]
* [2] verify {windows_count} greater than {1}
* [3] verify {windows_count} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiWeb.CloseAllChildWindowsScenarios
{
    public class C0064 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "pop_windows",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --windows_count --gt:1}}"
                },
                new ActionRule
                {
                    Action = PluginsList.CloseAllChildWindows
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --windows_count --eq:1}}"
                },
            };
        }
    }
}
