/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    [DataContract]
    public class OrbitPerformancePoint
    {
        /// <summary>
        /// Gets or sets the total run time of this <see cref="ActionRule"/>.
        /// </summary>
        [DataMember]
        public double Time { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.Reference"/> of this <see cref="ActionRule"/>.
        /// </summary>
        [DataMember]
        public int ActionReference { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.Action"/> of this <see cref="ActionRule"/>.
        /// </summary>
        [DataMember]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ActionRule.RepeatReference"/> of this <see cref="ActionRule"/>.
        /// </summary>
        [DataMember]
        public int RepeatReference { get; set; }
    }
}
