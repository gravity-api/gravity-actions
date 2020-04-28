/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;
using System.Collections.Generic;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class ClickTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void ClickCreate()
        {
            AssertPlugin<Click>();
        }

        [TestMethod]
        public void ClickDocumentation()
        {
            AssertDocumentation<Click>(pluginName: CommonPlugins.Click);
        }

        [TestMethod]
        public void ClickDocumentationResourceFile()
        {
            AssertDocumentation<Click>(
                pluginName: CommonPlugins.Click,
                resource: "click.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void ClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//stale'}")]
        public void ClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ElementNotVisibleException))]
        [DataRow("{'onElement':'//negative'}")]
        public void ClickNegative(string actionRule)
        {
            // execute
            ExecuteAction<Click>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ClickFlat()
        {
            // execute
            ExecuteAction<Click>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:no_alert}}','onElement':'//positive'}")]
        public void ClickUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<Click>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void ClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void ClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','locator':'Xpath'}")]
        [DataRow("{'onElement':'//null','locator':'Xpath'}")]
        [DataRow("{'onElement':'//stale','locator':'Xpath'}")]
        public void ClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void ClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{'onElement':'.//null'}")]
        public void ClickElementRelativeNull(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        public void ClickElementRelativeStale(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'.//null'}")]
        [DataRow("{'onElement':'.//stale'}")]
        [DataRow("{'onElement':'.//none'}")]
        public void ClickElementFlatNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Null(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ClickElementFlat()
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ClickElementFlatNull()
        {
            // execute
            ExecuteAction<Click>(MockBy.Null());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144