/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;

namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class UploadFileTests : ActionTests
    {
        [TestMethod]
        public void UploadFileCreate()
        {
            ValidateAction<UploadFile>();
        }

        [TestMethod]
        public void UploadFileDocumentation()
        {
            ValidateActionDocumentation<UploadFile>(WebPlugins.UploadFile);
        }

        [TestMethod]
        public void UploadFileDocumentationResourceFile()
        {
            ValidateActionDocumentation<UploadFile>(WebPlugins.UploadFile, "upload_file.json");
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//file'}")]
        public void UploadFilePositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//file'}")]
        public void UploadFileElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}