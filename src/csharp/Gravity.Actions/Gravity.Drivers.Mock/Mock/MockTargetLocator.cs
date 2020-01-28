using OpenQA.Selenium;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines the interface through which the user can locate a given frame or window.
    /// </summary>
    public class MockTargetLocator : ITargetLocator
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Creates a new instance of this TargetLocator object.
        /// </summary>
        /// <param name="driver">Driver by which this TargetLocator created.</param>
        public MockTargetLocator(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Switches to the element that currently has the focus, or the body element if 
        /// no element with focus can be detected.
        /// <returns>An OpenQA.Selenium.IWebElement instance representing the element with the focus, 
        /// or the body element if no element with focus can be detected.</returns>
        public IWebElement ActiveElement()
        {
            return driver.FindElement(MockBy.Positive());
        }

        /// <summary>
        /// Switches to the currently active modal dialog for this particular driver instance.
        /// </summary>
        /// <returns> A handle to the dialog.</returns>
        public IAlert Alert()
        {
            // extract driver
            var d = (MockWebDriver)driver;

            // setup conditions
            var hasKey = d.Capabilities.ContainsKey(MockCapabilities.HasAlert);
            var hasAlert = hasKey && (bool)d.Capabilities[MockCapabilities.HasAlert];

            // return alert if exists
            if (hasAlert)
            {
                return new MockAlert((MockWebDriver)driver);
            }
            throw new NoAlertPresentException();
        }

        /// <summary>
        /// Selects either the first frame on the page or the main document when a page contains
        /// iFrames.
        /// </summary>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the default frame.</returns>
        public IWebDriver DefaultContent()
        {
            return driver;
        }

        /// <summary>
        /// Select a frame by its (zero-based) index (passing -1 will throw an exception).
        /// </summary>
        /// <param name="frameIndex">The zero-based index of the frame to select.</param>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the specified frame.</returns>
        /// <exception cref="NoSuchFrameException">If the frame cannot be found.</exception>
        public IWebDriver Frame(int frameIndex)
        {
            if (frameIndex == -1)
            {
                throw new NoSuchElementException();
            }
            return driver;
        }

        /// <summary>
        /// Select a frame by its name or ID.
        /// </summary>
        /// <param name="frameName">The name of the frame to select.</param>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the specified frame.</returns>
        /// <exception cref="NoSuchFrameException">If the frame cannot be found.</exception>
        public IWebDriver Frame(string frameName)
        {
            return driver;
        }

        /// <summary>
        /// Select a frame using its previously located OpenQA.Selenium.IWebElement.
        /// Passing null value will throw an exception.
        /// </summary>
        /// <param name="frameElement">The frame element to switch to.</param>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the specified frame.</returns>
        /// <exception cref="NoSuchFrameException">If the element is neither a FRAME nor an IFRAME element.</exception>
        /// <exception cref="StaleElementReferenceException">If the element is no longer valid.</exception>
        public IWebDriver Frame(IWebElement frameElement)
        {
            if (frameElement == null)
            {
                throw new StaleElementReferenceException("Mock: Stale Element Reference Exception");
            }
            return driver;
        }

        /// <summary>
        /// Select the parent frame of the currently selected frame.
        /// </summary>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the specified frame.</returns>
        public IWebDriver ParentFrame()
        {
            return driver;
        }

        /// <summary>
        /// Switches the focus of future commands for this driver to the window with the
        /// given name (passing "-1" will throw an exception).
        /// </summary>
        /// <param name="windowName">The name of the window to select.</param>
        /// <returns>An OpenQA.Selenium.IWebDriver instance focused on the given window.</returns>
        /// <exception cref="NoSuchWindowException">If the window cannot be found.</exception>
        public IWebDriver Window(string windowName)
        {
            if (windowName == "-1")
            {
                throw new NoSuchWindowException("Mock: No Such Window Exception");
            }

            // switch
            var d = (MockWebDriver)driver;
            d.CurrentWindowHandle = windowName;
            return d;
        }
    }
}
