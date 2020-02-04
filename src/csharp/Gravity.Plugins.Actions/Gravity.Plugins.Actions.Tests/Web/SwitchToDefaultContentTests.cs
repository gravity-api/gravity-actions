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
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Web
{
    [TestClass]
    public class SwitchToDefaultContentTests : ActionTests
    {
        [TestMethod]
        public void SwitchToDefaultContentCreateNoTypes()
        {
            ValidateAction<SwitchToDefaultContent>();
        }

        [TestMethod]
        public void SwitchToDefaultContentCreateTypes()
        {
            ValidateAction<SwitchToDefaultContent>(Types);
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentationNoTypes()
        {
            ValidateActionDocumentation<SwitchToDefaultContent>(WebPlugins.SwitchToDefaultContent);
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentationTypes()
        {
            ValidateActionDocumentation<SwitchToDefaultContent>(WebPlugins.SwitchToDefaultContent, Types);
        }

        [TestMethod]
        public void SwitchToDefaultContentDocumentationResourceFile()
        {
            ValidateActionDocumentation<SwitchToDefaultContent>(
                WebPlugins.SwitchToDefaultContent, Types, "switch-to-default-content.json");
        }

        [TestMethod]
        public void SwitchToDefaultContentPositive()
        {
            // execute
            ExecuteAction<SwitchToDefaultContent>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SwitchToDefaultContentElementPositive()
        {
            // execute
            ExecuteAction<SwitchToDefaultContent>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void SwitchToDefaultContentNoDriver()
        {
            // setup
            WebDriver = null;

            // execute
            ExecuteAction<SwitchToDefaultContent>(MockBy.Positive());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144
