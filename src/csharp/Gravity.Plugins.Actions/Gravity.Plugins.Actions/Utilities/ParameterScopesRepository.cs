/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Utilities
{
    /// <summary>
    /// A collection of Operators methods.
    /// </summary>
    public class ParameterScopesRepository : ParameterScopeBase
    {
        /// <summary>
        /// Creates a new instance of ParameterScopeRepository.
        /// </summary>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public ParameterScopesRepository(string name, EnvironmentContext context, IEnumerable<Type> types)
            : base(name, context, types)
        { }

        #region *** GET ***
        [ParameterScope(ParameterScopes.Machine)]
        public string GetByMachine()
        {
            return Get(Name, EnvironmentVariableTarget.Machine);
        }

        [ParameterScope(ParameterScopes.User)]
        public string GetByUser()
        {
            return Get(Name, EnvironmentVariableTarget.User);
        }

        [ParameterScope(ParameterScopes.Process)]
        public string GetByProcess()
        {
            return Get(Name, EnvironmentVariableTarget.Process);
        }

        [ParameterScope(ParameterScopes.Application)]
        public string GetByApplication()
        {
            // not found
            if (!EnvironmentContext.ApplicationParams.ContainsKey(Name))
            {
                return string.Empty;
            }

            // get
            return $"{EnvironmentContext.ApplicationParams[Name]}";
        }

        [ParameterScope(ParameterScopes.Session)]
        public string GetBySession()
        {
            // not found
            if (!Context.SessionParams.ContainsKey(Name))
            {
                return string.Empty;
            }

            // get
            return $"{Context.SessionParams[Name]}";
        }
        #endregion

        #region *** SET ***
        [ParameterScope(ParameterScopes.Machine)]
        public void SetByMachine(string value)
        {
            Environment.SetEnvironmentVariable(Name, value, EnvironmentVariableTarget.Machine);
        }

        [ParameterScope(ParameterScopes.User)]
        public void SetByUser(string value)
        {
            Environment.SetEnvironmentVariable(Name, value, EnvironmentVariableTarget.User);
        }

        [ParameterScope(ParameterScopes.Process)]
        public void SetByProcess(string value)
        {
            Environment.SetEnvironmentVariable(Name, value, EnvironmentVariableTarget.Process);
        }

        [ParameterScope(ParameterScopes.Application)]
        public void SetByApplication(string value)
        {
            EnvironmentContext.ApplicationParams[Name] = value;
        }

        [ParameterScope(ParameterScopes.Session)]
        public void SetBySession(string value)
        {
            Context.SessionParams[Name] = value;
        }
        #endregion

        private static string Get(string name, EnvironmentVariableTarget target)
        {
            // setup
            var parameter = Environment.GetEnvironmentVariable(name, target);

            // get
            return string.IsNullOrEmpty(parameter) ? string.Empty : parameter;
        }
    }
}