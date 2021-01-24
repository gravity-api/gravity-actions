/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ExtractFromDomTests
    {
        [Description(description: "P - [0144] - Extract Data from DOM, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0144P(Context environment)
        {
            // execute
            var actual = new C0144().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0145] - Extract Data from DOM, Default, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0145P(Context environment)
        {
            // execute
            var actual = new C0145().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0146] - Extract Data from DOM, Default, Attribute")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0146P(Context environment)
        {
            // execute
            var actual = new C0146().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0147] - Extract Data from DOM, Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0147P(Context environment)
        {
            // execute
            var actual = new C0147().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0148] - Extract Data from DOM, Element, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0148P(Context environment)
        {
            // execute
            var actual = new C0148().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0149] - Extract Data from DOM, Default, HTML")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0149P(Context environment)
        {
            // execute
            var actual = new C0149().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0150] - Extract Data from DOM, Default, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0150P(Context environment)
        {
            // execute
            var actual = new C0150().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0151] - Extract Data from DOM, Element, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0151P(Context environment)
        {
            // execute
            var actual = new C0151().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0152] - Extract Data from DOM, Element, Absolute XPath")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0152P(Context environment)
        {
            // execute
            var actual = new C0152().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0153] - Extract Data from DOM, Element, Actions, Stale")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0153P(Context environment)
        {
            // execute
            var actual = new C0153().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0154] - Extract Data from DOM, Element, Actions, Switch")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0154P(Context environment)
        {
            // execute
            var actual = new C0154().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0155] - Extract Data from DOM, Default, Data Source, All Entities")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0155A(Context environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = false;

            // execute
            var actual = new C0155().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0155] - Extract Data from DOM, Default, Data Source, Per Entity")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0155E(Context environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = true;

            // execute
            var actual = new C0155().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0156] - Extract Data from DOM, Default, Multiple Extractions")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0156F(Context environment)
        {
            // setup
            environment.TestParams["extraction"] = "0";

            // execute
            var actual = new C0156().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0156] - Extract Data from DOM, Default, Multiple Extractions")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0156L(Context environment)
        {
            // setup
            environment.TestParams["extraction"] = "1";

            // execute
            var actual = new C0156().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [NonParallelizable]
        [Description(description: "P - [0157] - Extract Data from DOM, Default, Data Driven")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0157P(Context environment)
        {
            // execute
            var actual = new C0157().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}