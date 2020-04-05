#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0003
* [test-scenario] - Assert, Attribute, Not Equal, CSS Selector
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. close browser
* 
* [test-expected-results]
* [1] verify {attribute} on {p:nth-child(3) > a} from {class} using {css selector} not equal {btn-default btn}
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios
{
    public class C0003 : TestCase
    {
        public override bool AutomationTest(AutomationEnvironment environment)
        {
            // setup
            var driver = $"{environment.TestParams["driver"]}";
            var capabilities = $"{environment.TestParams["capabilities"]}";
            var isNegative = (bool)environment.TestParams["negative"];

            // web automation
            var actions = GetActions(isNegative);
            var webAutomation = GetWebAutomation(driver, capabilities);
            webAutomation = AddWebActions(webAutomation, actions, extractions: default);

            // execute
            var response = ExecuteWebAutomation(webAutomation, environment);
            var actual = GetActual<bool>(response, key: "evaluation");

            // assertion
            return isNegative ? !actual : actual;
        }

        // gets the actions collection of this test
        private IEnumerable<ActionRule> GetActions(bool isNegative)
        {
            var expected = isNegative ? "btn btn-default" : "btn-default btn";

            // setup
            return new List<ActionRule>()
            {
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --attribute --ne:" + expected + "}}",
                    ElementToActOn = "p:nth-child(3) > a",
                    ElementAttributeToActOn = "class",
                    Locator = LocatorType.CssSelector
                }
            };
        }
    }
}