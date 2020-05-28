﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0191
* [test-scenario] - Register Parameter, Literal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. register parameter {{$ --key:integration_parameter --value:10}}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {parameter} on {integration_parameter} equal {10}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.RegisterParameterScenarios
{
    public class C0191 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.RegisterParameter,
                    Argument = "{{$ --key:integration_parameter --value:10}}"
                },
                SharedSteps.AssertParameter(equal: "10")
            };
        }
    }
}