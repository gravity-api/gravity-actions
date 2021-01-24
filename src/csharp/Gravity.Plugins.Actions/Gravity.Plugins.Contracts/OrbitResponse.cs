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
    /// Describes a contract for receiving gravity response data from Gravity Service.
    /// </summary>
    [DataContract]
    public class OrbitResponse
    {
        /// <summary>
        /// Gets or sets a collection of <see cref="Extraction"/> data to be return by Gravity Service.
        /// </summary>
        [DataMember]
        public IEnumerable<Extraction> Extractions { get; set; }

        /// <summary>
        /// Gets or sets the request information return by Gravity Service.
        /// </summary>
        [DataMember]
        public OrbitRequest OrbitRequest { get; set; }
    }
}