﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.AssertScenarios;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class AssertExistsTests
    {
        [Description(description: "P - [0024] - Assert, Exists, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0024P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0024().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0024] - Assert, Exists, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0024N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0024().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}