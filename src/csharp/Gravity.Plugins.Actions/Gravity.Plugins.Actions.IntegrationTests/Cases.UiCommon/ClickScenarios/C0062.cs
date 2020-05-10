#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0062
* [test-scenario] - Click at the Last Known Mouse Coordinates
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. click
* 3. close browser
* 
* [test-expected-results]
* [2] verify {text} on {//h2[1]} equal {UI Controls}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0062 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule { Action = PluginsList.Click },
                SharedSteps.AssertUrl("(?i)uicontrols")
            };
        }
    }
}