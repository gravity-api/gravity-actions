/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToFrameTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SwitchToFrameCreate()
        {
            AssertPlugin<SwitchToFrame>();
        }

        [TestMethod]
        public void SwitchToFrameDocumentation()
        {
            AssertDocumentation<SwitchToFrame>(
                pluginName: WebPlugins.SwitchToFrame);
        }

        [TestMethod]
        public void SwitchToFrameDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToFrame>(
                pluginName: WebPlugins.SwitchToFrame,
                resource: "switch_to_frame.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'1'}")]
        public void SwitchToFrameIndex(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'frame_id'}")]
        public void SwitchToFrameId(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void SwitchToFrameElement(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//negative'}")]
        public void SwitchToFrameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//stale'}")]
        [DataRow("{'onElement':'//exception'}")]
        public void SwitchToFrameTimeout(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        public void SwitchToFrameElementonElement(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//negative'}")]
        public void SwitchToFrameElementNegative(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void SwitchToFrameElementNone(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        [DataRow("{'onElement':'.//null'}")]
        public void SwitchToFrameElementStale(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception'}")]
        public void SwitchToFrameElementException(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144
