#pragma warning disable S125
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
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0152 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
        {
            // setup
            var entity = responses.SelectMany(i=>i.Extractions).ElementAt(0).Entities.ElementAt(0);

            // assertion
            return SharedSteps.AssertEntitiesValues(
                responses,
                fieldsCount: 1,
                expectedPattern: $"^{entity.Content["FirstName"]}$");
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment) => new[]
        {
            new ActionRule
            {
                Action = GravityPlugins.ExtractFromDom
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> OnExtractions(Context environment)
        {
            // entity
            var contentEntry = new ContentEntry
            {
                Key = "FirstName",
                OnElement = "//td[contains(@id,'student_first_name')]",
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
