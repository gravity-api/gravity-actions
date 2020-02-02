﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Common;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Common
{
    [TestClass]
    public class DoubleClickTests : ActionTests
    {
        [TestMethod]
        public void DoubleClickCreateNoTypes()
        {
            ValidateAction<DoubleClick>();
        }

        [TestMethod]
        public void DoubleClickCreateTypes()
        {
            ValidateAction<DoubleClick>(Types);
        }

        [TestMethod]
        public void DoubleClickDocumentationNoTypes()
        {
            ValidateActionDocumentation<DoubleClick>(CommonPlugins.DoubleClick);
        }

        [TestMethod]
        public void DoubleClickDocumentationTypes()
        {
            ValidateActionDocumentation<DoubleClick>(CommonPlugins.DoubleClick, Types);
        }

        [TestMethod]
        public void DoubleClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<DoubleClick>(
                CommonPlugins.DoubleClick, Types, "double-click.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void DoubleClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void DoubleClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickFlat()
        {
            // execute
            ExecuteAction<DoubleClick>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void DoubleClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void DoubleClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','locator':'" + LocatorType.Xpath + "'}")]
        public void DoubleClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void DoubleClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlat()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlatNull()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void DoubleClickElementFlatNullElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144