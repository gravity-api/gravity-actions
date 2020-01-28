/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Provides a mechanism by which to find elements within a document.
    /// </summary>
    public static class MockBy
    {
        /// <summary>
        /// Gets elements with <option> tag.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Option() => By.Id(MockLocators.Option);

        /// <summary>
        /// Gets a mechanism to find a valid 'select' element (positive).
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By SelectElement() => By.Id(MockLocators.SelectElement);

        /// <summary>
        /// Gets a mechanism to find a valid 'select' element (positive) with no options.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By SelectElementNoOptions() => By.Id(MockLocators.SelectElement);

        /// <summary>
        /// Gets a mechanism to find a valid mock element (positive).
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
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

        /// <summary>
        /// Gets a mechanism to find an exists mock element with 90% success rate.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By RandomExists() => By.Id(MockLocators.RandomExists);

        /// <summary>
        /// Gets a mechanism to find an exists mock element with 10% success rate.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By RandomNotExists() => By.Id(MockLocators.RandomNotExists);

        /// <summary>
        /// Gets a mechanism to find the current focused element.
        /// </summary>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Focused() => By.Id(MockLocators.Focused);
    }
}