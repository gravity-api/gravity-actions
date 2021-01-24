/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="Authentication"/> to Gravity Service.
    /// </summary>
    [DataContract]
    public class Authentication
    {
        /// <summary>
        /// Gets or sets Gravity Service login password.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets Gravity Service login name (the email used for registering).
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
    }
}
