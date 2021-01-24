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
    /// Describes a contract for receiving gravity exceptions data from Gravity Service.
    /// </summary>
    [DataContract]
    public class OrbitException
    {
        /// <summary>
        /// Gets or sets the <see cref="System.Exception"/> object thrown.
        /// </summary>
        [DataMember]
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.Reference"/> for this exception.
        /// The action by which the exception was thrown.
        /// </summary>
        [DataMember]
        public int ActionReference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.Action"/> for this exception.
        /// The action by which the exception was thrown.
        /// </summary>
        [DataMember]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the full path of this exception screenshot (if taken).
        /// </summary>
        [DataMember]
        public string Screenshot { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.RepeatReference"/> for this exception.
        /// The action by which the exception was thrown.
        /// </summary>
        [DataMember]
        public int RepeatReference { get; set; }

        /// <summary>
        /// Gets or sets context for this exception which can hold an extra information.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Context { get; set; }
    }
}