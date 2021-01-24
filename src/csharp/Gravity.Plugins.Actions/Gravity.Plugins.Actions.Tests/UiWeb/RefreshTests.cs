/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class RefreshTests : ActionTests
    {
        #region *** tests: life cycle    ***
        [TestInitialize]
        public void Setup()
        {
            Automation.EngineConfiguration.LoadTimeout = 15000;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Automation.EngineConfiguration.LoadTimeout = 100;
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void RefreshCreate()
        {
            AssertPlugin<Refresh>();
        }

        [TestMethod]
        public void RefreshDocumentation()
        {
            AssertDocumentation<Refresh>(pluginName: PluginsList.Refresh);
        }

        [TestMethod]
        public void RefreshDocumentationResourceFile()
        {
            AssertDocumentation<Refresh>(
                pluginName: PluginsList.Refresh,
                resource: "refresh.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void RefreshPositive()
        {
            // execute
            ExecuteAction<Refresh>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void RefreshMultiple(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void RefreshNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void RefreshNegative(string actionRule)
        {
            // execute
            ExecuteAction<Refresh>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144