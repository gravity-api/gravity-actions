/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class GoToUrlTests : ActionTests
    {
        [TestMethod]
        public void GoToUrlCreate()
        {
            ValidateAction<GoToUrl>();
        }

        [TestMethod]
        public void GoToUrlDocumentation()
        {
            ValidateActionDocumentation<GoToUrl>(WebPlugins.GoToUrl);
        }

        [TestMethod]
        public void GoToUrlDocumentationResourceFile()
        {
            ValidateActionDocumentation<GoToUrl>(WebPlugins.GoToUrl, "go_to_url.json");
        }

        [TestMethod]
        [DataRow("{'argument':'http://noaddress.io'}")]
        public void GoToUrlPositive(string actionRule)
        {
            // execute
            ExecuteAction<GoToUrl>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.AreEqual("http://noaddress.io", WebDriver.Url);
        }
    }
}
