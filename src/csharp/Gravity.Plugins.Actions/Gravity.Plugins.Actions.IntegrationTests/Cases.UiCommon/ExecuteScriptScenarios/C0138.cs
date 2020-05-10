#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0138
* [test-scenario] - Execute Script, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. execute script {document.getElementById('input_enabled').setAttribute('value', 'foo bar')}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {input_enabled} from {value} using {id} match {foo bar}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExecuteScriptScenarios
{
    public class C0138 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "no_element" : "input_enabled";

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.ExecuteScript,
                    Argument = "{document.getElementById('" + condition + "').setAttribute('value', 'foo bar')}"
                },
                SharedSteps.AssertInputEnabledValue(expectedPattern: "foo bar")
            };
        }
    }
}