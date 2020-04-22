/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ElementsListenerScenarios;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ElementsListenerTests
    {
        [Description(description: "P - [0136] - Elements Listener, Default, XPath")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0136P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0136().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0136] - Elements Listener, Default, XPath")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0136N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0136().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0137] - Elements Listener, Sub Actions, XPath")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0137P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0137().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0137] - Elements Listener, Sub Actions, XPath")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0137N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0137().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}