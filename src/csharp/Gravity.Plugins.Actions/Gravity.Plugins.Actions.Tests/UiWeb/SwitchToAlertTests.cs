/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using System.Collections.Generic;
using Gravity.Plugins.Actions.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class SwitchToAlertTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void SwitchToAlertCreate()
        {
            AssertPlugin<SwitchToAlert>();
        }

        [TestMethod]
        public void SwitchToAlertDocumentation()
        {
            AssertDocumentation<SwitchToAlert>(pluginName: PluginsList.SwitchToAlert);
        }

        [TestMethod]
        public void SwitchToAlertDocumentationResourceFile()
        {
            AssertDocumentation<SwitchToAlert>(
                pluginName: PluginsList.SwitchToAlert,
                resource: "switch_to_alert.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
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
        #endregion
    }
}
#pragma warning restore S4144
