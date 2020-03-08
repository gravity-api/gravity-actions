/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class RegisterParameterTests : ActionTests
    {
        [TestMethod]
        public void RegisterParameterCreate()
        {
            ValidateAction<RegisterParameter>();
        }

        [TestMethod]
        public void RegisterParameterDocumentation()
        {
            ValidateActionDocumentation<RegisterParameter>(CommonPlugins.RegisterParameter);
        }

        [TestMethod]
        public void RegisterParameterDocumentationResourceFile()
        {
            ValidateActionDocumentation<RegisterParameter>(
                CommonPlugins.RegisterParameter, "register-parameter.json");
        }

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
        [DataRow("{'argument':'test_key','elementToActOn':'//positive'}")]
        [DataRow("{'argument':'{{$ --key:test_key}}','elementToActOn':'//positive'}")]
        public void RegisterParameterText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{EnvironmentContext.ApplicationParams["test_key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','elementToActOn':'//positive','elementAttributeToActOn':'id'}")]
        public void RegisterParameterAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','elementToActOn':'//positive','regularExpression':'\\\\d+','elementAttributeToActOn':'id'}")]
        public void RegisterParameterRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test_key','elementToActOn':'2000-12-01'}")]
        public void RegisterParameterNonElementText(string actionRule)
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
        [DataRow("{'argument':'test_key','elementToActOn':'//null'}")]
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
                var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
                Assert.AreEqual("//null", actual);
                throw;
            }
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','elementToActOn':'.//positive'}")]
        public void RegisterParameterElementText(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            Assert.AreEqual("Mock: Positive Element", $"{EnvironmentContext.ApplicationParams["test_key"]}");
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','elementToActOn':'.//positive','elementAttributeToActOn':'id'}")]
        public void RegisterParameterElementAttribute(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^mock attribute value \\d+$"));
        }

        [DataTestMethod]
        [DataRow("{'argument':'test_key','elementToActOn':'.//positive','regularExpression':'\\\\d+','elementAttributeToActOn':'id'}")]
        public void RegisterParameterElementRegex(string actionRule)
        {
            // execute
            ExecuteAction<RegisterParameter>(MockBy.Positive(), actionRule);

            // assertion
            var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
            Assert.IsTrue(Regex.IsMatch(actual, "^\\d+$"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'argument':'test_key','elementToActOn':'2000-12-01'}")]
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

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'argument':'test_key','elementToActOn':'//null'}")]
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
                var actual = $"{EnvironmentContext.ApplicationParams["test_key"]}";
                Assert.AreEqual("//null", actual);
                throw;
            }
        }
    }
}
#pragma warning restore S4144