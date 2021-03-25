/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class WaitForElementTests: ActionTests
    {
        #region *** tests: properties    ***
        public TestContext Context { get; set; }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void WaitForElementCreate()
        {
            AssertPlugin<WaitForElement>();
        }

        [TestMethod]
        public void WaitForElementDocumentation()
        {
            AssertDocumentation<WaitForElement>(
                pluginName: PluginsList.WaitForElement);
        }

        [TestMethod]
        public void WaitForElementDocumentationResourceFile()
        {
            AssertDocumentation<WaitForElement>(
                pluginName: PluginsList.WaitForElement,
                resource: "WaitForElement.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\"}")]
        [DataRow("{\"onElement\":\"//negative\"}")]
        public void WaitForElementExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --timeout:00:00:01}}\"}")]
        public void WaitForElementExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:visible}}\"}")]
        public void WaitForElementVisible(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:visible}}\"}")]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:visible --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:visible --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:visible}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:visible --timeout:00:00:01}}\"}")]
        public void WaitForElementVisibleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:hidden}}\"}")]
        public void WaitForElementHidden(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:hidden}}\"}")]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:hidden --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:hidden --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:hidden}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:hidden --timeout:00:00:01}}\"}")]
        public void WaitForElementHiddenTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        public void WaitForElementNotExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:not_exists --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:not_exists --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:not_exists --timeout:00:00:01}}\"}")]
        public void WaitForElementNotExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:stale}}\"}")]
        public void WaitForElementStale(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:stale}}\"}")]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:stale --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:stale --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:stale}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:stale --timeout:00:00:01}}\"}")]
        public void WaitForElementStaleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:enabled}}\"}")]
        public void WaitForElementEnabled(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:enabled}}\"}")]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:enabled --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:enabled --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:enabled}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:enabled --timeout:00:00:01}}\"}")]
        public void WaitForElementTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:selected}}\"}")]
        public void WaitForElementSelected(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:selected}}\"}")]
        [DataRow("{\"onElement\":\"//none\",\"argument\":\"{{$ --until:selected --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\"//stale\",\"argument\":\"{{$ --until:selected --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\"//null\",\"argument\":\"{{$ --until:selected}}\"}")]
        [DataRow("{\"onElement\":\"//exception\",\"argument\":\"{{$ --until:selected --timeout:00:00:01}}\"}")]
        public void WaitForElementSelectedTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow(@"{""onElement"":""//positive"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//negative"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementAttribute(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{""onElement"":""//none"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//stale"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//exception"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementAttributeTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\",\"argument\":\"{{$ --until:text}}\",\"regularExpression\":\"^Mock: Positive Element$\"}")]
        [DataRow("{\"onElement\":\"//negative\",\"argument\":\"{{$ --until:text}}\",\"regularExpression\":\"^Mock: Negative Element$\"}")]
        public void WaitForElementText(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{""onElement"":""//none"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//stale"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//null"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":""//exception"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementTextTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\"}")]
        [DataRow("{\"onElement\":\".//negative\"}")]
        public void WaitForElementOnElementExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:visible}}\"}")]
        public void WaitForElementOnElementVisible(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:visible}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:visible --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:visible --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:visible}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:visible --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementVisibleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:hidden}}\"}")]
        public void WaitForElementOnElementHidden(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:hidden}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:hidden --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:hidden --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:hidden}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:hidden --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementHiddenTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        public void WaitForElementOnElementNotExists(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:not_exists}}\"}")]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:not_exists --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:not_exists --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:not_exists --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementNotExistsTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:stale}}\"}")]
        public void WaitForElementOnElementStale(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:stale}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:stale --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:stale --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:stale}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:stale --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementStaleTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:enabled}}\"}")]
        public void WaitForElementOnElementEnabled(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:enabled}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:enabled --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:enabled --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:enabled}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:enabled --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:selected}}\"}")]
        public void WaitForElementOnElementSelected(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:selected}}\"}")]
        [DataRow("{\"onElement\":\".//none\",\"argument\":\"{{$ --until:selected --timeout:1000}}\"}")]
        [DataRow("{\"onElement\":\".//stale\",\"argument\":\"{{$ --until:selected --timeout:00:00:01}}\"}")]
        [DataRow("{\"onElement\":\".//null\",\"argument\":\"{{$ --until:selected}}\"}")]
        [DataRow("{\"onElement\":\".//exception\",\"argument\":\"{{$ --until:selected --timeout:00:00:01}}\"}")]
        public void WaitForElementOnElementSelectedTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow(@"{""onElement"":"".//positive"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//negative"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementOnElementAttribute(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//exception"",""argument"":""{{$ --until:attribute}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementOnElementAttributeTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\".//positive\",\"argument\":\"{{$ --until:text}}\",\"regularExpression\":\"^Mock: Positive Element$\"}")]
        [DataRow("{\"onElement\":\".//negative\",\"argument\":\"{{$ --until:text}}\",\"regularExpression\":\"^Mock: Negative Element$\"}")]
        public void WaitForElementOnElementText(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow(@"{""onElement"":"".//none"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//stale"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//null"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        [DataRow(@"{""onElement"":"".//exception"",""argument"":""{{$ --until:text}}"",""regularExpression"":""^mock attribute value \\d+$""}")]
        public void WaitForElementOnElementTextTimeouts(string actionRule)
        {
            // execute 
            ExecuteAction<WaitForElement>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }
        #endregion
    }
}
#pragma warning restore S4144