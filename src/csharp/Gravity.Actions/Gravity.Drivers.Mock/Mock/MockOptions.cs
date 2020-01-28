using OpenQA.Selenium;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines an interface allowing the user to set options on the browser.
    /// </summary>
    /// <seealso cref="IOptions" />
    public class MockOptions : IOptions
    {
        /// <summary>
        /// Gets an object allowing the user to manipulate cookies on the page.
        /// </summary>
        public ICookieJar Cookies => new MockCookieJar();

        /// <summary>
        /// Gets an object allowing the user to manipulate the currently-focused browser window.
        /// </summary>
        /// <remarks>
        /// "Currently-focused" is defined as the browser window having the window handle
        /// returned when IWebDriver.CurrentWindowHandle is called.
        /// </remarks>
        public IWindow Window => new MockWindow();

        /// <summary>
        /// Gets an object allowing the user to examining the logs for this driver instance.
        /// </summary>
        public ILogs Logs => new MockLogs();

        /// <summary>
        /// Provides access to the timeouts defined for this driver.
        /// </summary>
        /// <returns>
        /// An object implementing the <see cref="ITimeouts" /> interface.
        /// </returns>
        public ITimeouts Timeouts()
        {
            return new MockTimeouts();
        }
    }
}
