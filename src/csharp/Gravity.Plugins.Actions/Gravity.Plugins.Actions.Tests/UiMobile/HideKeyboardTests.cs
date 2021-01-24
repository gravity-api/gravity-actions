/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiMobile;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiMobile
{
    [TestClass]
    public class HideKeyboardTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void HideKeyboardCreate()
        {
            AssertPlugin<HideKeyboard>();
        }

        [TestMethod]
        public void HideKeyboardDocumentation()
        {
            AssertDocumentation<HideKeyboard>(
                pluginName: PluginsList.HideKeyboard);
        }

        [TestMethod]
        public void HideKeyboardDocumentationResourceFile()
        {
            AssertDocumentation<HideKeyboard>(
                pluginName: PluginsList.HideKeyboard,
                resource: "hide_keyboard.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void HideKeyboardPositive()
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<HideKeyboard>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void HideKeyboardElementPositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<HideKeyboard>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void HideKeyboardNoIHidesKeyboard()
        {
            // execute
            ExecuteAction<HideKeyboard>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144