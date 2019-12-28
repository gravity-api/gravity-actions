/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class RegisterParameterTests : ActionTests
    {
        [TestMethod]
        public void RegisterParameterCreateNoTypes()
        {
            ValidateAction<RegisterParameter>();
        }

        [TestMethod]
        public void RegisterParameterCreateTypes()
        {
            ValidateAction<RegisterParameter>(Types);
        }

        [TestMethod]
        public void RegisterParameterDocumentationNoTypes()
        {
            ValidateActionDocumentation<RegisterParameter>(
                ActionType.REGISTER_PARAMETER);
        }

        [TestMethod]
        public void RegisterParameterDocumentationTypes()
        {
            ValidateActionDocumentation<RegisterParameter>(
                ActionType.REGISTER_PARAMETER, Types);
        }

        [TestMethod]
        public void RegisterParameterDocumentationResourceFile()
        {
            ValidateActionDocumentation<RegisterParameter>(
                ActionType.REGISTER_PARAMETER, Types, "register-parameter.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'//positive'}")]
        public void RegisterParameterText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{AutomationEnvironment.SessionParams["test-key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'//positive','elementAttributeToActOn':'id'}")]
        public void RegisterParameterAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'//positive','regularExpression':'\\\\d+','elementAttributeToActOn':'id'}")]
        public void RegisterParameterRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test-key','elementToActOn':'2000-12-01'}")]
        public void RegisterParameterNonElementText(string actionRule)
        {
            // execute
            try
            {
                ExecuteAction<RegisterParameter>(actionRule);
            }
            catch (Exception)
            {
                var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
                Assert.IsTrue(Regex.IsMatch(actual, "^\\d{4}-\\d{2}-\\d{2}$"));
                throw;
            }
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test-key','elementToActOn':'//null'}")]
        public void RegisterParameterNullElement(string actionRule)
        {
            try
            {
                // execute
                ExecuteAction<RegisterParameter>(actionRule);
            }
            catch (Exception)
            {
                // assertion
                var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
                Assert.AreEqual("//null", actual);
                throw;
            }
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'.//positive'}")]
        public void RegisterParameterElementText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{AutomationEnvironment.SessionParams["test-key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'.//positive','elementAttributeToActOn':'id'}")]
        public void RegisterParameterElementAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test-key','elementToActOn':'.//positive','regularExpression':'\\\\d+','elementAttributeToActOn':'id'}")]
        public void RegisterParameterElementRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'argument':'test-key','elementToActOn':'2000-12-01'}")]
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
                var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
                Assert.IsTrue(Regex.IsMatch(actual, "^\\d{4}-\\d{2}-\\d{2}$"));
                throw;
            }
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test-key','elementToActOn':'//null'}")]
        public void RegisterParameterElementNullElement(string actionRule)
        {
            try
            {
                // execute
                ExecuteAction<RegisterParameter>(MockBy.Null(), actionRule);
            }
            catch (Exception)
            {
                // assertion
                var actual = $"{AutomationEnvironment.SessionParams["test-key"]}";
                Assert.AreEqual("//null", actual);
                throw;
            }
        }
    }
}
