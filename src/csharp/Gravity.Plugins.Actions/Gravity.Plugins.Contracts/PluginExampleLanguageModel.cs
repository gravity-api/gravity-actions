/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    [DataContract]
    public class PluginExampleLanguageModel
    {
        /// <summary>
        /// Gets or sets the action rule from this example.
        /// </summary>
        [DataMember]
        public string Example { get; set; }

        /// <summary>
        /// Gets or sets a literal example of how this action is described as a sentence
        /// </summary>
        [DataMember]
        public string Language { get; set; }
    }
}
