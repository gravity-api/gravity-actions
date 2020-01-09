/*
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
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class ClickTests : ActionTests
    {
        [TestMethod]
        public void ClickCreateNoTypes()
        {
            ValidateAction<Click>();
        }

        [TestMethod]
        public void ClickCreateTypes()
        {
            ValidateAction<Click>(Types);
        }

        [TestMethod]
        public void ClickDocumentationNoTypes()
        {
            ValidateActionDocumentation<Click>(ActionType.Click);
        }

        [TestMethod]
        public void ClickDocumentationTypes()
        {
            ValidateActionDocumentation<Click>(ActionType.Click, Types);
        }

        [TestMethod]
        public void ClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<Click>(ActionType.Click, Types, "click.json");
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
        [DataRow("{'elementToActOn':'//none'}")]
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
        [DataRow("{'Argument':'{{$ --until:no-alert}}','ElementToActOn':'//positive'}")]
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
        [DataRow("{'elementToActOn':'//none'}")]
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
    }
}
#pragma warning restore S4144