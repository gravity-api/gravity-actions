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

namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class WaitForPageTests : ActionTests
    {
        #region *** tests: properties    ***
        public TestContext TestContext { get; set; }
        #endregion

        #region *** tests: life cycle    ***
        [TestInitialize]
        public void Setup()
        {
            Automation.EngineConfiguration.LoadTimeout = 180000;
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void WaitForPageCreate()
        {
            AssertPlugin<WaitForPage>();
        }

        [TestMethod]
        public void WaitForPageDocumentation()
        {
            AssertDocumentation<WaitForPage>(
                pluginName: GravityPlugin.WaitForPage);
        }

        [TestMethod]
        public void WaitForPageDocumentationResourceFile()
        {
            AssertDocumentation<WaitForPage>(
                pluginName: GravityPlugin.WaitForPage,
                resource: "WaitForPage.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void WaitForPagePositive()
        {
            // execute
            ExecuteAction<WaitForPage>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"argument\":\"{{$ --until:false --timeout:00:00:00}}\"}")]
        public void WaitForPageTimeout(string actionRule)
        {
            // setup
            Automation.EngineConfiguration.LoadTimeout = 0;

            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(Stopwatch.ElapsedMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:uninitialized}}\"}")]
        public void WaitForPageUninitialized(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:loading}}\"}")]
        public void WaitForPageLoading(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:loaded}}\"}")]
        public void WaitForPageLoaded(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:interactive}}\"}")]
        public void WaitForPageInteractive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:complete}}\"}")]
        public void WaitForPageComplete(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow("{\"argument\":\"{{$ --until:not_a_state}}\"}")]
        public void WaitForPageNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:uninitialized}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementUninitialized(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:loading}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementLoading(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:loaded}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementLoaded(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:interactive}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementInteractive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --until:complete}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementComplete(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow("{\"argument\":\"{{$ --until:not_a_state}}\",\"onElement\":\".//positive\"}")]
        public void WaitForPageElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}