﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * https://dev.to/franndotexe/mstest-v2---new-old-kid-on-the-block
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using OpenQA.Selenium.Mock.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using Gravity.Plugins.Base;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;

namespace Gravity.Plugins.Actions.UnitTests.Base
{
    [DeploymentItem("Resources/license.lcn")]
    public abstract class ActionTests
    {
        #region *** constants      ***
        private const string ActionMethodName = "OnPerform";

        private const StringComparison Compare = StringComparison.OrdinalIgnoreCase;
        #endregion

        #region *** constructors   ***
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
        #endregion

        #region *** properties     ***
        /// <summary>
        /// Gets a basic web automation instance for all tests in this domain
        /// </summary>
        public WebAutomation WebAutomation { get; }

        /// <summary>
        /// Gets a new MockWebDriver instance or the last instance generated by ActionFactory.
        /// </summary>
        public MockWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets the <see cref="System.Diagnostics.Stopwatch"/> object used by this instance
        /// </summary>
        public Stopwatch Stopwatch { get; }
        #endregion

        #region *** execute plugin ***
        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        public Plugin ExecuteAction<T>() where T : Plugin
        {
            return DoExecuteAction<T>(
                by: default, actionRule: string.Empty, capabilities: null);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="actionRule">ActionRule JSON from which to create an <see cref="ActionRule"/> instance.</param>
        public Plugin ExecuteAction<T>(string actionRule)
            where T : Plugin
        {
            return DoExecuteAction<T>(by: default, actionRule: actionRule, capabilities: null);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="capabilities"><see cref="MockCapabilities"/> capabilities by which to create the <see cref="MockWebDriver"/> of this action.</param>
        public Plugin ExecuteAction<T>(IDictionary<string, object> capabilities)
            where T : Plugin
        {
            return DoExecuteAction<T>(by: default, actionRule: string.Empty, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        public Plugin ExecuteAction<T>(By by) where T : Plugin
        {
            return DoExecuteAction<T>(by: by, actionRule: string.Empty, capabilities: null);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="actionRule">ActionRule JSON from which to create an <see cref="ActionRule"/> instance.</param>
        public Plugin ExecuteAction<T>(By by, string actionRule)
            where T : Plugin
        {
            return DoExecuteAction<T>(by: by, actionRule: actionRule, capabilities: null);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="capabilities"><see cref="MockCapabilities"/> capabilities by which to create the <see cref="MockWebDriver"/> of this action.</param>
        public Plugin ExecuteAction<T>(By by, IDictionary<string, object> capabilities)
            where T : Plugin
        {
            return DoExecuteAction<T>(by: by, actionRule: string.Empty, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="actionRule">ActionRule JSON from which to create an <see cref="ActionRule"/> instance.</param>
        /// <param name="capabilities"><see cref="MockCapabilities"/> capabilities by which to create the <see cref="MockWebDriver"/> of this action.</param>
        public Plugin ExecuteAction<T>(string actionRule, IDictionary<string, object> capabilities)
            where T : Plugin
        {
            return DoExecuteAction<T>(by: default, actionRule: actionRule, capabilities: capabilities);
        }

        /// <summary>
        /// Executes an action <see cref="Plugin"/> of the provided type.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of action which will be executed.</typeparam>
        /// <param name="by">Provides a mechanism by which to find elements within a document.</param>
        /// <param name="actionRule">ActionRule JSON from which to create an <see cref="ActionRule"/> instance.</param>
        /// <param name="capabilities"><see cref="MockCapabilities"/> capabilities by which to create the <see cref="MockWebDriver"/> of this action.</param>
        public Plugin ExecuteAction<T>(By by, string actionRule, IDictionary<string, object> capabilities)
            where T : Plugin
        {
            return DoExecuteAction<T>(by, actionRule, capabilities);
        }

        // executes an action plug-in of the provided type.
        private Plugin DoExecuteAction<T>(By by, string actionRule, IDictionary<string, object> capabilities)
            where T : Plugin
        {
            // setup
            var onActionRule = GetActionRule(actionRule);
            var plugin = ActionFactory<T>(WebAutomation, capabilities);

            // setup conditions
            var isGeneric = plugin is GenericPlugin;
            var isWebDriver = plugin is WebDriverActionPlugin;

            // timer: setup
            Stopwatch.Restart();
            Stopwatch.Start();

            // execute
            try
            {
                if (isWebDriver)
                {
                    ExecuteWebDriverPlugin(plugin, actionRule: onActionRule, by);
                }

                if (isGeneric)
                {
                    ExecuteGenericPlugin(plugin, actionRule: onActionRule);
                }
            }
            finally
            {
                // timer: stop
                Stopwatch.Stop();
            }

            // return the executed plug-in instance.
            return plugin;
        }

        // executes web-driver action plugin
        private void ExecuteWebDriverPlugin(Plugin plugin, ActionRule actionRule, By by)
        {
            // get arguments
            var arguments = by == default
                ? new object[] { actionRule }
                : new object[] { actionRule, WebDriver.FindElement(by) };

            // execute
            ExecutePlugin(plugin, arguments);
        }

        // executes generic action plugin
        private static void ExecuteGenericPlugin(Plugin plugin, ActionRule actionRule)
        {
            // get arguments
            var arguments = actionRule == default
                ? null
                : new object[] { actionRule };

            // execute
            ExecutePlugin(plugin, arguments);
        }

        private static void ExecutePlugin(Plugin plugin, object[] arguments)
        {
            try
            {
                // get method
                var method = Array.Find(plugin
                    .GetType()
                    .GetMethods(), i => i.Name.Equals(ActionMethodName, Compare) && i.GetParameters().Length == arguments.Length);

                // execute
                method.Invoke(plugin, arguments);
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    throw e.InnerException;
                }
                throw;
            }
        }
        #endregion

        #region *** documentation  ***
        /// <summary>
        /// Validate if an action plug in documentation was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="pluginName">The plug-in name to validate against the documentation.</param>
        public void ValidateActionDocumentation<T>(string pluginName) where T : Plugin
        {
            DoValidateActionDocumentation<T>(pluginName, resource: default);
        }

        /// <summary>
        /// Validate if an action plug in documentation was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        /// <param name="pluginName">The plug-in name to validate against the documentation.</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        /// <param name="resource">Resource file name by which to validate ActionAttribute.</param>
        public void ValidateActionDocumentation<T>(string pluginName, string resource)
            where T : Plugin
        {
            DoValidateActionDocumentation<T>(pluginName, resource);
        }

        private void DoValidateActionDocumentation<T>(string pluginName, string resource)
            where T : Plugin
        {
            // get action
            var action = ActionFactory<T>(webAutomation: WebAutomation, capabilities: default);

            // get action attribute
            var attribute = action.GetType().GetCustomAttribute<PluginAttribute>();

            // verify resource
            if (!string.IsNullOrEmpty(resource))
            {
                var assembly = typeof(T).Assembly;
                var actionAttribute = ReadEmbeddedResource<PluginAttribute>(assembly, resource);
                var isName = attribute.Name.Equals(actionAttribute.Name);
                Assert.IsTrue(isName, "Plug-in name does not match to action name in resource file.");
            }

            // validation
            Assert.IsTrue(!string.IsNullOrEmpty(attribute.Description), "Plug-in must have a description.");
            Assert.IsTrue(!string.IsNullOrEmpty(attribute.Summary), "Plug-in must have a summary.");
            Assert.IsTrue(attribute.Name.Equals(pluginName), "Plug-in name does not match to action name.");
            Assert.IsTrue(attribute.Examples.Length > 0, "Plug-in must have at least one example.");
        }
        #endregion

        #region *** documentation  ***
        /// <summary>
        /// Validate if an action plug in was correctly generated (!= default) and have loaded relevant properties.
        /// </summary>
        /// <typeparam name="T">ActionPlugin type to generate.</typeparam>
        public void ValidateAction<T>() where T : Plugin
        {
            // get action
            var action = ActionFactory<T>(webAutomation: WebAutomation, capabilities: default);

            // get properties
            var byFactory = action.GetType().GetProperty("ByFactory");
            var webDriver = action.GetType().GetProperty("WebDriver");

            // validation
            Assert.IsTrue(action != default(T), "Action plug-in was not generated correctly.");
            Assert.IsTrue(Plugin.Types.Any(), "Action plug-in types were not loaded.");

            if (action is WebDriverActionPlugin)
            {
                Assert.IsTrue(byFactory?.GetValue(action) != null, "Action plug-in ByFactory was not generated correctly.");
                Assert.IsTrue(webDriver?.GetValue(action) != null, "Action plug-in WebDriver was not generated correctly.");
            }
        }
        #endregion

        #region *** action rule    ***
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
        #endregion

        #region *** action factory ***
        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>() where T : Plugin
        {
            return ActionFactory<T>(WebAutomation, capabilities: default);
        }

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>(WebAutomation webAutomation)
            where T : Plugin
        {
            return ActionFactory<T>(webAutomation, capabilities: default);
        }

        /// <summary>
        /// Generates an action based on the provided type
        /// </summary>
        /// <typeparam name="T">Action type from which to generate the action.</typeparam>
        /// <param name="webAutomation">Web Automation object by which to generate the action.</param>
        /// <param name="capabilities">Capabilities to add to the action Web Driver instance</param>
        /// <returns>Action plug-in instance of the specified type.</returns>
        public T ActionFactory<T>(WebAutomation webAutomation, IDictionary<string, object> capabilities)
            where T : Plugin
        {
            // setup
            if (capabilities != default)
            {
                WebDriver = WebDriver.ApplyCapabilities(capabilities);
            }

            // generate constructor arguments
            var arguments = WebDriver == default
                ? new object[] { webAutomation }
                : new object[] { webAutomation, WebDriver };

            // generate
            return (T)Activator.CreateInstance(typeof(T), arguments);
        }
        #endregion

        #region *** resources      ***
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
                .Find(assembly.GetManifestResourceNames(), i => i.EndsWith($".{Path.GetFileName(name)}", StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(fileReference))
            {
                return string.Empty;
            }

            var stream = assembly.GetManifestResourceStream(fileReference);
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        #endregion

        #region *** testing        ***
        /// <summary>
        /// Executes a tests by a given number of attempts.
        /// </summary>
        /// <param name="attempts">Number of attempts if the test fails.</param>
        /// <param name="test">Delegate to execute the test.</param>
        public static void Execute(int attempts, Action test)
        {
            for (int i = 0; i < attempts; i++)
            {
                try
                {
                    test.Invoke();
                    return;
                }
                catch (Exception e) when (e != null)
                {
                    Console.WriteLine($"Failed on attempt [{i + 1}] out of [{attempts}].");
                    if (i == attempts - 1)
                    {
                        throw;
                    }
                }
            }
        }
        #endregion
    }
}