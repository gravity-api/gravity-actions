/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;

using HtmlAgilityPack;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Utilities
{
    /// <summary>
    /// A collection of ExtractionSegments methods.
    /// </summary>
    public class ExtractionSegmentsRepository : ExtractionSegmentsBase
    {
        /// <summary>
        /// Creates a new instance of ExtractionSegmentsRepository.
        /// </summary>
        /// <param name="driver">The IWebDriver (session) for using with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public ExtractionSegmentsRepository(IWebDriver driver, IEnumerable<Type> types)
            : base(driver, types)
        { }

        #region *** Element ***
        /// <summary>
        /// Gets the outer HTML of the IWebElement.
        /// </summary>
        /// <param name="element">The IWebElement to get outer HTML for.</param>
        /// <returns>The outer HTML.</returns>
        [ExtractionSegment("html")]
        public static string Html(IWebElement element) => element.GetSource();

        /// <summary>
        /// Gets the outer HTML of the IWebElement.
        /// </summary>
        /// <param name="element">The IWebElement to get outer HTML for.</param>
        /// <returns>The outer HTML.</returns>
        [ExtractionSegment("html")]
        public static string Html(HtmlNode element) => element.OuterHtml;
        #endregion
    }
}
