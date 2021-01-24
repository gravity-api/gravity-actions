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
    /// Describes a contract for receiving gravity <see cref="Extraction"/> from Gravity Service.
    /// </summary>
    [DataContract]
    public class Extraction
    {
        /// <summary>
        /// Gets or sets the extraction key (will be used as unique identifier for this extraction).
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// Gets of sets a collection of <see cref="Entity"/> extracted by this rule.
        /// </summary>
        [DataMember]
        public IEnumerable<Entity> Entities { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Contracts.OrbitSession"/> information for this rule.
        /// </summary>
        [DataMember]
        public OrbitSession OrbitSession { get; set; }
    }
}