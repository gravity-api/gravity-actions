/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gravity.Plugins.Actions.Contracts;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToWindowTests : ActionTests
    {
        [TestMethod]
        public void SwitchToWindowCreate()
        {
            ValidateAction<SwitchToWindow>();
        }

        [TestMethod]
        public void SwitchToWindowDocumentation()
        {
            ValidateActionDocumentation<SwitchToWindow>(WebPlugins.SwitchToWindow);
        }

        [TestMethod]
        public void SwitchToWindowDocumentationResourceFile()
        {
            ValidateActionDocumentation<SwitchToWindow>(
                WebPlugins.SwitchToWindow, "switch_to_window.json");
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
