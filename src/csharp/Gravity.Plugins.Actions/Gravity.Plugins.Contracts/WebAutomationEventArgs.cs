/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// A contract for passing data and information when WebAutomation event
    /// is raised.
    /// </summary>
    public class WebAutomationEventArgs
    {
        /// <summary>
        /// Gets or sets the ActionRule state at the time of the event.
        /// </summary>
        public ActionRule ActionRule { get; set; }

        /// <summary>
        /// Gets or sets the collection of Application parameters at the time of the event.
        /// </summary>
        public IDictionary<string, object> ApplicationParams { get; set; } = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Gets or sets the WebDriver state at the time of the event.
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets the collection of exceptions thrown on the event.
        /// </summary>
        public IEnumerable<OrbitException> Exceptions { get; set; } = new ConcurrentBag<OrbitException>();

        /// <summary>
        /// Gets or sets the collection of extractions at the time of the event.
        /// </summary>
        public IEnumerable<Extraction> Extractions { get; set; } = new ConcurrentBag<Extraction>();

        /// <summary>
        /// Gets or sets the collection of Session parameters at the time of the event.
        /// </summary>
        public IDictionary<string, object> SessionParams { get; set; } = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Gets or sets the WebAutomation state at the time of the event.
        /// </summary>
        public WebAutomation WebAutomation { get; set; }
    }
}