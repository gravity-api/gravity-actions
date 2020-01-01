/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium;

#pragma warning disable S2326
namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Defines the interface through which the user controls a mobile device.
    /// </summary>
    public class MockAppiumDriver<W> : MockWebDriver where W : IWebElement
    { }
}
#pragma warning restore
