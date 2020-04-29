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

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToFrameTests : ActionTests
    {
        [TestMethod]
        public void SwitchToFrameCreate()
        {
            AssertPlugin<SwitchToFrame>();
        }

        [TestMethod]
        public void SwitchToFrameDocumentation()
        {
            AssertDocumentation<SwitchToFrame>(WebPlugins.SwitchToFrame);
        }

        [TestMethod]
        public void SwitchToFrameDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToFrame>(
                WebPlugins.SwitchToFrame, "switch_to_frame.json");
        }

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
        public void SwitchToFrameNoElement(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null'}")]
        public void SwitchToFrameNoNull(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale'}")]
        public void SwitchToFrameStale(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'//exception'}")]
        public void SwitchToFrameException(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144
