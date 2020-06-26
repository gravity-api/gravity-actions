/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
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
            var actual = new C0218().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Send Keys, Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219P(Context environment)
        {
            // execute
            var actual = new C0219().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0220] - Send Keys, Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0220P(Context environment)
        {
            // execute
            var actual = new C0220().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0221] - Send Keys, Clear, Interval")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0221P(Context environment)
        {
            // execute
            var actual = new C0221().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0222] - Send Keys, Clear, Interval, Force Clear")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0222P(Context environment)
        {
            // execute
            var actual = new C0222().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
