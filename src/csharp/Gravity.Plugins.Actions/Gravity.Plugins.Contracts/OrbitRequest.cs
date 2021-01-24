/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for receiving gravity request data from Gravity Service.
    /// </summary>
    [DataContract]
    public class OrbitRequest
    {
        /// <summary>
        /// Gets or sets the serialized <see cref="WebAutomation"/> sent by the client.
        /// </summary>
        [DataMember]
        public string SerializedRequest { get; set; }

        /// <summary>
        /// Gets or sets the serialized <see cref="OrbitResponse"/> sent by Gravity Service.
        /// </summary>
        [DataMember]
        public string SerializedResponse { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="OrbitException"/> thrown during execution.
        /// </summary>
        [DataMember]
        public IEnumerable<OrbitException> Exceptions { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="OrbitPerformancePoint"/> collected during execution.
        /// </summary>
        [DataMember]
        public IEnumerable<OrbitPerformancePoint> PerformancePoints { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Authentication.UserName"/> used to execute this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the execution start time of this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the execution end time of this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets the total <see cref="TimeSpan.Ticks"/> of this <see cref="WebAutomation"/> execution time.
        /// </summary>
        [DataMember]
        public long RunTime { get; set; }

        /// <summary>
        /// Gets or sets response size in KB of this <see cref="OrbitResponse"/>.
        /// </summary>
        [DataMember]
        public long ResponseSize { get; set; }

        /// <summary>
        /// Gets or sets response size in KB of this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public long RequestSize { get; set; }
    }
}