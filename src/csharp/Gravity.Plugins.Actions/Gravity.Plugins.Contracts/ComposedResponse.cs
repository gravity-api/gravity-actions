/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Concurrent;
using System.Linq;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Bridge object for composing responses from multiple <see cref="WebAutomation"/>.
    /// </summary>
    public /*internal*/ class ComposedResponse
    {
        /// <summary>
        /// Creates a new <see cref="ComposedResponse"/> instance.
        /// </summary>
        /// <param name="automation"><see cref="WebAutomation"/> by which to create this <see cref="ComposedResponse"/>.</param>
        public ComposedResponse(WebAutomation automation)
        {
            Exceptions ??= new ConcurrentBag<OrbitException>();
            Extractions ??= new ConcurrentBag<Extraction>();
            PerformancePoints ??= new ConcurrentBag<OrbitPerformancePoint>();
            Automation = automation;
        }

        /// <summary>
        /// Gets or sets the session on which this <see cref="WebAutomation"/> is running.
        /// </summary>
        public string OnSession { get; set; }

        /// <summary>
        /// Gets this <see cref="WebAutomation"/> instance.
        /// </summary>
        public WebAutomation Automation { get; }

        /// <summary>
        /// Gets or sets the <see cref="OrbitException"/> collection of <see cref="OrbitResponse"/>.
        /// </summary>
        public ConcurrentBag<OrbitException> Exceptions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Extraction"/> collection of <see cref="OrbitResponse"/>.
        /// </summary>
        public ConcurrentBag<Extraction> Extractions { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="OrbitPerformancePoint"/> collection of <see cref="OrbitResponse"/>.
        /// </summary>
        public ConcurrentBag<OrbitPerformancePoint> PerformancePoints { get; set; }

        /// <summary>
        /// Gets a complete <see cref="OrbitResponse"/> of this <see cref="WebAutomation"/>.
        /// </summary>
        /// <returns>A complete <see cref="OrbitResponse"/> of this <see cref="WebAutomation"/>.</returns>
        public OrbitResponse GetResponse()
        {
            // setup
            var orbitRequest = new OrbitRequest();
            var isConfiguration = Automation.EngineConfiguration != null;
            var isPerformance = isConfiguration && Automation.EngineConfiguration.ReturnPerformancePoints;
            var isExceptions = isConfiguration && Automation.EngineConfiguration.RetrunExceptions;

            // performance points
            if (isPerformance)
            {
                orbitRequest.PerformancePoints = PerformancePoints.OrderBy(i => i.ActionReference).ToArray();
            }

            // exceptions
            if (isExceptions)
            {
                orbitRequest.Exceptions = Exceptions.OrderBy(i => i.ActionReference).ToArray();
            }

            // results
            return new OrbitResponse
            {
                Extractions = Extractions.OrderBy(i => i.Key).ToArray(),
                OrbitRequest = orbitRequest
            };
        }
    }
}