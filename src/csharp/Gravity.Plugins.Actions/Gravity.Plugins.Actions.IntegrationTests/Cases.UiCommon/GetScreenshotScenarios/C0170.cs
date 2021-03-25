#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0170
* [test-scenario] - Get Screenshot, Default
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/}
* 2. get screenshot {GetScreenshot/image_0170.png}
* 3. close browser
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Graivty.IntegrationTests.Cases.UiCommon.GetScreenshotScenarios
{
    public class C0170 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            var action = new ActionRule
            {
                Action = PluginsList.GetScreenshot,
                Argument = $"GetScreenshot/image_0170_{Guid.NewGuid()}.png"
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