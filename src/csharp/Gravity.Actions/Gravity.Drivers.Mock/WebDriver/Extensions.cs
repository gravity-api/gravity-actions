using System.Collections.Generic;

namespace Gravity.Drivers.Mock.WebDriver
{
    public static class Extensions
    {
        public static MockWebDriver ApplyCapabilities(this MockWebDriver driver, IDictionary<string, object> capabilities)
        {
            return new MockWebDriver(driver.DriverBinaries, capabilities);
        }
    }
}
