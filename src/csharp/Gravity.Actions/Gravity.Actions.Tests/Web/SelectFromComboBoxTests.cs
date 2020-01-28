/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class SelectFromComboBoxTests:ActionTests
    {
        [TestMethod]
        public void SelectFromComboBoxCreateNoTypes() => ValidateAction<SelectFromComboBox>();

        [TestMethod]
        public void SelectFromComboBoxCreateTypes() => ValidateAction<SelectFromComboBox>(Types);

        [TestMethod]
        public void SelectFromComboBoxDocumentationNoTypes()
            => ValidateActionDocumentation<SelectFromComboBox>(ActionType.SelectFromComboBox);

        [TestMethod]
        public void SelectFromComboBoxDocumentationTypes()
            => ValidateActionDocumentation<SelectFromComboBox>(ActionType.SelectFromComboBox, Types);

        [TestMethod]
        public void SelectFromComboBoxDocumentationResourceFile()
            => ValidateActionDocumentation<SelectFromComboBox>(ActionType.SelectFromComboBox, Types, "select-from-combo-box.json");

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//select-element','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144