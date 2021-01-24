/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium;
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="EngineConfiguration"/> to Gravity Service.
    /// </summary
    [DataContract]
    public class EngineConfiguration
    {
        /// <summary>
        /// Creates a new instance of this <see cref="EngineConfiguration"/>.
        /// </summary>
        public EngineConfiguration()
        {
            SearchTimeout = 15000;
            LoadTimeout = 60000;
            MaxParallel = 1;
            RetrunExceptions = true;
            ReturnPerformancePoints = true;
            ReturnScreenshots = false;
        }

        /// <summary>
        /// Gets or sets the amount of time the driver should wait when searching for
        /// an element if it is not immediately present.
        /// </summary>
        [DataMember]
        public int SearchTimeout { get; set; }

        /// <summary>
        /// Gets or sets the page load timeout, which is the amount of time the driver should
        /// wait for a page to load when setting the <see cref="IWebDriver.Url"/> property.
        /// </summary>
        [DataMember]
        public int LoadTimeout { get; set; }

        /// <summary>
        /// Gets or sets the parallel rows number while executing actions based <see cref="DataSource"/>.
        /// </summary>
        [DataMember]
        public int MaxParallel { get; set; }

        /// <summary>
        /// Gets or set the value indicating rather to return exceptions under <see cref="OrbitResponse"/>.
        /// </summary>
        [DataMember]
        public bool RetrunExceptions { get; set; }

        /// <summary>
        /// Gets or set the value indicating rather to return performance points under <see cref="OrbitResponse"/>.
        /// </summary>
        [DataMember]
        public bool ReturnPerformancePoints { get; set; }

        /// <summary>
        /// Gets or sets the value indicates rather or not to automatically take and return
        /// screenshots under <see cref="OrbitResponse"/>.
        /// </summary>
        [DataMember]
        public bool ReturnScreenshots { get; set; }

        /// <summary>
        /// Gets or set the <see cref="ScreenshotsConfiguration"/> for this <see cref="WebAutomation"/>.
        /// </summary>
        [DataMember]
        public ScreenshotsConfiguration AutoScreenshots { get; set; }

        /// <summary>
        /// Get or sets a value indicating if the engine will terminate the <see cref="WebAutomation"/>
        /// when assertion fails, throwing Assert.Fail()
        /// </summary>
        [DataMember]
        public bool TerminateOnAssertFailure { get; set; }
    }
}