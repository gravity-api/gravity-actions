/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
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
                pluginName: WebPlugins.SwitchToDefaultContent);
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToDefaultContent>(
                pluginName: WebPlugins.SwitchToDefaultContent,
                resource: "switch_to_default_content.json");
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