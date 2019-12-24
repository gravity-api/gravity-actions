/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests
{
    [TestClass]
    public class ClickTests : ActionTests
    {
        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ClickPositive(string actionRule)
        {
            // execute
            GetClick(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void ClickNoElement(string actionRule)
        {
            // execute
            GetClick(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ClickFlat(string actionRule)
        {
            // execute
            GetClick(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:NoAlert}}','ElementToActOn':'//positive'}")]
        public void ClickUntilNoAlert(string actionRule)
        {
            // execute
            GetClick(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ClickElementAbsolutePositive(string actionRule)
        {
            // setup
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // execute
            GetClick(element, actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void ClickElementRelativePositive(string actionRule)
        {
            // setup
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // execute
            GetClick(element, actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void ClickElementAbsoluteNoElement(string actionRule)
        {
            // setup
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // execute
            GetClick(element, actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void ClickElementRelativeNoElement(string actionRule)
        {
            // setup
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // execute
            GetClick(element, actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ClickElementFlat(string actionRule)
        {
            // setup
            var element = WebDriver.FindElement(By.XPath("//positive"));

            // execute
            GetClick(element, actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        // base unit test for all element actions
        private void GetClick(IWebElement element, string actionRule, IDictionary<string, object> capabilities = null)
        {
            // setup
            var _actionRule = GetActionRule(actionRule);

            // execute
            var action = ActionFactory<Click>(WebAutomation, capabilities);
            action.OnPerform(element, _actionRule);
        }

        // base unit test for all non-element actions
        private void GetClick(string actionRule, IDictionary<string, object> capabilities = null)
        {
            // setup
            var _actionRule = GetActionRule(actionRule);

            // execute
            var action = ActionFactory<Click>(WebAutomation, capabilities);
            action.OnPerform(_actionRule);
        }
    }
}
#pragma warning restore S4144