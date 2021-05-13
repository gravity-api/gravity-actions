/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Contracts;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class GoToUrlTests : ActionTests
    {
        #region *** tests: life cycle    ***
        [TestCleanup]
        public void Cleanup()
        {
            WebDriver = new MockWebDriver();
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void GoToUrlCreate()
        {
            AssertPlugin<GoToUrl>();
        }

        [TestMethod]
        public void GoToUrlDocumentation()
        {
            AssertDocumentation<GoToUrl>(pluginName: PluginsList.GoToUrl);
        }

        [TestMethod]
        public void GoToUrlDocumentationResourceFile()
        {
            AssertDocumentation<GoToUrl>(
                pluginName: PluginsList.GoToUrl,
                resource: "GoToUrl.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        [DataRow("{\"argument\":\"http://noaddress.io\"}")]
        public void GoToUrlPositive(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"{{$ --url:http://noaddress.io --blank}}\"}")]
        public void GoToUrlNewTab(string actionRule)
        {
            // setup
            var expectedCount = WebDriver.WindowHandles.Count + 1;
            var expectedWindow = WebDriver.CurrentWindowHandle;

            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: expectedCount, actual: WebDriver.WindowHandles.Count);
            Assert.AreNotEqual(notExpected: expectedWindow, actual: WebDriver.CurrentWindowHandle);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"{{$ --url:http://noaddress.io --blank}}\"}")]
        public void GoToUrlNewMultipleWindows(string actionRule)
        {
            // setup
            WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = 5
            });
            var expectedCount = WebDriver.WindowHandles.Count + 1;
            var expectedWindow = WebDriver.CurrentWindowHandle;

            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: expectedCount, actual: WebDriver.WindowHandles.Count);
            Assert.AreNotEqual(notExpected: expectedWindow, actual: WebDriver.CurrentWindowHandle);
        }

        [TestMethod]
        [DataRow("{\"onElement\":\"//positive\"}")]
        public void GoToUrlText(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "Mock: Positive Element", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"onElement\":\"//positive\", \"onAttribute\":\"href\"}")]
        [DataRow("{\"onElement\":\"//negative\", \"onAttribute\":\"href\"}")]
        public void GoToUrlAttribute(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://m.from-href.io/", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"http://noaddress.io\"}")]
        public void GoToUrlAppiumDriver(string actionRule)
        {
            // setup
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//null\"}")]
        public void GoToUrlTimeout(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\"//none\"}")]
        public void GoToUrlNone(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\"//stale\"}")]
        public void GoToUrlStale(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\"//exception\"}")]
        public void GoToUrlException(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [TestMethod]
        [DataRow("{\"argument\":\"http://noaddress.io\"}")]
        public void GoToUrlElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"{{$ --url:http://noaddress.io --user:myUesr --password:myPassword}}\"}")]
        public void GoToUrlElementCredentials(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"{{$ --url:http://noaddress.io --blank}}\"}")]
        public void GoToUrlElementNewTab(string actionRule)
        {
            // setup
            var expectedCount = WebDriver.WindowHandles.Count + 1;
            var expectedWindow = WebDriver.CurrentWindowHandle;

            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: expectedCount, actual: WebDriver.WindowHandles.Count);
            Assert.AreNotEqual(notExpected: expectedWindow, actual: WebDriver.CurrentWindowHandle);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"{{$ --url:http://noaddress.io --blank}}\"}")]
        public void GoToUrlElementNewMultipleWindows(string actionRule)
        {
            // setup
            WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = 5
            });
            var expectedCount = WebDriver.WindowHandles.Count + 1;
            var expectedWindow = WebDriver.CurrentWindowHandle;

            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: expectedCount, actual: WebDriver.WindowHandles.Count);
            Assert.AreNotEqual(notExpected: expectedWindow, actual: WebDriver.CurrentWindowHandle);
        }

        [TestMethod]
        [DataRow("{\"onElement\":\".//positive\"}")]
        public void GoToUrlElementText(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "Mock: Positive Element", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"onElement\":\".//positive\", \"onAttribute\":\"href\"}")]
        public void GoToUrlElementAttribute(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://m.from-href.io/", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{\"argument\":\"http://noaddress.io\"}")]
        public void GoToUrlElementAppiumDriver(string actionRule)
        {
            // setup
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\"}")]
        public void GoToUrlElementNone(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow("{\"onElement\":\".//null\"}")]
        public void GoToUrlElementNull(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: string.Empty, actual: WebDriver.Url);
        }

        [TestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\"}")]
        public void GoToUrlElementStale(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\"}")]
        public void GoToUrlElementException(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144