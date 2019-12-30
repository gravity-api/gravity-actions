/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
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
        public static By Positive() => By.Id(MockLocators.Positive);

        /// <summary>
        /// Gets a mechanism to find an invalid mock element (negative).
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Negative() => By.Id(MockLocators.Negative);

        /// <summary>
        /// Gets a mechanism to find mock element which will throw <see cref="NoSuchElementException"/>
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By None() => By.Id(MockLocators.None);

        /// <summary>
        /// Gets a mechanism to find mock element which will throw <see cref="StaleElementReferenceException"/>
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Stale() => By.Id(MockLocators.Stale);

        /// <summary>
        /// Gets a mechanism to find mock element which will return null reference.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Null() => By.Id(MockLocators.Null);

        /// <summary>
        /// Gets a mechanism to find mock element which will throw <see cref="WebDriverException"/>
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Exception() => By.Id(MockLocators.Exception);

        /// <summary>
        /// Gets a mechanism to find a valid mock element (positive) with 90% success rate.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By RandomPositive() => By.Id(MockLocators.RandomPositive);

        /// <summary>
        /// Gets a mechanism to find an invalid mock element (negative) with 90% success rate.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By RandomNegative() => By.Id(MockLocators.RandomNegative);
    }
}