#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0193
* [test-scenario] - Register Parameter, Element, Attribute
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. register parameter {integration_parameter} on {attribute_div} using {id} from {number}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {parameter} on {integration_parameter} equal {10}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.RegisterParameterScenarios
{
    public class C0193 : TestCase
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
                    Argument = "integration_parameter",
                    OnElement = "attribute_div",
                    OnAttribute = "number",
                    Locator = Locators.Id
                },
                SharedSteps.AssertParameter(equal: "10"),
            };
        }
    }
}
