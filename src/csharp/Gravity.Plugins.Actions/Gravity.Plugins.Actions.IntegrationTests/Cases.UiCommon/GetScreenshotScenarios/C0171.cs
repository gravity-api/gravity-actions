#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0171
* [test-scenario] - Get Screenshot, Element, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. get screenshot {GetScreenshot/image_0171.png} on {//div[@class='jumbotron']}
* 3. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Graivty.IntegrationTests.Cases.UiCommon.GetScreenshotScenarios
{
    public class C0171 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var action = new ActionRule
            {
                Action = PluginsList.GetScreenshot,
                Argument = $"GetScreenshot/image_0171_{Guid.NewGuid()}.png",
                OnElement = "//div[@class='jumbotron']"
            };
            return new[] { action };
        }

        // assertions
        public override bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
        {
            // setup
            var path = responses
                .SelectMany(i => i.Extractions)
                .SelectMany(i => i.Entities)
                .First(i => i.Content.ContainsKey("screenshot"))
                .Content["screenshot"];

            // assert
            return File.Exists($"{path}");
        }
    }
}