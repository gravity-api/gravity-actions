#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0139
* [test-scenario] - Execute Script, Element, ID
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. execute script {arguments[0].click();} on {click_button} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {click_outcome} using {id} match {click on element}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExecuteScriptScenarios
{
    public class C0139 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "no_element" : "click_button";

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.ExecuteScript,
                    Argument = "{arguments[0].click();}",
                    OnElement = condition,
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertClickOutcome(expectedPattern: "click on element")
            };
        }
    }
}
