#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0157
* [test-scenario] - Extract Data from DOM, Default, Data Driven
* 
* [test-actions]
* 1. navigate to {@Address}
* 2. extract from dom on {@RootElement}
*        3. < column {@ColumnName}
* 4. close browser
* 
* [test-data-provider]
* [
*     {
*         "Address":"https://gravitymvctestapplication.azurewebsites.net/student",
*         "RootElement":"//td[contains(@id,'student_first_name')]",
*         "ColumnName":"StudentFirstName"
*     },
*     {
*         "Address":"https://gravitymvctestapplication.azurewebsites.net/instructor",
*         "RootElement":"//tbody/tr/td[2]",
*         "ColumnName":"InstructorFirstName"
*     }
* ]
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0157 : TestCase
    {
        public override string ApplicationUnderTest => "{{address}}";

        // before execute implementation
        public override void OnAutomation(WebAutomation automation)
        {
            var data = JsonConvert.SerializeObject(new[]
            {
                new
                {
                    Address = "https://gravitymvctestapplication.azurewebsites.net/student",
                    RootElement = "//td[contains(@id,'student_first_name')]",
                    ColumnName = "StudentFirstName"
                },
                new
                {
                    Address = "https://gravitymvctestapplication.azurewebsites.net/instructor",
                    RootElement = "//tbody/tr/td[2]",
                    ColumnName = "InstructorFirstName"
                }
            });
            automation.DataSource = new DataSource
            {
                Type = DataSourcesList.JSON,
                Source = data
            };
            automation.EngineConfiguration.MaxParallel = 5;
        }

        // assertion implementation
        public override bool OnAfterAutomation(AutomationEnvironment environment, IEnumerable<OrbitResponse> responses)
        {
            // keys extracted
            var isKeys = SharedSteps.AssertEntitiesKeys(
                responses,
                fieldsCount: 1,
                expectedPattern: "^StudentFirstName$|^InstructorFirstName");

            // values are not empty
            var isValues = SharedSteps.AssertEntitiesValues(
                responses,
                fieldsCount: 1,
                expectedPattern: "^\\w+$");

            // entities gathered from more than one page
            var isCount = responses.SelectMany(i => i.Extractions).SelectMany(i => i.Entities).Count() > 5;

            // assertion
            return isKeys && isValues && isCount;
        }

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(AutomationEnvironment environment) => new[]
        {
            new ActionRule
            {
                Action = PluginsList.ExtractFromDom
            }
        };

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> OnExtractions(AutomationEnvironment environment)
        {
            // entity
            var contentEntries = new[]
            {
                new ContentEntry { Key = "{{ColumnName}}" },
            };

            // get extractions
            var extraction = new ExtractionRule
            {
                OnRootElements = "{{RootElement}}",
                OnElements = contentEntries
            };

            // results
            return new[] { extraction };
        }
    }
}