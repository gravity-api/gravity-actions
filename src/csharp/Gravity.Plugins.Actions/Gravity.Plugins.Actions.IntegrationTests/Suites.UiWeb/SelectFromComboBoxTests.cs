/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class SelectFromComboBoxTests
    {
        [Description(description: "P - [207] - Select From Combo Box, Text, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0207P(Context environment)
        {
            // execute
            var actual = new C0207().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0208] - Select From Combo Box, Value, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0208P(Context environment)
        {
            // execute
            var actual = new C0208().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0209] - Select From Combo Box, Index, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0209P(Context environment)
        {
            // execute
            var actual = new C0209().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0210] - (A) Select From Combo Box, Text, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0210A(Context environment)
        {
            // setup
            environment.TestParams["argument"] = "Two";

            // execute
            var actual = new C0210().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0210] - (B) Select From Combo Box, Text, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0210B(Context environment)
        {
            // setup
            environment.TestParams["argument"] = "['Two']";

            // execute
            var actual = new C0210().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0211] - (A) Select From Combo Box, Value, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0211A(Context environment)
        {
            // setup
            environment.TestParams["argument"] = "2";

            // execute
            var actual = new C0211().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0211] - (B) Select From Combo Box, Value, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0211B(Context environment)
        {
            // setup
            environment.TestParams["argument"] = "['2']";

            // execute
            var actual = new C0211().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0212] - (A) Select From Combo Box, Index, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0212A(Context environment)
        {
            // setup
            environment.TestParams["argument"] = "1";

            // execute
            var actual = new C0212().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0212] - (B) Select From Combo Box, Value, Multiple, Single Value")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0212B(Context environment)
        {
            // execute
            var actual = new C0212().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0213] - Select From Combo Box, Text, Multiple, Multiple Values")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0213(Context environment)
        {
            // execute
            var actual = new C0213().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0214] - Select From Combo Box, Value, Multiple, Multiple Values")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0214(Context environment)
        {
            // execute
            var actual = new C0214().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0215] - Select From Combo Box, Index, Multiple, Multiple Values")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXMojaveSafari))]
        public void T0215(Context environment)
        {
            // execute
            var actual = new C0215().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0216] - Select From Combo Box, Index, Multiple, All Values")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0216(Context environment)
        {
            // execute
            var actual = new C0216().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0217] - Select From Combo Box, Index, Multiple, All Values, Regular Expression")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0217(Context environment)
        {
            // execute
            var actual = new C0217().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}