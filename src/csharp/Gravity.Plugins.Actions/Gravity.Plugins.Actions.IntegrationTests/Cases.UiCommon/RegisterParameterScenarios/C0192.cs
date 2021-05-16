#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0192
* [test-scenario] - Register Parameter, Element, Text
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. register parameter {integration_parameter} on {text_div_number} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {parameter} on {integration_parameter} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.RegisterParameterScenarios
{
    public class C0192 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugin.RegisterParameter,
                    Argument = "integration_parameter",
                    OnElement = "text_div_number",
                    Locator = Locators.Id
                },
                SharedSteps.AssertParameter(equal: "10"),
            };
        }
    }
}