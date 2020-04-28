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
        public void NavigateBackCreate()
        {
            AssertPlugin<NavigateBack>();
        }

        [TestMethod]
        public void NavigateBackDocumentation()
        {
            AssertDocumentation<NavigateBack>(WebPlugins.NavigateBack);
        }

        [TestMethod]
        public void NavigateBackDocumentationResourceFile()
        {
            AssertDocumentation<NavigateBack>(
                WebPlugins.NavigateBack, "navigate_back.json");
        }

        [TestMethod]
        public void NavigateBackPositive()
        {
            // execute
            ExecuteAction<NavigateBack>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void NavigateBackMultiple(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void NavigateBackNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void NavigateBackNegative(string actionRule)
        {
            // execute
            ExecuteAction<NavigateBack>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144