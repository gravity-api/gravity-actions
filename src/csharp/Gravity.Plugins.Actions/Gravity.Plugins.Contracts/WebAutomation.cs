/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending Gravity Automation Request to Gravity Service.
    /// </summary
    [DataContract]
    public class WebAutomation
    {
        /// <summary>
        /// Creates a new instance of <see cref="WebAutomation"/>.
        /// </summary>
        public WebAutomation() : this(default) { }

        /// <summary>
        /// Creates a new instance of <see cref="WebAutomation"/>.
        /// </summary>
        /// <param name="json">JSON file or string to create <see cref="WebAutomation"/> by.</param>
        public WebAutomation(string json)
        {
            CreateFromJson(json);
            Context ??= new ConcurrentDictionary<string, object>();
            EngineConfiguration ??= new EngineConfiguration();
            Authentication ??= new Authentication();
        }

        /// <summary>
        /// Gets or sets the input <see cref="DataSource"/> for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public DataSource DataSource { get; set; }

        /// <summary>
        /// Gets or sets the authentication information for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public Authentication Authentication { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EngineConfiguration"/> for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public EngineConfiguration EngineConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the Driver Parameters for this <see cref="WebAutomation"/>.
        /// If no parameters provided or no driver created, the engine will create a mock implementation.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> DriverParams { get; set; }

        /// <summary>
        /// gets or sets a collection of <see cref="ExtractionRule"/> for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public IEnumerable<ExtractionRule> Extractions { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="ActionRule"/> for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public IEnumerable<ActionRule> Actions { get; set; }

        /// <summary>
        /// Gets or sets a context for this <see cref="WebAutomation"/>. Context can be used to save or pass extra data.
        /// </summary>
        [DataMember]
        public IDictionary<string, object> Context { get; set; }

        // populate this instance from predefined JSON (file or string)
        private void CreateFromJson(string json)
        {
            // exit conditions
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            // deserialize
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var automation = File.Exists(json)
                ? JsonSerializer.Deserialize<WebAutomation>(File.ReadAllText(json), options)
                : JsonSerializer.Deserialize<WebAutomation>(json, options);

            // apply
            DataSource = automation.DataSource;
            Authentication = automation.Authentication;
            EngineConfiguration = automation.EngineConfiguration;
            DriverParams = automation.DriverParams;
            Extractions = automation.Extractions;
            Actions = automation.Actions;
            Context = automation.Context;
        }
    }
}
