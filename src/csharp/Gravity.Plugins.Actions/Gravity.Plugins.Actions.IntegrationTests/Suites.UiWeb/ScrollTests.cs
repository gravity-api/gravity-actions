/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
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
            var actual = new C0199().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0200] - Scroll, Top, Page, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0200P(Context environment)
        {
            // execute
            var actual = new C0200().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0201] - Scroll, Top, Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0201P(Context environment)
        {
            // execute
            var actual = new C0201().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0202] - Scroll, Top, Element, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0202P(Context environment)
        {
            // execute
            var actual = new C0202().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0203] - Scroll, Left, Element, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0203P(Context environment)
        {
            // execute
            var actual = new C0203().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0204] - Scroll, Top, Left, Element, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0204P(Context environment)
        {
            // execute
            var actual = new C0204().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0205] - Scroll, Top, Left, Behavior, Element, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0205P(Context environment)
        {
            // execute
            var actual = new C0205().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0206] - Scroll, Top, Behavior, Page, JS Argument")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        public void T0206P(Context environment)
        {
            // execute
            var actual = new C0206().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}