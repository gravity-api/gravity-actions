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
using OpenQA.Selenium.Mock.Extensions;
using System.Collections.Generic;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToAlertTests : ActionTests
    {
        [TestMethod]
        public void SwitchToAlertCreate() => AssertPlugin<SwitchToAlert>();

        [TestMethod]
        public void SwitchToAlertDocumentation()
            => AssertDocumentation<SwitchToAlert>(WebPlugins.SwitchToAlert);

        [TestMethod]
        public void SwitchToAlertDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToAlert>(
                WebPlugins.SwitchToAlert, "switch_to_alert.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'accept'}")]
        public void SwitchToAlertAccept(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'dismiss'}")]
        public void SwitchToAlertDismiss(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --user:userName --pass:Password}}'}")]
        public void SwitchToAlertCredentials(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --keys:automation}}'}")]
        public void SwitchToAlertKeys(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --keys:automation --user:userName --pass:Password}}'}")]
        public void SwitchToAlertAll(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'accept'}")]
        public void SwitchToAlertNoAlert(string actionRule)
        {
            // execute
            ExecuteAction<SwitchToAlert>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'accept'}")]
        public void SwitchToAlertElementAccept(string actionRule)
        {
            // apply alert
            WebDriver = WebDriver.ApplyCapabilities(new Dictionary<string, object>
            {
                [MockCapabilities.HasAlert] = true
            });

            // execute
            ExecuteAction<SwitchToAlert>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144
