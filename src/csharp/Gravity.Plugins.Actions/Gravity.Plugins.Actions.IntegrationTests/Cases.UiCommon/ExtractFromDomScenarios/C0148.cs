﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0148
* [test-scenario] - Extract Data from DOM, Element, Regular Expression
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from dom take {//tbody/tr}
*        3. < column {FirstName} take {.//td[contains(@id,'student_first_name')]} filter {^\w{1}}
* 4. close browser
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0148 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAutomationTest(AutomationEnvironment environment, OrbitResponse response)
        {
            return SharedSteps.AssertEntitiesValues(
                response,
                fieldsCount: 1,
                expectedPattern: @"^\w{1}$");
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment) => new[]
        {
            new ActionRule
            {
                ActionType = CommonPlugins.ExtractFromDom
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        {
            // entity
            var contentEntry = new ContentEntry
            {
                Key = "FirstName",
                ElementToActOn = ".//td[contains(@id,'student_first_name')]",
                RegularExpression = @"^\w{1}"
            };
            var contentEntries = new[] { contentEntry };

            // get extractions
            var extraction = new ExtractionRule
            {
                RootElementToExtractFrom = "//tbody/tr",
                ElementsToExtract = contentEntries
            };

            // results
            return new[] { extraction };
        }
    }
}