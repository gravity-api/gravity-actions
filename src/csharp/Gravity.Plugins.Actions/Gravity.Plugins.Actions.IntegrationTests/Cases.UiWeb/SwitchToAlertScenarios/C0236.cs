/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0236
 * [test-scenario] - Switch to Alert, Prompt, Send Keys, Accept
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
 * 2. click on {create_prompt} using {id}
 * 3. switch to alert {{$ --keys:Foo Bar --accept}}
 * 4. close browser
 * 
 * [test-expected-results]
 * [1] vertiy that {text} of {prompt_text} using {id} match {^0$}
 * [2] verify that {alert_exists}
 * [3] vertiy that {text} of {prompt_text} using {id} match {^Foo Bar$}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SwitchToAlertScenarios
{
    public class C0236 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertInputTextValue(expectedPattern: "^0$", id: "prompt_text"),
                new ActionRule
                {
                    Action = GravityPlugins.Click,
                    OnElement = "create_prompt",
                    Locator = Locators.Id
                },
                SharedSteps.AssertAlert(exists: true),
                new ActionRule
                {
                    Action = GravityPlugins.SwitchToAlert,
                    Argument = "{{$ --keys:Foo Bar --accept}}"
                },
                SharedSteps.AssertInputTextValue(expectedPattern: "^Foo Bar$", id: "prompt_text")
            };
        }
    }
}