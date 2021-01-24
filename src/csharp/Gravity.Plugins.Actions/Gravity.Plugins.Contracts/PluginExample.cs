/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
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
        /// Gets or sets the action rule from this example.
        /// </summary>
        [DataMember]
        public ActionRule ActionExample { get; set; }

        /// <summary>
        /// Gets or sets a literal example of how this action is described as a sentence
        /// </summary>
        [DataMember]
        public string LiteralExample { get; set; }

        /// <summary>
        /// Gets or sets a comment for this example
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets extraction rule for this example
        /// </summary>
        [DataMember]
        public ExtractionRule ExtractionExample { get; set; }

        /// <summary>
        /// Gets or sets macro for this example
        /// </summary>
        [DataMember]
        public string MacroExample { get; set; }
    }
}