/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 * 
 * work items
 * TODO: add more Capabilities on Selenium 4.0
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiWeb.ContextClickScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class ContextClickTests
    {
        [Ignore(reason: "Wait for Selenium 4")]
        [Description(description: "P - [0131] - Right Click on Element, ID")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoEdgeNoSafari))]
        public void T0131P(Context environment)
        {
            // execute
            var actual = new C0131().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Ignore(reason: "Wait for Selenium 4")]
        [Description(description: "P - [0132] - Right Click")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoEdgeNoSafari))]
        public void T0132P(Context environment)
        {
            // execute
            var actual = new C0132().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Ignore(reason: "Wait for Selenium 4")]
        [Description(description: "P - [0133] - Right Click on Element, Alias, RightClick, ID")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoEdgeNoSafari))]
        public void T0133P(Context environment)
        {
            // execute
            var actual = new C0133().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}