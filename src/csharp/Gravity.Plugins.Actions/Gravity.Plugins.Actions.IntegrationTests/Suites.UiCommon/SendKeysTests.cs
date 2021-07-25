/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiCommon.SendKeysScenarios;

using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class SendKeysTests
    {
        [Description(description: "P - [0218] - Send Keys, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218P(Context environment)
        {
            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Send Keys, Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219P(Context environment)
        {
            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0220] - Send Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0220P(Context environment)
        {
            // execute
            var actual = new C0220().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0221] - Send Keys, Clear, Interval")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0221P(Context environment)
        {
            // execute
            var actual = new C0221().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0222] - Send Keys, Clear, Interval, Force Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0222P(Context environment)
        {
            // execute
            var actual = new C0222().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0223] - Send Keys, Keys, Clear, Interval")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0223P(Context environment)
        {
            // execute
            var actual = new C0223().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        #region *** T0224 ***
        [Description(description: "P - [0224] - Send Keys, Combination, Control+A, Windows")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Firefox))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win7InternetExplorer))]
        public void T0224P(Context environment)
        {
            // setup
            environment.TestParams["downKey"] = "control";
            environment.TestParams["key"] = "a";

            // execute
            var actual = new C0224().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0224] - Send Keys, Combination, Control+A, OSX")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXCatalinaFirefox))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXMojaveSafari))]
        public void T0224M(Context environment)
        {
            // setup
            environment.TestParams["downKey"] = "command";
            environment.TestParams["key"] = "A";

            // execute
            var actual = new C0224().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        // TODO: move to 224P when stable
        [Ignore("Not supported or not working properly for these platforms. Check again when new WebDriver version is available.")]
        [Description(description: "P - [0224] - Send Keys, Combination, Control+A")]
        [Test]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXCatalinaChrome))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Edge))]
        [TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10InternetExplorer))]
        public void T0224N(Context environment)
        {
            // execute
            var actual = new C0224().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion
    }
}