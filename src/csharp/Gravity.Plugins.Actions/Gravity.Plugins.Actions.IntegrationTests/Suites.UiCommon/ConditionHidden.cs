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
    public class ConditionHiddenTests
    {
        [Description(description: "P - [0091] - Condition, Hidden, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0091P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0091().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0091] - Condition, Hidden, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0091N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0091().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}