﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Contracts;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class ExecuteScriptTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void ExecuteScriptCreate()
        {
            AssertPlugin<ExecuteScript>();
        }

        [TestMethod]
        public void ExecuteScriptDocumentation()
        {
            AssertDocumentation<ExecuteScript>(
                pluginName: GravityPlugin.ExecuteScript);
        }

        [TestMethod]
        public void ExecuteScriptDocumentationResourceFile()
        {
            AssertDocumentation<ExecuteScript>(
                pluginName: GravityPlugin.ExecuteScript,
                resource: "ExecuteScript.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow(@"{""argument"":""console.log('unitTesting');""}")]
        public void ExecuteScriptPositive(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ExecuteScriptNoScript()
        {
            // execute
            ExecuteAction<ExecuteScript>();

            // assertion (no assertion here)
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

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{\"argument\":\"{{$ --args:[\\\"argument\\\",0,false]}}\"}")]
        public void ExecuteScriptArgs(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --src:console.log('unitTesting'); --args:[\\\"argument\\\",0,false]}}\"}")]
        public void ExecuteScriptSrcArgs(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --src:console.log(\u0027unitTesting\u0027); --args:[\\\"argument\\\",0,false]}}\"}")]
        public void ExecuteScriptSrcArgsUnicode(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow(@"{""argument"":"".checked=false;""}")]
        public void ExecuteScriptElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":""log('unitTesting');""}")]
        public void ExecuteScriptElementNoDot(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow(@"{""argument"":"".checked=false""}")]
        public void ExecuteScriptElementNoSemicolon(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow(@"{""argument"":"".invalid script;""}")]
        public void ExecuteScriptElementInvalidScript(string actionRule)
        {
            // execute
            ExecuteAction<ExecuteScript>(MockBy.Positive(), actionRule);
        }
        #endregion
    }
}
#pragma warning restore S4144