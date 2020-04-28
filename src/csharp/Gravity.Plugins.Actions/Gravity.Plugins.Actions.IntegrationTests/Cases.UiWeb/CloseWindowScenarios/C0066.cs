#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0066
* [test-scenario] - Close Window
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. click on {pop_window} using {id}
* 3. click on {pop_window} using {id}
* 4. close window {2}
* 5. close browser
* 
* [test-expected-results]
* [3] verify {windows_count} equal {3}
* [4] verify {windows_count} equal {2}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiWeb.CloseWindowScenarios
{
    public class C0066 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Click,
                    OnElement = "pop_window",
                    Locator = LocatorType.Id
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Click,
                    OnElement = "pop_window",
                    Locator = LocatorType.Id
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --windows_count --eq:3}}"
                },
                new ActionRule
                {
                    ActionType = WebPlugins.CloseWindow,
                    Argument = "2"
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --windows_count --eq:2}}"
                },
            };
        }
    }
}
