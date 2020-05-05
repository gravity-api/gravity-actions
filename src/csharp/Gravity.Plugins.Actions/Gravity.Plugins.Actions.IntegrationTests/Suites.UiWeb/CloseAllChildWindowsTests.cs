/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiWeb.CloseAllChildWindowsScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class CloseAllChildWindowsTests
    {
        [Description(description: "P - [0064] - Close All Child Windows")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesNoIos))]
        public void T0064P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0064().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0065] - Close All Child Windows, No Child Windows")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesNoIos))]
        public void T0065P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0065().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
