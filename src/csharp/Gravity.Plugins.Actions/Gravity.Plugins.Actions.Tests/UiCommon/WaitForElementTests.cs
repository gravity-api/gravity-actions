/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class WaitForElementTests: ActionTests
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void WaitForElementCreate()
        {
            ValidateAction<WaitForElement>();
        }

        [TestMethod]
        public void WaitForElementDocumentation()
        {
            ValidateActionDocumentation<WaitForElement>(CommonPlugins.WaitForElement);
        }

        [TestMethod]
        public void WaitForElementDocumentationResourceFile()
        {
            ValidateActionDocumentation<WaitForElement>(
                CommonPlugins.WaitForElement, "wait_for_element.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        [DataRow("{'elementToActOn':'//negative'}")]
        public void WaitForElementExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --timeout:00:00:01}}'}")]
        public void WaitForElementExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:visible}}'}")]
        public void WaitForElementVisible(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:visible}}'}")]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:visible --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:visible --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:visible}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:visible --timeout:00:00:01}}'}")]
        public void WaitForElementVisibleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:hidden}}'}")]
        public void WaitForElementHidden(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:hidden}}'}")]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:hidden --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:hidden --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:hidden}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:hidden --timeout:00:00:01}}'}")]
        public void WaitForElementHiddenTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:not_exists}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:not_exists}}'}")]
        public void WaitForElementNotExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:not_exists}}'}")]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:not_exists --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:not_exists --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:not_exists --timeout:00:00:01}}'}")]
        public void WaitForElementNotExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:stale}}'}")]
        public void WaitForElementStale(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:stale}}'}")]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:stale --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:stale --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:stale}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:stale --timeout:00:00:01}}'}")]
        public void WaitForElementStaleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:enabled}}'}")]
        public void WaitForElementEnabled(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:enabled}}'}")]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:enabled --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:enabled --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:enabled}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:enabled --timeout:00:00:01}}'}")]
        public void WaitForElementTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:selected}}'}")]
        public void WaitForElementSelected(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:selected}}'}")]
        [DataRow("{'elementToActOn':'//none','argument':'{{$ --until:selected --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'//stale','argument':'{{$ --until:selected --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'//null','argument':'{{$ --until:selected}}'}")]
        [DataRow("{'elementToActOn':'//exception','argument':'{{$ --until:selected --timeout:00:00:01}}'}")]
        public void WaitForElementSelectedTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow(@"{'elementToActOn':'//positive','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//negative','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementAttribute(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{'elementToActOn':'//none','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//stale','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//null','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//exception','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementAttributeTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive','argument':'{{$ --until:text}}','regularExpression':'^Mock: Positive Element$'}")]
        [DataRow("{'elementToActOn':'//negative','argument':'{{$ --until:text}}','regularExpression':'^Mock: Negative Element$'}")]
        public void WaitForElementText(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{'elementToActOn':'//none','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//stale','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//null','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'//exception','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementTextTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        [DataRow("{'elementToActOn':'.//negative'}")]
        public void WaitForElementOnElementExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:visible}}'}")]
        public void WaitForElementOnElementVisible(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:visible}}'}")]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:visible --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:visible --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:visible}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:visible --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementVisibleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:hidden}}'}")]
        public void WaitForElementOnElementHidden(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:hidden}}'}")]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:hidden --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:hidden --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:hidden}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:hidden --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementHiddenTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:not_exists}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:not_exists}}'}")]
        public void WaitForElementOnElementNotExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:not_exists}}'}")]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:not_exists --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:not_exists --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:not_exists --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementNotExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:stale}}'}")]
        public void WaitForElementOnElementStale(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:stale}}'}")]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:stale --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:stale --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:stale}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:stale --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementStaleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:enabled}}'}")]
        public void WaitForElementOnElementEnabled(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:enabled}}'}")]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:enabled --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:enabled --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:enabled}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:enabled --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:selected}}'}")]
        public void WaitForElementOnElementSelected(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:selected}}'}")]
        [DataRow("{'elementToActOn':'.//none','argument':'{{$ --until:selected --timeout:1000}}'}")]
        [DataRow("{'elementToActOn':'.//stale','argument':'{{$ --until:selected --timeout:00:00:01}}'}")]
        [DataRow("{'elementToActOn':'.//null','argument':'{{$ --until:selected}}'}")]
        [DataRow("{'elementToActOn':'.//exception','argument':'{{$ --until:selected --timeout:00:00:01}}'}")]
        public void WaitForElementOnElementSelectedTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow(@"{'elementToActOn':'.//positive','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//negative','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementOnElementAttribute(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{'elementToActOn':'.//none','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//stale','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//null','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//exception','argument':'{{$ --until:attribute}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementOnElementAttributeTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'{{$ --until:text}}','regularExpression':'^Mock: Positive Element$'}")]
        [DataRow("{'elementToActOn':'.//negative','argument':'{{$ --until:text}}','regularExpression':'^Mock: Negative Element$'}")]
        public void WaitForElementOnElementText(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{'elementToActOn':'.//none','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//stale','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//null','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        [DataRow(@"{'elementToActOn':'.//exception','argument':'{{$ --until:text}}','regularExpression':'^mock attribute value \\d+$'}")]
        public void WaitForElementOnElementTextTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }
    }
}
#pragma warning restore S4144