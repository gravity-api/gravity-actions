/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gravity.Plugins.Engine
{
    /// <summary>
    /// Factory for generating and executing <see cref="Plugin"/> types.
    /// </summary>
    public sealed class PluginFactory
    {
        #region *** constructors    ***
        /// <summary>
        /// Creates a new instance of <see cref="PluginFactory"/>.
        /// </summary>
        /// <param name="automation"><see cref="Contracts.WebAutomation"/> by which to factor <see cref="Base.Plugin"/> instance.</param>
        public PluginFactory(WebAutomation automation)
            : this(automation, Array.Empty<object>())
        { }

        /// <summary>
        /// Creates a new instance of <see cref="PluginFactory"/>.
        /// </summary>
        /// <param name="automation"><see cref="Contracts.WebAutomation"/> by which to factor <see cref="Base.Plugin"/> instance.</param>
        /// <param name="parameters">This is an array of objects with the same number, order, and type as the parameters of the <see cref="Base.Plugin"/> constructor to be invoked.</param>
        public PluginFactory(WebAutomation automation, object[] parameters)
        {
            // setup
            WebAutomation = automation;
            parameters ??= Array.Empty<object>();
            ConstructorParameters = new[] { automation }.Concat(parameters).Where(i => i != null);
        }
        #endregion

        #region *** properties      ***
        /// <summary>
        /// Gets the <see cref="Services.DataContracts.WebAutomation"/> which is used to create <see cref="Base.Plugin"/> objects.
        /// </summary>
        public WebAutomation WebAutomation { get; }

        /// <summary>
        /// Gets or sets the constructor parameters used to create <see cref="Base.Plugin"/> objects.
        /// </summary>
        public IEnumerable<object> ConstructorParameters { get; set; }

        /// <summary>
        /// Gets the <see cref="Contracts.ActionRule"/> under this <see cref="PluginFactory"/> instance.
        /// </summary>
        public ActionRule ActionRule { get; private set; }

        /// <summary>
        /// Gets the <see cref="Base.Plugin"/> instance populated by <see cref="DoFactor(ActionRule, object[])"/> method.
        /// </summary>
        public Plugin Plugin { get; private set; }
        #endregion

        #region *** plugin: get     ***
        /// <summary>
        /// Factors a <see cref="Base.Plugin"/> instance from the provided <see cref="Contracts.ActionRule"/>.
        /// </summary>
        /// <param name="actionRule">The <see cref="Contracts.ActionRule"/> by which to factor a <see cref="Base.Plugin"/>.</param>
        /// <returns>A new <see cref="Base.Plugin"/> instance.</returns>
        public PluginFactory Factor(ActionRule actionRule)
        {
            return DoFactor(actionRule, parameters: ConstructorParameters.ToArray());
        }

        /// <summary>
        /// Factors a <see cref="Base.Plugin"/> instance from the provided <see cref="Contracts.ActionRule"/>.
        /// </summary>
        /// <param name="actionRule">The <see cref="Contracts.ActionRule"/> by which to factor a <see cref="Base.Plugin"/>.</param>
        /// <param name="parameters">This is an array of objects with the same number, order, and type as the parameters of the <see cref="Base.Plugin"/> constructor to be invoked.</param>
        /// <returns>A new <see cref="Base.Plugin"/> instance.</returns>
        public PluginFactory Factor(ActionRule actionRule, object[] parameters)
        {
            return DoFactor(actionRule, parameters);
        }

        // factor a plugin
        private PluginFactory DoFactor(ActionRule actionRule, object[] parameters)
        {
            // setup
            AssertDoGet(actionRule);
            ActionRule = actionRule;

            // get plugin type
            var pluginType = Plugin.Types.FirstOrDefault(i => i.IsPlugin(actionRule.Action));

            // exit conditions
            if (pluginType == default)
            {
                return default;
            }

            // factor parameters
            var actualParameters = ParametersFactory(pluginType, parameters);

            // factor plugin
            Plugin = (Plugin)Activator.CreateInstance(type: pluginType, args: actualParameters);

            // result
            return this;
        }

        private object[] ParametersFactory(Type pluginType, object[] parameters)
        {
            // setup
            var actualParameters = new List<object>();

            // factory
            if (typeof(GenericPlugin).IsAssignableFrom(pluginType))
            {
                var range = parameters
                    .Where(i => i != null && (i.GetType() == typeof(WebAutomation) || i.GetType() == typeof(EnvironmentContext)));
                actualParameters.AddRange(range);
            }
            else if (typeof(WebDriverActionPlugin).IsAssignableFrom(pluginType))
            {
                var range = parameters
                    .Where(i => i.GetType() == typeof(WebAutomation) || (i is IWebDriver));
                actualParameters.AddRange(range);
            }
            else
            {
                actualParameters.AddRange(parameters);
            }

            // result
            return actualParameters.ToArray();
        }

        // assert for DoGet compliance
        private static void AssertDoGet(ActionRule actionRule)
        {
            // assertion: null
            if (actionRule == default)
            {
                throw new ArgumentNullException(nameof(actionRule));
            }
        }
        #endregion

        #region *** plugin: execute ***
        /// <summary>
        /// Executes a <see cref="Base.Plugin"/> with no arguments (will call <see cref="GenericPlugin.OnPerform"/> method).
        /// </summary>
        public Plugin Execute()
        {
            return DoExecute(actionRule: ActionRule, parameters: Array.Empty<object>());
        }

        /// <summary>
        /// Executes a <see cref="Plugin"/> with no arguments (will call <see cref="GenericPlugin.OnPerform"/> method).
        /// </summary>
        /// <param name="parameters">An argument list for the invoked method. This is an array of objects with the same number, order, and type as the parameters of the method.</param>
        public Plugin Execute(object[] parameters)
        {
            return DoExecute(actionRule: ActionRule, parameters);
        }

        /// <summary>
        /// Executes a <see cref="Plugin"/> with no arguments (will call <see cref="GenericPlugin.OnPerform"/> method).
        /// </summary>
        /// <param name="actionRule">The <see cref="ActionRule"/> to execute.</param>
        /// <returns>The <see cref="Base.Plugin"/> under this execution context.</returns>
        public Plugin Execute(ActionRule actionRule)
        {
            return DoExecute(actionRule, parameters: null);
        }

        /// <summary>
        /// Executes a <see cref="Base.Plugin"/> with no arguments (will call <see cref="GenericPlugin.OnPerform"/> method).
        /// </summary>
        /// <param name="actionRule">The <see cref="Contracts.ActionRule"/> to execute.</param>
        /// <param name="parameters">An argument list for the invoked method. This is an array of objects with the same number, order, and type as the parameters of the method.</param>
        /// <returns>The <see cref="Base.Plugin"/> under this execution context.</returns>
        public Plugin Execute(ActionRule actionRule, object[] parameters)
        {
            return DoExecute(actionRule, parameters);
        }

        // executes a single Perform
        private Plugin DoExecute(ActionRule actionRule, object[] parameters)
        {
            // setup
            parameters ??= Array.Empty<object>();
            Plugin ??= DoFactor(actionRule, ConstructorParameters.ToArray()).Plugin;

            // no plugin
            AssertPlugin();

            // get plugin execution method with no arguments
            var perform = Array.Find(Plugin.GetType().GetMethods(), i => i.Name.Equals("Perform"));

            // exit conditions
            if (perform == default)
            {
                throw new InvalidOperationException($"Plugin [{actionRule.Action}] was not found.");
            }

            // build parameters
            var parametersList = new object[] { actionRule }.Concat(FactorParameters(perform, parameters)).ToArray();
            parametersList = NormalizeParametersList(perform, parametersList);

            // invoke with 0 arguments
            perform.Invoke(obj: Plugin, parametersList);

            // return plugin after execution
            return Plugin;
        }

        // assert that plugin under context is not null
        private void AssertPlugin()
        {
            if (Plugin != default)
            {
                return;
            }
            throw new InvalidOperationException(
                "Plugin members is null, please user <Factor> method or pass Plugin argument.");
        }

        // factor parameters for Perform method under this plugin
        private static object[] FactorParameters(MethodInfo perform, object[] parameters)
        {
            // setup
            var parametersList = new List<object>();
            var performParameters = perform.GetParameters();

            // apply parameter or default to match Perform signature
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i > performParameters.Length - 1)
                {
                    break;
                }
                parametersList.Add(parameters[i]);
            }

            // results
            return parametersList.ToArray();
        }

        // fix perform method parameters list to match signature
        private object[] NormalizeParametersList(MethodInfo perform, object[] parameters)
        {
            // setup
            var iterations = perform.GetParameters().Length - parameters.Length;
            var parametersList = parameters.ToList();

            // apply
            for (int i = 0; i < iterations; i++)
            {
                parametersList.Add(item: default);
            }

            // results
            return parametersList.ToArray();
        }
        #endregion
    }
}