/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Cases.UiMobile.LongSwipeScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiMobile
{
    [TestFixture]
    public class LongSwipeTests
    {
        // static context
        public static string AppUrl { get; set; }

        [OneTimeSetUp]
        public static void Setup()
        {
            // setup
            var name = TestContext.Parameters.Get("Appium.App.Name", string.Empty);
            var publicAccessUrl = TestContext.Parameters.Get("Appium.App.PublicAccessUrl", string.Empty);
            var authorization = TestContext.Parameters.Get("Grid.BasicAuthorization", string.Empty);

            // client
            var client = new BrowserStackClient()
            {
                BasicAuthorization = authorization
            };
            AppUrl = client.UploadApplication(name, publicAccessUrl)["app_url"].ToString();
        }

        [Ignore(reason: "development")]
        [Description(description: "P - [0183] - Long Swipe, Element to Coordinates")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesMobileNative))]
        public void T183P(Context environment)
        {
            // setup
            environment.TestParams[nameof(AppUrl)] = AppUrl;

            // execute
            var actual = new C0183().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}