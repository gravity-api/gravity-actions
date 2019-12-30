/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class RepeatTests : ActionTests
    {
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
            ValidateActionDocumentation<Repeat>(ActionType.REPEAT);
        }

        [TestMethod]
        public void RepeatDocumentationTypes()
        {
            ValidateActionDocumentation<Repeat>(ActionType.REPEAT, Types);
        }

        [TestMethod]
        public void RepeatDocumentationResourceFile()
        {
            ValidateActionDocumentation<Repeat>(ActionType.REPEAT, Types, "repeat.json");
        }

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "   'argument':'3'," +
            "   'actions':[" +
            "       {" +
            "           'actionType':'Click'," +
            "           'elementToActOn':'//positive'" +
            "       }" +
            "   ]" +
            "}")]
        public void RepeatPositive(string actionRule)
        {
            // execute 
            var plugin = ExecuteAction<Repeat>(actionRule);

            // assertion
            Assert.AreEqual(2, GetRptPos(plugin));
        }

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "   'argument':'{{$ --iterations:3}}'," +
            "   'actions':[" +
            "       {" +
            "           'actionType':'Click'," +
            "           'elementToActOn':'//positive'" +
            "       }" +
            "   ]" +
            "}")]
        public void RepeatIterationsPositive(string actionRule)
        {
            // execute 
            var plugin = ExecuteAction<Repeat>(actionRule);

            // assertion
            Assert.AreEqual(2, GetRptPos(plugin));
        }

        // Gets the repeater position of this plug-in session (from WebDriver)
        private dynamic GetRptPos(Plugin plugin)
        {
            // setup
            var session = plugin.WebDriver.GetSession().ToString();
            var repeatReferenceKey = $"{AutomationEnvironment.REPEATER_POSITION_PARAM}-{session}";

            // fetch
            return AutomationEnvironment.SessionParams[repeatReferenceKey];
        }
    }
}
#pragma warning restore S4144