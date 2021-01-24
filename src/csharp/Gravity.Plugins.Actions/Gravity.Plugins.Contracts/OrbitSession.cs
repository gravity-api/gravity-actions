/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for receiving gravity <see cref="OrbitSession"/> information from Gravity Service.
    /// </summary>
    [DataContract]
    public class OrbitSession
    {
        /// <summary>
        /// Gets or sets the session id returned by Gravity Service.
        /// </summary>
        [DataMember]
        public string SessionsId { get; set; }

        /// <summary>
        /// Gets or sets the machine name returned by Gravity Service.
        /// </summary>
        [DataMember]
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the machine IP returned by Gravity Service.
        /// </summary>
        [DataMember]
        public string MachineIp { get; set; }
    }
}