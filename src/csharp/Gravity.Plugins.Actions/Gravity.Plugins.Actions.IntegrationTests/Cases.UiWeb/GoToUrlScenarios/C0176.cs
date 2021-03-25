#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0176
* [test-scenario] - Go To URL, Element, Attribute
* 
* [test-actions]
* 1. go to url take {url_a} using {id} from {href}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} match {.net/$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.GoToUrlScenarios
{
    public class C0176 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.GoToUrl,
                    OnElement = "url_a",
                    OnAttribute = "href",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertUrl(expectedPattern: ".net/$")
            };
        }
    }
}