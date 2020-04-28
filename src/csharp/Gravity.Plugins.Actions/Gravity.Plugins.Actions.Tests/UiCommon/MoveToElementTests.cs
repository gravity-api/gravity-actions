/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class MoveToElementTests : ActionTests
    {
        [TestMethod]
        public void MoveToElementCreate()
        {
            AssertPlugin<MoveToElement>();
        }

        [TestMethod]
        public void MoveToElementDocumentation()
        {
            AssertDocumentation<MoveToElement>(CommonPlugins.MoveToElement);
        }

        [TestMethod]
        public void MoveToElementDocumentationResourceFile()
        {
            AssertDocumentation<MoveToElement>(
                CommonPlugins.MoveToElement, "move_to_element.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        [DataRow("{'onElement':'//negative'}")]
        public void MoveToElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//stale'}")]
        public void MoveToElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'//exception'}")]
        public void MoveToElementException(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        [DataRow("{'onElement':'.//negative'}")]
        public void MoveToNestedElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void MoveToNestedElementNone(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("{'onElement':'.//null'}")]
        public void MoveToNestedElementNull(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        public void MoveToNestedElementStale(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception'}")]
        public void MoveToNestedElementException(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MoveToElementNoElement()
        {
            // execute
            ExecuteAction<MoveToElement>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144