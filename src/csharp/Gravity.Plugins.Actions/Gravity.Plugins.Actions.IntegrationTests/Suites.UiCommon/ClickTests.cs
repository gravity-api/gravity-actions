﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
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
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0001P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0001().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0062] - Click at the Last Known Mouse Coordinates")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0062P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0062().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0063] - Click Element Until No Alert, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesPopups))]
        public void T0063P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0063().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}