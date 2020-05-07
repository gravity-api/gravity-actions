#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0181
* [test-scenario] - Keyboard, Enter, Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. type {Carson} into {SearchString} using {id}
* 3. keyboard {Enter} into {SearchString} using {id}
* 4. close browser
* 
* [test-expected-results]
* [3] verify that {count} of {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.KeyboardScenarios
{
    public class C0181 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.SendKeys,
                    Argument = "Carson",
                    OnElement = "SearchString",
                    Locator = LocatorsList.Id
                },
                new ActionRule
                {
                    Action = PluginsList.Keyboard,
                    Argument = "Enter",
                    OnElement = "SearchString",
                    Locator = LocatorsList.Id
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}