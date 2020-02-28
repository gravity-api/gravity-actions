/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class SelectFromComboBoxTests : ActionTests
    {
        [TestMethod]
        public void SelectFromComboBoxCreate() => ValidateAction<SelectFromComboBox>();

        [TestMethod]
        public void SelectFromComboBoxDocumentation()
            => ValidateActionDocumentation<SelectFromComboBox>(WebPlugins.SelectFromComboBox);

        [TestMethod]
        public void SelectFromComboBoxDocumentationResourceFile()
            => ValidateActionDocumentation<SelectFromComboBox>(WebPlugins.SelectFromComboBox, "select-from-combo-box.json");

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//select-element','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//select-element','argument':'Mock: Positive Element', 'elementAttributeToActOn':'value'}")]
        public void SelectFromComboBoxValuePositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//select-element','argument':'0', 'elementAttributeToActOn':'index'}")]
        public void SelectFromComboBoxIndexPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//select-element','argument':'{{$ --all}}'}")]
        public void SelectFromComboBoxAllPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxNone(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxStale(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxNull(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//select-element','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//select-element','argument':'Mock: Positive Element', 'elementAttributeToActOn':'value'}")]
        public void SelectFromComboBoxElementValuePositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//select-element','argument':'0', 'elementAttributeToActOn':'index'}")]
        public void SelectFromComboBoxElementIndexPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//select-element','argument':'{{$ --all}}'}")]
        public void SelectFromComboBoxElementAllPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'elementToActOn':'.//none','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementNone(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementStale(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentNullException))]
        [DataRow("{'elementToActOn':'.//null','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementNull(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144