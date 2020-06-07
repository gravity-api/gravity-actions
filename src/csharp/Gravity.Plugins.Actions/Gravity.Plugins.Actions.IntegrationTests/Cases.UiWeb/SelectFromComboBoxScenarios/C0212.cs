#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0212
* [test-scenario] - Select From Combo Box, Index, Multiple, Single Value
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {1} from {index}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {select_menu_multiple} from {value} using {id} match {Open this select menu}
* [2] verify {attribute} on {select_menu_multiple} from {value} using {id} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0212 : TestCase
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
                    OnAttribute = "index",
                    Argument = $"{environment.TestParams["argument"]}",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 1),
                SharedSteps.AssertMultipleComboBox(expectedPattern: "2", option: 2)
            };
        }
    }
}
