﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class SendKeysTest : ActionTests
    {
        [TestMethod]
        public void SendKeysCreateNoTypes()
        {
            ValidateAction<SendKeys>();
        }

        [TestMethod]
        public void SendKeysCreateTypes()
        {
            ValidateAction<SendKeys>(Types);
        }

        [TestMethod]
        public void SendKeysDocumentationNoTypes()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS);
        }

        [TestMethod]
        public void SendKeysDocumentationTypes()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS, Types);
        }

        [TestMethod]
        public void SendKeysDocumentationResourceFile()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS, Types, "send-keys.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'unitTesting'}")]
        public void SendKeysPositive(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'elementToActOn':'//negative','argument':'unitTesting'}")]
        public void SendKeysNegative(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --keys:unitTesting --clear}}'}")]
        public void SendKeysClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClear(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
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
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClearNull(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --keys:unitTesting --forceClear}}'}")]
        public void SendKeysForceClearException(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --keys:unitTesting --interval:100}}'}")]
        public void SendKeysInterval(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
        public void SendKeysCombination(string actionRule)
        {
            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --down:control --keys:a}}'}")]
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
        [DataRow("{'elementToActOn':'//positive','argument':'android'}")]
        public void SendKeysAppium(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SendKeys>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144