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
    /// Describes a contract for sending gravity ExtractionRule to Gravity Service.
    /// </summary>
    [DataContract]
    public class ExtractionRule
    {
        /// <summary>
        /// Gets or sets the output <see cref="GravityDataProvider"/> used by this rule.
        /// </summary>
        [DataMember]
        public GravityDataProvider DataProvider { get; set; }

        /// <summary>
        /// Gets or sets the element which will be extracted by this rule.
        /// </summary>
        [DataMember]
        public IEnumerable<ContentEntry> OnElements { get; set; }

        /// <summary>
        /// Gets or sets the root element on which this rule is based.
        /// </summary>
        [DataMember]
        public string OnRootElements { get; set; }

        /// <summary>
        /// Gets or sets value indicating if the extraction will be done on the page source or on the page DOM.
        /// </summary>
        [DataMember]
        public bool PageSource { get; set; }
    }
}