/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Gravity.Plugins.Contracts;

namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class CloseBrowserTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void CloseBrowserCreate()
        {
            AssertPlugin<CloseBrowser>();
        }

        [TestMethod]
        public void CloseBrowserDocumentation()
        {
            AssertDocumentation<CloseBrowser>(
                pluginName: GravityPlugins.CloseBrowser);
        }

        [TestMethod]
        public void CloseBrowserDocumentationResourceFile()
        {
            AssertDocumentation<CloseBrowser>(
                pluginName: GravityPlugins.CloseBrowser,
                resource: "CloseBrowser.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
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
        #endregion
    }
}