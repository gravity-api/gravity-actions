/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiMobile;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiMobile
{
    [TestClass]
    public class LongSwipeTests : ActionTests
    {
        [TestMethod]
        public void LongSwipeCreate() => AssertPlugin<LongSwipe>();

        [TestMethod]
        public void LongSwipeDocumentation()
            => AssertDocumentation<LongSwipe>(MobilePlugins.LongSwipe);

        [TestMethod]
        public void LongSwipeDocumentationResourceFile()
            => AssertDocumentation<LongSwipe>(MobilePlugins.LongSwipe, "long_swipe.json");

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:100,100 --target:200,200}}'}")]
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
        [DataRow("{'argument':'{{$ --target:200,200}}'}")]
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
        [DataRow("{'argument':'{{$ --source:100,100}}'}")]
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
        [DataRow("{'argument':'{{$ --source://positive --target:200,200}}'}")]
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
        [DataRow("{'locator':'CssSelector','argument':'{{$ --source:#positive --target:200,200}}'}")]
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
        [DataRow("{'onElement':'//positive','argument':'{{$ --target:200,200}}'}")]
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
        [DataRow("{'onElement':'//negative','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeNoneToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeStaleToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeNullToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --target://positive --source:200,200}}'}")]
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
        [DataRow("{'locator':'CssSelector','argument':'{{$ --target:#positive --source:200,200}}'}")]
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
        [DataRow("{'onElement':'//positive','argument':'{{$ --source:200,200}}'}")]
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
        [DataRow("{'onElement':'//negative','argument':'{{$ --source:200,200}}'}")]
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
        [DataRow("{'onElement':'//none','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeCoordinatesToNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeCoordinatesToStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeCoordinatesToNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:.//positive --target:200,200}}'}")]
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
        [DataRow("{'locator':'CssSelector','argument':'{{$ --source:#positive --target:200,200}}'}")]
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
        [DataRow("{'onElement':'.//positive','argument':'{{$ --target:200,200}}'}")]
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
        [DataRow("{'onElement':'.//negative','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeElementNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeElementNoneToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeElementStaleToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'onElement':'.//null','argument':'{{$ --target:200,200}}'}")]
        public void LongSwipeElementNullToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --target:.//positive --source:200,200}}'}")]
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
        [DataRow("{'locator':'CssSelector','argument':'{{$ --target:#positive --source:200,200}}'}")]
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
        [DataRow("{'onElement':'.//positive','argument':'{{$ --source:200,200}}'}")]
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
        [DataRow("{'onElement':'.//negative','argument':'{{$ --source:200,200}}'}")]
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
        [DataRow("{'onElement':'.//none','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeElementCoordinatesToNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeElementCoordinatesToStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'onElement':'.//null','argument':'{{$ --source:200,200}}'}")]
        public void LongSwipeElementCoordinatesToNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144