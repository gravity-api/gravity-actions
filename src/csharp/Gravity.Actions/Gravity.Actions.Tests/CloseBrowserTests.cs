/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Tests
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
            ValidateActionDocumentation<CloseBrowser>(ActionType.CLOSE_BROWSER);
        }

        [TestMethod]
        public void CloseBrowserDocumentationTypes()
        {
            ValidateActionDocumentation<CloseBrowser>(ActionType.CLOSE_BROWSER, Types);
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