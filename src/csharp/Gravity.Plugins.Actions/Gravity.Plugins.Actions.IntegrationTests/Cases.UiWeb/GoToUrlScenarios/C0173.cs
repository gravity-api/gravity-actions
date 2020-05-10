#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0172
* [test-scenario] - Go To URL, Blank
* 
* [test-actions]
* 1. navigate to {{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {windows_count} greater than {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.GoToUrlScenarios
{
    public class C0173 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.GoToUrl,
                    Argument ="{{$ --url:https://gravitymvctestapplication.azurewebsites.net/uicontrols/ --blank}}"
                },
                SharedSteps.AssertWindowsCount(greaterThan: 1)
            };
        }
    }
}