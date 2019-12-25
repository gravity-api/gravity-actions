/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.Services.ActionPlugins.Tests
{
    [TestClass]
    public class CloseWindowTests : ActionTests
    {
        private const int NumberOfWindows = 5;

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