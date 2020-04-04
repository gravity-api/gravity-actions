/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class AssertTests
    {
        [Description(description: "P - [0002] - Assert, Attribute, Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0002P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["expected"] = "nav-link text-dark";

            // execute
            var actual = new C0002().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0002] - Assert, Attribute, Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0002N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;
            environment.TestParams["expected"] = "text-dark nav-link";

            // execute
            var actual = new C0002().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0002] - Assert, Attribute, Not Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0003P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["expected"] = "btn-default btn";

            // execute
            var actual = new C0003().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0002] - Assert, Attribute, Not Equal")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0003N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;
            environment.TestParams["expected"] = "btn btn-default";

            // execute
            var actual = new C0003().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
