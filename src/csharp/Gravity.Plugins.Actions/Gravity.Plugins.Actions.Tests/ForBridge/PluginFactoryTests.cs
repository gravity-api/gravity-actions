/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-02-03
 *    - modify: refactoring
 * 
 * online resources
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Gravity.Plugins.UnitTests.Mocks.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gravity.Plugins.UnitTests.Engine
{
    [TestClass]
    public class PluginFactoryTests
    {
        [TestMethod]
        public void GenericPluginFactorEmptyAttribute()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericAction) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule);

            // assertion
            Assert.IsTrue(plugin != null);
        }

        [TestMethod]
        public void GenericPluginFactorNoAttribute()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericActionNoAttribute) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule);

            // assertion
            Assert.IsTrue(plugin == null);
        }

        [TestMethod]
        public void GenericPluginFactorNoPlugin()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericActionNoPlugin) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule);

            // assertion
            Assert.IsTrue(plugin == null);
        }

        [TestMethod]
        public void GenericPluginFactorEmpty()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericActionEmpty) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule);

            // assertion
            Assert.IsTrue(plugin == null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GenericPluginFactorNoActionRule()
        {
            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule: default);

            // assertion
            Assert.IsTrue(plugin == null);
        }

        [TestMethod]
        public void GenericPluginFactorActionRuleParameters()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericAction) };

            // execute
            var plugin = new PluginFactory(new WebAutomation(), null).Factor(actionRule);

            // assertion
            Assert.IsTrue(plugin != null);
        }

        [TestMethod]
        public void GenericPluginExecute()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericAction) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule).Execute(actionRule: default);

            // assertion
            Assert.AreEqual(expected: "completed", actual: plugin.Environment.SessionParams["OnPerform()"]);
        }

        [TestMethod]
        public void GenericPluginExecuteWithActionRule()
        {
            // setup
            var actionRule = new ActionRule { ActionType = nameof(GenericAction) };

            // execute
            var plugin = new PluginFactory(new WebAutomation()).Factor(actionRule).Execute(actionRule);

            // assertion
            Assert.AreEqual(expected: "completed", actual: plugin.Environment.SessionParams["OnPerform(ActionRule)"]);
        }
    }
}