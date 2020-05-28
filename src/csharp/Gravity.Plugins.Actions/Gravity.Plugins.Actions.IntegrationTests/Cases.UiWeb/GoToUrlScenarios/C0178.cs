﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0172
* [test-scenario] - Go To URL, Default, Alias
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
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
    public class C0178 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var action = $"{environment.TestParams["action"]}";

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = action,
                    Argument ="https://gravitymvctestapplication.azurewebsites.net/"
                },
                SharedSteps.AssertUrl(expectedPattern: ".net/$")
            };
        }
    }
}