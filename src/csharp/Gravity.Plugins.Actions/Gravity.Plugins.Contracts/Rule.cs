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
    /// Describes a contract for sending Gravity <see cref="Rule"/> to Gravity Service.
    /// </summary>
    [DataContract]
    public abstract class Rule
    {
        // constants
        public const string ExecuteSubActions = "ExecuteSubActions";

        // set default values
        protected Rule()
        {
            Actions = Array.Empty<ActionRule>();
            OnAttribute = string.Empty;
            OnElement = string.Empty;
            RegularExpression = ".*";
            Argument = string.Empty;
            Context = new Dictionary<string, object>
            {
                [ExecuteSubActions] = true
            };
        }

        /// <summary>
        /// Gets or sets a collection of <see cref="ActionRule"/> as sub actions.
        /// </summary>
        [DataMember]
        public IEnumerable<ActionRule> Actions { get; set; }

        /// <summary>
        /// Gets or sets the element attribute on which this <see cref="ActionRule"/> will act.
        /// </summary>
        [DataMember]
        public string OnAttribute { get; set; }

        /// <summary>
        /// Gets or sets the element on which this <see cref="ActionRule"/> will act.
        /// </summary>
        [DataMember]
        public string OnElement { get; set; }

        /// <summary>
        /// Gets or sets a pattern which this <see cref="ActionRule"/> will use (will be ignored of not applicable).
        /// </summary>
        [DataMember]
        public string RegularExpression { get; set; }

        /// <summary>
        /// Gets or sets this <see cref="ActionRule"/> argument (as implemented by the plugin).
        /// </summary>
        [DataMember]
        public string Argument { get; set; }

        /// <summary>
        /// Gets or sets a context for this action. Context can be used to save or pass extra data.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Context { get; set; }
    }
}