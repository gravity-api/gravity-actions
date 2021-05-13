/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    [DataContract]
    public class PluginExampleModel
    {
        /// <summary>
        /// Gets or sets a short description of the example.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a literal example of how this segment can be described in a sentence.
        /// </summary>
        [DataMember]
        public string Example { get; set; }
    }
}
