using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity data source type to Gravity Service.
    /// </summary
    [DataContract]
    public static class GravityDataProviders
    {
        /// <summary>
        /// Constant for representing CSV data source.
        /// </summary>
        [DataMember]
        public const string CSV = "CSV";

        /// <summary>
        /// Constant for representing JSON data source.
        /// </summary>
        [DataMember]
        public const string JSON = "JSON";

        /// <summary>
        /// Constant for representing MarkDown data source.
        /// </summary>
        public const string MarkDown = "MarkDown";

        /// <summary>
        /// Constant for representing Rest API data source.
        /// </summary>
        [DataMember]
        public const string RestApi = "RestApi";

        /// <summary>
        /// Constant for representing SQL Server data source.
        /// </summary>
        [DataMember]
        public const string SQLServer = "SQLServer";

        /// <summary>
        /// Constant for representing XML data source.
        /// </summary>
        [DataMember]
        public const string XML = "XML";
    }
}