﻿/*
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

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class ExecuteScriptTests : ActionTests
    {
        [TestMethod]
        public void ExecuteScriptCreateNoTypes()
        {
            ValidateAction<ExecuteScript>();
        }

        [TestMethod]
        public void ExecuteScriptCreateTypes()
        {
            ValidateAction<ExecuteScript>(Types);
        }

        [TestMethod]
        public void ExecuteScriptDocumentationNoTypes()
        {
            ValidateActionDocumentation<ExecuteScript>(ActionType.ExecuteScript);
        }

        [TestMethod]
        public void ExecuteScriptDocumentationTypes()
        {
            ValidateActionDocumentation<ExecuteScript>(ActionType.ExecuteScript, Types);
        }

        [TestMethod]
        public void ExecuteScriptDocumentationResourceFile()
        {
            ValidateActionDocumentation<ExecuteScript>(
                ActionType.ExecuteScript, Types, "execute-script.json");
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":""console.log('unitTesting');""}")]
        public void ExecuteScriptPositive(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExecuteScriptNoScript()
        {
            // execute
            ExecuteAction<ExecuteScript>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow(@"{""argument"":""invalid script""}")]
        public void ExecuteScriptInvalidScript(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":""{{$ --src:console.log('unitTesting');}}""}")]
        public void ExecuteScriptSrc(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow(@"{""argument"":""{{$ --args:['argument',0,false]}}""}")]
        public void ExecuteScriptArgs(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":""{{$ --src:console.log('unitTesting'); --args:['argument',0,false]}}""}")]
        public void ExecuteScriptSrcArgs(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":"".checked=false;""}")]
        public void ExecuteScriptElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":""log('unitTesting');""}")]
        public void ExecuteScriptElementNoDot(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":"".checked=false""}")]
        public void ExecuteScriptElementNoSemicolon(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow(@"{""argument"":"".invalid script;""}")]
        public void ExecuteScriptElementInvalidScript(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);
        }
    }
}
#pragma warning restore S4144