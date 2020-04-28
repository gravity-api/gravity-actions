#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0136
* [test-scenario] - Elements Listener, Default, XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. elements listener {{$ --interval:500 --timeout:30000}} on {//div[./strong[contains(.,'Random Element.')]]}
* 3. wait {30000}
* 4. close browser
* 
* [test-expected-results]
* [3] verify {attribute} on {dismissed_elements} from {value} using {id} greater than {1}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ElementsListenerScenarios
{
    public class C0136 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"] ? "3" : "30000";

            // setup
            return new[]
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.ElementsListener,
                    Argument = "{{$ --interval:500 --timeout:" + condition + "}}",
                    OnElement = "//div[./strong[contains(.,'Random Element.')]]"
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Click,
                    OnElement = "generate_elements",
                    Locator = LocatorType.Id
                },
                new ActionRule
                {
                    ActionType = "Wait",
                    Argument = $"{condition}"
                },
                SharedSteps.AssertListenerOutcome(greaterThan: 1)
            };
        }
    }
}