/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiMobile;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiMobile
{
    [TestClass]
    public class HideKeyboardTests : ActionTests
    {
        [TestMethod]
        public void HideKeyboardCreate()
        {
            AssertPlugin<HideKeyboard>();
        }

        [TestMethod]
        public void HideKeyboardDocumentation()
        {
            AssertDocumentation<HideKeyboard>(MobilePlugins.HideKeyboard);
        }

        [TestMethod]
        public void HideKeyboardDocumentationResourceFile()
        {
            AssertDocumentation<HideKeyboard>(
                MobilePlugins.HideKeyboard, "hide_keyboard.json");
        }

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
    }
}
#pragma warning restore S4144