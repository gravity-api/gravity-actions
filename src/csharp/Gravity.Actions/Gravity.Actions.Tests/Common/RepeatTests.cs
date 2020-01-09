/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class RepeatTests : ActionTests
    {
        private const string RepeatRule = "" +
            "{" +
            "   'argument':'index'," +
            "   'actions':[" +
            "       {" +
            "           'actionType':'Click'," +
            "           'elementToActOn':'//positive'" +
            "       }" +
            "   ]" +
            "}";

        private const string RepeatRuleCondition = "" +
            "{" +
            "   'argument':'condition'," +
            "   'elementToActOn':'random'," +
            "   'actions':[" +
            "       {" +
            "           'actionType':'Click'," +
            "           'elementToActOn':'//positive'" +
            "       }" +
            "   ]" +
            "}";

        [TestMethod]
        public void RepeatCreateNoTypes()
        {
            ValidateAction<Repeat>();
        }

        [TestMethod]
        public void RepeatCreateTypes()
        {
            ValidateAction<Repeat>(Types);
        }

        [TestMethod]
        public void RepeatDocumentationNoTypes()
        {
            ValidateActionDocumentation<Repeat>(ActionType.Repeat);
        }

        [TestMethod]
        public void RepeatDocumentationTypes()
        {
            ValidateActionDocumentation<Repeat>(ActionType.Repeat, Types);
        }

        [TestMethod]
        public void RepeatDocumentationResourceFile()
        {
            ValidateActionDocumentation<Repeat>(ActionType.Repeat, Types, "repeat.json");
        }

        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatPositive(string actionRule)
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "3");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(2, GetRptPos(plugin));
        }

        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatNegativeNumber(string actionRule)
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "-3");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(-1, GetRptPos(plugin));
        }

        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatInvalid(string actionRule)
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "NotNumber");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(-1, GetRptPos(plugin));
        }

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionInvalid(string actionRule)
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomPositive)
                .Replace("condition", "{{$ --until:NoCondition}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin, 2);
        }

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionVisible(string actionRule)
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomNegative)
                .Replace("condition", "{{$ --until:visible}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        }

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionNotVisible(string actionRule)
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomPositive)
                .Replace("condition", "{{$ --until:not-visible}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        }

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionExists(string actionRule)
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomNotExists)
                .Replace("condition", "{{$ --until:exists}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        }

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionNotExists(string actionRule)
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomExists)
                .Replace("condition", "{{$ --until:not-exists}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        }

        // assert conditional repeat. since this is a 90% success rate, inconclusive assert
        // will be thrown if no actions were executed.
        private void AssertCondition(Plugin plugin)
        {
            AssertCondition(plugin, 0);
        }

        // assert conditional repeat. since this is a 90% success rate, inconclusive assert
        // will be thrown if no actions were executed.
        private static void AssertCondition(Plugin plugin, int minimumExpected)
        {
            // get repeat position index
            var repeatPosition = GetRptPos(plugin);

            // inconclusive (if actions were not executed (10% chance)
            var isPosition = repeatPosition != -1;
            var isInconclusive = isPosition && repeatPosition == minimumExpected;
            if (isInconclusive)
            {
                Assert.Inconclusive("Was not able to execute Repeat actions, please rerun this test.");
            }

            // assert repeat position index
            Assert.IsTrue(repeatPosition > minimumExpected);
        }

        // Gets the repeater position of this plug-in session (from WebDriver)
        private static int GetRptPos(Plugin plugin)
        {
            // shortcuts
            const string P = AutomationEnvironment.REPEATER_POSITION_PARAM;
            var S = plugin.WebDriver.GetSession().ToString();
            var K = $"{P}-{S}";

            // exit conditions
            if (!AutomationEnvironment.SessionParams.ContainsKey(K))
            {
                return -1;
            }

            // fetch
            return (int)AutomationEnvironment.SessionParams[K];
        }
    }
}
#pragma warning restore S4144