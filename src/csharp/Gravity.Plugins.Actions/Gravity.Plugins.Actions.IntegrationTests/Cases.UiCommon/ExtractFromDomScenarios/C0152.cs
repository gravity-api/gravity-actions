﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0152
* [test-scenario] - Extract Data from DOM, Element, Absolute XPath
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from dom take {//tbody/tr}
*        3. < column {HTML} take {//td[contains(@id,'student_first_name')]}
* 4. close browser
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0152 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAutomationTest(AutomationEnvironment environment, OrbitResponse response)
        {
            // setup
            var entity = response.Extractions.ElementAt(0).Entities.ElementAt(0);

            // assertion
            return SharedSteps.AssertEntitiesValues(
                response,
                fieldsCount: 1,
                expectedPattern: $"^{entity.EntityContent["FirstName"]}$");
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
                ElementToActOn = "//td[contains(@id,'student_first_name')]",
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