﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
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
        public void KeyboardCreate() => ValidateAction<Keyboard>();

        [TestMethod]
        public void KeyboardDocumentation()
            => ValidateActionDocumentation<Keyboard>(WebPlugins.Keyboard);

        [TestMethod]
        public void KeyboardDocumentationResourceFile()
            => ValidateActionDocumentation<Keyboard>(WebPlugins.Keyboard, "Keyboard.json");

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'Enter'}")]
        public void KeyboardPositive(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'elementToActOn':'//negative','argument':'Enter'}")]
        public void KeyboardNegative(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale','argument':'Enter'}")]
        public void KeyboardStale(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'//exception','argument':'Enter'}")]
        public void KeyboardException(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null','argument':'Enter'}")]
        public void KeyboardNull(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','argument':'Enter'}")]
        public void KeyboardNone(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'NoSuckKey'}")]
        public void KeyboardInvalidKeyName(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'Enter'}")]
        public void KeyboardElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'Enter'}")]
        public void KeyboardElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale','argument':'Enter'}")]
        public void KeyboardElementStale(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'.//exception','argument':'Enter'}")]
        public void KeyboardElementException(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'elementToActOn':'.//null','argument':'Enter'}")]
        public void KeyboardElementNull(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none','argument':'Enter'}")]
        public void KeyboardElementNone(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'NoSuckKey'}")]
        public void KeyboardElementInvalidKeyName(string actionRule)
        {
            // execute
            ExecuteAction<Keyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144