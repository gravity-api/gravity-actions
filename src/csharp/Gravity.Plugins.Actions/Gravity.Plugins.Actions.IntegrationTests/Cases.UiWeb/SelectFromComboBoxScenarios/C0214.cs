#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0214
* [test-scenario] - Select From Combo Box, Value, Multiple, Multiple Values
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {[\"1\",\"2\"]} on {select_menu_multiple} using {id} from {value}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {select_menu_multiple} from {value} using {id} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0214 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.Scroll,
                    Argument = "1000"
                },
                new ActionRule
                {
                    Action = GravityPlugins.SelectFromComboBox,
                    OnElement = "select_menu_multiple",
                    OnAttribute = "value",
                    Argument = "[\"1\", \"2\"]",
                    Locator = Locators.Id
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 2)
            };
        }
    }
}
