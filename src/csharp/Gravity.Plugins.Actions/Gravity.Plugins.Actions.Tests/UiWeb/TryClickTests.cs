/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
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
            ValidateAction<TryClick>();
        }

        [TestMethod]
        public void TryClickDocumentation()
        {
            ValidateActionDocumentation<TryClick>(WebPlugins.TryClick);
        }

        [TestMethod]
        public void TryClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<TryClick>(WebPlugins.TryClick, "try-click.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void TryClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale'}")]
        public void TryClickStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//exception'}")]
        public void TryClickException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null'}")]
        public void TryClickNull(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void TryClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void TryClickElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale'}")]
        public void TryClickElementStale(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//exception'}")]
        public void TryClickElementException(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null'}")]
        public void TryClickElementNull(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void TryClickElementNoElement(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144