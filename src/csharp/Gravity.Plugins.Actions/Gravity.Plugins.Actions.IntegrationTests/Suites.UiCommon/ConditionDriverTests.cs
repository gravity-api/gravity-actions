/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ConditionDriverTests
    {
        [Description(description: "P - [0085] - Condition, Driver, Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0085P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0085().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0085] - Condition, Driver, Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0085N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0085().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0086] - Condition, Driver, Not Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0086P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0086().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0086] - Condition, Driver, Not Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0086N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0086().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0087] - Condition, Driver, Match")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0087P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0087().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0087] - Condition, Driver, Match")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0087N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0087().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0088] - Condition, Driver, Not Match")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0088P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0088().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0088] - Condition, Driver, Not Match")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0088N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0088().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}