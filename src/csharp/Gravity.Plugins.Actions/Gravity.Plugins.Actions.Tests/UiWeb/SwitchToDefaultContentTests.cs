/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using System;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToDefaultContentTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SwitchToDefaultContentCreate()
        {
            AssertPlugin<SwitchToDefaultContent>();
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentation()
        {
            AssertDocumentation<SwitchToDefaultContent>(
                pluginName: PluginsList.SwitchToDefaultContent);
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToDefaultContent>(
                pluginName: PluginsList.SwitchToDefaultContent,
                resource: "SwitchToDefaultContent.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void SwitchToDefaultContentPositive()
        {
            // execute
            ExecuteAction<SwitchToDefaultContent>();

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SwitchToDefaultContentElementPositive()
        {
            // execute
            ExecuteAction<SwitchToDefaultContent>(MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(MissingMethodException))]
        public void SwitchToDefaultContentNoDriver()
        {
            // setup
            WebDriver = null;

            // execute
            ExecuteAction<SwitchToDefaultContent>(MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144