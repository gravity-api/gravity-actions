﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.ConditionScenarios;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ConditionEnabledTests
    {
        [Description(description: "P - [0089] - Condition,Enabled, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        public void T0089P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0089().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0089] - Condition, Enabled, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0089N(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0089().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}