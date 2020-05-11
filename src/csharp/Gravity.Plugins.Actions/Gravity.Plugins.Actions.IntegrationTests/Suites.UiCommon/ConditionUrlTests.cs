/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ConditionUrlTests
    {
        [Description(description: "P - [0111] - Condition, URL, Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0111P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0111().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0111] - Condition, URL, Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0111N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0111().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0112] - Condition, URL, Not Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0112P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0112().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0112] - Condition, URL, Not Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0112N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0112().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0113] - Condition, URL, Match")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0113P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0113().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0113] - Condition, URL, Match")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0113N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0113().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0114] - Condition, URL, Not Match")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0114P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0114().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0114] - Condition, URL, Not Match")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0114N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0114().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0115] - Condition, URL, Greater Than, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0115P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0115().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0115] - Condition, URL, Greater Than, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0115N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0115().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0116] - Condition, URL, Lower Than, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0116P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0116().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0116] - Condition, URL, Lower Than, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0116N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0116().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0117] - Condition, URL, Greater or Equal, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0117P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0117().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0117] - Condition, URL, Greater or Equal, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0117N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0117().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0118] - Condition, URL, Lower or Equal, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0118P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0118().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0118] - Condition, URL, Lower or Equal, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0118N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0118().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}