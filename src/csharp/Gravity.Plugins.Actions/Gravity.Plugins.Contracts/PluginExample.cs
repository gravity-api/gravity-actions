/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for action rule example information.
    /// </summary>
    [DataContract]
    public class PluginExample
    {
        /// <summary>
        /// Gets or sets the description of this example.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or set an application link or page link where this action can tested.
        /// </summary>
        [DataMember]
        public string CanBeTestedOn { get; set; }

        /// <summary>
        /// Gets or sets a collection of examples for this action.
        /// </summary>
        [DataMember]
        public IEnumerable<PluginExampleModel> Examples { get; set; }

        /// <summary>
        /// Gets or sets a comment for this example
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}