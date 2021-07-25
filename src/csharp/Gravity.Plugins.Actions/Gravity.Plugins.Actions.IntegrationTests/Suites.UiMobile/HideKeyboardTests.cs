/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiMobile.HideKeyboardScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiMobile
{
    [TestFixture]
    public class HideKeyboardTests
    {
        [Description(description: "P - [0180] - Hide Keyboard, Default")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesMobileWeb))]
        public void T180P(Context environment)
        {
            // execute
            var actual = new C0180().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
