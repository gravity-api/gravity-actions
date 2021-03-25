/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class WaitForUrlTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void WaitForUrlCreate()
        {
            AssertPlugin<WaitForUrl>();
        }

        [TestMethod]
        public void WaitForUrlDocumentation()
        {
            AssertDocumentation<WaitForUrl>(
                pluginName: PluginsList.WaitForUrl);
        }

        [TestMethod]
        public void WaitForUrlDocumentationResourceFile()
        {
            AssertDocumentation<WaitForUrl>(
                pluginName: PluginsList.WaitForUrl,
                resource: "WaitForUrl.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlPositive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"regularExpression\":\"negative\"}")]
        public void WaitForUrlNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"2000\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"00:00:02\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:2000}}\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:00:00:02}}\",\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlPositiveTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"argument\":\"1000\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"00:00:01\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:1000}}\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:00:00:01}}\",\"regularExpression\":\"negative\"}")]
        public void WaitForUrlNegativeTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementNone(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.None(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementNull(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Null(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementStale(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Stale(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementException(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Exception(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"regularExpression\":\"negative\"}")]
        public void WaitForUrlElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"2000\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"00:00:02\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:2000}}\",\"regularExpression\":\"positive.io\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:00:00:02}}\",\"regularExpression\":\"positive.io\"}")]
        public void WaitForUrlElementPositiveTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"argument\":\"1000\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"00:00:01\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:1000}}\",\"regularExpression\":\"negative\"}")]
        [DataRow("{\"argument\":\"{{$ --timeout:00:00:01}}\",\"regularExpression\":\"negative\"}")]
        public void WaitForUrlElementNegativeTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }
        #endregion
    }
}
#pragma warning restore S4144