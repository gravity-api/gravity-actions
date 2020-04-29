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
    public class NavigateBackTests : ActionTests
    {
        #region *** tests: life cycle    ***
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
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void NavigateBackCreate()
        {
            AssertPlugin<NavigateBack>();
        }

        [TestMethod]
        public void NavigateBackDocumentation()
        {
            AssertDocumentation<NavigateBack>(
                pluginName: WebPlugins.NavigateBack);
        }

        [TestMethod]
        public void NavigateBackDocumentationResourceFile()
        {
            AssertDocumentation<NavigateBack>(
                pluginName: WebPlugins.NavigateBack,
                resource: "navigate_back.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void NavigateBackPositive()
        {
            // execute
            ExecuteAction<NavigateBack>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void NavigateBackMultiple(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void NavigateBackNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void NavigateBackNegative(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144