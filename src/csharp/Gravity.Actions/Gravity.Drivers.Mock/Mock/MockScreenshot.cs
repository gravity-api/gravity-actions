/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Represents an image of the page currently loaded in the browser.
    /// </summary>
    public class MockScreenshot : Screenshot
    {
        /// <summary>
        /// Initializes a new instance of the OpenQA.Selenium.Screenshot class.
        /// </summary>
        /// <param name="base64EncodedScreenshot">The image of the page as a Base64-encoded string.</param>
        public MockScreenshot(string base64EncodedScreenshot)
            : base(base64EncodedScreenshot)
        { }

#pragma warning disable CA1822, RCS1163, IDE0060
        /// <summary>
        /// Saves the screenshot to a Portable Network Graphics (PNG) file, overwriting the
        /// file if it already exists.
        /// </summary>
        /// <param name="fileName">The full path and file name to save the screenshot to.</param>
        public new void SaveAsFile(string fileName)
        {
            // mock method - should not do anything
        }

        /// <summary>
        /// Saves the screenshot to a Portable Network Graphics (PNG) file, overwriting the
        /// file if it already exists.
        /// </summary>
        /// <param name="fileName">The full path and file name to save the screenshot to.</param>
        /// <param name="format">A <see cref="ScreenshotImageFormat"/> value indicating the format to save the image to.</param>
        public new void SaveAsFile(string fileName, ScreenshotImageFormat format)
        {
            // mock method - should not do anything
        }
#pragma warning restore
    }
}
