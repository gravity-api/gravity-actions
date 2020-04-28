/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
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
            AssertPlugin<UploadFile>();
        }

        [TestMethod]
        public void UploadFileDocumentation()
        {
            AssertDocumentation<UploadFile>(WebPlugins.UploadFile);
        }

        [TestMethod]
        public void UploadFileDocumentationResourceFile()
        {
            AssertDocumentation<UploadFile>(WebPlugins.UploadFile, "upload_file.json");
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//file'}")]
        public void UploadFilePositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//file'}")]
        public void UploadFileElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<UploadFile>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}