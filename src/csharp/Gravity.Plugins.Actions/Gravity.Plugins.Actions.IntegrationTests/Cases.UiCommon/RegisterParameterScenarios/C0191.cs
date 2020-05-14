#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0045
* [test-scenario] - Register Parameter, Literal, Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/}
* 2. register parameter {{$ --key:test_param --value:10}}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {parameter} on {test_param} equal {10}
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
            var @operator = $"{environment.TestParams["operator"]}";

            // setup
            return new[]
            {
                SharedSteps.RegisterParameter(value: "10"),
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --parameter " + @operator +"}}",
                    OnElement = "integration_parameter"
                }
            };
        }
    }
}