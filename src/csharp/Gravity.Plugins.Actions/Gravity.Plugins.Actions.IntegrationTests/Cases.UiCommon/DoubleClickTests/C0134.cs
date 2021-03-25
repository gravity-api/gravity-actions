﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0134
* [test-scenario] - Double Click on Element, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. double click on {click_button} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {click_outcome} from {value} using {id} equal {double on element}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.DoubleClickTests
{
    public class C0134 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.DoubleClick,
                    OnElement = "click_button",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertClickOutcome(expectedPattern: "double on element")
            };
        }
    }
}
