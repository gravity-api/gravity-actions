/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class ContextClickTests : ActionTests
    {
        [TestMethod]
        public void ContextClickCreateNoTypes()
        {
            ValidateAction<ContextClick>();
        }

        [TestMethod]
        public void ContextClickCreateTypes()
        {
            ValidateAction<ContextClick>(Types);
        }

        [TestMethod]
        public void ContextClickDocumentationNoTypes()
        {
            ValidateActionDocumentation<ContextClick>(ActionType.CONTEXT_CLICK);
        }

        [TestMethod]
        public void ContextClickDocumentationTypes()
        {
            ValidateActionDocumentation<ContextClick>(ActionType.CONTEXT_CLICK, Types);
        }

        [TestMethod]
        public void ContextClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<ContextClick>(
                ActionType.CONTEXT_CLICK, Types, "context-click.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ContextClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void ContextClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule);

            // assertion (no assertion here, expected WebDriverTimeoutException exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContextClickFlat()
        {
            // execute
            ExecuteAction<ContextClick>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'Argument':'{{$ --until:NoAlert}}','ElementToActOn':'//positive'}")]
        public void ContextClickUntilNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(actionRule, new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void ContextClickElementAbsolutePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void ContextClickElementRelativePositive(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//no-element'}")]
        public void ContextClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//no-element'}")]
        public void ContextClickElementRelativeNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContextClickElementFlat()
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144