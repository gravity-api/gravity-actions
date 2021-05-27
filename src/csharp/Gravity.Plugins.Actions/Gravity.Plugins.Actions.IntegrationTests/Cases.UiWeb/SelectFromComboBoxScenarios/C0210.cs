﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0210
* [test-scenario] - Select From Combo Box, Text, Multiple, Single Value
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. scroll {1000}
* 3. Select From Combo Box {Two} on {select_menu_multiple} using {id}
* 4. close browser
* 
* [test-expected-results]
* [2] verify {count} on {#select_menu_multiple > option:checked} using {css selector} equal {1}
* [3] verify {attribute} on {#select_menu_multiple > option:checked:nth-child(2)} from {value} using {css selector} match {2}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios
{
    public class C0210 : TestCase
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
                    Argument = $"{environment.TestParams["argument"]}",
                    Locator = Locators.Id
                },
                SharedSteps.AssertMultipleComboBoxSelectedCount(count: 1),
                SharedSteps.AssertMultipleComboBox(expectedPattern: "2", option: 2)
            };
        }
    }
}