/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Cases.UiWeb.ExtractFromSourceScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class ExtractFromSourceTests
    {
        [Description(description: "P - [0158] - Extract Data from Source, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0158P(Context environment)
        {
            // execute
            var actual = new C0158().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0159] - Extract Data from Source, Default, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0159P(Context environment)
        {
            // execute
            var actual = new C0159().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0160] - Extract Data from Source, Default, Attribute")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0160P(Context environment)
        {
            // execute
            var actual = new C0160().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0161] - Extract Data from Source, Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0161P(Context environment)
        {
            // execute
            var actual = new C0161().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0162] - Extract Data from Source, Element, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0162P(Context environment)
        {
            // execute
            var actual = new C0162().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0163] - Extract Data from Source, Default, HTML")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0163P(Context environment)
        {
            // execute
            var actual = new C0163().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0164] - Extract Data from Source, Default, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0164P(Context environment)
        {
            // execute
            var actual = new C0164().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0165] - Extract Data from Source, Element, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0165P(Context environment)
        {
            // execute
            var actual = new C0165().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0166] - Extract Data from Source, Element, Absolute XPath")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0166P(Context environment)
        {
            // execute
            var actual = new C0166().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0167] - Extract Data from Source, Default, Data Source")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0167A(Context environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = false;

            // execute
            var actual = new C0167().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0167] - Extract Data from Source, Default, Data Source")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0167E(Context environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = true;

            // execute
            var actual = new C0167().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0168] - Extract Data from Source, Default, Multiple Extractions")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0168F(Context environment)
        {
            // setup
            environment.TestParams["extraction"] = "0";

            // execute
            var actual = new C0168().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0168] - Extract Data from Source, Default, Multiple Extractions")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0168L(Context environment)
        {
            // setup
            environment.TestParams["extraction"] = "1";

            // execute
            var actual = new C0168().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [NonParallelizable]
        [Description(description: "P - [0169] - Extract Data from Source, Default, Data Driven")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0169P(Context environment)
        {
            // execute
            var actual = new C0169().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}