/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Tests
{
    [TestClass]
    public class CloseAllChildWindowsTests : ActionTests
    {
        private const int NumberOfWindows = 5;
        private const string MessageNoWindows = "No child windows are currently active.";
        private const string MessageStillActive = "Some child windows are still active.";

        [TestMethod]
        public void CloseAllPositive()
        {
            // setup            
            var _actionRule = GetActionRule(string.Empty);
            var action = ActionFactory<CloseAllChildWindows>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            action.OnPerform(_actionRule);

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void CloseAllElementPositive(string actionRule)
        {
            // setup            
            var _actionRule = GetActionRule(actionRule);
            var action = ActionFactory<CloseAllChildWindows>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            action.OnPerform(element, _actionRule);

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }
    }
}
