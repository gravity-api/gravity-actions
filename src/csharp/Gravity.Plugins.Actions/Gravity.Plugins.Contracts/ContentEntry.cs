/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="ContentEntry"/> to Gravity Service.
    /// </summary>
    [DataContract]
    public class ContentEntry : Rule
    {
        /// <summary>
        /// Gets or sets the name of the entry.
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the entry value should be cleared from line breaks or not.
        /// </summary>
        [DataMember]
        public bool ClearLinesBreak { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating if the entry value should be trimmed or not.
        /// </summary>
        [DataMember]
        public bool Trim { get; set; } = true;
    }
}