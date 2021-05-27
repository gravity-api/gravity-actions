/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiWeb.SwitchToAlertScenarios;

using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiWeb
{
    [TestFixture]
    public class SwitchToAlertTests
    {
        [Description(description: "P - [234] - Switch to Alert, Dismiss")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0234P(Context environment)
        {
            // execute
            var actual = new C0234().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [235] - Switch to Alert, Accept")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0235P(Context environment)
        {
            // execute
            var actual = new C0235().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [236] - Switch to Alert, Prompt, Send Keys, Accept")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0236P(Context environment)
        {
            // execute
            var actual = new C0236().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [237] - Switch to Alert, Prompt, Send Keys, Dismiss")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0237P(Context environment)
        {
            // execute
            var actual = new C0237().AddEnvironments(environment).Execute();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}
