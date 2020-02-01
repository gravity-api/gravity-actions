/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Mobile;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Mobile
{
    [TestClass]
    public class HideKeyboardTests : ActionTests
    {
        [TestMethod]
        public void HideKeyboardCreateNoTypes()
        {
            ValidateAction<HideKeyboard>();
        }

        [TestMethod]
        public void HideKeyboardCreateTypes()
        {
            ValidateAction<HideKeyboard>(Types);
        }

        [TestMethod]
        public void HideKeyboardDocumentationNoTypes()
        {
            ValidateActionDocumentation<HideKeyboard>(ActionPlugins.HideKeyboard);
        }

        [TestMethod]
        public void HideKeyboardDocumentationTypes()
        {
            ValidateActionDocumentation<HideKeyboard>(ActionPlugins.HideKeyboard, Types);
        }

        [TestMethod]
        public void HideKeyboardDocumentationResourceFile()
        {
            ValidateActionDocumentation<HideKeyboard>(
                ActionPlugins.HideKeyboard, Types, "hide-keyboard.json");
        }

        [TestMethod]
        public void HideKeyboardPositive()
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<HideKeyboard>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void HideKeyboardElementPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<HideKeyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void HideKeyboardNoIHidesKeyboard()
        {
            // execute
            ExecuteAction<HideKeyboard>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144