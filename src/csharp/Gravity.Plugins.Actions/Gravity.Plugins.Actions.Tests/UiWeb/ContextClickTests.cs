/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ContextClickTests : ActionTests
    {
        [TestMethod]
        public void ContextClickCreate()
        {
            AssertPlugin<ContextClick>();
        }

        [TestMethod]
        public void ContextClickDocumentation()
        {
            AssertDocumentation<ContextClick>(WebPlugins.ContextClick);
        }

        [TestMethod]
        public void ContextClickDocumentationResourceFile()
        {
            AssertDocumentation<ContextClick>(
                WebPlugins.ContextClick, "context_click.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void ContextClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        public void ContextClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContextClickFlat()
        {
            // execute
            ExecuteAction<ContextClick>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:NoAlert}}','onElement':'//positive'}")]
        public void ContextClickUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void ContextClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void ContextClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','locator':'" + LocatorType.Xpath + "'}")]
        public void ContextClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void ContextClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContextClickElementFlat()
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144