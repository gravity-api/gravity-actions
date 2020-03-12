/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Gravity.Plugins.Actions.Contracts;

namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class CloseWindowTests : ActionTests
    {
        private const int NumberOfWindows = 5;

        [TestMethod]
        public void CloseWindowCreate()
        {
            ValidateAction<CloseWindow>();
        }

        [TestMethod]
        public void CloseWindowDocumentation()
        {
            ValidateActionDocumentation<CloseWindow>(WebPlugins.CloseWindow);
        }

        [TestMethod]
        public void CloseWindowDocumentationResourceFile()
        {
            ValidateActionDocumentation<CloseWindow>(
                WebPlugins.CloseWindow, "close_window.json");
        }

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
    }
}