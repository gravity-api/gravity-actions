﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0135
* [test-scenario] - Double Click
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. right click
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {click_outcome} from {value} using {id} not equal {double on element}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.DoubleClickTests
{
    public class C0135 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.DoubleClick
                },
                SharedSteps.AssertClickOutcome(expectedPattern: "^$")
            };
        }
    }
}
