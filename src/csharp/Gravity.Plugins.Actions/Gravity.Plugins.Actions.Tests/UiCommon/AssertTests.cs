/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Framework;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Mock;

using System.Linq;
using System.Text.Json;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144 // Methods should not have identical implementations
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class AssertTests : ActionTests
    {
        #region *** constants            ***
        private const string TestKey = "evaluation";
        private const string OnElement = "[onElement]";
        private const string OnAttribute = "[onAttribute]";
        private const string OnCondition = "[onCondition]";
        private const string OnOperator = "[onOperator]";
        private const string OnOperatorExpected = "[onOperatorExpected]";

        private const string ActionRuleArgumentOperator =
            "{" +
            "    \"argument\":\"{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}\"" +
            "}";

        private const string ActionRuleBoolean =
            "{" +
            "    \"argument\":\"{{$ --" + OnCondition + "}}\"," +
            "    \"onElement\":\"" + OnElement + "\"" +
            "}";

        private const string ActionRuleAttributeOperator =
            "{" +
            "    \"argument\":\"{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}\"," +
            "    \"onElement\":\"" + OnElement + "\"," +
            "    \"onAttribute\":\"" + OnAttribute + "\"" +
            "}";

        private const string ActionRuleNoAttributeOperator =
            "{" +
            "    \"argument\":\"{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}\"," +
            "    \"onElement\":\"" + OnElement + "\"" +
            "}";
        #endregion

        // members
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        #region *** tests: documentation ***
        [TestMethod]
        public void AssertCreate()
        {
            AssertPlugin<Plugins.Actions.UiCommon.Assert>();
        }

        [TestMethod]
        public void AssertDocumentation()
        {
            AssertDocumentation<Plugins.Actions.UiCommon.Assert>(
                pluginName: PluginsList.Assert);
        }

        [TestMethod]
        public void AssertDocumentationResourceFile()
        {
            AssertDocumentation<Plugins.Actions.UiCommon.Assert>(
                pluginName: PluginsList.Assert,
                resource: "assert.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [TestMethod]
        public void HasAlert()
        {
            // setup
            const string actionRule = "{\"argument\":\"{{$ --alert_exists}}\"}";
            WebDriver.Capabilities[MockCapabilities.HasAlert] = true;

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // result
            var actual = GetEvaluation(plugin);

            // assertion
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasAlertFalse()
        {
            // setup
            const string actionRule = "{\"argument\":\"{{$ --no_alert}}\"}";
            WebDriver.Capabilities[MockCapabilities.HasAlert] = false;

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // result
            var actual = GetEvaluation(plugin);

            // assertion
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void HasNoAlert()
        {
            // setup
            const string actionRule = "{\"argument\":\"{{$ --no_alert}}\"}";

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // result
            var actual = GetEvaluation(plugin);

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleNoAttributeOperator, "eq", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "ne", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "gt", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "lt", "11")]
        [DataRow(ActionRuleNoAttributeOperator, "ge", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "le", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "match", "^10$")]
        [DataRow(ActionRuleNoAttributeOperator, "not_match", "^1$")]
        public void AssertParameter(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            ExecuteAction<RegisterParameter>("{\"argument\":\"{{$ --key:test_key --value:10}}\"}");
            var actual = GetActual(actionRule, string.Empty, onOperator, onOperatorExpected, "parameter", "test_key");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleNoAttributeOperator, "eq", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "ne", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "gt", "0")]
        [DataRow(ActionRuleNoAttributeOperator, "lt", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "ge", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "le", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "match", "^1$")]
        [DataRow(ActionRuleNoAttributeOperator, "not_match", "^10$")]
        public void AssertParameterReqularExpression(string actionRule, string onOperator, string onOperatorExpected)
        {
            // setup
            var onActionRule = JsonSerializer.Deserialize<ActionRule>(actionRule, serializerOptions);
            onActionRule.RegularExpression = "\\d{1}";
            actionRule = JsonSerializer.Serialize(onActionRule, serializerOptions);

            // execute
            ExecuteAction<RegisterParameter>("{\"argument\":\"{{$ --key:test_key --value:10}}\"}");
            var actual = GetActual(actionRule, string.Empty, onOperator, onOperatorExpected, "parameter", "test_key");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleNoAttributeOperator, "eq", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "gt", "0")]
        [DataRow(ActionRuleNoAttributeOperator, "lt", "10")]
        [DataRow(ActionRuleNoAttributeOperator, "ge", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "le", "1")]
        [DataRow(ActionRuleNoAttributeOperator, "match", "^1$")]
        public void AssertParameterNoKey(string actionRule, string onOperator, string onOperatorExpected)
        {
            // setup
            var onActionRule = JsonSerializer.Deserialize<ActionRule>(actionRule, serializerOptions);
            onActionRule.RegularExpression = "\\d{1}";
            actionRule = JsonSerializer.Serialize(onActionRule, serializerOptions);

            // execute
            ExecuteAction<RegisterParameter>("{\"argument\":\"{{$ --key:test_key --value:10}}\"}");
            var actual = GetActual(actionRule, string.Empty, onOperator, onOperatorExpected, "parameter", "no_test_key");

            // assertion
            Assert.IsFalse(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleAttributeOperator, "index", "eq", "0")]
        [DataRow(ActionRuleAttributeOperator, "index", "ne", "1")]
        [DataRow(ActionRuleAttributeOperator, "index", "gt", "-1")]
        [DataRow(ActionRuleAttributeOperator, "index", "lt", "1")]
        [DataRow(ActionRuleAttributeOperator, "index", "ge", "0")]
        [DataRow(ActionRuleAttributeOperator, "index", "le", "0")]
        [DataRow(ActionRuleAttributeOperator, "random", "match", @"^mock attribute value \\d+$")]
        [DataRow(ActionRuleAttributeOperator, "random", "not_match", @"^\\d+ mock attribute value$")]
        public void AssertAttribute(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(actionRule, onAttribute, onOperator, onOperatorExpected, "attribute", "//positive");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleAttributeOperator, "index", "eq", "2")]
        [DataRow(ActionRuleAttributeOperator, "index", "ne", "3")]
        [DataRow(ActionRuleAttributeOperator, "index", "gt", "1")]
        [DataRow(ActionRuleAttributeOperator, "index", "lt", "3")]
        [DataRow(ActionRuleAttributeOperator, "index", "ge", "2")]
        [DataRow(ActionRuleAttributeOperator, "index", "le", "2")]
        public void AssertCount(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(actionRule, onAttribute, onOperator, onOperatorExpected, "count", "//positive");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void AssertDisabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "disabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertDisabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "disabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleArgumentOperator, "eq", "OpenQA.Selenium.Mock.MockWebDriver")]
        [DataRow(ActionRuleArgumentOperator, "ne", "Selenium.Mock.MockWebDriver.OpenQA")]
        [DataRow(ActionRuleArgumentOperator, "match", "OpenQA.Selenium")]
        [DataRow(ActionRuleArgumentOperator, "not_match", "Selenium.OpenQA")]
        public void AssertDriver(string actionRule, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnCondition, "driver")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected);

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void AssertEnabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "enabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertEnabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "enabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void AssertExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void AssertExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void AssertHidden(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "hidden");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void AssertHiddenNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "hidden");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertNotExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void AssertNotExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void AssertNotSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertNotSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void AssertSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void AssertStale(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "stale");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void AssertStaleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "stale");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleNoAttributeOperator, "eq", "Mock: Positive Element")]
        [DataRow(ActionRuleNoAttributeOperator, "ne", "Mock: Element Positive")]
        [DataRow(ActionRuleNoAttributeOperator, "match", "Positive")]
        [DataRow(ActionRuleNoAttributeOperator, "not_match", "Element Positive")]
        public void AssertText(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(actionRule, onAttribute: default, onOperator, onOperatorExpected, "text", "//positive");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleArgumentOperator, "eq", "Mock Gravity API Page Title")]
        [DataRow(ActionRuleArgumentOperator, "ne", "Title Mock Gravity API Page")]
        [DataRow(ActionRuleArgumentOperator, "match", "Mock Gravity")]
        [DataRow(ActionRuleArgumentOperator, "not_match", "Gravity Mock")]
        public void AssertTitle(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(actionRule, onAttribute: default, onOperator, onOperatorExpected, "title", onElement: default);

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleArgumentOperator, "eq", "http://positive.io/")]
        [DataRow(ActionRuleArgumentOperator, "ne", "http://io.positive/")]
        [DataRow(ActionRuleArgumentOperator, "match", "positive.io")]
        [DataRow(ActionRuleArgumentOperator, "not_match", "io.positive")]
        public void AssertUrl(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(actionRule, onAttribute: default, onOperator, onOperatorExpected, "url", onElement: default);

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void AssertVisible(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "visible");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void AssertVisibleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "visible");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleArgumentOperator, "eq", "1")]
        [DataRow(ActionRuleArgumentOperator, "ne", "2")]
        [DataRow(ActionRuleArgumentOperator, "gt", "0")]
        [DataRow(ActionRuleArgumentOperator, "lt", "2")]
        [DataRow(ActionRuleArgumentOperator, "ge", "1")]
        [DataRow(ActionRuleArgumentOperator, "le", "1")]
        public void AssertWindowsCount(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(
                actionRule, onAttribute: default, onOperator, onOperatorExpected, "windows_count", onElement: default);

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "eq", "24")]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "ne", "25")]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "gt", "23")]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "lt", "25")]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "ge", "23")]
        [DataRow(ActionRuleAttributeOperator, "MockAttribute", "le", "25")]
        public void AssertTextLengthFromAttribute(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(
                actionRule,
                onAttribute,
                onOperator,
                onOperatorExpected,
                onCondition: Conditions.TextLength,
                onElement: "//positive");

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(ActionRuleNoAttributeOperator, "eq", "22")]
        [DataRow(ActionRuleNoAttributeOperator, "ne", "23")]
        [DataRow(ActionRuleNoAttributeOperator, "gt", "21")]
        [DataRow(ActionRuleNoAttributeOperator, "lt", "23")]
        [DataRow(ActionRuleNoAttributeOperator, "ge", "22")]
        [DataRow(ActionRuleNoAttributeOperator, "le", "22")]
        public void AssertTextLength(string actionRule, string onOperator, string onOperatorExpected)
        {
            // execute
            var actual = GetActual(
                actionRule,
                onAttribute: string.Empty,
                onOperator,
                onOperatorExpected,
                onCondition: Conditions.TextLength,
                onElement: "//positive");

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementDisabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "disabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementDisabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "disabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void AssertElementEnabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "enabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementEnabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "enabled");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void AssertElementExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementHidden(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "hidden");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void AssertElementHiddenNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "hidden");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementNotExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void AssertElementNotExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_exists");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementNotSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementNotSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "not_selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void AssertElementSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "selected");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void AssertElementStale(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "stale");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void AssertElementStaleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "stale");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void AssertElementVisible(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "visible");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(GetEvaluation(plugin));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementVisibleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "visible");

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }
        #endregion

        #region *** tests: utilities     ***
        private bool GetActual(
            string actionRule,
            string onAttribute,
            string onOperator,
            string onOperatorExpected,
            string onCondition,
            string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, onCondition)
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, onElement);

            // execute
            var plugin = ExecuteAction<Plugins.Actions.UiCommon.Assert>(actionRule);

            // result
            return GetEvaluation(plugin);
        }

        private static bool GetEvaluation(Plugin plugin) => (bool)plugin
            .Extractions
            .First()
            .Entities
            .First()
            .Content[TestKey];
        #endregion
    }
}