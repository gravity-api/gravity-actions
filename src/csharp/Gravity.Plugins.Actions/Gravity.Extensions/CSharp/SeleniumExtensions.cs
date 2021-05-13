/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium.Internal;

using System;

namespace OpenQA.Selenium.Extensions
{
    public static class SeleniumExtensions
    {
        // TODO: migrate to Gravity.Core and remove when available
        /// <summary>
        /// Try to put element into the port view. If fails, a fall back script will be initiated.
        /// </summary>
        /// <param name="element">The element to put in the port view.</param>
        /// <returns>The element in the port view.</returns>
        public static IWebElement TryMoveToElement(this IWebElement element)
        {
            // constants
            const string fallbackScript =
                "var rectangle = arguments[0].getBoundingClientRect(); " +
                "window.scroll(rectangle.left, rectangle.top);";

            // exit conditions
            if (!(element is IWrapsDriver))
            {
                return element;
            }

            // setup
            var driver = ((IWrapsDriver)element).WrappedDriver;

            // get actions
            var actions = new Interactions.Actions(driver);

            // move to element
            try
            {
                try
                {
                    actions.MoveToElement(element).Build().Perform();
                }
                catch (Exception e) when (e != null)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript(script: fallbackScript, args: element);
                }
            }
            catch (Exception e) when (e != null)
            {
                // ignore exceptions
            }

            // get
            return element;
        }
    }
}