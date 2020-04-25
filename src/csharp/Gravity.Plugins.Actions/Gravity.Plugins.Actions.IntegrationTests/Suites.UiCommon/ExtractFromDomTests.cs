/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ExtractFromDomScenarios;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ExtractFromDomTests
    {
        [Description(description: "P - [0144] - Extract Data from DOM, Default")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0144P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0144().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0145] - Extract Data from DOM, Default, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0145P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0145().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        //[Description(description: "P - [0140] - Execute Script, Arguments")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0140P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0140().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0140] - Execute Script, Arguments")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0140N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0140().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0141] - Execute Script, Extractions")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0141P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0141().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0141] - Execute Script, Extractions")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0141N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0141().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}
    }
}