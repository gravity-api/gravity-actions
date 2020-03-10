/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class ClickTests : ActionTests
    {
        [TestMethod]
        public void ClickCreate()
        {
            ValidateAction<Click>();
        }

        [TestMethod]
        public void ClickDocumentation()
        {
            ValidateActionDocumentation<Click>(CommonPlugins.Click);
        }

        [TestMethod]
        public void ClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<Click>(CommonPlugins.Click, "click.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','locator':'" + LocatorType.Xpath + "'}")]
        public void ClickNoElement(string actionRule)
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
        [DataRow("{'Argument':'{{$ --until:no_alert}}','ElementToActOn':'//positive'}")]
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

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void ClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','locator':'"+ LocatorType.Xpath +"'}")]
        public void ClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void ClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Positive(), actionRule);

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

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'.//none'}")]
        public void ClickElementFlatNullElement(string actionRule)
        {
            // execute
            ExecuteAction<Click>(MockBy.Null(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144