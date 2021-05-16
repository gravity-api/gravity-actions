#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0085
* [test-scenario] - Condition, Driver, Equal
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. condition {{$ --driver --eq:OpenQA.Selenium.Remote.RemoteWebDriver}} on {//tr[./td[@id]]}
*     3. type {Carson} into {SearchString} using {id}
*     4. click on {SearchButton} using {id}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {count} on {//tr[./td[@id]]} equal {1}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios
{
    public class C0085 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var onDriver = (bool)environment.TestParams["negative"]
                ? "not_a_driver"
                : "OpenQA.Selenium.Remote.RemoteWebDriver";

            // actions to execute
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    Action = GravityPlugin.Condition,
                    Argument = "{{$ --driver --eq:" + onDriver + "}}",
                    OnElement = "//tr[./td[@id]]",
                    Actions = SharedSteps.SearchStudent(searchFor: "Carson")
                },
                SharedSteps.AssertStudentsCount(count: 1)
            };
        }
    }
}