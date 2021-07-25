/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiCommon.GetScreenshotScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;
using System.IO;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class GetScreenshotTests
    {
        [OneTimeTearDown]
        public static void Cleanup()
        {
            if (!Directory.Exists("GetScreenshot"))
            {
                return;
            }
            Directory.Delete(path: "GetScreenshot", recursive: true);
        }

        [Description(description: "P - [0170] - Get Screenshot, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0170P(Context environment)
        {
            // execute
            var actual = new C0170().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Ignore(reason: "Not implemented")]
        [Description(description: "P - [0171] - Get Screenshot, Element, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0171P(Context environment)
        {
            // execute
            var actual = new C0171().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
