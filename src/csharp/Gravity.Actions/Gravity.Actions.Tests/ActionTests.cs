﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Tests
{
    public abstract class ActionTests
    {
        /// <summary>
        /// Set all static members of this action tests.
        /// </summary>
        static ActionTests()
        {
            Types = Utilities.GetTypes();
        }

        /// <summary>
        /// Creates a new instance of this action tests.
        /// </summary>
        protected ActionTests()
        {
            // setup: web automation
            var configuration = new EngineConfiguration
            {
                ElementSearchingTimeout = 100,
                PageLoadTimeout = 100
            };
            WebAutomation = new WebAutomation { EngineConfiguration = configuration };
        }

        /// <summary>
        /// Gets the types repository loaded for all tests in this domain.
        /// </summary>
        public static IEnumerable<Type> Types { get; }

        /// <summary>
        /// Gets a basic web automation instance for all tests in this domain
        /// </summary>
        public WebAutomation WebAutomation { get; }

        /// <summary>
        /// Gets an action rule object out of action rule JSON (deserialize).
        /// </summary>
        /// <param name="actionRule">Action rule JSON by which to create an action rule object.</param>
        /// <returns>Action rule object.</returns>
        public static ActionRule GetActionRule(string actionRule)
        {
            if (string.IsNullOrEmpty(actionRule))
            {
                return new ActionRule();
            }
            return JsonConvert.DeserializeObject<ActionRule>(actionRule);
        }

        /// <summary>
        /// Gets a new MockWebDriver instance.
        /// </summary>
        public static MockWebDriver WebDriver => new MockWebDriver();

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <param name="capabilities">Capabilities to add to the action Web Driver instance</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public static T ActionFactory<T>(WebAutomation webAutomation, IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            // setup
            capabilities ??= new Dictionary<string, object>();
            var driver = new MockWebDriver(".", capabilities);

            // generate
            return (T)Activator.CreateInstance(typeof(T), new object[] { driver, webAutomation, Types });
        }
    }
}