/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class WaitForPageTests : ActionTests
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            WebAutomation.EngineConfiguration.PageLoadTimeout = 180000;
        }

        [TestMethod]
        public void WaitForPageCreate()
        {
            ValidateAction<WaitForPage>();
        }

        [TestMethod]
        public void WaitForPageDocumentation()
        {
            ValidateActionDocumentation<WaitForPage>(WebPlugins.WaitForPage);
        }

        [TestMethod]
        public void WaitForPageDocumentationResourceFile()
        {
            ValidateActionDocumentation<WaitForPage>(WebPlugins.WaitForPage, "wait_for_page.json");
        }

        [TestMethod]
        public void WaitForPagePositive()
        {
            // execute
            ExecuteAction<WaitForPage>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'{{$ --until:false --timeout:00:00:00}}'}")]
        public void WaitForPageTimeout(string actionRule)
        {
            // setup
            WebAutomation.EngineConfiguration.PageLoadTimeout = 0;

            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.ElapsedMilliseconds < 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:uninitialized}}'}")]
        public void WaitForPageUninitialized(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:loading}}'}")]
        public void WaitForPageLoading(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:loaded}}'}")]
        public void WaitForPageLoaded(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:interactive}}'}")]
        public void WaitForPageInteractive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:complete}}'}")]
        public void WaitForPageComplete(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow("{'argument':'{{$ --until:not_a_state}}'}")]
        public void WaitForPageNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:uninitialized}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementUninitialized(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:loading}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementLoading(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:loaded}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementLoaded(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:interactive}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementInteractive(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --until:complete}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementComplete(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow("{'argument':'{{$ --until:not_a_state}}','elementToActOn':'.//positive'}")]
        public void WaitForPageElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<WaitForPage>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144