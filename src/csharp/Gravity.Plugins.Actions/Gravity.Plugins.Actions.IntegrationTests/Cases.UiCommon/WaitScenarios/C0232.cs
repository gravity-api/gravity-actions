/*
 * TEST SCENARIO (Rhino)
 * [test-id] 0232
 * [test-scenario] - Wait, Milliseconds, Timespan
 * 
 * [test-actions]
 * 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
 * 2. wait {3000}
 */
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Graivty.IntegrationTests.Cases.UiCommon.WaitScenarios
{
    public class C0232 : TestCase
    {
        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            var time = $"{environment.TestParams["time"]}";

            // build
            return new[]
            {
                new ActionRule
                {
                    Action = GravityPlugins.Wait,
                    Argument = time
                }
            };
        }

        // assert preformance of wait action to be greater than time provided.
        public override bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
        {
            // setup
            var preformance = responses.Select(i => i.OrbitRequest).SelectMany(i => i.PerformancePoints);
            var waits = preformance.Where(i => i.Action == GravityPlugins.Wait);
            var time = $"{environment.TestParams["time"]}";

            // setup conditions
            var isDouble = double.TryParse(time, out double timeOut);
            var isTimespan = Regex.IsMatch(time, @"(\d{2}:)+\d{2}");
            var actual = false;

            // build
            if(isDouble)
            {
                actual = waits.All(i => i.Time > timeOut);
            }
            else if(isTimespan)
            {
                _ = TimeSpan.TryParse(time, out TimeSpan timeSpanOut);
                actual = waits.All(i => i.Time > timeSpanOut.TotalMilliseconds);
            }

            // assert
            responses
                .ElementAt(0)
                .AddExtraction(new Extraction().AddEntityContent((Key: "evaluation", Value: actual)));

            // get
            return actual;
        }
    }
}