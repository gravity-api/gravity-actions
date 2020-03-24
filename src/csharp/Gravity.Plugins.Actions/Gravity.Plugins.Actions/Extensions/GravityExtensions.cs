/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System;
using OpenQA.Selenium;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class GravityExtensions
    {
        #region *** Extraction     ***
        /// <summary>
        /// Generates default values for this <see cref="Extraction"/> object.
        /// </summary>
        /// <param name="extraction">This <see cref="Extraction"/> object instance.</param>
        /// <returns><see cref="Extraction"/> object with default values.</returns>
        public static Extraction GetDefault(this Extraction extraction) => Get(extraction, string.Empty);

        /// <summary>
        /// Generates default values for this <see cref="Extraction"/> object.
        /// </summary>
        /// <param name="extraction">This <see cref="Extraction"/> object instance.</param>
        /// <param name="session">This <see cref="IWebDriver"/> session id.</param>
        /// <returns><see cref="Extraction"/> object with default values.</returns>
        public static Extraction GetDefault(this Extraction extraction, string session) => Get(extraction, session);

        // basic object initialization
        private static Extraction Get(Extraction extraction, string session)
        {
            extraction.OrbitSession = new OrbitSession
            {
                MachineIp = Misc.GetLocalEndpoint(),
                MachineName = Environment.MachineName,
                SessionsId = session
            };
            return extraction;
        }
        #endregion

        #region *** Web Automation ***
        /// <summary>
        /// Gets a collection of <see cref="ExtractionRule"/> from this <see cref="WebAutomation"/>.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> from which to get <see cref="ExtractionRule"/> collection.</param>
        /// <param name="extractions"><see cref="ExtractionRule"/> zero-based index to collection to get. Empty to get all.</param>
        /// <returns></returns>
        public static IEnumerable<ExtractionRule> GetExtractionRules(this WebAutomation webAutomation, IEnumerable<string> extractions)
        {
            // exit conditions
            if (!extractions.Any())
            {
                return webAutomation.Extractions;
            }

            // build extractions list
            var extractionsList = new List<ExtractionRule>();
            foreach (var extraction in extractions)
            {
                var isExtraction = int.TryParse(extraction, out int extractionOut);
                var isRange = extractionOut <= webAutomation.Extractions.Count() - 1;
                var isValidExtraction = isExtraction && isRange;

                if (isValidExtraction)
                {
                    extractionsList.Add(webAutomation.Extractions.ElementAt(extractionOut));
                }
            }
            return extractionsList;
        }
        #endregion
    }
}