/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */

#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0001
* [test-scenario] - Click on Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. click on {//a[.='Departments']}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {text} on {//a[.='Departments']} equal {Departments}
*/
#pragma warning restore
using Gravity.Abstraction.Contracts;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon
{
    public class C0001 : TestCase
    {
        public override bool AutomationTest(AutomationEnvironment environment)
        {
            // setup
            var driver = $"{environment.TestParams["driver"]}";
            var capabilities = $"{environment.TestParams["capabilities"]}";

            // web automation
            var actions = GetActions(environment);
            var extractions = GetExtractions(rootElement: "//h1[1]");

            var webAutomation = GetWebAutomation(driver, capabilities);
            webAutomation = AddWebActions(webAutomation, actions, extractions);

            // execute
            var response = ExecuteWebAutomation(webAutomation, environment);
            var actual = GetActual(response);

            // assertion
            return actual.Equals("Departments");
        }

        // gets the actions collection of this test
        private IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            // setup
            var actions = new List<ActionRule>();
            var driver = $"{environment.TestParams["driver"]}";

            // setup conditions
            var isMobile = driver == Driver.Android || driver == Driver.iOS;

            // mobile handler
            if (isMobile)
            {
                actions.Add(new ActionRule { ActionType = "Click", ElementToActOn = "//button[@data-toggle]" });
            }

            // common actions
            actions.Add(new ActionRule { ActionType = CommonPlugins.Click, ElementToActOn = "//a[.='Departments']" });
            actions.Add(new ActionRule { ActionType = CommonPlugins.ExtractFromDom });

            // results
            return actions;
        }

        // gets the actions collection of this test
        private IEnumerable<ExtractionRule> GetExtractions(string rootElement)
        {
            // setup
            var extraction = new ExtractionRule
            {
                RootElementToExtractFrom = rootElement,
                ElementsToExtract = new[]
                {
                    new ContentEntry { Key = "actual" }
                }
            };

            // results
            return new[] { extraction };
        }
    }
}