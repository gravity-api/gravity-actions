/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class SelectFromComboBoxTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SelectFromComboBoxCreate()
        {
            AssertPlugin<SelectFromComboBox>();
        }

        [TestMethod]
        public void SelectFromComboBoxDocumentation()
        {
            AssertDocumentation<SelectFromComboBox>(
                pluginName: PluginsList.SelectFromComboBox);
        }

        [TestMethod]
        public void SelectFromComboBoxDocumentationResourceFile()
        {
            AssertDocumentation<SelectFromComboBox>(
                pluginName: PluginsList.SelectFromComboBox,
                resource: "select_from_combo_box.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'onElement':'//select-element','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//select-element','argument':'Mock: Positive Element', 'onAttribute':'value'}")]
        public void SelectFromComboBoxValuePositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//select-element','argument':'0', 'onAttribute':'index'}")]
        public void SelectFromComboBoxIndexPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//select-element','argument':'{{$ --all}}'}")]
        [DataRow("{'onElement':'//select-element','argument':'{{$ --all}}','regularExpression':'T'}")]
        public void SelectFromComboBoxAllPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','argument':'Mock: Positive Element'}")]
        [DataRow("{'onElement':'//stale','argument':'Mock: Positive Element'}")]
        [DataRow("{'onElement':'//null','argument':'Mock: Positive Element'}")]
        [DataRow("{'onElement':'//exception','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxTimeout(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'.//select-element','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//select-element','argument':'Mock: Positive Element', 'onAttribute':'value'}")]
        public void SelectFromComboBoxElementValuePositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//select-element','argument':'0', 'onAttribute':'index'}")]
        public void SelectFromComboBoxElementIndexPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//select-element','argument':'{{$ --all}}'}")]
        public void SelectFromComboBoxElementAllPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementNone(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementStale(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentNullException))]
        [DataRow("{'onElement':'.//null','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementNull(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxElementException(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144