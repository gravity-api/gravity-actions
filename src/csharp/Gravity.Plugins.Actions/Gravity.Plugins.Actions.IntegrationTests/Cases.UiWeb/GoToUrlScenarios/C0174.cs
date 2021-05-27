#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0174
* [test-scenario] - Go To URL, Element, Text
* 
* [test-actions]
* 1. go to url take {url_div} using {id}
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
    public class C0174 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.GoToUrl,
                    OnElement = "url_div",
                    Locator = Locators.Id
                },
                SharedSteps.AssertUrl(expectedPattern: ".net/$")
            };
        }
    }
}