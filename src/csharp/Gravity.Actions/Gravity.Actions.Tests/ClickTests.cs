/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Gravity.Services.ActionPlugins.Tests
{
    [TestClass]
    public class ClickTests
    {
        [TestMethod]
        public void ClickPositive()
        {
            // setup
            var driver = new MockWebDriver();
            var actionRule = new ActionRule { ElementToActOn = "//positive" };

            // execute
            var click = new Click(driver, null);
            click.OnPerform(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        public void ClickNoElement()
        {
            // setup
            var driver = new MockWebDriver();
            var actionRule = new ActionRule { ElementToActOn = "//none" };

            // execute
            var click = new Click(driver, null);
            click.OnPerform(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ClickFlat()
        {
            // setup
            var driver = new MockWebDriver();
            var actionRule = new ActionRule();

            // execute
            var click = new Click(driver, null);
            click.OnPerform(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
