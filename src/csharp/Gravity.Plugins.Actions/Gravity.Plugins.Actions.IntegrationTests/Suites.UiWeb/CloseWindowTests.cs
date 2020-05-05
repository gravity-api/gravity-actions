﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiWeb.CloseWindowScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class CloseWindowTests
    {
        [Description(description: "P - [0066] - Close Window")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesNoIos))]
        public void T0066P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0066().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0067] - Close Window, No Child Windows")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesNoIos))]
        public void T0067P(AutomationEnvironment environment)
        {
            // execute
            var actual = new C0067().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}