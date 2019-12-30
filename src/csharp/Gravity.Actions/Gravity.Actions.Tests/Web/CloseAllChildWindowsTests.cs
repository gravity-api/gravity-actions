/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Drivers.Mock.Extensions;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class CloseAllChildWindowsTests : ActionTests
    {
        private const int NumberOfWindows = 5;
        private const string MessageNoWindows = "No child windows are currently active.";
        private const string MessageStillActive = "Some child windows are still active.";

        [TestMethod]
        public void CloseAllChildWindowsCreateNoTypes()
        {
            ValidateAction<CloseAllChildWindows>();
        }

        [TestMethod]
        public void CloseAllChildWindowsCreateTypes()
        {
            ValidateAction<CloseAllChildWindows>(Types);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationNoTypes()
        {
            ValidateActionDocumentation<CloseAllChildWindows>(ActionType.CLOSE_ALL_CHILD_WINDOWS);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationTypes()
        {
            ValidateActionDocumentation<CloseAllChildWindows>(ActionType.CLOSE_ALL_CHILD_WINDOWS, Types);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationResourceFile()
        {
            ValidateActionDocumentation<CloseAllChildWindows>(
                ActionType.CLOSE_ALL_CHILD_WINDOWS, Types, "close-all-child-windows.json");
        }

        [TestMethod]
        public void CloseAllPositive()
        {
            // open child windows
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            ExecuteAction<CloseAllChildWindows>();

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'.//positive'}")]
        public void CloseAllElementPositive(string actionRule)
        {
            // open child windows
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = NumberOfWindows
            });

            // assert that at least numberOfWindows are currently active
            Assert.IsTrue(WebDriver.WindowHandles.Count > NumberOfWindows, MessageNoWindows);

            // execute
            ExecuteAction<CloseAllChildWindows>(By.XPath("//positive"), actionRule);

            // assert that all child windows are now closed
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1, MessageStillActive);
        }
    }
}
