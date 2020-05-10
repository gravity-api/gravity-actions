#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0057
* [test-scenario] - Assert, Windows Count, Not Match
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {windows_count} not match {1\d+}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0057 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "\\d{1}" : "1\\d+";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --windows_count --not_match:" + expected + "}}"
                }
            };
        }
    }
}