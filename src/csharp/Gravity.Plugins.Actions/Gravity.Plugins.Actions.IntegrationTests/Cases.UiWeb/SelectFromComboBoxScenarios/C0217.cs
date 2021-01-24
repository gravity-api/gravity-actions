#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0215
* [test-scenario] - Select From Combo Box, Index, Multiple, All Values, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {{$ --all}} on {select_menu_multiple} using {id} filter {T}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {select_menu_multiple} from {value} using {id} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0217 : TestCase
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
                    Locator = LocatorsList.Id,
                    RegularExpression = "T"
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 2)
            };
        }
    }
}
