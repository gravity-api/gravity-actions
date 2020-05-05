#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0175
* [test-scenario] - Go To URL, Element, Attribute, Blank
* 
* [test-actions]
* 1. go to url {{$ --blank}} take {url_a} using {id} from {href}
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
    public class C0177 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.GoToUrl,
                    Argument = "{{$ --blank}}",
                    OnElement = "url_a",
                    OnAttribute = "href",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertWindowsCount(greaterThan: 1)
            };
        }
    }
}