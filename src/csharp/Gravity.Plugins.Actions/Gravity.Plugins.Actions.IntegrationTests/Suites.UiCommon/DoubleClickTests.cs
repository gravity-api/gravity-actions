﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.IntegrationTests.Base;
using Gravity.Plugins.Actions.IntegrationTests.Cases.UiCommon.DoubleClickTests;
using Gravity.Plugins.Actions.IntegrationTests.Providers;
using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Gravity.Plugins.Actions.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class DoubleClickTests
    {
        [Description(description: "P - [0134] - Double Click on Element, ID")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesNoSafari))]
        public void T0134P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0134().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "N - [0135] - Double Click")]
        [Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        public void T0135P(AutomationEnvironment environment)
        {
            // setup
            environment.TestParams["negative"] = false;

            // execute
            var actual = new C0135().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}