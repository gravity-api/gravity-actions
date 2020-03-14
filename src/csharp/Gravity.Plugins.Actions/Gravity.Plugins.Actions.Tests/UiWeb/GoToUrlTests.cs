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
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class GoToUrlTests : ActionTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            WebDriver = new MockWebDriver();
        }

        [TestMethod]
        public void GoToUrlCreate()
        {
            ValidateAction<GoToUrl>();
        }

        [TestMethod]
        public void GoToUrlDocumentation()
        {
            ValidateActionDocumentation<GoToUrl>(WebPlugins.GoToUrl);
        }

        [TestMethod]
        public void GoToUrlDocumentationResourceFile()
        {
            ValidateActionDocumentation<GoToUrl>(WebPlugins.GoToUrl, "go_to_url.json");
        }

        [TestMethod]
        [DataRow("{'argument':'http://noaddress.io'}")]
        public void GoToUrlPositive(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'{{$ --url:http://noaddress.io --blank}}'}")]
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
        [DataRow("{'argument':'{{$ --url:http://noaddress.io --blank}}'}")]
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
        [DataRow("{'elementToActOn':'//positive'}")]
        public void GoToUrlText(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "Mock: Positive Element", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'elementToActOn':'//positive', 'elementAttributeToActOn':'href'}")]
        public void GoToUrlAttribute(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://m.from-href.io/", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'http://noaddress.io'}")]
        public void GoToUrlAppiumDriver(string actionRule)
        {
            // setup
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'http://noaddress.io'}")]
        public void GoToUrlElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'{{$ --url:http://noaddress.io --user:myUesr --password:myPassword}}'}")]
        public void GoToUrlElementCredentials(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'{{$ --url:http://noaddress.io --blank}}'}")]
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
        [DataRow("{'argument':'{{$ --url:http://noaddress.io --blank}}'}")]
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
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void GoToUrlElementText(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "Mock: Positive Element", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'elementToActOn':'.//positive', 'elementAttributeToActOn':'href'}")]
        public void GoToUrlElementAttribute(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual(expected: "http://m.from-href.io/", actual: WebDriver.Url);
        }

        [TestMethod]
        [DataRow("{'argument':'http://noaddress.io'}")]
        public void GoToUrlElementAppiumDriver(string actionRule)
        {
            // setup
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<GoToUrl>(MockBy.Positive(),actionRule);

            // assertion
            Assert.AreEqual(expected: "http://noaddress.io", actual: WebDriver.Url);
        }
    }
}
#pragma warning restore S4144