#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0180
* [test-scenario] - Hide Keyboard, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/}
* 2. click on {SearchString} using {id}
* 3. hide keyboard
* 4. close browser
* 
* [test-expected-results]
* [2] verify {keyboard_visible}
* [3] verify {keyboard_hidden}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiMobile.HideKeyboardScenarios
{
    public class C0180 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Click,
                    OnElement = "SearchString",
                    Locator = LocatorsList.Id
                },
                // TODO: assert keyboard visible
                new ActionRule
                {
                    Action = PluginsList.HideKeyboard
                }
                // TODO: assert keyboard hidden
            };
        }
    }
}