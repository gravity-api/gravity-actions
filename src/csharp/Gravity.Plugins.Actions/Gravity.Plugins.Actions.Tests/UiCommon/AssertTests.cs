/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using System.Linq;

namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class AssertTests : ActionTests
    {
        private const string TestKey = "evaluation";
        private const string OnElement = "[onElement]";
        private const string OnAttribute = "[onAttribute]";
        private const string OnCondition = "[onCondition]";
        private const string OnOperator = "[onOperator]";
        private const string OnOperatorExpected = "[onOperatorExpected]";

        private const string ActionRuleArgumentOperator =
            "{" +
            "    'argument':'{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}'" +
            "}";

        private const string ActionRuleBoolean =
            "{" +
            "    'argument':'{{$ --" + OnCondition + "}}'," +
            "    'elementToActOn':'" + OnElement + "'" +
            "}";

        private const string ActionRuleAttributeOperator =
            "{" +
            "    'argument':'{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}'," +
            "    'elementToActOn':'" + OnElement + "'," +
            "    'elementAttributeToActOn':'" + OnAttribute + "'" +
            "}";

        private const string ActionRuleNoAttributeOperator =
            "{" +
            "    'argument':'{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}'," +
            "    'elementToActOn':'" + OnElement + "'" +
            "}";

        [TestMethod]
        public void AssertCreate()
        {
            ValidateAction<Actions.UiCommon.Assert>();
        }

        [TestMethod]
        public void AssertDocumentation()
        {
            ValidateActionDocumentation<Actions.UiCommon.Assert>(CommonPlugins.Assert);
        }

        [TestMethod]
        public void AssertDocumentationResourceFile()
        {
            ValidateActionDocumentation<Actions.UiCommon.Assert>(CommonPlugins.Assert, "assert.json");
        }

        #region *** on driver  ***
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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
        [DataRow(ActionRuleArgumentOperator, "eq", "http://mockgravityapiurl.com/")]
        [DataRow(ActionRuleArgumentOperator, "ne", "http://com.mockgravityapiurl/")]
        [DataRow(ActionRuleArgumentOperator, "match", "mockgravityapiurl")]
        [DataRow(ActionRuleArgumentOperator, "not_match", "com.mockgravityapiurl")]
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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

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
        #endregion

        #region *** on element ***
        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void AssertElementDisabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule.Replace(OnElement, onElement).Replace(OnCondition, "disabled");

            // execute
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

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
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(!GetEvaluation(plugin));
        }
        #endregion

        private bool GetActual(string actionRule, string onAttribute, string onOperator, string onOperatorExpected, string onCondition, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, onCondition)
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, onElement);

            // execute
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

            // result
            return GetEvaluation(plugin);
        }

        private static bool GetEvaluation(Plugin plugin) => (bool)plugin
            .ExtractionResults
            .First()
            .Entities
            .First()
            .EntityContent[TestKey];
    }
}