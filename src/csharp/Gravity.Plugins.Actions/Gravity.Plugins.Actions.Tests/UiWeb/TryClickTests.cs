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

namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class TryClickTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void TryClickCreate()
        {
            AssertPlugin<TryClick>();
        }

        [TestMethod]
        public void TryClickDocumentation()
        {
            AssertDocumentation<TryClick>(
                pluginName: GravityPlugins.TryClick);
        }

        [TestMethod]
        public void TryClickDocumentationResourceFile()
        {
            AssertDocumentation<TryClick>(
                pluginName: GravityPlugins.TryClick,
                resource: "TryClick.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\"}")]
        [DataRow("{\"onElement\":\"//negative\"}")]
        public void TryClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\"//none\"}")]
        public void TryClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//null\"}")]
        public void TryClickTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\"//stale\"}")]
        public void TryClickStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\"//exception\"}")]
        public void TryClickException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\"}")]
        [DataRow("{\"onElement\":\".//negative\"}")]
        public void TryClickElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//null\"}")]
        public void TryClickElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\"}")]
        public void TryClickElementStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\"}")]
        public void TryClickElementException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\"}")]
        public void TryClickElementNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}