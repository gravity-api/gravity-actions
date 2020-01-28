using OpenQA.Selenium;
using System;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines the interface through which the user can define timeouts.
    /// </summary>
    /// <seealso cref="ITimeouts" />
    public class MockTimeouts : ITimeouts
    {
        /// <summary>
        /// Gets or sets the implicit wait timeout, which is the  amount of time the
        /// driver should wait when searching for an element if it is not immediately
        /// present.
        /// </summary>
        /// <remarks>
        /// When searching for a single element, the driver should poll the page
        /// until the element has been found, or this timeout expires before throwing
        /// a <see cref="NoSuchElementException" />. When searching for multiple elements,
        /// the driver should poll the page until at least one element has been found
        /// or this timeout has expired.
        /// <para>
        /// Increasing the implicit wait timeout should be used judiciously as it
        /// will have an adverse effect on test run time, especially when used with
        /// slower location strategies like XPath.
        /// </para>
        /// </remarks>
        public TimeSpan ImplicitWait { get ; set ; }

        /// <summary>
        /// Gets or sets the asynchronous script timeout, which is the amount
        /// of time the driver should wait when executing JavaScript asynchronously.
        /// This timeout only affects the <see cref="IJavaScriptExecutor.ExecuteAsyncScript(System.String,System.Object[])" />
        /// method.
        /// </summary>
        public TimeSpan AsynchronousJavaScript { get ; set; }

        /// <summary>
        /// Gets or sets the page load timeout, which is the amount of time the driver
        /// should wait for a page to load when setting the <see cref="IWebDriver.Url" />
        /// property.
        /// </summary>
        public TimeSpan PageLoad { get; set; }

        /// <summary>
        /// Specifies the amount of time the driver should wait when searching for an
        /// element if it is not immediately present.
        /// </summary>
        /// <param name="timeToWait">A <see cref="TimeSpan" /> structure defining the amount of time to wait.</param>
        /// <returns>
        /// A self reference
        /// </returns>
        /// <remarks>
        /// When searching for a single element, the driver should poll the page
        /// until the element has been found, or this timeout expires before throwing
        /// a <see cref="NoSuchElementException" />. When searching for multiple elements,
        /// the driver should poll the page until at least one element has been found
        /// or this timeout has expired.
        /// <para>
        /// Increasing the implicit wait timeout should be used judiciously as it
        /// will have an adverse effect on test run time, especially when used with
        /// slower location strategies like XPath.
        /// </para>
        /// </remarks>
        public ITimeouts ImplicitlyWait(TimeSpan timeToWait)
        {
            ImplicitWait = timeToWait;
            return this;
        }

        /// <summary>
        /// Specifies the amount of time the driver should wait for a page to load when setting the <see cref="IWebDriver.Url" /> property.
        /// </summary>
        /// <param name="timeToWait">A <see cref="TimeSpan" /> structure defining the amount of time to wait.
        /// Setting this parameter to <see cref="TimeSpan.MinValue" /> will allow the page to load indefinitely.</param>
        /// <returns>
        /// A self reference
        /// </returns>
        public ITimeouts SetPageLoadTimeout(TimeSpan timeToWait)
        {
            PageLoad = timeToWait;
            return this;
        }

        /// <summary>
        /// Specifies the amount of time the driver should wait when executing JavaScript asynchronously.
        /// </summary>
        /// <param name="timeToWait">A <see cref="TimeSpan" /> structure defining the amount of time to wait.
        /// Setting this parameter to <see cref="TimeSpan.MinValue" /> will allow the script to run indefinitely.</param>
        /// <returns>
        /// A self reference
        /// </returns>
        public ITimeouts SetScriptTimeout(TimeSpan timeToWait)
        {
            AsynchronousJavaScript = timeToWait;
            return this;
        }
    }
}