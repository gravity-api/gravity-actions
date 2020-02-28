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
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class ExecuteScriptTests : ActionTests
    {
        [TestMethod]
        public void ExecuteScriptCreate()
        {
            ValidateAction<ExecuteScript>();
        }

        [TestMethod]
        public void ExecuteScriptDocumentation()
        {
            ValidateActionDocumentation<ExecuteScript>(CommonPlugins.ExecuteScript);
        }

        [TestMethod]
        public void ExecuteScriptDocumentationResourceFile()
        {
            ValidateActionDocumentation<ExecuteScript>(
                CommonPlugins.ExecuteScript, "execute-script.json");
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