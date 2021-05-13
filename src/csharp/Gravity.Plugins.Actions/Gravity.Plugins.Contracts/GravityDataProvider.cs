/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="GravityDataProvider"/> to Gravity Service.
    /// </summary>
    [DataContract]
    public class GravityDataProvider
    {
        /// <summary>
        /// Gets or sets the <see cref="GravityDataProvider"/> type, please refer this action KB for valid inputs.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GravityDataProvider"/> source (i.e. connection string or file name).
        /// </summary>
        [DataMember]
        public object Source { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="GravityDataProvider"/> repository (i.e. table name).
        /// </summary>
        [DataMember]
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the criteria to use to filter the rows. For examples on how to filter rows, see DataView RowFilter Syntax [C#].
        /// </summary>
        [DataMember]
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating rather to write the extraction data per <see cref="Entity"/>.
        /// set to <see cref="false"/> for writing per <see cref="Extraction"/>.
        /// </summary>
        [DataMember]
        public bool WritePerEntity { get; set; }
    }
}