/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 * 
 * notes
 * comparabilities: https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll
 * use ExecuteScript plugin with relevant platform support to get similar effect.
 */
using Graivty.IntegrationTests.Cases.UiWeb.ScrollScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class ScrollTests
    {
        [Description(description: "P - [0199] - Scroll, Top, Page")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0199P(Context environment)
        {
            // execute
            var actual = new C0199().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0200] - Scroll, Top, Page, JS Argument, top")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0200P(Context environment)
        {
            // execute
            var actual = new C0200().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0201] - Scroll, Top, Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0201P(Context environment)
        {
            // execute
            var actual = new C0201().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0202] - Scroll, Top, Element, JS Argument, top")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0202P(Context environment)
        {
            // execute
            var actual = new C0202().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}