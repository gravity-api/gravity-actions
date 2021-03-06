﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * https://dev.to/franndotexe/mstest-v2---new-old-kid-on-the-block
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Drivers.Mock.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Gravity.Services.ActionPlugins.Tests.Base
{
    [DeploymentItem("Resources/license.lcn")]
    public abstract class ActionTests
    {
        /// <summary>
        /// Set all static members of this action tests.
        /// </summary>
        static ActionTests()
        {
            Types = Utilities.GetTypes().Where(i => !i.FullName.Contains("Gravity.Services.Comet.Engine.Browser"));
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
            var authentication = new Authentication
            {
                UserName = "",
                Password = ""
            };
            WebAutomation = new WebAutomation
            {
                Authentication = authentication,
                EngineConfiguration = configuration
            };

            // setup: web driver
            WebDriver = new MockWebDriver();

            // setup: timer
            Stopwatch = new Stopwatch();
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
        /// Gets a new MockWebDriver instance or the last instance generated by ActionFactory.
        /// </summary>
        public MockWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets the <see cref="Stopwatch"/> object used by this instance
        /// </summary>
        public Stopwatch Stopwatch { get; }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        public ActionPlugin ExecuteAction<T>() where T : ActionPlugin
        {
            return ExecuteAction<T>(
                by: default, actionRule: string.Empty, capabilities: null);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="actionRule">ActionRule JSON from which to create an ActionRule instance.</param>
        public ActionPlugin ExecuteAction<T>(string actionRule)
            where T : ActionPlugin
        {
            return ExecuteAction<T>(by: default, actionRule: actionRule, capabilities: null);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="capabilities">MockWebDriver capabilities by which to create the MockWebDriver of this action.</param>
        public ActionPlugin ExecuteAction<T>(IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            return ExecuteAction<T>(by: default, actionRule: string.Empty, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="by">WebElement instance on which to perform the action.</param>
        public ActionPlugin ExecuteAction<T>(By by) where T : ActionPlugin
        {
            return ExecuteAction<T>(by: by, actionRule: string.Empty, capabilities: null);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="by">WebElement instance on which to perform the action.</param>
        /// <param name="actionRule">ActionRule JSON from which to create an ActionRule instance.</param>
        public ActionPlugin ExecuteAction<T>(By by, string actionRule)
            where T: ActionPlugin
        {
            return ExecuteAction<T>(by: by, actionRule: actionRule, capabilities: null);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="by">WebElement instance on which to perform the action.</param>
        /// <param name="capabilities">MockWebDriver capabilities by which to create the MockWebDriver of this action.</param>
        public ActionPlugin ExecuteAction<T>(By by, IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            return ExecuteAction<T>(by: by, actionRule: string.Empty, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="actionRule">ActionRule JSON from which to create an ActionRule instance.</param>
        /// <param name="capabilities">MockWebDriver capabilities by which to create the MockWebDriver of this action.</param>
        public ActionPlugin ExecuteAction<T>(string actionRule, IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            return ExecuteAction<T>(by: default, actionRule: actionRule, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action plug-in of the provided type.
        /// </summary>
        /// <typeparam name="T">The type of action which will be executed.</typeparam>
        /// <param name="by">WebElement instance on which to perform the action.</param>
        /// <param name="actionRule">ActionRule JSON from which to create an ActionRule instance.</param>
        /// <param name="capabilities">MockWebDriver capabilities by which to create the MockWebDriver of this action.</param>
        public ActionPlugin ExecuteAction<T>(By by, string actionRule, IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            // setup
            var _actionRule = GetActionRule(actionRule);
            var action = ActionFactory<T>(WebAutomation, capabilities, Types);

            // timer: setup
            Stopwatch.Restart();
            Stopwatch.Start();

            // execute
            if (by == default)
            {
                action.OnPerform(_actionRule);
                return action;
            }
            var element = WebDriver.FindElement(by);
            action.OnPerform(element, _actionRule);

            // timer: stop
            Stopwatch.Stop();

            // return the executed plug-in instance.
            return action;
        }

        /// <summary>
        /// Validate if an action plug in documentation was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="pluginName">The plug-in name to validate against the documentation.</param>
        public void ValidateActionDocumentation<T>(string pluginName) where T : ActionPlugin
        {
            ValidateActionDocumentation<T>(pluginName, default);
        }

        /// <summary>
        /// Validate if an action plug in documentation was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="pluginName">The plug-in name to validate against the documentation.</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public void ValidateActionDocumentation<T>(string pluginName, IEnumerable<Type> types) where T : ActionPlugin
        {
            ValidateActionDocumentation<T>(pluginName, types, string.Empty);
        }

        /// <summary>
        /// Validate if an action plug in documentation was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="pluginName">The plug-in name to validate against the documentation.</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        /// <param name="resource">Resource file name by which to validate ActionAttribute.</param>
        public void ValidateActionDocumentation<T>(string pluginName, IEnumerable<Type> types, string resource)
            where T : ActionPlugin
        {
            // get action
            var action = ActionFactory<T>(webAutomation: WebAutomation, capabilities: default, types: types);

            // get action attribute
            var attribute = action.GetType().GetCustomAttribute<ActionAttribute>();

            // verify resource
            if (!string.IsNullOrEmpty(resource))
            {
                var assembly = typeof(T).Assembly;
                var actionAttribute = ReadEmbeddedResource<ActionAttribute>(assembly, resource);
                var isName = attribute.Name.Equals(actionAttribute.Name);
                Assert.IsTrue(isName, "Plug-in name does not match to action name in resource file.");
            }

            // validation
            Assert.IsTrue(!string.IsNullOrEmpty(attribute.Description), "Plug-in must have a description.");
            Assert.IsTrue(!string.IsNullOrEmpty(attribute.Summary), "Plug-in must have a summary.");
            Assert.IsTrue(attribute.Name.Equals(pluginName), "Plug-in name does not match to action name.");
            Assert.IsTrue(attribute.Examples.Length > 0, "Plug-in must have at least one example.");
        }

        /// <summary>
        /// Validate if an action plug in was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        public void ValidateAction<T>() where T : ActionPlugin
        {
            ValidateAction<T>(types: default);
        }

        /// <summary>
        /// Validate if an action plug in was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public void ValidateAction<T>(IEnumerable<Type> types) where T : ActionPlugin
        {
            // get action
            var action = ActionFactory<T>(webAutomation: WebAutomation, capabilities: default, types: types);

            // validation
            Assert.IsTrue(action != default(T), "Action plug-in was not generated correctly.");
            Assert.IsTrue(action.Types.Any(), "Action plug-in types were not loaded.");
            Assert.IsTrue(action.ByFactory != null, "Action plug-in ByFactory was not generated correctly.");
            Assert.IsTrue(action.WebDriver != default, "Action plug-in WebDriver was not generated correctly.");
        }

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
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>() where T : ActionPlugin
        {
            return ActionFactory<T>(WebAutomation, default, default);
        }

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>(WebAutomation webAutomation)
            where T : ActionPlugin
        {
            return ActionFactory<T>(webAutomation, default, default);
        }

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <param name="capabilities">Capabilities to add to the action Web Driver instance</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>(WebAutomation webAutomation, IDictionary<string, object> capabilities)
            where T : ActionPlugin
        {
            return ActionFactory<T>(webAutomation, capabilities, default);
        }

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <param name="capabilities">Capabilities to add to the action Web Driver instance</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>(WebAutomation webAutomation, IDictionary<string, object> capabilities, IEnumerable<Type> types)
            where T : ActionPlugin
        {
            // setup
            if(capabilities != default)
            {
                WebDriver = WebDriver.ApplyCapabilities(capabilities);
            }

            // generate constructor arguments
            var arguments = (types == default || !types.Any())
                ? new object[] { WebDriver, webAutomation }
                : new object[] { WebDriver, webAutomation, types };

            // generate
            return (T)Activator.CreateInstance(typeof(T), arguments);
        }

        /// <summary>
        /// Reads an embedded resource and attempts to deserialize it into the given type.
        /// Assuming this is a JSON file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">Assembly from which to read the resource.</param>
        /// <param name="name">Resource name, name must match the resource file name.</param>
        public static T ReadEmbeddedResource<T>(Assembly assembly, string name)
        {
            var resource = ReadEmbeddedResource(assembly, name);
            return JsonConvert.DeserializeObject<T>(resource);
        }

        /// <summary>
        /// Reads an embedded resource.
        /// </summary>
        /// <param name="assembly">Assembly from which to read the resource.</param>
        /// <param name="name">Resource name, name must match the resource file name.</param>
        public static string ReadEmbeddedResource(Assembly assembly, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            var fileReference = Array
                .Find(assembly.GetManifestResourceNames(), i => i.EndsWith(Path.GetFileName(name), StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(fileReference))
            {
                return string.Empty;
            }

            using Stream stream = assembly.GetManifestResourceStream(fileReference);
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}