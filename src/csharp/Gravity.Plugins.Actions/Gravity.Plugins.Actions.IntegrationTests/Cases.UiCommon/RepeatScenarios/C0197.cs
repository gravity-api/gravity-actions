#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0197
* [test-scenario] - Repeat, Iterations, Click
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student/}
* 2. repeat {2}
*        3. > click on {//a[contains(.,\"Next\") and @class=\"btn btn-default \"]}
* 4. close browser
* 
* [test-expected-results]
* [2] verify {url} filter {\d+/?$} greater than {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiCommon.RepeatScenarios
{
    public class C0197 : TestCase
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
                    Action = PluginsList.Click,
                    OnElement = "//a[contains(.,\"Next\") and @class=\"btn btn-default \"]"
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
                    Argument = "{{$ --url --gt:1}}",
                    RegularExpression = "\\d+/?$"
                }
            };
        }
    }
}