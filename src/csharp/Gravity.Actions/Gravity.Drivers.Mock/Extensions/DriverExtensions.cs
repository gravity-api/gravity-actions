using Gravity.Drivers.Mock.WebDriver;
using System.Collections.Generic;

namespace Gravity.Drivers.Mock.Extensions
{
    public static class DriverExtensions
    {
        public static MockWebDriver ApplyCapabilities(this MockWebDriver driver, IDictionary<string, object> capabilities)
        {
            return new MockWebDriver(driver.DriverBinaries, capabilities);
        }
    }
}
