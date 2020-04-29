/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */

using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ContextClickTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void ContextClickCreate()
        {
            AssertPlugin<ContextClick>();
        }

        [TestMethod]
        public void ContextClickDocumentation()
        {
            AssertDocumentation<ContextClick>(
                pluginName: WebPlugins.ContextClick);
        }

        [TestMethod]
        public void ContextClickDocumentationResourceFile()
        {
            AssertDocumentation<ContextClick>(
                pluginName: WebPlugins.ContextClick,
                resource:"context_click.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void ContextClickFlat()
        {
            // execute
            ExecuteAction<ContextClick>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        [DataRow("{'onElement':'//negative'}")]
        public void ContextClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:NoAlert}}','onElement':'//positive'}")]
        public void ContextClickUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//stale'}")]
        [DataRow("{'onElement':'//exception'}")]
        [DataRow("{'onElement':'//null'}")]
        public void ContextClickTimeout(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [TestMethod]
        public void ContextClickElementFlat()
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        [DataRow("{'onElement':'//negative'}")]
        public void ContextClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:NoAlert}}','onElement':'//positive'}")]
        public void ContextClickElementUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        [DataRow("{'onElement':'.//negative'}")]
        public void ContextClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','locator':'Xpath'}")]
        [DataRow("{'onElement':'//stale','locator':'Xpath'}")]
        [DataRow("{'onElement':'//exception','locator':'Xpath'}")]
        public void ContextClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void ContextClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("{'onElement':'.//null'}")]
        public void ContextClickElementRelativeNull(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        public void ContextClickElementRelativeStale(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception'}")]
        public void ContextClickElementRelativeException(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144