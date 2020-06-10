#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0210
* [test-scenario] - Select From Combo Box, Value, Multiple, Single Value
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {2} on {select_menu_multiple} using {id} from {value}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {count} on {#select_menu_multiple > option:checked} using {css selector} equal {1}
* [2] verify {attribute} on {#select_menu_multiple > option:checked:nth-child(2)} from {value} using {css selector} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0211 : TestCase
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
                    OnAttribute = "value",
                    Argument = $"{environment.TestParams["argument"]}",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 1),
                SharedSteps.AssertMultipleComboBox(expectedPattern: "2", option: 2)
            };
        }
    }
}