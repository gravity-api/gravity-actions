/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gravity.Plugins.Actions.Contracts;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
{
    [TestClass]
    public class SwitchToWindowTests : ActionTests
    {
        [TestMethod]
        public void SwitchToWindowCreateNoTypes()
        {
            ValidateAction<SwitchToWindow>();
        }

        [TestMethod]
        public void SwitchToWindowCreateTypes()
        {
            ValidateAction<SwitchToWindow>(Types);
        }

        [TestMethod]
        public void SwitchToWindowDocumentationNoTypes()
        {
            ValidateActionDocumentation<SwitchToWindow>(WebPlugins.SwitchToWindow);
        }

        [TestMethod]
        public void SwitchToWindowDocumentationTypes()
        {
            ValidateActionDocumentation<SwitchToWindow>(WebPlugins.SwitchToWindow, Types);
        }

        [TestMethod]
        public void SwitchToWindowDocumentationResourceFile()
        {
            ValidateActionDocumentation<SwitchToWindow>(
                WebPlugins.SwitchToWindow, Types, "switch-to-window.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'3'}")]
        public void SwitchToWindowPositive(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle != expected);
        }

        [DataTestMethod]
        [DataRow("{'argument':'-1'}")]
        public void SwitchToWindowNegativeNumber(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle == expected);
        }

        [DataTestMethod]
        [DataRow("{'argument':'50'}")]
        public void SwitchToWindowOutOfRange(string actionRule)
        {
            // get first handler
            var expected = GetExpected(isLast: true);

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.WindowHandles.Last() == expected);
        }

        [DataTestMethod]
        [DataRow("{'argument':'A'}")]
        public void SwitchToWindowNotNumber(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle == expected);
        }

        [DataTestMethod]
        [DataRow("{'argument':'A'}")]
        public void SwitchToWindowNoWindows(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        private string GetExpected(bool isLast = false)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = 5
            });

            // get first handler
            return isLast ? WebDriver.WindowHandles.Last() : WebDriver.CurrentWindowHandle;
        }
    }
}
#pragma warning restore S4144
