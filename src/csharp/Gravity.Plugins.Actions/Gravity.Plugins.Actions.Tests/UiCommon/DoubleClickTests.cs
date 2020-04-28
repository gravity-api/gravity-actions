/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class DoubleClickTests : ActionTests
    {
        [TestMethod]
        public void DoubleClickCreate()
        {
            AssertPlugin<DoubleClick>();
        }

        [TestMethod]
        public void DoubleClickDocumentation()
        {
            AssertDocumentation<DoubleClick>(CommonPlugins.DoubleClick);
        }

        [TestMethod]
        public void DoubleClickDocumentationResourceFile()
        {
            AssertDocumentation<DoubleClick>(
                CommonPlugins.DoubleClick, "double_click.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void DoubleClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        public void DoubleClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickFlat()
        {
            // execute
            ExecuteAction<DoubleClick>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void DoubleClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void DoubleClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','locator':'" + LocatorType.Xpath + "'}")]
        public void DoubleClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void DoubleClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlat()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleClickElementFlatNull()
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'.//none'}")]
        public void DoubleClickElementFlatNullElement(string actionRule)
        {
            // execute
            ExecuteAction<DoubleClick>(MockBy.Null(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144