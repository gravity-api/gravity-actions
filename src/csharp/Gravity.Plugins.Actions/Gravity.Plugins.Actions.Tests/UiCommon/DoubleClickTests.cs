/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class DoubleClickTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void DoubleClickCreate()
        {
            AssertPlugin<DoubleClick>();
        }

        [TestMethod]
        public void DoubleClickDocumentation()
        {
            AssertDocumentation<DoubleClick>(pluginName: PluginsList.DoubleClick);
        }

        [TestMethod]
        public void DoubleClickDocumentationResourceFile()
        {
            AssertDocumentation<DoubleClick>(
                pluginName: PluginsList.DoubleClick,
                resource: "double_click.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void DoubleClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//stale'}")]
        public void DoubleClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//negative'}")]
        public void DoubleClickNegative(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickFlat()
        {
            // execute
            ExecuteAction<DoubleClick>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:no_alert}}','onElement':'//positive'}")]
        public void DoubleClickUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void DoubleClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void DoubleClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','locator':'Xpath'}")]
        [DataRow("{'onElement':'//null','locator':'Xpath'}")]
        [DataRow("{'onElement':'//stale','locator':'Xpath'}")]
        public void DoubleClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void DoubleClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("{'onElement':'.//null'}")]
        public void DoubleClickElementRelativeNull(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        public void DoubleClickElementRelativeStale(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'.//null'}")]
        [DataRow("{'onElement':'.//stale'}")]
        [DataRow("{'onElement':'.//none'}")]
        public void DoubleClickElementFlatNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlat()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlatNull()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144