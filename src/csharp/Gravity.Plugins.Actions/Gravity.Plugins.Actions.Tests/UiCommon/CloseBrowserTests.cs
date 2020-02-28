/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;

namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class CloseBrowserTests : ActionTests
    {
        [TestMethod]
        public void CloseBrowserCreate()
        {
            ValidateAction<CloseBrowser>();
        }

        [TestMethod]
        public void CloseBrowserDocumentation()
        {
            ValidateActionDocumentation<CloseBrowser>(CommonPlugins.CloseBrowser);
        }

        [TestMethod]
        public void CloseBrowserDocumentationResourceFile()
        {
            ValidateActionDocumentation<CloseBrowser>(
                CommonPlugins.CloseBrowser, "close-browser.json");
        }

        [TestMethod]
        public void CloseBrowserPositive()
        {
            // assert that at least browser is currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1);

            // execute
            ExecuteAction<CloseBrowser>();

            // assert that browser is currently closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 0);
        }

        [TestMethod, ExpectedException(typeof(WebDriverException))]
        public void CloseBrowserException()
        {
            // execute
            ExecuteAction<CloseBrowser>(new Dictionary<string, object>
            {
                [MockCapabilities.ThrowOnClose] = true
            });
        }
    }
}