using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests
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
            ValidateActionDocumentation<NavigateBack>(ActionType.NAVIGATE_BACK);
        }

        [TestMethod]
        public void NavigateBackDocumentationTypes()
        {
            ValidateActionDocumentation<NavigateBack>(ActionType.NAVIGATE_BACK, Types);
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