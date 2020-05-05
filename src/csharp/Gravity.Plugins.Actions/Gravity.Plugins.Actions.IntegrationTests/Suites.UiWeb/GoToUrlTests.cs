/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Cases.UiWeb.GoToUrlScenarios;
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiWeb
{
    public class GoToUrlTests
    {
        [Description(description: "P - [0172] - Go To URL, Default")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0172P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0172().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0173] - Go To URL, Blank")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0173P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0173().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0174] - Go To URL, Element, Text")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0174P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0174().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0175] - Go To URL, Element, Text, Blank")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0175P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0175().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0176] - Go To URL, Element, Attribute")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0176P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0176().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0177] - Go To URL, Element, Attribute, Blank")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0177P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0177().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0178] - Go To URL, Default, Alias")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0178A(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["action"] = "NavigateTo";

            // execute
            var actual = new C0178().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0178] - Go To URL, Default, Alias")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0178B(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["action"] = "Open";

            // execute
            var actual = new C0178().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0178] - Go To URL, Default, Alias")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0178C(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["action"] = "GoTo";

            // execute
            var actual = new C0178().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0179] - Go To URL, Element, Text, Regular Expression")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0179C(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0179().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}