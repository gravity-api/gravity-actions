/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes an environment context for with multiple parameters collections.
    /// </summary>
    public class EnvironmentContext
    {
        /// <summary>
        /// Set all static members of this <see cref="EnvironmentContext"/>
        /// </summary>
        static EnvironmentContext()
        {
            ApplicationParams = new ConcurrentDictionary<string, object>();
        }

        /// <summary>
        /// Creates a new instance of <see cref="EnvironmentContext"/>.
        /// </summary>
        public EnvironmentContext()
        {
            SessionParams = new ConcurrentDictionary<string, object>();
        }

        /// <summary>
        /// Gets an application parameters context. Use this context to set parameters on application level,
        /// which means the parameter will be available for all calling objects (static).
        /// </summary>
        public static IDictionary<string, object> ApplicationParams { get; }

        /// <summary>
        /// Gets session parameters context. Use this context to set parameters on the session level,
        /// which means the parameter will be available only for the calling object (per instance).
        /// </summary>
        public IDictionary<string, object> SessionParams { get; }
    }
}