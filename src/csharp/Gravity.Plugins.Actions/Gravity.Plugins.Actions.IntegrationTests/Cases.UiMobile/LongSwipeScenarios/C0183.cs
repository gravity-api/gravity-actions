#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0183
* [test-scenario] - Long Swipe, Element to Coordinates
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. long swipt {{$ --target:#input_range --source:200,200}} using {css selector}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {} greater than {50}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graivty.IntegrationTests.Cases.UiMobile.LongSwipeScenarios
{
    public class C0183 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.LongSwipe,
                    Argument = "{{$ --source:#input_range --target:200,200}}",
                    Locator = LocatorsList.CssSelector
                },
                // TODO: assert keyboard hidden
            };
        }
    }
}
