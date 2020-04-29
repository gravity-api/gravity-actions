/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
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
        public void SelectFromComboBoxCreate() => AssertPlugin<SelectFromComboBox>();

        [TestMethod]
        public void SelectFromComboBoxDocumentation()
            => AssertDocumentation<SelectFromComboBox>(WebPlugins.SelectFromComboBox);

        [TestMethod]
        public void SelectFromComboBoxDocumentationResourceFile()
            => AssertDocumentation<SelectFromComboBox>(WebPlugins.SelectFromComboBox, "select_from_combo_box.json");

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
        public void SelectFromComboBoxAllPositive(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxNone(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxStale(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null','argument':'Mock: Positive Element'}")]
        public void SelectFromComboBoxNull(string actionRule)
        {
            // execute
            ExecuteAction<SelectFromComboBox>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

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
    }
}
#pragma warning restore S4144