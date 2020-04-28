/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Appium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Contracts;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class SendKeysTests : ActionTests
    {
        [TestMethod]
        public void SendKeysCreate()
        {
            AssertPlugin<SendKeys>();
        }

        [TestMethod]
        public void SendKeysDocumentation()
        {
            AssertDocumentation<SendKeys>(CommonPlugins.SendKeys);
        }

        [TestMethod]
        public void SendKeysDocumentationResourceFile()
        {
            AssertDocumentation<SendKeys>(CommonPlugins.SendKeys, "send_keys.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'unitTesting'}")]
        public void SendKeysPositive(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'onElement':'//negative','argument':'unitTesting'}")]
        public void SendKeysNegative(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --clear}}'}")]
        public void SendKeysClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClearAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClearNull(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'//exception','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClearException(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --interval:100}}'}")]
        public void SendKeysInterval(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void SendKeysCombination(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void SendKeysCombinationAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'android'}")]
        public void SendKeysAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'unitTesting'}")]
        public void SendKeysElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'onElement':'.//negative','argument':'unitTesting'}")]
        public void SendKeysElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Negative(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --clear}}'}")]
        public void SendKeysElementClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysElementForceClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysElementForceClearAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//null','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysElementForceClearNull(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysElementForceClearException(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --interval:100}}'}")]
        public void SendKeysElementInterval(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void SendKeysElementCombination(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'android'}")]
        public void SendKeysElementAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//invalid-state','argument':'android'}")]
        public void SendKeysAppiumInvalidState(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//invalid-state','argument':'throw new InvalidElementStateException();'}")]
        public void SendKeysElementAppiumInvalidState(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144