/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Contracts;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;

using System.Collections.Generic;
using System.Linq;

namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToWindowTests : ActionTests
    {
        #region *** tests: life cycle    ***
        [TestCleanup]
        public void TestClean()
        {
            WebDriver = new MockWebDriver();
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void SwitchToWindowCreate()
        {
            AssertPlugin<SwitchToWindow>();
        }

        [TestMethod]
        public void SwitchToWindowDocumentation()
        {
            AssertDocumentation<SwitchToWindow>(
                pluginName: GravityPlugins.SwitchToWindow);
        }

        [TestMethod]
        public void SwitchToWindowDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToWindow>(
                pluginName: GravityPlugins.SwitchToWindow,
                resource: "SwitchToWindow.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"3\"}")]
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
        [DataRow("{\"argument\":\"-1\"}")]
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
        [DataRow("{\"argument\":\"50\"}")]
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
        [DataRow("{\"argument\":\"A\"}")]
        public void SwitchToWindowNotNumber(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle == expected);
        }

        [DoNotParallelize]
        [DataTestMethod]
        [DataRow("{\"argument\":\"10\"}")]
        public void SwitchToWindowNoWindows(string actionRule)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = 0
            });

            // execute
            ExecuteAction<SwitchToWindow>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//negative\"}")]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//null\"}")]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//none\"}")]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//stale\"}")]
        [DataRow("{\"argument\":\"3\",\"onElement\":\".//exception\"}")]
        public void SwitchToWindowElementPositive(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle != expected);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//negative\"}")]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//null\"}")]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//none\"}")]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//stale\"}")]
        [DataRow("{\"argument\":\"-1\",\"onElement\":\".//exception\"}")]
        public void SwitchToWindowElementNegativeNumber(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle == expected);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//negative\"}")]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//null\"}")]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//none\"}")]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//stale\"}")]
        [DataRow("{\"argument\":\"50\",\"onElement\":\".//exception\"}")]
        public void SwitchToWindowElementOutOfRange(string actionRule)
        {
            // get first handler
            var expected = GetExpected(isLast: true);

            // execute
            ExecuteAction<SwitchToWindow>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.WindowHandles.Last() == expected);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//negative\"}")]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//null\"}")]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//none\"}")]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//stale\"}")]
        [DataRow("{\"argument\":\"A\",\"onElement\":\".//exception\"}")]
        public void SwitchToWindowElementNotNumber(string actionRule)
        {
            // get first handler
            var expected = GetExpected();

            // execute
            ExecuteAction<SwitchToWindow>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.CurrentWindowHandle == expected);
        }

        [DoNotParallelize]
        [DataTestMethod]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//positive\"}")]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//negative\"}")]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//null\"}")]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//none\"}")]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//stale\"}")]
        [DataRow("{\"argument\":\"10\",\"onElement\":\".//exception\"}")]
        public void SwitchToWindowElementNoWindows(string actionRule)
        {
            // setup
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.ChildWindows] = 0
            });

            // execute
            ExecuteAction<SwitchToWindow>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.WindowHandles.Count == 1);
        }
        #endregion

        #region *** utilities            ***
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
        #endregion
    }
}