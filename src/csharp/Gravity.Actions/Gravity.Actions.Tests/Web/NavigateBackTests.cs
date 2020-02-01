/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
{
    [TestClass]
    public class NavigateBackTests : ActionTests
    {
        [TestMethod]
        public void NavigateBackCreateNoTypes()
        {
            ValidateAction<NavigateBack>();
        }

        [TestMethod]
        public void NavigateBackCreateTypes()
        {
            ValidateAction<NavigateBack>(Types);
        }

        [TestMethod]
        public void NavigateBackDocumentationNoTypes()
        {
            ValidateActionDocumentation<NavigateBack>(ActionType.NavigateBack);
        }

        [TestMethod]
        public void NavigateBackDocumentationTypes()
        {
            ValidateActionDocumentation<NavigateBack>(ActionType.NavigateBack, Types);
        }

        [TestMethod]
        public void NavigateBackDocumentationResourceFile()
        {
            ValidateActionDocumentation<NavigateBack>(
                ActionType.NavigateBack, Types, "navigate-back.json");
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