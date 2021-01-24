using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// describes a license contract - for validation purposes
    /// </summary>
    [DataContract]
    public class License
    {
        /// <summary>
        /// license file name under current location
        /// </summary>
        [JsonIgnore]
        public const string FileName = "license.lcn";

        /// <summary>
        /// packages available under this license
        /// </summary>
        [DataMember]
        public string[] Packages { get; set; }

        /// <summary>
        /// the date this license was created
        /// </summary>
        [DataMember]
        public DateTime Created { get; set; }

        /// <summary>
        /// expiration date of this license
        /// </summary>
        [DataMember]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// last update time of this license
        /// </summary>
        [DataMember]
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// total minutes for this license (yearly, or per given period)
        /// </summary>
        [DataMember]
        public double Minutes { get; set; }

        /// <summary>
        /// total usage of this license
        /// </summary>
        [DataMember]
        public double Usage { get; set; }
    }
}
