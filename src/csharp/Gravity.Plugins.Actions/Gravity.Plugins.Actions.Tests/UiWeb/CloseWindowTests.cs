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
using System.Linq;
using Gravity.Plugins.Contracts;

namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class CloseWindowTests : ActionTests
    {
        #region *** tests: constants     ***
        private const int NumberOfWindows = 5;
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void CloseWindowCreate()
        {
            AssertPlugin<CloseWindow>();
        }

        [TestMethod]
        public void CloseWindowDocumentation()
        {
            AssertDocumentation<CloseWindow>(
                pluginName: PluginsList.CloseWindow);
        }

        [TestMethod]
        public void CloseWindowDocumentationResourceFile()
        {
            AssertDocumentation<CloseWindow>(
               pluginName: PluginsList.CloseWindow,
               resource: "close_window.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'1'}", 1)]
        [DataRow("{'argument':'2'}", 2)]
        public void CloseWindowPositive(string actionRule, int windowsHandle)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // get window number for assertion
            var window = WebDriver.WindowHandles[windowsHandle];

            // execute
            ExecuteAction<CloseWindow>(actionRule);

            // assert that the window is now closed
            Assert.IsFalse(WebDriver.WindowHandles.Any(i => i.Equals(window)));
        }

        [DataTestMethod]
        [DataRow("{'argument':'10'}")]
        public void CloseWindowOutOfBound(string actionRule)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // execute
            ExecuteAction<CloseWindow>(actionRule);

            // assert that the window is now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == NumberOfWindows + 1);
        }

        [DataTestMethod]
        [DataRow("{'argument':'1'}", 1)]
        [DataRow("{'argument':'2'}", 2)]
        public void CloseWindowElementPositive(string actionRule, int windowsHandle)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // get window number for assertion
            var window = WebDriver.WindowHandles[windowsHandle];

            // execute
            ExecuteAction<CloseWindow>(By.XPath("//positive"), actionRule);

            // assert that the window is now closed
            Assert.IsFalse(WebDriver.WindowHandles.Any(i => i.Equals(window)));
        }

        [DataTestMethod]
        [DataRow("{'argument':'10'}")]
        public void CloseWindowElementOutOfBound(string actionRule)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // execute
            ExecuteAction<CloseWindow>(By.XPath("//positive"), actionRule);

            // assert that the window is now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == NumberOfWindows + 1);
        }

        [DataTestMethod]
        [DataRow("{'argument':'notAnumber'}")]
        public void CloseWindowNegative(string actionRule)
        {
            // execute
            ExecuteAction<CloseWindow>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that no window has been closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == NumberOfWindows + 1);
        }
        #endregion
    }
}