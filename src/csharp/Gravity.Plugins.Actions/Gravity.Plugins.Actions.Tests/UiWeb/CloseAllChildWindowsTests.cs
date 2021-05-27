/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Contracts;

namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class CloseAllChildWindowsTests : ActionTests
    {
        #region *** tests: constants     ***
        private const int NumberOfWindows = 5;
        private const string MessageNoWindows = "No child windows are currently active.";
        private const string MessageStillActive = "Some child windows are still active.";
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void CloseAllChildWindowsCreate()
        {
            AssertPlugin<CloseAllChildWindows>();
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentation()
        {
            AssertDocumentation<CloseAllChildWindows>(
                pluginName: GravityPlugins.CloseAllChildWindows);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationResourceFile()
        {
            AssertDocumentation<CloseAllChildWindows>(
                pluginName: GravityPlugins.CloseAllChildWindows,
                resource: "CloseAllChildWindows.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void CloseAllPositive()
        {
            // open child windows
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            ExecuteAction<CloseAllChildWindows>();

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\"}")]
        public void CloseAllElementPositive(string actionRule)
        {
            // open child windows
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            ExecuteAction<CloseAllChildWindows>(By.XPath("//positive"), actionRule);

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }
        #endregion
    }
}