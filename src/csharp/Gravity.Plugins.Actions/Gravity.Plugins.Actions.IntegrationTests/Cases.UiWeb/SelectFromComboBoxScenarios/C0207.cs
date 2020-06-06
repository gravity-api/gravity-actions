#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0207
* [test-scenario] - Select From Combo Box, Text, Single
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. Select From Combo Box {Two}
* 3. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {select_menu} from {value} using {id} match {Open this select menu}
* [2] verify {attribute} on {select_menu} from {value} using {id} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0207 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                SharedSteps.AssertComboBox(expectedPattern: "Open this select menu"),
                new ActionRule
                {
                    Action = PluginsList.SelectFromComboBox,
                    OnElement = "select_menu",
                    Argument = "Two",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertComboBox(expectedPattern: "2")
            };
        }
    }
}
