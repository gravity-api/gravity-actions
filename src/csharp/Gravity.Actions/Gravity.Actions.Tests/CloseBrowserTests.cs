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
    public class CloseBrowserTests : ActionTests
    {
        [TestMethod]
        public void CloseBrowserPositive()
        {
            // setup            
            var _actionRule = GetActionRule(string.Empty);
            var action = ActionFactory<CloseBrowser>(WebAutomation);

            // assert that at least browser is currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1);

            // execute
            action.OnPerform(_actionRule);

            // assert that browser is currently closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 0);
        }

        [TestMethod, ExpectedException(typeof(WebDriverException))]
        public void CloseBrowserException()
        {
            // setup            
            var _actionRule = GetActionRule(string.Empty);
            var action = ActionFactory<CloseBrowser>(WebAutomation, new Dictionary<string, object>
            {
                [MockCapabilities.ThrowOnClose] = true
            });

            // execute
            action.OnPerform(_actionRule);
        }
    }
}