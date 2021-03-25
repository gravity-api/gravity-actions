#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0161
* [test-scenario] - Extract Data from Source, Element
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from source take {//tbody/tr}
*        3. < column {FirstName} take {.//td[contains(@id,'student_first_name')]}
* 4. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ExtractFromSourceScenarios
{
    public class C0161 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
        {
            return SharedSteps.AssertEntitiesValues(
                responses,
                fieldsCount: 1,
                expectedPattern: @"^(?!\s*$).+");
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment) => new[]
        {
            new ActionRule
            {
                Action = PluginsList.ExtractFromSource
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> OnExtractions(Context environment)
        {
            // entity
            var contentEntry = new ContentEntry
            {
                Key = "FirstName",
                OnElement = ".//td[contains(@id,'student_first_name')]"
            };
            var contentEntries = new[] { contentEntry };

            // get extractions
            var extraction = new ExtractionRule
            {
                OnRootElements = "//tbody/tr",
                OnElements = contentEntries
            };

            // results
            return new[] { extraction };
        }
    }
}
