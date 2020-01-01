/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using System.Collections.Generic;

namespace Gravity.Drivers.Mock.Extensions
{
    public static class DriverExtensions
    {
        /// <summary>
        /// Applies a new set of capabilities into this <see cref="MockWebDriver"/> instance.
        /// </summary>
        /// <param name="driver">This <see cref="MockWebDriver"/> instance.</param>
        /// <param name="capabilities">Set of Key/Value pairs to apply on this <see cref="MockWebDriver"/> instance.</param>
        /// <returns></returns>
        public static MockWebDriver ApplyCapabilities(this MockWebDriver driver, IDictionary<string, object> capabilities)
        {
            return new MockWebDriver(driver.DriverBinaries, capabilities);
        }
    }
}
