/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class TrySendKeysTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void TrySendKeysCreate()
        {
            AssertPlugin<TrySendKeys>();
        }

        [TestMethod]
        public void TrySendKeysDocumentation()
        {
            AssertDocumentation<TrySendKeys>(
                pluginName: PluginsList.TrySendKeys);
        }

        [TestMethod]
        public void TrySendKeysDocumentationResourceFile()
        {
            AssertDocumentation<TrySendKeys>(
                pluginName: PluginsList.TrySendKeys,
                resource: "try_send_keys.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'unitTesting'}")]
        public void TrySendKeysPositive(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --clear}}'}")]
        public void TrySendKeysClear(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void TrySendKeysForceClear(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void TrySendKeysForceClearAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        [DataRow("{'onElement':'//stale','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        [DataRow("{'onElement':'//none','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        [DataRow("{'onElement':'//exception','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        [DataRow("{'onElement':'//negative','argument':'unitTesting'}")]
        public void TrySendKeysForceClearTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --keys:unitTesting --interval:100}}'}")]
        public void TrySendKeysInterval(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void TrySendKeysCombination(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void TrySendKeysCombinationAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'android'}")]
        public void TrySendKeysAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'unitTesting'}")]
        public void TrySendKeysElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'.//null','argument':'unitTesting'}")]
        [DataRow("{'onElement':'.//exception','argument':'unitTesting'}")]
        [DataRow("{'onElement':'.//stale','argument':'unitTesting'}")]
        [DataRow("{'onElement':'.//none','argument':'unitTesting'}")]
        [DataRow("{'onElement':'.//negative','argument':'unitTesting'}")]
        public void TrySendKeysElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Negative(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --clear}}'}")]
        public void TrySendKeysElementClear(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void TrySendKeysElementForceClear(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void TrySendKeysElementForceClearAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --keys:unitTesting --interval:100}}'}")]
        public void TrySendKeysElementInterval(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void TrySendKeysElementCombination(string actionRule)
        {
            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'android'}")]
        public void TrySendKeysElementAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//invalid-state','argument':'android'}")]
        public void TrySendKeysAppiumInvalidState(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//invalid-state','argument':'throw new InvalidElementStateException();'}")]
        public void TrySendKeysElementAppiumInvalidState(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<TrySendKeys>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144