/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class TryClickTests : ActionTests
    {
        [TestMethod]
        public void TryClickCreateNoTypes()
        {
            ValidateAction<TryClick>();
        }

        [TestMethod]
        public void TryClickCreateTypes()
        {
            ValidateAction<TryClick>(Types);
        }

        [TestMethod]
        public void TryClickDocumentationNoTypes()
        {
            ValidateActionDocumentation<TryClick>(ActionType.TryClick);
        }

        [TestMethod]
        public void TryClickDocumentationTypes()
        {
            ValidateActionDocumentation<TryClick>(ActionType.TryClick, Types);
        }

        [TestMethod]
        public void TryClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<TryClick>(
                ActionType.TryClick, Types, "try-click.json");
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