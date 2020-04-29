/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;
using System.Text.RegularExpressions;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    [DoNotParallelize]
    public class RegisterParameterTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void RegisterParameterCreate()
        {
            AssertPlugin<RegisterParameter>();
        }

        [TestMethod]
        public void RegisterParameterDocumentation()
        {
            AssertDocumentation<RegisterParameter>(
                pluginName: CommonPlugins.RegisterParameter);
        }

        [TestMethod]
        public void RegisterParameterDocumentationResourceFile()
        {
            AssertDocumentation<RegisterParameter>(
                pluginName: CommonPlugins.RegisterParameter,
                resource: "register_parameter.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'{{$ --key:test_key --value:John}}'}")]
        public void RegisterParameterLiteral(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.AreEqual("John", $"{EnvironmentContext.ApplicationParams["test_key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --key:test_key}}'}")]
        public void RegisterParameterLiteralNoValue(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.AreEqual(string.Empty, EnvironmentContext.ApplicationParams["test_key"]);
        }

        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("{'argument':'{{$ --value:John}}'}")]
        public void RegisterParameterLiteralNoKey(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.Inconclusive();
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'//positive'}")]
        [DataRow("{'argument':'{{$ --key:test_key}}','onElement':'//positive'}")]
        public void RegisterParameterText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{EnvironmentContext.ApplicationParams["test_key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'//positive','onAttribute':'id'}")]
        public void RegisterParameterAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'//positive','regularExpression':'\\\\d+','onAttribute':'id'}")]
        public void RegisterParameterRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test_key','onElement':'2000-12-01'}")]
        public void RegisterParameterNonElement(string actionRule)
        {
            // execute
            try
            {
                ExecuteAction<RegisterParameter>(actionRule);
            }
            catch (Exception)
            {
                var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
                Assert.IsTrue(Regex.IsMatch(actual, "^\\d{4}-\\d{2}-\\d{2}$"));
                throw;
            }
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test_key','onElement':'//null'}")]
        [DataRow("{'argument':'test_key','onElement':'//stale'}")]
        [DataRow("{'argument':'test_key','onElement':'//none'}")]
        [DataRow("{'argument':'test_key','onElement':'//exception'}")]
        public void RegisterParameterTimeout(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'.//positive'}")]
        public void RegisterParameterElementText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{EnvironmentContext.ApplicationParams["test_key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'.//positive','onAttribute':'id'}")]
        public void RegisterParameterElementAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'.//positive','regularExpression':'\\\\d+','onAttribute':'id'}")]
        public void RegisterParameterElementRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'argument':'test_key','onElement':'2000-12-01'}")]
        public void RegisterParameterElementNonElementText(string actionRule)
        {
            try
            {
                // execute
                ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);
            }
            catch (Exception)
            {
                // assertion
                var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
                Assert.IsTrue(Regex.IsMatch(actual, "^\\d{4}-\\d{2}-\\d{2}$"));
                throw;
            }
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','onElement':'.//null'}")]
        public void RegisterParameterElementNull(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(string.IsNullOrEmpty(actual));
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'argument':'test_key','onElement':'.//stale'}")]
        public void RegisterParameterElementStale(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'argument':'test_key','onElement':'.//none'}")]
        public void RegisterParameterElementNone(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'argument':'test_key','onElement':'.//exception'}")]
        public void RegisterParameterElementException(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144