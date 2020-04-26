﻿#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0156
* [test-scenario] - Extract Data from DOM, Default, Multiple Extractions
* 
* [test-actions]
* Not supported by literal engine
*/
#pragma warning restore
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0156 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAutomationTest(AutomationEnvironment environment, OrbitResponse response)
        {
            // get pattern based on results (assuming page content is known)
            var expectedPattern = $"{environment.TestParams["extraction"]}" == "0"
                ? "FirstName"
                : "LastName";

            return SharedSteps.AssertEntitiesKeys(
                response,
                fieldsCount: 1,
                expectedPattern: $"^{expectedPattern}$");
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment) => new[]
        {
            new ActionRule
            {
                ActionType = CommonPlugins.ExtractFromDom,
                Argument = "{{$ --extractions:" + environment.TestParams["extraction"] + "}}"
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        {
            #region *** extraction 0 ***
            // entity
            var contentEntries0 = new[]
            {
                new ContentEntry { Key = "FirstName" },
            };

            // get extractions
            var extraction0 = new ExtractionRule
            {
                RootElementToExtractFrom = "//td[contains(@id,'student_first_name')]",
                ElementsToExtract = contentEntries0
            };
            #endregion

            #region *** extraction 1 ***
            // entity
            var contentEntries1 = new[]
            {
                new ContentEntry { Key = "LastName" },
            };

            // get extractions
            var extraction1 = new ExtractionRule
            {
                RootElementToExtractFrom = "//td[contains(@id,'student_last_name')]",
                ElementsToExtract = contentEntries1
            };
            #endregion

            // results
            return new[] { extraction0, extraction1 };
        }
    }
}