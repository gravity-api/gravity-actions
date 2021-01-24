/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="ActionRule"/> to Gravity Service.
    /// </summary>
    public class ActionRule : Rule
    {
        public ActionRule()
        {
            Action = string.Empty;
            Locator = string.Empty;
        }

        /// <summary>
        /// Gets or sets this <see cref="ActionRule"/> type.
        /// </summary>
        [DataMember]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets this <see cref="ActionRule"/> element locator type.
        /// </summary>
        [DataMember]
        public string Locator { get; set; }

        /// <summary>
        /// Gets or sets this <see cref="ActionRule"/> reference index.
        /// </summary>
        [DataMember]
        public int Reference { get; set; }

        /// <summary>
        /// Gets or sets this <see cref="ActionRule"/> repeater index (if under repeat action).
        /// </summary>
        [DataMember]
        public int RepeatReference { get; set; }
    }
}
