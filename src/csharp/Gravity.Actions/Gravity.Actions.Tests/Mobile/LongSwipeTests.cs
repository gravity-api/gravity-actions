/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Services.ActionPlugins.Mobile;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Mobile
{
    [TestClass]
    public class LongSwipeTests : ActionTests
    {
        [TestMethod]
        public void LongSwipeCreateNoTypes() => ValidateAction<LongSwipe>();

        [TestMethod]
        public void LongSwipeCreateTypes() => ValidateAction<LongSwipe>(Types);

        [TestMethod]
        public void LongSwipeDocumentationNoTypes()
            => ValidateActionDocumentation<LongSwipe>(ActionType.LongSwipe);

        [TestMethod]
        public void LongSwipeDocumentationTypes()
            => ValidateActionDocumentation<LongSwipe>(ActionType.LongSwipe, Types);

        [TestMethod]
        public void LongSwipeDocumentationResourceFile()
            => ValidateActionDocumentation<LongSwipe>(ActionType.LongSwipe, Types, "long-swipe.json");

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --source:100,100 --target:200,200}}'}")]
        public void LongSwipeCoordinates(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<LongSwipe>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144