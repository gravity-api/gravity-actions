﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Cases.UiCommon.ConditionScenarios;
using Gravity.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class ConditionNotSelectedTests
    {
        [Description(description: "P - [0142] - Condition, Not Selected, ID")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0142P(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0142().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0142] - Condition, Not Selected, ID")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Win10Chrome))]
        public void T0142N(Context environment)
        {
            // setup
            environment.TestParams["negative"] = true;

            // execute
            var actual = new C0142().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}