#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0032
* [test-scenario] - Assert, Text, Not Match, Name
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {text} on {text for testing} using {name} not match {^Bar Foo$}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0032 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "^Foo Bar$" : "^Bar Foo$";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --text --not_match:" + expected + "}}",
                    OnElement = "text for testing",
                    Locator = LocatorsList.Name
                }
            };
        }
    }
}
