/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Cases.UiWeb.SelectFromComboBoxScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class SelectFromComboBoxTests
    {
        [Description(description: "P - [207] - Select From Combo Box, Text, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0207P(Context environment)
        {
            // execute
            var actual = new C0207().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0208] - Select From Combo Box, Value, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0208P(Context environment)
        {
            // execute
            var actual = new C0208().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0209] - Select From Combo Box, Index, Single")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.OSXMojaveSafari))]
        public void T0209P(Context environment)
        {
            // execute
            var actual = new C0209().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        //[Description(description: "P - [0202] - Scroll, Top, Element, JS Argument")]
        //[Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        //public void T0202P(Context environment)
        //{
        //    // execute
        //    var actual = new C0202().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0203] - Scroll, Left, Element, JS Argument")]
        //[Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        //public void T0203P(Context environment)
        //{
        //    // execute
        //    var actual = new C0203().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0204] - Scroll, Top, Left, Element, JS Argument")]
        //[Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        //public void T0204P(Context environment)
        //{
        //    // execute
        //    var actual = new C0204().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0205] - Scroll, Top, Left, Behavior, Element, JS Argument")]
        //[Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        //public void T0205P(Context environment)
        //{
        //    // execute
        //    var actual = new C0205().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0206] - Scroll, Top, Behavior, Page, JS Argument")]
        //[Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.CapabilitiesNoIeNoSafari))]
        //public void T0206P(Context environment)
        //{
        //    // execute
        //    var actual = new C0206().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}
    }
}