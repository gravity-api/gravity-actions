/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Cases.UiCommon.RepeatScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class RepeatTests
    {
        [Description(description: "P - [0196] - Repeat, Element Exists, Click")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0196P(Context environment)
        {
            // execute
            var actual = new C0196().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0197] - Repeat, Iterations, Click")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0197P(Context environment)
        {
            // execute
            var actual = new C0197().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0198] - Repeat Inside Repeat, Send Keys, Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0198P(Context environment)
        {
            // execute
            var actual = new C0198().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}