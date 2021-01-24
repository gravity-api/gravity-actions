/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Gravity.Plugins.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Mock;
using System;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Gravity.Plugins.Contracts;

namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    [DoNotParallelize]
    public class ConditionTests : ActionTests
    {
        #region *** constants            ***
        private const string TestKey = "test_key";
        private const string TestValue = "true";
        private const string OnElement = "[onElement]";
        private const string OnAttribute = "[onAttribute]";
        private const string OnCondition = "[onCondition]";
        private const string OnOperator = "[onOperator]";
        private const string OnOperatorExpected = "[onOperatorExpected]";

        private const string ActionRuleBoolean =
            "{" +
            "    'argument':'{{$ --" + OnCondition + "}}'," +
            "    'onElement':'" + OnElement + "'," +
            "    'actions': [" +
            "    {" +
            "        'action':'RegisterParameter'," +
            "        'argument':'{{$ --key:test_key --value:true}}'" +
            "    }]" +
            "}";

        private const string ActionRuleOperator =
            "{" +
            "    'argument':'{{$ --" + OnCondition + " --" + OnOperator + ":" + OnOperatorExpected + "}}'," +
            "    'onElement':'" + OnElement + "'," +
            "    'onAttribute':'" + OnAttribute + "'," +
            "    'actions': [" +
            "    {" +
            "        'action':'RegisterParameter'," +
            "        'argument':'{{$ --key:test_key --value:true}}'" +
            "    }]" +
            "}";
        #endregion

        #region *** tests: life cycle    ***
        [TestCleanup]
        public void Cleanup()
        {
            EnvironmentContext.ApplicationParams.Clear();
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void ConditionCreate()
        {
            AssertPlugin<Condition>();
        }

        [TestMethod]
        public void ConditionDocumentation()
        {
            AssertDocumentation<Condition>(
                pluginName: PluginsList.Condition);
        }

        [TestMethod]
        public void ConditionDocumentationResourceFile()
        {
            AssertDocumentation<Condition>(
                pluginName: PluginsList.Condition,
                resource: "condition.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void ConditionExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "exists");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void ConditionExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "exists");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void ConditionVisible(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "visible");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void ConditionVisibleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "visible");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void ConditionHidden(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "hidden");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void ConditionHiddenNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "hidden");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionNotExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_exists");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void ConditionNotExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_exists");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        public void ConditionStale(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "stale");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionStaleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "stale");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void ConditionEnabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "enabled");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionEnabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "enabled");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void ConditionDisabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "disabled");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionDisabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "disabled");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//positive")]
        public void ConditionSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "selected");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//negative")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "selected");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//negative")]
        public void ConditionNotSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_selected");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, "//stale")]
        [DataRow(ActionRuleBoolean, "//positive")]
        [DataRow(ActionRuleBoolean, "//none")]
        [DataRow(ActionRuleBoolean, "//null")]
        public void ConditionNotSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_selected");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "index", "eq", "0")]
        [DataRow(ActionRuleOperator, "index", "ne", "1")]
        [DataRow(ActionRuleOperator, "index", "gt", "-1")]
        [DataRow(ActionRuleOperator, "index", "lt", "1")]
        [DataRow(ActionRuleOperator, "index", "ge", "0")]
        [DataRow(ActionRuleOperator, "index", "le", "0")]
        [DataRow(ActionRuleOperator, "random", "match", @"^mock attribute value \\d+$")]
        [DataRow(ActionRuleOperator, "random", "not_match", @"^\\d+ mock attribute value$")]
        public void ConditionAttribute(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "attribute")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "", "eq", "Mock: Positive Element")]
        [DataRow(ActionRuleOperator, "", "ne", "Mock: Element Positive")]
        [DataRow(ActionRuleOperator, "", "match", "Positive")]
        [DataRow(ActionRuleOperator, "", "not_match", "Element Positive")]
        public void ConditionText(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "text")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "", "eq", "OpenQA.Selenium.Mock.MockWebDriver")]
        [DataRow(ActionRuleOperator, "", "ne", "Selenium.Mock.MockWebDriver.OpenQA")]
        [DataRow(ActionRuleOperator, "", "match", "OpenQA.Selenium")]
        [DataRow(ActionRuleOperator, "", "not_match", "Selenium.OpenQA")]
        public void ConditionDriver(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "driver")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "index", "eq", "2")]
        [DataRow(ActionRuleOperator, "index", "ne", "3")]
        [DataRow(ActionRuleOperator, "index", "gt", "1")]
        [DataRow(ActionRuleOperator, "index", "lt", "3")]
        [DataRow(ActionRuleOperator, "index", "ge", "2")]
        [DataRow(ActionRuleOperator, "index", "le", "2")]
        public void ConditionCount(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "count")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "", "eq", "http://positive.io/")]
        [DataRow(ActionRuleOperator, "", "ne", "http://io.positive/")]
        [DataRow(ActionRuleOperator, "", "match", "positive.io")]
        [DataRow(ActionRuleOperator, "", "not_match", "io.positive")]
        public void ConditionUrl(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "url")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "", "eq", "Mock Gravity API Page Title")]
        [DataRow(ActionRuleOperator, "", "ne", "Title Mock Gravity API Page")]
        [DataRow(ActionRuleOperator, "", "match", "Mock Gravity")]
        [DataRow(ActionRuleOperator, "", "not_match", "Gravity Mock")]
        public void ConditionTitle(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "title")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleOperator, "index", "eq", "1")]
        [DataRow(ActionRuleOperator, "index", "ne", "2")]
        [DataRow(ActionRuleOperator, "index", "gt", "0")]
        [DataRow(ActionRuleOperator, "index", "lt", "2")]
        [DataRow(ActionRuleOperator, "index", "ge", "1")]
        [DataRow(ActionRuleOperator, "index", "le", "1")]
        public void ConditionWindowsCount(string actionRule, string onAttribute, string onOperator, string onOperatorExpected)
        {
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "windows_count")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            ExecuteAction<Condition>(actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void ConditionElementExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "exists");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void ConditionElementExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "exists");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void ConditionElementVisible(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "visible");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void ConditionElementVisibleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "visible");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void ConditionElementHidden(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "hidden");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void ConditionElementHiddenNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "hidden");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementNotExists(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_exists");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void ConditionElementNotExistsNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_exists");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        public void ConditionElementStale(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "stale");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementStaleNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "stale");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void ConditionElementEnabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "enabled");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementEnabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "enabled");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void ConditionElementDisabled(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "disabled");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementDisabledNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "disabled");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//positive")]
        public void ConditionElementSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "selected");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//negative")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "selected");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//negative")]
        public void ConditionElementNotSelected(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_selected");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }

        [DataTestMethod]
        [DataRow(ActionRuleBoolean, ".//stale")]
        [DataRow(ActionRuleBoolean, ".//positive")]
        [DataRow(ActionRuleBoolean, ".//none")]
        [DataRow(ActionRuleBoolean, ".//null")]
        public void ConditionElementNotSelectedNegative(string actionRule, string onElement)
        {
            // setup
            actionRule = actionRule
                .Replace(OnElement, onElement)
                .Replace(OnCondition, "not_selected");

            // execute
            ExecuteAction<Condition>(MockBy.Positive(), actionRule, parameters: Array.Empty<object>());

            // assertion
            Assert.IsTrue(!EnvironmentContext.ApplicationParams.ContainsKey(TestKey));
        }
        #endregion
    }
}