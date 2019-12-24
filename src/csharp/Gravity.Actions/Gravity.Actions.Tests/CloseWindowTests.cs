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
        [DataRow("{'Argument':'1'}")]
        [DataRow("{'Argument':'2'}")]
        public void CloseWindowPositive(string actionRule)
        {
            // setup            
            var _actionRule = GetActionRule(actionRule);
            var action = ActionFactory<CloseWindow>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // get window number for assertion
            var window = WebDriver.WindowHandles[int.Parse(_actionRule.Argument)];

            // execute
            action.OnPerform(_actionRule);

            // assert that the window is now closed
            Assert.IsFalse(WebDriver.WindowHandles.Any(i => i.Equals(window)));
        }

        [DataTestMethod]
        [DataRow("{'Argument':'1'}")]
        [DataRow("{'Argument':'2'}")]
        public void CloseWindowElementPositive(string actionRule)
        {
            // setup            
            var _actionRule = GetActionRule(actionRule);
            var action = ActionFactory<CloseWindow>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // get window number for assertion
            var window = WebDriver.WindowHandles[int.Parse(_actionRule.Argument)];

            // execute
            action.OnPerform(element, _actionRule);

            // assert that the window is now closed
            Assert.IsFalse(WebDriver.WindowHandles.Any(i => i.Equals(window)));
        }

        [DataTestMethod]
        [DataRow("{'Argument':'notAnumber'}")]
        public void CloseWindowNegative(string actionRule)
        {
            // setup            
            var _actionRule = GetActionRule(actionRule);
            var action = ActionFactory<CloseWindow>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // execute
            action.OnPerform(_actionRule);

            // assert that no window has been closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == NumberOfWindows + 1);
        }
    }
}