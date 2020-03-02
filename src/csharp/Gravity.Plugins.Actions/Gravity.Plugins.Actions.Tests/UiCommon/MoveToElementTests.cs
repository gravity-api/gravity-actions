/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class MoveToElementTests : ActionTests
    {
        [TestMethod]
        public void MoveToElementCreate()
        {
            ValidateAction<MoveToElement>();
        }

        [TestMethod]
        public void MoveToElementDocumentation()
        {
            ValidateActionDocumentation<MoveToElement>(CommonPlugins.MoveToElement);
        }

        [TestMethod]
        public void MoveToElementDocumentationResourceFile()
        {
            ValidateActionDocumentation<MoveToElement>(
                CommonPlugins.MoveToElement, "move-to-element.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        [DataRow("{'elementToActOn':'//negative'}")]
        public void MoveToElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        [DataRow("{'elementToActOn':'//null'}")]
        [DataRow("{'elementToActOn':'//stale'}")]
        public void MoveToElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'//exception'}")]
        public void MoveToElementException(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        [DataRow("{'elementToActOn':'.//negative'}")]
        public void MoveToNestedElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void MoveToNestedElementNone(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("{'elementToActOn':'.//null'}")]
        public void MoveToNestedElementNull(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale'}")]
        public void MoveToNestedElementStale(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'.//exception'}")]
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