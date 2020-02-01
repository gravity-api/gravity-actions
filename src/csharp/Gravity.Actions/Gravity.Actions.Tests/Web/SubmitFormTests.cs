/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
{
    [TestClass]
    public class SubmitFormTests: ActionTests
    {
        [TestMethod]
        public void SubmitFormCreateNoTypes() => ValidateAction<SubmitForm>();

        [TestMethod]
        public void SubmitFormCreateTypes() => ValidateAction<SubmitForm>(Types);

        [TestMethod]
        public void SubmitFormDocumentationNoTypes()
            => ValidateActionDocumentation<SubmitForm>(ActionType.SubmitForm);

        [TestMethod]
        public void SubmitFormDocumentationTypes()
            => ValidateActionDocumentation<SubmitForm>(ActionType.SubmitForm, Types);

        [TestMethod]
        public void SubmitFormDocumentationResourceFile()
        {
            ValidateActionDocumentation<SubmitForm>(ActionType.SubmitForm, Types, "submit-form.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNamePositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNone(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameStale(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'mock_form'}")]
        public void SubmitFormNameNull(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'1'}")]
        public void SubmitFormIdPositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive','argument':'mock-form'}")]
        public void SubmitFormElementNamePositive(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//negative','argument':'mock-form'}")]
        public void SubmitFormElementNameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//none','argument':'mock-form'}")]
        public void SubmitFormElementNameNone(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//stale','argument':'mock-form'}")]
        public void SubmitFormElementNameStale(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//null','argument':'mock-form'}")]
        public void SubmitFormElementNameNull(string actionRule)
        {
            // execute
            ExecuteAction<SubmitForm>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144