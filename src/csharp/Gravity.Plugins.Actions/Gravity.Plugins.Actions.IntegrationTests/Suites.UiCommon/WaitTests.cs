/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiCommon.WaitScenarios;

using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class WaitTests
    {
        #region *** Wait ***
        [Description(description: "P - [0232] - Wait, Milliseconds")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Firefox))]
        public void T0232A(Context environment)
        {
            // setup
            environment.TestParams["time"] = "3000";

            // execute
            var actual = new C0232().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0232] - Wait, Time Span")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Firefox))]
        public void T0232B(Context environment)
        {
            // setup
            environment.TestParams["time"] = "00:00:03";

            // execute
            var actual = new C0232().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion
    }
}