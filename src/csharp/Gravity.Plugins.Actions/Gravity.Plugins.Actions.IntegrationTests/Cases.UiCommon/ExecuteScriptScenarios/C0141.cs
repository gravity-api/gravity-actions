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
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExecuteScriptScenarios
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
                    ActionType = CommonPlugins.ExtractFromDom,
                },
                new ActionRule
                {
                    ActionType = CommonPlugins.Assert,
                    Argument = "{{$ --" + condition + "}}",
                    ElementToActOn = "input_selected",
                    Locator = LocatorType.Id
                }
            };
        }

        // gets the extractions collection of this test
        public override IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        {
            var extraction = new ExtractionRule
            {
                RootElementToExtractFrom = "//input[@id='input_selected']",
                ElementsToExtract = new[]
                {
                    new ContentEntry
                    {
                        Key = "inner_text",
                        Actions = new[]
                        {
                            new ActionRule
                            {
                                ActionType = CommonPlugins.ExecuteScript,
                                Argument = ".checked=false;"
                            }
                        }
                    }
                }
            };
            return new[] { extraction };
        }
    }
}