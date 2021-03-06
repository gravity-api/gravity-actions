﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class NavigateForwardTests : ActionTests
    {
        [TestMethod]
        public void NavigateForwardCreateNoTypes()
        {
            ValidateAction<NavigateForward>();
        }

        [TestMethod]
        public void NavigateForwardCreateTypes()
        {
            ValidateAction<NavigateForward>(Types);
        }

        [TestMethod]
        public void NavigateForwardDocumentationNoTypes()
        {
            ValidateActionDocumentation<NavigateForward>(ActionType.NavigateForward);
        }

        [TestMethod]
        public void NavigateForwardDocumentationTypes()
        {
            ValidateActionDocumentation<NavigateForward>(ActionType.NavigateForward, Types);
        }

        [TestMethod]
        public void NavigateForwardDocumentationResourceFile()
        {
            ValidateActionDocumentation<NavigateForward>(
                ActionType.NavigateForward, Types, "navigate-forward.json");
        }

        [TestMethod]
        public void NavigateForwardPositive()
        {
            // execute
            ExecuteAction<NavigateForward>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void NavigateForwardMultiple(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void NavigateForwardNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void NavigateForwardNegative(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144