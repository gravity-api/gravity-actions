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
    /// describes a contract for receiving gravity entity information from gravity-service
    /// </summary>
    [DataContract]
    public class Entity
    {
        /// <summary>
        /// Describes a single extracted entity which is composed of a key/value collection.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Content { get; set; }
    }
}
