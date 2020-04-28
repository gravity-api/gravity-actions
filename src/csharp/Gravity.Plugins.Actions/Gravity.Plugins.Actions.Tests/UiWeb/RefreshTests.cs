/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class RefreshTests : ActionTests
    {
        [TestInitialize]
        public void Setup()
        {
            Automation.EngineConfiguration.PageLoadTimeout = 15000;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Automation.EngineConfiguration.PageLoadTimeout = 100;
        }

        [TestMethod]
        public void RefreshCreate()
        {
            AssertPlugin<Refresh>();
        }

        [TestMethod]
        public void RefreshDocumentationNoTypes()
        {
            AssertDocumentation<Refresh>(WebPlugins.Refresh);
        }

        [TestMethod]
        public void RefreshDocumentationTypes()
        {
            AssertDocumentation<Refresh>(WebPlugins.Refresh);
        }

        [TestMethod]
        public void RefreshDocumentationResourceFile()
        {
            AssertDocumentation<Refresh>(WebPlugins.Refresh, "refresh.json");
        }

        [TestMethod]
        public void RefreshPositive()
        {
            // execute
            ExecuteAction<Refresh>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void RefreshMultiple(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void RefreshNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void RefreshNegative(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144