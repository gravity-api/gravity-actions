#pragma warning disable S125
/*
* TEST SCENARIO (Rhino)
* [test-id] 0183
* [test-scenario] - Long Swipe, Element to Coordinates
* 
* [test-actions]
* 1. navigate to {https://gravitymvctestapplication.azurewebsites.net/uicontrols/}
* 2. long swipt {{$ --target:#input_range --source:200,200}} using {css selector}
* 3. close browser
* 
* [test-expected-results]
* [2] verify {attribute} on {} greater than {50}
*/
#pragma warning restore
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Graivty.IntegrationTests.Cases.UiMobile.LongSwipeScenarios
{
    public class C0183 : TestCase
    {
        // set to mobile native
        public override bool IsWebTest => false;

        // gets the actions collection of this test
        public override IEnumerable<ActionRule> OnActions(Context environment)
        {
            // setup
            return new[]
            {
                new ActionRule
                {
                    Action = PluginsList.Wait,
                    Argument = "3000"
                },
                //new ActionRule
                //{
                //    Action = PluginsList.LongSwipe,
                //    Argument = "{{$ --source:org.wikipedia.alpha:id/view_card_header_image --target:200,200}}",
                //    Locator = LocatorsList.Id
                //},
                // TODO: assert keyboard hidden
            };
        }

        // set capabilities
        public override IDictionary<string, object> OnDriver(Context environment, IDictionary<string, object> driverParams)
        {
            // setup
            var capabilities = (IDictionary<string, object>)driverParams["capabilities"];

            // apply
            capabilities["app"] = environment.TestParams["AppUrl"];

            // return to base
            return base.OnDriver(environment, driverParams);
        }
    }
}