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

        [Description(description: "P - [0146] - Extract Data from DOM, Default, Attribute")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0146P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0146().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0147] - Extract Data from DOM, Element")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0147P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0147().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0148] - Extract Data from DOM, Element, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0148P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0148().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0149] - Extract Data from DOM, Default, HTML")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0149P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0149().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0150] - Extract Data from DOM, Default, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0150P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0150().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0151] - Extract Data from DOM, Element, HTML, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0151P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0151().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0152] - Extract Data from DOM, Element, Absolute XPath")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0152P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0152().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0153] - Extract Data from DOM, Element, Actions, Stale")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0153P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0153().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0154] - Extract Data from DOM, Element, Actions, Switch")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0154P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0154().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0155] - Extract Data from DOM, Default, Data Source, All Entities")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0155A(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = false;

            // execute
            var actual = new C0155().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0155] - Extract Data from DOM, Default, Data Source, Per Entity")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0155E(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["is_per_entity"] = true;

            // execute
            var actual = new C0155().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}