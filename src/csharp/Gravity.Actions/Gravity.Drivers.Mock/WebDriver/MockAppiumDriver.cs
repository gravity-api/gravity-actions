/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * 
 * notes
 * change Location implementation to interface when available.
 */
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

#pragma warning disable S2326
namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Defines the interface through which the user controls a mobile device.
    /// </summary>
    public class MockAppiumDriver<W> : MockWebDriver where W : IWebElement
    {
        /// <summary>
        /// Gets or sets the GEO location of this device
        /// </summary>
        public Location Location { get; set; } = new Location
        {
            Altitude = 0.0,
            Latitude = 0.0,
            Longitude = 0.0
        };
    }
}
#pragma warning restore
