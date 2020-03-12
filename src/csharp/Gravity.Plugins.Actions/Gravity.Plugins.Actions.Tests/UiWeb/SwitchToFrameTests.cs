/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
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
            ValidateAction<SwitchToFrame>();
        }

        [TestMethod]
        public void SwitchToFrameDocumentation()
        {
            ValidateActionDocumentation<SwitchToFrame>(WebPlugins.SwitchToFrame);
        }

        [TestMethod]
        public void SwitchToFrameDocumentationResourceFile()
        {
            ValidateActionDocumentation<SwitchToFrame>(
                WebPlugins.SwitchToFrame, "switch_to_frame.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'1'}")]
        public void SwitchToFrameIndex(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'frame_id'}")]
        public void SwitchToFrameId(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//positive'}")]
        public void SwitchToFrameElement(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'elementToActOn':'//negative'}")]
        public void SwitchToFrameNegative(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//none'}")]
        public void SwitchToFrameNoElement(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//null'}")]
        public void SwitchToFrameNoNull(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'elementToActOn':'//stale'}")]
        public void SwitchToFrameStale(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'//exception'}")]
        public void SwitchToFrameException(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToFrame>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144
