/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiWeb.CloseWindowScenarios;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class CloseWindowTests
    {
        [Description(description: "P - [0066] - Close Window")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesCloseWindow))]
        public void T0066P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0066().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0067] - Close Window, No Child Windows")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0067N(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0067().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}