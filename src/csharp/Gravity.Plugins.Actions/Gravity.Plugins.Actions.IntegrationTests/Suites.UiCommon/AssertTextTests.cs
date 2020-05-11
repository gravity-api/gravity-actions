/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.AssertScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class AssertTextTests
    {
        [Description(description: "P - [0029] - Assert, Text, Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0029P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0029().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0029] - Assert, Text, Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0029N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0029().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0030] - Assert, Text, Not Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0030P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0030().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0030] - Assert, Text, Not Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0030N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0030().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0031] - Assert, Text, Match, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0031P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0031().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0031] - Assert, Text, Match, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0031N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0031().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0032] - Assert, Text, Not Match, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0032P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0032().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0032] - Assert, Text, Not Match, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0032N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0032().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0033] - Assert, Text, Greater Than, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0033P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0033().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0033] - Assert, Text, Greater Than, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0033N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0033().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0034] - Assert, Text, Lower Than, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0034P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0034().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0034] - Assert, Text, Lower Than, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0034N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0034().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0035] - Assert, Text, Greater or Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0035P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0035().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0035] - Assert, Text, Greater or Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0035N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0035().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0036] - Assert, Text, Lower or Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0036P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0036().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0036] - Assert, Text, Lower or Equal, Name")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0036N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0036().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}