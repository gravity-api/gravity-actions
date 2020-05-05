﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0163
* [test-scenario] - Extract Data from Source, Default, HTML
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from source take {//td[contains(@id,'student_first_name')]}
*        3. < column {HTML} from {html}
* 4. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ExtractFromSourceScenarios
{
    public class C0163 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAutomationTest(AutomationEnvironment environment, IEnumerable<OrbitResponse> responses)
        {
            return SharedSteps.AssertEntitiesValues(
                responses,
                fieldsCount: 1,
                expectedPattern: @"<\s*td[^>]*>(.*?)<\s*/\s*td>");
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment) => new[]
        {
            new ActionRule
            {
                Action = PluginsList.ExtractFromSource
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        {
            // entity
            var contentEntry = new ContentEntry
            {
                Key = "FirstName",
                OnAttribute = "html"
            };
            var contentEntries = new[] { contentEntry };

            // get extractions
            var extraction = new ExtractionRule
            {
                OnRootElements = "//td[contains(@id,'student_first_name')]",
                OnElements = contentEntries
            };

            // results
            return new[] { extraction };
        }
    }
}