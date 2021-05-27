/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Extensions;
using OpenQA.Selenium.Mock;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class RepeatTests : ActionTests
    {
        #region *** constants            ***
        private const int Attempts = 10;

        private const string RepeatRule = "" +
            "{" +
            "   \"argument\":\"index\"," +
            "   \"actions\":[" +
            "       {" +
            "           \"action\":\"Click\"," +
            "           \"onElement\":\"//positive\"" +
            "       }" +
            "   ]" +
            "}";

        private const string RepeatRuleCondition = "" +
            "{" +
            "   \"argument\":\"condition\"," +
            "   \"onElement\":\"random\"," +
            "   \"actions\":[" +
            "       {" +
            "           \"action\":\"Click\"," +
            "           \"onElement\":\"//positive\"" +
            "       }" +
            "   ]" +
            "}";
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void RepeatCreate()
        {
            AssertPlugin<Repeat>();
        }

        [TestMethod]
        public void RepeatDocumentation()
        {
            AssertDocumentation<Repeat>(pluginName: GravityPlugins.Repeat);
        }

        [TestMethod]
        public void RepeatDocumentationResourceFile()
        {
            AssertDocumentation<Repeat>(
                pluginName: GravityPlugins.Repeat,
                resource: "repeat.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatPositive(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "3");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(2, GetRptPos(plugin));
        });

        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatNegativeNumber(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "-3");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(-1, GetRptPos(plugin));
        });

        [DataTestMethod]
        [DataRow(RepeatRule)]
        public void RepeatInvalid(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule.Replace("index", "NotNumber");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            Assert.AreEqual(-1, GetRptPos(plugin));
        });

        [DataTestMethod, ExpectedException(typeof(InvalidOperationException))]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionInvalid(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomPositive)
                .Replace("condition", "{{$ --until:NoCondition}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin, 2);
        });

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionVisible(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomNegative)
                .Replace("condition", "{{$ --until:visible}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        });

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionHidden(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomPositive)
                .Replace("condition", "{{$ --until:hidden}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        });

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionExists(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomNotExists)
                .Replace("condition", "{{$ --until:exists}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        });

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionNotExists(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomExists)
                .Replace("condition", "{{$ --until:not_exists}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        });

        [DataTestMethod]
        [DataRow(RepeatRuleCondition)]
        public void RepeatConditionStale(string actionRule) => Execute(Attempts, () =>
        {
            // parse action-rule
            var rule = actionRule
                .Replace("random", MockLocators.RandomStale)
                .Replace("condition", "{{$ --until:stale}}");

            // execute 
            var plugin = ExecuteAction<Repeat>(rule);

            // assertion
            AssertCondition(plugin);
        });
        #endregion

        #region *** utilities            ***
        // assert conditional repeat. since this is a 90% success rate, inconclusive assert
        // will be thrown if no actions were executed.
        private static void AssertCondition(Plugin plugin)
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
            var S = ((WebDriverActionPlugin)plugin).WebDriver.GetSession().ToString();
            var K = $"rptpos_{S}";

            // exit conditions
            if (!EnvironmentContext.ApplicationParams.ContainsKey(K))
            {
                return -1;
            }

            // fetch
            return (int)EnvironmentContext.ApplicationParams[K];
        }
        #endregion
    }
}