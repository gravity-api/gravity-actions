/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests
{
    [TestClass]
    public class NavigateForwardTests : ActionTests
    {
        [TestMethod]
        public void NavigateForwardCreateNoTypes()
        {
            ValidateAction<NavigateForward>();
        }

        [TestMethod]
        public void NavigateForwardCreateTypes()
        {
            ValidateAction<NavigateForward>(Types);
        }

        [TestMethod]
        public void NavigateForwardDocumentationNoTypes()
        {
            ValidateActionDocumentation<NavigateForward>(ActionType.NAVIGATE_FORWARD);
        }

        [TestMethod]
        public void NavigateForwardDocumentationTypes()
        {
            ValidateActionDocumentation<NavigateForward>(ActionType.NAVIGATE_FORWARD, Types);
        }

        [TestMethod]
        public void NavigateForwardPositive()
        {
            // execute
            ExecuteAction<NavigateForward>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void NavigateForwardMultiple(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NoNumber'}")]
        public void NavigateForwardNotNumber(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void NavigateForwardNegative(string actionRule)
        {
            // execute
            ExecuteAction<NavigateForward>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144