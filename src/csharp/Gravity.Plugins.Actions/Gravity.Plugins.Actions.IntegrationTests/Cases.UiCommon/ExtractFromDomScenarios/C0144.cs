#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0144
* [test-scenario] - Extract Data from DOM, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from dom on {//td[contains(@id,'student_first_name')]}
*        3. < column {FirstName}
* 4. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0144 : TestCase
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
                Action = PluginsList.ExtractFromDom
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> OnExtractions(Context environment)
        {
            // entity
            var contentEntries = new[]
            {
                new ContentEntry { Key = "FirstName" },
            };

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