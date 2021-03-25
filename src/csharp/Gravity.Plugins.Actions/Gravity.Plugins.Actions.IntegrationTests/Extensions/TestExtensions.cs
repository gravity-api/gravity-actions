/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Abstraction.Contracts;
using Gravity.IntegrationTests.Base;
using Gravity.Plugins.Contracts;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Graivty.IntegrationTests.Extensions
{
    public static class TestExtensions
    {
        /// <summary>
        /// Return <see cref="true"/> if ALL assertion have passed, <see cref="false"/> if not.
        /// </summary>
        /// <param name="responses">A collection of <see cref="OrbitResponse"/> to evaluate.</param>
        /// <returns><see cref="true"/> if ALL assertion have passed, <see cref="false"/> if not.</returns>
        public static bool Assert(this IEnumerable<OrbitResponse> responses)
        {
            if (!responses.SelectMany(i => i.Extractions).Any())
            {
                return false;
            }

            return responses
                .SelectMany(i => i.Extractions)
                .SelectMany(i => i.Entities)
                .SelectMany(i => i.Content)
                .Where(i => i.Key == "evaluation")
                .All(i => (bool)i.Value);
        }

        /// <summary>
        /// Throws <see cref="InconclusiveException"/> if no evaluation can be made.
        /// </summary>
        /// <param name="responses">A collection of <see cref="OrbitResponse"/> to evaluate.</param>
        public static void AssertInconclusive(this IEnumerable<OrbitResponse> responses)
        {
            // data
            var exceptions = responses.SelectMany(i => i.OrbitRequest.Exceptions).Select(i => i.Exception.Message);

            // setup
            var isEvaluation = responses
                .SelectMany(i => i.Extractions)
                .SelectMany(i => i.Entities)
                .Any(i => i.Content.ContainsKey("evaluation"));

            // exit condition
            if (isEvaluation)
            {
                return;
            }

            // throw
            var message = JsonSerializer.Serialize(exceptions);
            throw new InconclusiveException(message);
        }

        /// <summary>
        /// Gets a driver full name.
        /// </summary>
        /// <param name="environment"><see cref="Context"/> to get driver full name by.</param>
        /// <returns>Driver full name</returns>
        public static string GetDriverFullName(this Context environment)
        {
            // setup conditions
            var isKey = environment.TestParams?.ContainsKey("driver") == true;

            // exit conditions
            if (!isKey)
            {
                return "not_a_driver";
            }

            // fetch
            return $"{environment.TestParams["driver"]}" switch
            {
                Driver.Android => "AndroidDriver",
                Driver.Chrome => "RemoteWebDriver",
                Driver.Edge => "RemoteWebDriver",
                Driver.Firefox => "RemoteWebDriver",
                Driver.InternetExplorer => "RemoteWebDriver",
                Driver.iOS => "iOS.IOSDriver",
                Driver.Mock => "MockWebDriver",
                Driver.Safari => "RemoteWebDriver",
                _ => null
            };
        }
    }
}