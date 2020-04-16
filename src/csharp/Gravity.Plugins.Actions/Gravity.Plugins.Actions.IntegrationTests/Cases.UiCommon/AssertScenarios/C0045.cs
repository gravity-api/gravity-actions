﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0045
* [test-scenario] - Assert, URL, Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} equal {https://gravitymvctestapplication.azurewebsites.net/course/}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0045 : TestCase
    {
        public override string ApplicationUnderTest => CoursesPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var expected = (bool)environment.TestParams["negative"]
                ? "https://gravitymvctestapplication.azurewebsites.net/"
                : "https://gravitymvctestapplication.azurewebsites.net/course/";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --url --eq:" + expected + "}}"
                }
            };
        }
    }
}