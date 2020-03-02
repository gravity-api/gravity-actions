/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
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
    public class SwipeTests : ActionTests
    {
        [TestMethod]
        public void SwipeCreate() => ValidateAction<Swipe>();

        [TestMethod]
        public void SwipeDocumentation()
            => ValidateActionDocumentation<Swipe>(MobilePlugins.Swipe);

        [TestMethod]
        public void SwipeDocumentationResourceFile()
            => ValidateActionDocumentation<Swipe>(MobilePlugins.Swipe, "swipe.json");

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:100,100 --target:200,200}}'}")]
        public void SwipeCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --target:200,200}}'}")]
        public void SwipeCoordinatesNoSource(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:100,100}}'}")]
        public void SwipeCoordinatesNoTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SwipeCoordinatesNoArguments()
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source://positive --target:200,200}}'}")]
        public void SwipeTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'locator':'CssSelector','argument':'{{$ --source:#positive --target:200,200}}'}")]
        public void SwipeTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --target:200,200}}'}")]
        public void SwipePositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --target:200,200}}'}")]
        public void SwipeNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --target:200,200}}'}")]
        public void SwipeNoneToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --target:200,200}}'}")]
        public void SwipeStaleToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --target:200,200}}'}")]
        public void SwipeNullToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --target://positive --source:200,200}}'}")]
        public void SwipeCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'locator':'CssSelector','argument':'{{$ --target:#positive --source:200,200}}'}")]
        public void SwipeCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --source:200,200}}'}")]
        public void SwipeCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --source:200,200}}'}")]
        public void SwipeCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --source:200,200}}'}")]
        public void SwipeCoordinatesToNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --source:200,200}}'}")]
        public void SwipeCoordinatesToStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --source:200,200}}'}")]
        public void SwipeCoordinatesToNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:.//positive --target:200,200}}'}")]
        public void SwipeElementTargetToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'locator':'CssSelector','argument':'{{$ --source:#positive --target:200,200}}'}")]
        public void SwipeElementTargetCssToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --target:200,200}}'}")]
        public void SwipeElementPositiveToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --target:200,200}}'}")]
        public void SwipeElementNegativeToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --target:200,200}}'}")]
        public void SwipeElementNoneToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --target:200,200}}'}")]
        public void SwipeElementStaleToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --target:200,200}}'}")]
        public void SwipeElementNullToCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --target:.//positive --source:200,200}}'}")]
        public void SwipeElementCoordinatesToTarget(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'locator':'CssSelector','argument':'{{$ --target:#positive --source:200,200}}'}")]
        public void SwipeElementCoordinatesToTargetCss(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --source:200,200}}'}")]
        public void SwipeElementCoordinatesToPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --source:200,200}}'}")]
        public void SwipeElementCoordinatesToNegative(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --source:200,200}}'}")]
        public void SwipeElementCoordinatesToNone(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --source:200,200}}'}")]
        public void SwipeElementCoordinatesToStale(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --source:200,200}}'}")]
        public void SwipeElementCoordinatesToNull(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<Swipe>(by: MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144