/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.ClickScenarios;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ClickTests
    {
        [Description(description: "P - [0001] - Click on Element")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0001P(Context environment)
        {
            // execute
            var actual = new C0001().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0062] - Click at the Last Known Mouse Coordinates")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0062P(Context environment)
        {
            // execute
            var actual = new C0062().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0063] - Click Element Until No Alert, ID")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIe11NoIos))]
        public void T0063P(Context environment)
        {
            // execute
            var actual = new C0063().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}