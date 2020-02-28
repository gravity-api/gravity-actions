/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Common;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;

namespace Gravity.Plugins.Actions.UnitTests.Common
{
    [TestClass]
    public class CloseBrowserTests : ActionTests
    {
        [TestMethod]
        public void CloseBrowserCreateNoTypes()
        {
            ValidateAction<CloseBrowser>();
        }

        [TestMethod]
        public void CloseBrowserCreateTypes()
        {
            ValidateAction<CloseBrowser>(Types);
        }

        [TestMethod]
        public void CloseBrowserDocumentationNoTypes()
        {
            ValidateActionDocumentation<CloseBrowser>(CommonPlugins.CloseBrowser);
        }

        [TestMethod]
        public void CloseBrowserDocumentationTypes()
        {
            ValidateActionDocumentation<CloseBrowser>(CommonPlugins.CloseBrowser, Types);
        }

        [TestMethod]
        public void CloseBrowserDocumentationResourceFile()
        {
            ValidateActionDocumentation<CloseBrowser>(
                CommonPlugins.CloseBrowser, Types, "close-browser.json");
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