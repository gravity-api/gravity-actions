#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0198
* [test-scenario] - Repeat Inside Repeat, Send Keys, Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/}
* 2. repeat {2}
*        3. > send keys {a} into {//input[@id='SearchString']}
*        4. > repeat {6}
*                 5. > send keys {b} into {//input[@id='SearchString']}
* 4. close browser
* 
* [test-expected-results]
* [2] verify {url} filter {\d+/?$} greater than {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.RepeatScenarios
{
    public class C0198 : TestCase
    {
        // set application under test
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // action to repeat
            var actions = new[]
            {
                new ActionRule
                {
                    Action = PluginsList.SendKeys,
                    Argument = "a",
                    OnElement = "//input[@id='SearchString']"
                },
                new ActionRule
                {
                    Action = PluginsList.Repeat,
                    Argument = "3",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            Action = PluginsList.SendKeys,
                            Argument = "b",
                            OnElement = "//input[@id='SearchString']"
                        }
                    }
                }
            };

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Repeat,
                    Argument = "2",
                    Actions = actions
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --attribute --eq:abbbabbb}}",
                    OnElement = "//input[@id='SearchString']",
                    OnAttribute = "value"
                }
            };
        }
    }
}