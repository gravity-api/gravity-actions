/*
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
    public class ConditionUrlTests
    {
        //[Description(description: "P - [0045] - Assert, URL, Equal")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0045P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0045().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0045] - Assert, URL, Equal")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0045N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0045().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0046] - Assert, URL, Not Equal")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0046P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0046().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0046] - Assert, URL, Not Equal")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0046N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0046().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0047] - Assert, URL, Match")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0047P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0047().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0047] - Assert, URL, Match")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0047N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0047().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0048] - Assert, URL, Not Match")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0048P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0048().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0048] - Assert, URL, Not Match")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0048N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0048().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0049] - Assert, URL, Greater Than, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0049P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0049().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0049] - Assert, URL, Greater Than, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0049N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0049().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0050] - Assert, URL, Lower Than, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0050P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0050().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0050] - Assert, URL, Lower Than, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0050N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0050().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0051] - Assert, URL, Greater or Equal, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0051P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0051().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0051] - Assert, URL, Greater or Equal, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0051N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0051().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "P - [0052] - Assert, URL, Lower or Equal, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.Compatibilities))]
        //public void T0052P(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = false;

        //    // execute
        //    var actual = new C0052().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}

        //[Description(description: "N - [0052] - Assert, URL, Lower or Equal, Regular Expression")]
        //[Test, TestCaseSource(typeof(CompatibilityProvider), nameof(CompatibilityProvider.CompatibilitiesChrome))]
        //public void T0052N(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.TestParams["negative"] = true;

        //    // execute
        //    var actual = new C0052().AddEnvironments(environment).Execute();

        //    // assertion
        //    Assert.IsTrue(actual);
        //}
    }
}