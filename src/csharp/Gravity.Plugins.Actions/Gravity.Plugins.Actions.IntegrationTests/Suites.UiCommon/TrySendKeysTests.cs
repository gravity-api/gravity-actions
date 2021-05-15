/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiCommon.TrySendKeysScenarios;

using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class TrySendKeysTests
    {
        [Description(description: "P - [0225] - Send Keys, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Firefox))]
        public void T0225P(Context environment)
        {
            // execute
            var actual = new C0225().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0226] - Send Keys, Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0226P(Context environment)
        {
            // execute
            var actual = new C0226().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0227] - Send Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0227P(Context environment)
        {
            // execute
            var actual = new C0227().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0228] - Send Keys, Clear, Interval")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0228P(Context environment)
        {
            // execute
            var actual = new C0228().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0229] - Send Keys, Clear, Interval, Force Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0229P(Context environment)
        {
            // execute
            var actual = new C0229().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0230] - Send Keys, Keys, Clear, Interval")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0230P(Context environment)
        {
            // execute
            var actual = new C0230().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        #region *** T0231 ***
        [Description(description: "P - [0231] - Send Keys, Combination, Control+A, Windows")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Firefox))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win7InternetExplorer))]
        public void T0231P(Context environment)
        {
            // setup
            environment.TestParams["downKey"] = "control";
            environment.TestParams["key"] = "a";

            // execute
            var actual = new C0231().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0231] - Send Keys, Combination, Control+A, OSX")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXCatalinaFirefox))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXMojaveSafari))]
        public void T0231M(Context environment)
        {
            // setup
            environment.TestParams["downKey"] = "command";
            environment.TestParams["key"] = "A";

            // execute
            var actual = new C0231().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        // TODO: move to 231P when stable
        [Ignore("Not supported or not working properly for these platforms. Check again when new WebDriver version is available.")]
        [Description(description: "P - [0231] - Send Keys, Combination, Control+A")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXCatalinaChrome))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Edge))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10InternetExplorer))]
        public void T0231N(Context environment)
        {
            // execute
            var actual = new C0231().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion
    }
}