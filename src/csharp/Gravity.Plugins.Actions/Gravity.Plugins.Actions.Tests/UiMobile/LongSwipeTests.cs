/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiMobile;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiMobile
{
    [TestClass]
    public class LongSwipeTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void LongSwipeCreate() => AssertPlugin<LongSwipe>();

        [TestMethod]
        public void LongSwipeDocumentation()
        {
            AssertDocumentation<LongSwipe>(
                pluginName: GravityPlugins.LongSwipe);
        }

        [TestMethod]
        public void LongSwipeDocumentationResourceFile()
        {
            AssertDocumentation<LongSwipe>(
                pluginName: GravityPlugins.LongSwipe,
                resource: "LongSwipe.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:100,100 --target:200,200}}\"}")]
        public void LongSwipeCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeCoordinatesNoSource(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:100,100}}\"}")]
        public void LongSwipeCoordinatesNoTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LongSwipeCoordinatesNoArguments()
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source://positive --target:200,200}}\"}")]
        public void LongSwipeTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --source:#positive --target:200,200}}\"}")]
        public void LongSwipeTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipePositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target://positive --source:200,200}}\"}")]
        public void LongSwipeCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --target:#positive --source:200,200}}\"}")]
        public void LongSwipeCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void LongSwipeCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void LongSwipeCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//null\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//null\"}")]
        public void LongSwipeTimeout(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//stale\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//stale\"}")]
        public void LongSwipeStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//none\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//none\"}")]
        public void LongSwipeNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//exception\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//exception\"}")]
        public void LongSwipeException(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:.//positive --target:200,200}}\"}")]
        public void LongSwipeElementTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --source:#positive --target:200,200}}\"}")]
        public void LongSwipeElementTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementPositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target:.//positive --source:200,200}}\"}")]
        public void LongSwipeElementCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --target:#positive --source:200,200}}\"}")]
        public void LongSwipeElementCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void LongSwipeElementCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void LongSwipeElementCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void LongSwipeElementException(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144