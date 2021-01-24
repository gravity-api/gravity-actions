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
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiWeb.CloseWindowScenarios
{
    public class C0066 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "pop_window",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "pop_window",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --windows_count --gt:1}}"
                },
                new ActionRule
                {
                    Action = PluginsList.CloseWindow,
                    Argument = "1"
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --windows_count --gt:0}}"
                },
            };
        }
    }
}
