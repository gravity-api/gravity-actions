/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
{
    [TestClass]
    public class RefreshTests : ActionTests
    {
        [TestMethod]
        public void RefreshCreateNoTypes()
        {
            ValidateAction<Refresh>();
        }

        [TestMethod]
        public void RefreshCreateTypes()
        {
            ValidateAction<Refresh>(Types);
        }

        [TestMethod]
        public void RefreshDocumentationNoTypes()
        {
            ValidateActionDocumentation<Refresh>(ActionPlugins.Refresh);
        }

        [TestMethod]
        public void RefreshDocumentationTypes()
        {
            ValidateActionDocumentation<Refresh>(ActionPlugins.Refresh, Types);
        }

        [TestMethod]
        public void RefreshDocumentationResourceFile()
        {
            ValidateActionDocumentation<Refresh>(ActionPlugins.Refresh, Types, "refresh.json");
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