/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.DataContracts;
using System;
using OpenQA.Selenium;
using Gravity.Plugins.Extensions;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class GravityExtensions
    {
        #region *** Extraction ***
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
    }
}