/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Cases.UiCommon.AssertScenarios;

using Gravity.IntegrationTests.Base;
using Gravity.IntegrationTests.Providers;

using NUnit.Framework;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Graivty.IntegrationTests.Suites.UiCommon
{
    [TestFixture]
    public class AssertTextLengthTests
    {
        [Description(description: "P - [0218] - Assert, Text Length, Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218A(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --eq:10}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Not Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218B(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ne:10}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsFalse(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Greater")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218C(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --gt:9}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Lower")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218D(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --lt:11}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Greater Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218E(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ge:10}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Greater Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218F(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ge:9}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Lower Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218G(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --le:10}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0218] - Assert, Text Length, Lower Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0218H(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --le:11}}";

            // execute
            var actual = new C0218().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219A(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --eq:9}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Not Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219B(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ne:9}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsFalse(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Greater")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219C(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --gt:8}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Lower")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219D(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --lt:10}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Greater Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219E(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ge:9}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Greater Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219F(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --ge:8}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Lower Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219G(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --le:9}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }

        [Description(description: "P - [0219] - Assert, Text Length, Attribute, Lower Equal")]
        [Test, TestCaseSource(typeof(CapabilitiesProvider), nameof(CapabilitiesProvider.Capabilities))]
        public void T0219H(Context environment)
        {
            // setup
            environment.TestParams["negative"] = false;
            environment.TestParams["argument"] = "{{$ --text_length --le:10}}";

            // execute
            var actual = new C0219().AddEnvironments(environment).Invoke();

            // assertion
            Assert.IsTrue(actual);
        }
    }
}