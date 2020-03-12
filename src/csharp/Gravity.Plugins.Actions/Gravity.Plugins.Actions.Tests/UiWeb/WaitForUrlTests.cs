/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class WaitForUrlTests : ActionTests
    {
        [TestMethod]
        public void WaitForUrlCreate()
        {
            ValidateAction<WaitForUrl>();
        }

        [TestMethod]
        public void WaitForUrlDocumentation()
        {
            ValidateActionDocumentation<WaitForUrl>(WebPlugins.WaitForUrl);
        }

        [TestMethod]
        public void WaitForUrlDocumentationResourceFile()
        {
            ValidateActionDocumentation<WaitForUrl>(WebPlugins.WaitForUrl, "wait_for_url.json");
        }

        [DataTestMethod]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlPositive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'regularExpression':'negative'}")]
        public void WaitForUrlNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'2000','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'00:00:02','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'{{$ --timeout:2000}}','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'{{$ --timeout:00:00:02}}','regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlPositiveTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'1000','regularExpression':'negative'}")]
        [DataRow("{'argument':'00:00:01','regularExpression':'negative'}")]
        [DataRow("{'argument':'{{$ --timeout:1000}}','regularExpression':'negative'}")]
        [DataRow("{'argument':'{{$ --timeout:00:00:01}}','regularExpression':'negative'}")]
        public void WaitForUrlNegativeTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementNone(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.None(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementNull(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Null(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementStale(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Stale(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementException(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Exception(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'regularExpression':'negative'}")]
        public void WaitForUrlElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'2000','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'00:00:02','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'{{$ --timeout:2000}}','regularExpression':'mockgravityapiurl'}")]
        [DataRow("{'argument':'{{$ --timeout:00:00:02}}','regularExpression':'mockgravityapiurl'}")]
        public void WaitForUrlElementPositiveTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'1000','regularExpression':'negative'}")]
        [DataRow("{'argument':'00:00:01','regularExpression':'negative'}")]
        [DataRow("{'argument':'{{$ --timeout:1000}}','regularExpression':'negative'}")]
        [DataRow("{'argument':'{{$ --timeout:00:00:01}}','regularExpression':'negative'}")]
        public void WaitForUrlElementNegativeTimeout(string actionRule)
        {
            // execute
            ExecuteAction<WaitForUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }
    }
}
#pragma warning restore S4144