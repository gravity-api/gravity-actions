﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0052
* [test-scenario] - Assert, URL, Lower or Equal, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/course/edit/1045}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {url} filter {\d+} lower or equal {1045}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0052 : TestCase
    {
        public override string ApplicationUnderTest => $"{CoursesPage}/edit/1045";

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var expected = (bool)environment.TestParams["negative"] ? "1000" : "1045";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --url --le:" + expected + "}}",
                    RegularExpression = "\\d+"
                }
            };
        }
    }
}
