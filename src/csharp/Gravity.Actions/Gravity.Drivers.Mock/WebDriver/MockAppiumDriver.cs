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
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

#pragma warning disable S2326
namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Defines the interface through which the user controls a mobile device.
    /// </summary>
    public class MockAppiumDriver<W> : MockWebDriver, IHidesKeyboard where W : IWebElement
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

        /// <summary>
        /// Executes appium command against appium server.
        /// </summary>
        /// <param name="commandName">Command to execute.</param>
        /// <param name="parameters">Command parameters.</param>
        /// <returns>Handles responses from the browser.</returns>
        public Response Execute(string commandName, Dictionary<string, object> parameters)
        {
            return new Response();
        }

        /// <summary>
        /// Executes appium command against appium server.
        /// </summary>
        /// <param name="driverCommand">Driver command to execute.</param>
        /// <returns>Handles responses from the browser.</returns>
        public Response Execute(string driverCommand)
        {
            return new Response();
        }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        public void HideKeyboard()
        {
            // mock method - should not do anything
        }
    }
}
#pragma warning restore
