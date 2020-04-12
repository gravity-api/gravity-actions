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
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ClickScenarios
{
    public class C0062 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule { ActionType = CommonPlugins.Click },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --text --eq:UI Controls}}",
                    ElementToActOn = "//h2[1]"
                }
            };
        }
    }
}