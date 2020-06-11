#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0215
* [test-scenario] - Select From Combo Box, Index, Multiple, All Values
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {{$ --all}} on {select_menu_multiple} using {id}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {select_menu_multiple} from {value} using {id} match {3}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0216 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Scroll,
                    Argument = "1000"
                },
                new ActionRule
                {
                    Action = PluginsList.SelectFromComboBox,
                    OnElement = "select_menu_multiple",
                    Argument = "{{$ --all}}",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 3)
            };
        }
    }
}
