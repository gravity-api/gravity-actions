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
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class TryClickTests : ActionTests
    {
        [TestMethod]
        public void TryClickCreate()
        {
            AssertPlugin<TryClick>();
        }

        [TestMethod]
        public void TryClickDocumentation()
        {
            AssertDocumentation<TryClick>(WebPlugins.TryClick);
        }

        [TestMethod]
        public void TryClickDocumentationResourceFile()
        {
            AssertDocumentation<TryClick>(WebPlugins.TryClick, "try_click.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void TryClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale'}")]
        public void TryClickStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//exception'}")]
        public void TryClickException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null'}")]
        public void TryClickNull(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        public void TryClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void TryClickElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale'}")]
        public void TryClickElementStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//exception'}")]
        public void TryClickElementException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null'}")]
        public void TryClickElementNull(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        public void TryClickElementNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144