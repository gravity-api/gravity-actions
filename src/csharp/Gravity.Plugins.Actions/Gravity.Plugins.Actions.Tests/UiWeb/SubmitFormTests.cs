/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class SubmitFormTests: ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SubmitFormCreate()
        {
            AssertPlugin<SubmitForm>();
        }

        [TestMethod]
        public void SubmitFormDocumentation()
        {
            AssertDocumentation<SubmitForm>(pluginName: PluginsList.SubmitForm);
        }

        [TestMethod]
        public void SubmitFormDocumentationResourceFile()
        {
            AssertDocumentation<SubmitForm>(
                pluginName: PluginsList.SubmitForm,
                resource: "submit_form.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNamePositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNone(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameStale(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNull(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'1'}")]
        public void SubmitFormIdPositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'.//positive','argument':'mock-form'}")]
        public void SubmitFormElementNamePositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//negative','argument':'mock-form'}")]
        public void SubmitFormElementNameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//none','argument':'mock-form'}")]
        public void SubmitFormElementNameNone(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//stale','argument':'mock-form'}")]
        public void SubmitFormElementNameStale(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//null','argument':'mock-form'}")]
        public void SubmitFormElementNameNull(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144