/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using OpenQA.Selenium.Mock;
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class TryClickTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void TryClickCreate()
        {
            AssertPlugin<TryClick>();
        }

        [TestMethod]
        public void TryClickDocumentation()
        {
            AssertDocumentation<TryClick>(
                pluginName: PluginsList.TryClick);
        }

        [TestMethod]
        public void TryClickDocumentationResourceFile()
        {
            AssertDocumentation<TryClick>(
                pluginName: PluginsList.TryClick,
                resource: "try_click.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        [DataRow("{'onElement':'//negative'}")]
        public void TryClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//stale'}")]
        [DataRow("{'onElement':'//exception'}")]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//none'}")]
        public void TryClickTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        [DataRow("{'onElement':'.//negative'}")]
        public void TryClickElementPositive(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'.//stale'}")]
        [DataRow("{'onElement':'.//exception'}")]
        [DataRow("{'onElement':'.//null'}")]
        [DataRow("{'onElement':'.//none'}")]
        public void TryClickElementTimeout(string actionRule)
        {
            // execute
            ExecuteAction<TryClick>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144