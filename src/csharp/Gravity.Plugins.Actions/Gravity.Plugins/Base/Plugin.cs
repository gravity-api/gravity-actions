/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-02-03
 *    - modify: refactoring
 * 
 * RESOURCES
 * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1
 * https://github.com/ProfessionalCSharp/ProfessionalCSharp7/blob/master/Diagnostics/LoggingSample/LoggingWithoutDI/Program.cs
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Gravity.Plugins.Base
{
    /// <summary>
    /// Base class for all Gravity Plugins.
    /// </summary>
    public abstract class Plugin
    {
        #region *** constructors ***
        /// <summary>
        /// set all static members for Plugins use.
        /// </summary>
        static Plugin()
        {
            // setup
            var allTypes = Misc.GetTypes();
            var types = new ConcurrentBag<Type>();

            // collect
            var pluginTypes = allTypes.Where(i => !i.IsAbstract && typeof(Plugin).IsAssignableFrom(i));
            var byTypes = allTypes.Where(i => i.GetMethods().Any(m => m.IsStatic && m.ReturnType == typeof(By)));

            // apply
            types.AddRange(pluginTypes);
            types.AddRange(byTypes);

            // assign
            Types ??= types;
        }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        protected Plugin(WebAutomation automation)
            : this(automation, new EnvironmentContext())
        { }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        /// <param name="environment">Environment under this context.</param>
        protected Plugin(WebAutomation automation, EnvironmentContext environment)
        {
            // setup
            Automation = automation ?? new WebAutomation();
            Environment = environment ?? new EnvironmentContext();
            CliFactory ??= new CliFactory();
            Extractions ??= new ConcurrentBag<Extraction>();
        }
        #endregion

        #region *** properties   ***
        /// <summary>
        /// Gets the <see cref="WebAutomation"/> under this <see cref="Plugin"/> context.
        /// </summary>
        public WebAutomation Automation { get; }

        /// <summary>
        /// Gets or sets the <see cref="EnvironmentContext"/> under this <see cref="Plugin"/> context.
        /// </summary>
        public EnvironmentContext Environment { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Extraction"/> results collection for this <see cref="Plugin"/> run.
        /// </summary>
        public ConcurrentBag<Extraction> Extractions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OrbitException"/> results collection for this <see cref="Plugin"/> run.
        /// </summary>
        public ConcurrentBag<OrbitException> Exceptions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OrbitPerformancePoint"/> results collection for this <see cref="Plugin"/> run.
        /// </summary>
        public ConcurrentBag<OrbitPerformancePoint> PerformancePoints { get; set; }

        /// <summary>
        /// Gets a <see cref="Utilities.CliFactory"/> instance for command line parsing.
        /// </summary>
        public CliFactory CliFactory { get; }

        /// <summary>
        /// Gets or sets the <see cref="AutomationExecutor"/> used to execute this <see cref="Plugin"/>.
        /// </summary>
        public AutomationExecutor Executor { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ConcurrentBag{T}"/> types collection.
        /// </summary>
        public static ConcurrentBag<Type> Types { get; set; }
        #endregion
    }
}