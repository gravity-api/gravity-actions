#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0141
* [test-scenario] - Execute Script, Extractions
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols}
* 2. extract from page on {//body}
*        3. < column {inner_text}
*        4.    > execute script {.checked=false;} on {.//input[@id='input_selected']}
* 5. close browser
* 
* [test-expected-results]
* [4] verify {selected} on {input_selected} using {id}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Cases.UiCommon.ExecuteScriptScenarios
{
    public class C0141 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        {
            var condition = (bool)environment.TestParams["negative"]
                ? "selected"
                : "not_selected";

            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.ExtractFromDom,
                },
                new ActionRule
                {
                    Action = PluginsList.Assert,
                    Argument = "{{$ --" + condition + "}}",
                    OnElement = "input_selected",
                    Locator = LocatorsList.Id
                }
            };
        }

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        {
            // entity
            var contentEntries = new[]
            {
                new ContentEntry
                {
                    Key = "inner_text",
                    Actions = new[]
                    {
                        new ActionRule
                        {
                            Action = PluginsList.ExecuteScript,
                            Argument = ".checked=false;"
                        }
                    }
                }
            };

            // get extractions
            var extraction = new ExtractionRule
            {
                OnRootElements = "//input[@id='input_selected']",
                OnElements = contentEntries
            };
            return new[] { extraction };
        }
    }
}