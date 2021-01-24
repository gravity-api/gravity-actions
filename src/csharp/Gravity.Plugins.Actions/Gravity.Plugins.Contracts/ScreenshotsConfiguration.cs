/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    [DataContract]
    public class ScreenshotsConfiguration
    {
        /// <summary>
        /// Fully qualified path of folder under which to save screenshot.
        /// </summary>
        [DataMember]
        public string OnFolder { get; set; } = Environment.CurrentDirectory;

        /// <summary>
        /// Endpoint of REST API to which the screenshot will be sent when capturing.
        /// </summary>
        [DataMember]
        public string OnUrl { get; set; } = string.Empty;

        /// <summary>
        /// If set to <see cref="true"/>, a screenshot will be taken only when exception is thrown.
        /// </summary>
        public bool OnExceptionOnly { get; set; }
    }
}