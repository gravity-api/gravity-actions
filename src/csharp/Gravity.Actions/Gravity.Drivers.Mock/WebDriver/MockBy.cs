using OpenQA.Selenium;

namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Provides a mechanism by which to find elements within a document.
    /// </summary>
    public static class MockBy
    {
        /// <summary>
        /// Gets a mechanism to find a valid mock element (positive).
        /// </summary>
        /// <returns>A OpenQA.Selenium.By object the driver can use to find the elements.</returns>
        public static By Positive()
        {
            return By.Id("positive");
        }

        /// <summary>
        /// Gets a mechanism to find an invalid mock element (negative).
        /// </summary>
        /// <returns>A OpenQA.Selenium.By object the driver can use to find the elements.</returns>
        public static By Negative()
        {
            return By.Id("negative");
        }

        /// <summary>
        /// Gets a mechanism to find mock element which will throw <see cref="NoSuchElementException"/>
        /// </summary>
        /// <returns>A OpenQA.Selenium.By object the driver can use to find the elements.</returns>
        public static By NoSuchElement()
        {
            return By.Id("none");
        }

        /// <summary>
        /// Gets a mechanism to find mock element which will throw <see cref="StaleElementReferenceException"/>
        /// </summary>
        /// <returns>A OpenQA.Selenium.By object the driver can use to find the elements.</returns>
        public static By Stale()
        {
            return By.Id("stale");
        }
    }
}