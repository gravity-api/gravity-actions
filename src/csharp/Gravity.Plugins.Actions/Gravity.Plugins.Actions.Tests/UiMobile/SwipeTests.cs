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
    public class SwipeTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SwipeCreate() => AssertPlugin<Swipe>();

        [TestMethod]
        public void SwipeDocumentation()
        {
            AssertDocumentation<Swipe>(pluginName: GravityPlugins.Swipe);
        }

        [TestMethod]
        public void SwipeDocumentationResourceFile()
        {
            AssertDocumentation<Swipe>(
                pluginName: GravityPlugins.Swipe,
                resource: "swipe.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:100,100 --target:200,200}}\"}")]
        public void SwipeCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeCoordinatesNoSource(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:100,100}}\"}")]
        public void SwipeCoordinatesNoTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SwipeCoordinatesNoArguments()
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source://positive --target:200,200}}\"}")]
        public void SwipeTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --source:#positive --target:200,200}}\"}")]
        public void SwipeTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipePositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target://positive --source:200,200}}\"}")]
        public void SwipeCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --target:#positive --source:200,200}}\"}")]
        public void SwipeCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void SwipeCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void SwipeCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --source:.//positive --target:200,200}}\"}")]
        public void SwipeElementTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --source:#positive --target:200,200}}\"}")]
        public void SwipeElementTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//null\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//null\"}")]
        public void SwipeTimeout(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//none\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//none\"}")]
        public void SwipeNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//stale\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//stale\"}")]
        public void SwipeStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"argument\":\"{{$ --source:200,200}}\",\"onElement\":\"//exception\"}")]
        [DataRow("{\"argument\":\"{{$ --target:200,200}}\",\"onElement\":\"//exception\"}")]
        public void SwipeException(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementPositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --target:.//positive --source:200,200}}\"}")]
        public void SwipeElementCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"locator\":\"CssSelector\",\"argument\":\"{{$ --target:#positive --source:200,200}}\"}")]
        public void SwipeElementCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void SwipeElementCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --source:200,200}}\"}")]
        public void SwipeElementCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --source:200,200}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --target:200,200}}\"}")]
        public void SwipeElementException(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144