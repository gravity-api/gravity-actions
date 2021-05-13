/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Contracts;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

using System;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class UploadFileTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void UploadFileCreate()
        {
            AssertPlugin<UploadFile>();
        }

        [TestMethod]
        public void UploadFileDocumentation()
        {
            AssertDocumentation<UploadFile>(pluginName: PluginsList.UploadFile);
        }

        [TestMethod]
        public void UploadFileDocumentationResourceFile()
        {
            AssertDocumentation<UploadFile>(
                pluginName: PluginsList.UploadFile,
                resource: "UploadFile.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\"//file\"}")]
        public void UploadFilePositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//null\"}")]
        public void UploadFileTimeout(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\"//stale\"}")]
        public void UploadFileStale(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\"//exception\"}")]
        public void UploadFileException(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\"//none\"}")]
        public void UploadFileNoElement(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//file\"}")]
        public void UploadFileElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\"}")]
        public void UploadFileElementStale(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\"}")]
        public void UploadFileElementException(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{\"onElement\":\".//null\"}")]
        public void UploadFileElementNull(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\"}")]
        public void UploadFileElementNone(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144