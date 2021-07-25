/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0238
 * [test-scenario] - Wait for Element, Exists, Default
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. click on {generate_elements} using {id}
 * 3. wait for element {{$ --until:exists}} on {//div/strong[.='Random Element.']}
 * 4. close browser
 * 
 * [test-expected-results]
 * [3] verify that element {exists} on {//div/strong[.='Random Element.']}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.WaitScenarios
{
    public class C0238 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // build
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.Click,
                    OnElement = "generate_elements",
                    Locator = Locators.Id
                },
                new ActionRule
                {
                    Action = GravityPlugins.WaitForElement,
                    Argument = "{{$ --until:exists}}"
                },
                new ActionRule
                {
                    Action = GravityPlugins.Assert,
                    Argument = "{{$ --exists}}",
                    OnElement = "//div/strong[.='Random Element.']"
                }
            };
        }
    }
}