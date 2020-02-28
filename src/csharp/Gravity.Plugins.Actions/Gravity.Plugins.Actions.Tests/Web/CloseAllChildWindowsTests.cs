﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;

namespace Gravity.Plugins.Actions.UnitTests.Web
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
            ValidateActionDocumentation<CloseAllChildWindows>(WebPlugins.CloseAllChildWindows);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationTypes()
        {
            ValidateActionDocumentation<CloseAllChildWindows>(WebPlugins.CloseAllChildWindows, Types);
        }

        [TestMethod]
        public void CloseAllChildWindowsDocumentationResourceFile()
        {
            ValidateActionDocumentation<CloseAllChildWindows>(
                WebPlugins.CloseAllChildWindows, Types, "close-all-child-windows.json");
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