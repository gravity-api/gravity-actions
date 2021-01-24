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
    public class NavigateForwardTests : ActionTests
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
        public void NavigateForwardCreate()
        {
            AssertPlugin<NavigateForward>();
        }

        [TestMethod]
        public void NavigateForwardDocumentation()
        {
            AssertDocumentation<NavigateForward>(
                pluginName: PluginsList.NavigateForward);
        }

        [TestMethod]
        public void NavigateForwardDocumentationResourceFile()
        {
            AssertDocumentation<NavigateForward>(
                pluginName: PluginsList.NavigateForward,
                resource: "navigate_forward.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void NavigateForwardPositive()
        {
            // execute
            ExecuteAction<NavigateForward>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void NavigateForwardMultiple(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void NavigateForwardNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void NavigateForwardNegative(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144