/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;

using System.Collections.Generic;

namespace Gravity.Plugins.Attributes
{
    public interface IExampleable
    {
        /// <summary>
        /// Gets or sets the implementation examples of this <see cref="Plugin"/>.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        IEnumerable<PluginExample> Examples { get; set; }
    }
}
