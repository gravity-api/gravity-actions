﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
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
            ValidateActionDocumentation<ContextClick>(ActionPlugins.ContextClick);
        }

        [TestMethod]
        public void ContextClickDocumentationTypes()
        {
            ValidateActionDocumentation<ContextClick>(ActionPlugins.ContextClick, Types);
        }

        [TestMethod]
        public void ContextClickDocumentationResourceFile()
        {
            ValidateActionDocumentation<ContextClick>(
                ActionPlugins.ContextClick, Types, "context-click.json");
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
        [DataRow("{'elementToActOn':'//none','locator':'" + LocatorType.Xpath + "'}")]
        public void ContextClickElementAbsoluteNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ContextClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none'}")]
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