#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0137
* [test-scenario] - Elements Listener, Sub Actions, XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. elements listener {{$ --interval:500 --timeout:30000}} on {//div[./strong[contains(.,'Random Element.')]]}
*     3. type {dismissed} into {input_enabled} using {id}
*     4. click on {//div[./strong[contains(.,'Random Element.')]]}
* 5. wait {30000}
* 6. close browser
* 
* [test-expected-results]
* [3] verify {attribute} on {input_enabled} from {value} using {id} match {dismissed}
* [5] verify {attribute} on {dismissed_elements} from {value} using {id} greater than {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ElementsListenerScenarios
{
    public class C0137 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "3" : "30000";

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.ElementsListener,
                    Argument = "{{$ --interval:500 --timeout:" + condition + "}}",
                    OnElement = "//div[./strong[contains(.,'Random Element.')]]",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            Action = PluginsList.SendKeys,
                            Argument = "dismissed",
                            OnElement = "input_enabled",
                            Locator = LocatorsList.Id
                        },
                        new ActionRule
                        {
                            Action = PluginsList.Click,
                            OnElement = "//div[./strong[contains(.,'Random Element.')]]"
                        }
                    }
                },
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "generate_elements",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = "Wait",
                    Argument = $"{condition}"
                },
                SharedSteps.AssertInputEnabledValue(expectedPattern: "dismissed"),
                SharedSteps.AssertListenerOutcome(greaterThan: 1)
            };
        }
    }
}