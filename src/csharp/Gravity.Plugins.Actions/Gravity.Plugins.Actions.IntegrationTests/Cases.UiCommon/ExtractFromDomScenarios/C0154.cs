#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0154
* [test-scenario] - Extract Data from DOM, Element, Actions, Switch
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/student}
* 2. extract from dom take {//tbody/tr}
*     3. < column {HTML} take {.//td[contains(@id,'student_first_name')]}
*           4. > go to url {{$ --blank}} take {Details} using {link text} from {href}
*           5. > switch to window {1}
*     6. < column {Course} take {"//tbody/tr/td[1]"}
*           7. > close all child windows
* 8. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios
{
    public class C0154 : TestCase
    {
        public override string ApplicationUnderTest => StudentsPage;

        // assertion implementation
        public override bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
        {
            // assertion
            return SharedSteps.AssertEntitiesValues(
                responses,
                fieldsCount: 2,
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
            var getFirstName = new ContentEntry
            {
                Key = "FirstName",
                OnElement = ".//td[contains(@id,'student_first_name')]",
                Actions = new[]
                {
                    new ActionRule
                    {
                        Action = PluginsList.GoToUrl,
                        Argument = "{{$ --blank}}",
                        OnElement = "Details",
                        OnAttribute = "href",
                        Locator = LocatorsList.LinkText
                    },
                    new ActionRule
                    {
                        Action = PluginsList.SwitchToWindow,
                        Argument = "1"
                    }
                }
            };
            var getFirstCourse = new ContentEntry
            {
                Key = "Course",
                OnElement = "//tbody/tr/td[1]",
                Actions = new[]
                {
                    new ActionRule { Action = PluginsList.CloseAllChildWindows }
                }
            };
            var contentEntries = new[] { getFirstName, getFirstCourse };

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