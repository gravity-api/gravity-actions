﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0167
* [test-scenario] - Extract Data from Source, Default, Data Source
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from source on {//td[contains(@id,'student_first_name')]}
*        3. < column {FirstName}
* 4. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiWeb.ExtractFromSourceScenarios
{
    public class C0167 : TestCase
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
                Action = GravityPlugin.ExtractFromSource
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> OnExtractions(Context environment)
        {
            // data source
            var dataSource = new GravityDataProvider
            {
                WritePerEntity = (bool)environment.TestParams["is_per_entity"],
                Source = $"{environment.SystemParams["Integration.MockApi"]}",
                Type = GravityDataProviders.RestApi
            };

            // entity
            var contentEntries = new[]
            {
                new ContentEntry { Key = "FirstName" },
            };

            // get extractions
            var extraction = new ExtractionRule
            {
                OnRootElements = "//td[contains(@id,'student_first_name')]",
                OnElements = contentEntries,
                DataProvider = dataSource
            };

            // results
            return new[] { extraction };
        }
    }
}
