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
    public class ConditionAttributeTests
    {
        [Description(description: "P - [0068] - Condition, Attribute, Equal, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0068P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0068().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0068] - Condition, Attribute, Equal, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0068N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0068().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0069] - Condition, Attribute, Not Equal, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0069P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0069().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0069] - Condition, Attribute, Not Equal, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0069N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0069().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0070] - Condition, Attribute, Match, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0070P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0070().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0070] - Condition, Attribute, Match, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0070N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0070().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0071] - Condition, Attribute, Not Match, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0071P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0071().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0071] - Condition, Attribute, Not Match, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0071N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0071().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0072] - Condition, Attribute, Greater Than, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0072P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0072().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0072] - Condition, Attribute, Greater Than, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0072N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0072().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0073] - Condition, Attribute, Lower Than, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0073P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0073().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0073] - Condition, Attribute, Lower Than, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0073N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0073().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0074] - Condition, Attribute, Greater or Equal, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0074P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0074().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0074] - Condition, Attribute, Greater or Equal, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0074N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0074().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0075] - Condition, Attribute, Lower or Equal, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0075P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0075().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0075] - Condition, Attribute, Lower or Equal, Link Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0075N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0075().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}