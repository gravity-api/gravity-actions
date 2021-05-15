﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class MoveToElementTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void MoveToElementCreate()
        {
            AssertPlugin<MoveToElement>();
        }

        [TestMethod]
        public void MoveToElementDocumentation()
        {
            AssertDocumentation<MoveToElement>(
                pluginName: PluginsList.MoveToElement);
        }

        [TestMethod]
        public void MoveToElementDocumentationResourceFile()
        {
            AssertDocumentation<MoveToElement>(
                pluginName: PluginsList.MoveToElement,
                resource: "MoveToElement.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\"}")]
        [DataRow("{\"onElement\":\"//negative\"}")]
        public void MoveToElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\"//stale\"}")]
        public void MoveToElementStale(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//null\"}")]
        public void MoveToElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\"//exception\"}")]
        public void MoveToElementException(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\"//none\"}")]
        public void MoveToElementNone(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MoveToElementNoElement()
        {
            // execute
            ExecuteAction<MoveToElement>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\"}")]
        [DataRow("{\"onElement\":\".//negative\"}")]
        public void MoveToNestedElement(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\"}")]
        public void MoveToNestedElementNone(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//null\"}")]
        public void MoveToNestedElementNull(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\"}")]
        public void MoveToNestedElementStale(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\"}")]
        public void MoveToNestedElementException(string actionRule)
        {
            // execute
            ExecuteAction<MoveToElement>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144