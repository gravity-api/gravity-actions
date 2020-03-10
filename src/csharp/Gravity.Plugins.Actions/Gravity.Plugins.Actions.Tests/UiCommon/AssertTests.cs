/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class AssertTests: ActionTests
    {
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
            // setup
            actionRule = actionRule
                .Replace(OnAttribute, onAttribute)
                .Replace(OnCondition, "attribute")
                .Replace(OnOperator, onOperator)
                .Replace(OnOperatorExpected, onOperatorExpected)
                .Replace(OnElement, "//positive");

            // execute
            var plugin = ExecuteAction<Actions.UiCommon.Assert>(actionRule);

            // assertion
            //Assert.IsTrue(EnvironmentContext.ApplicationParams[TestKey].Equals(TestValue));
        }
    }
}
