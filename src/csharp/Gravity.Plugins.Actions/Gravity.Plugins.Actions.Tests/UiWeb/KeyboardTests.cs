/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class KeyboardTests : ActionTests
    {
        [TestMethod]
        public void KeyboardCreate() => AssertPlugin<Keyboard>();

        [TestMethod]
        public void KeyboardDocumentation()
            => AssertDocumentation<Keyboard>(WebPlugins.Keyboard);

        [TestMethod]
        public void KeyboardDocumentationResourceFile()
            => AssertDocumentation<Keyboard>(WebPlugins.Keyboard, "Keyboard.json");

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'Enter'}")]
        public void KeyboardPositive(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'onElement':'//negative','argument':'Enter'}")]
        public void KeyboardNegative(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale','argument':'Enter'}")]
        public void KeyboardStale(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'//exception','argument':'Enter'}")]
        public void KeyboardException(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'Enter'}")]
        public void KeyboardNull(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','argument':'Enter'}")]
        public void KeyboardNone(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive','argument':'NoSuckKey'}")]
        public void KeyboardInvalidKeyName(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'Enter'}")]
        public void KeyboardElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'onElement':'.//negative','argument':'Enter'}")]
        public void KeyboardElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale','argument':'Enter'}")]
        public void KeyboardElementStale(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception','argument':'Enter'}")]
        public void KeyboardElementException(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'onElement':'.//null','argument':'Enter'}")]
        public void KeyboardElementNull(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none','argument':'Enter'}")]
        public void KeyboardElementNone(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'NoSuckKey'}")]
        public void KeyboardElementInvalidKeyName(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144