/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Interactions.Internal;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using OpenQA.Selenium.Mock.Extensions;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines the interface through which the user controls elements on the page.
    /// </summary>
    public class MockWebElement : IWebElement, IWrapsDriver, ILocatable, IFindsByLinkText, ITakesScreenshot
    {
        // members: static
        private static readonly Random random = new Random();

        // members: state
        private string value;

        #region *** constructors ***
        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        public MockWebElement(MockWebDriver parent) : this(parent, tagName: "div")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="tagName">Sets the <see cref="IWebElement.TagName"/> property of this element.</param>
        public MockWebElement(MockWebDriver parent, string tagName)
            : this(parent, tagName, text: "Mock: Positive Element")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="tagName">Sets the <see cref="IWebElement.TagName"/> property of this element.</param>
        /// <param name="text">Sets the <see cref="IWebElement.Text"/> property of this element.</param>
        public MockWebElement(MockWebDriver parent, string tagName, string text)
            : this(parent, tagName, text, enabled: true)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="tagName">Sets the <see cref="IWebElement.TagName"/> property of this element.</param>
        /// <param name="text">Sets the <see cref="IWebElement.Text"/> property of this element.</param>
        /// <param name="enabled">Sets the <see cref="IWebElement.Enabled"/> property of this element.</param>
        public MockWebElement(MockWebDriver parent, string tagName, string text, bool enabled)
            : this(parent, tagName, text, enabled, selected: true)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="tagName">Sets the <see cref="IWebElement.TagName"/> property of this element.</param>
        /// <param name="text">Sets the <see cref="IWebElement.Text"/> property of this element.</param>
        /// <param name="enabled">Sets the <see cref="IWebElement.Enabled"/> property of this element.</param>
        /// <param name="selected">Sets the <see cref="IWebElement.Selected"/> property of this element.</param>
        public MockWebElement(MockWebDriver parent, string tagName, string text, bool enabled, bool selected)
            : this(parent, tagName, text, enabled, selected, displayed: true)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MockWebElement"/> class.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tagName">Sets the <see cref="IWebElement.TagName"/> property of this element.</param>
        /// <param name="text">Sets the <see cref="IWebElement.Text"/> property of this element.</param>
        /// <param name="enabled">Sets the <see cref="IWebElement.Enabled"/> property of this element.</param>
        /// <param name="selected">Sets the <see cref="IWebElement.Selected"/> property of this element.</param>
        /// <param name="displayed">Sets the <see cref="IWebElement.Displayed"/> property of this element.</param>
        public MockWebElement(MockWebDriver parent, string tagName, string text, bool enabled, bool selected, bool displayed)
        {
            // state
            value = "default";

            // properties
            WrappedDriver = parent;
            TagName = tagName;
            Text = text;
            Enabled = enabled;
            Selected = selected;
            Displayed = displayed;
            Location = new Point(1, 1);
            Size = new Size(10, 10);
        }
        #endregion

        #region *** properties   ***
        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public string TagName { get; }

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, 
        /// and with other whitespace collapsed.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled.
        /// </summary>
        public bool Enabled { get; }

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public bool Selected { get; }

        /// <summary>
        /// Gets a System.Drawing.Point object containing the coordinates of the upper-left 
        /// corner of this element relative to the upper-left corner of the page.
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// Gets a OpenQA.Selenium.IWebElement.Size object containing the height and width 
        /// of this element.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.
        /// </summary>
        public bool Displayed { get; }

        /// <summary>
        /// Defines the interface through which the user controls the browser.
        /// </summary>
        public IWebDriver WrappedDriver { get; }

        /// <summary>
        /// Represents an ordered pair of integer x- and y-coordinates that defines a point 
        /// in a two-dimensional plane.
        /// </summary>
        public Point LocationOnScreenOnceScrolledIntoView => new Point(1, 1);

        /// <summary>
        /// Provides location of the element using various frames of reference.
        /// </summary>
        public ICoordinates Coordinates => new MockCoordinates();

        /// <summary>
        /// Gets or sets a value indicating whether or not this element is state is invalid.
        /// </summary>
        public bool IsInvalidState { get; set; }
        #endregion

        #region *** selenium     ***
        /// <summary>
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            // mock method - should not do anything
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            if (!Displayed)
            {
                throw new ElementNotVisibleException();
            }
        }

        /// <summary>
        /// Finds the first OpenQA.Selenium.IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching OpenQA.Selenium.IWebElement on the current context.</returns>
        public IWebElement FindElement(By by) => GetElement((MockWebDriver)WrappedDriver, by);

        /// <summary>
        /// Finds the first element matching the specified link text.
        /// </summary>
        /// <param name="linkText">The link text to match.</param>
        /// <returns>The first OpenQA.Selenium.IWebElement matching the criteria.</returns>
        public IWebElement FindElementByLinkText(string linkText)
        {
            return FindElement(By.LinkText(linkText));
        }

        /// <summary>
        /// Finds all OpenQA.Selenium.IWebElement within the current context using the given mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>A ReadOnlyCollection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            try
            {
                return GetElements(parent: (MockWebDriver)WrappedDriver, by);
            }
            catch (Exception e) when (e is NoSuchElementException)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
        }

        /// <summary>
        /// Finds all elements matching the specified link text.
        /// </summary>
        /// <param name="linkText">The link text to match.</param>
        /// <returns>A ReadOnlyCollection of all <see cref="IWebElement"/> matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return FindElements(By.LinkText(linkText));
        }

        /// <summary>
        /// Gets the value of the specified attribute for this element.
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The attribute's current value. Returns a null if the value is not set.</returns>
        public string GetAttribute(string attributeName)
        {
            if (attributeName.Equals(MockLocators.Null, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (attributeName.Equals(MockLocators.Exception))
            {
                throw new WebDriverException();
            }

            if (attributeName.Equals(MockLocators.Index))
            {
                return "0";
            }

            return attributeName.Equals(nameof(value), StringComparison.OrdinalIgnoreCase)
                ? value
                : $"mock attribute value {new Random().Next(0, 1000)}";
        }

        /// <summary>
        /// Gets the value of a CSS property of this element.
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>The value of the specified CSS property.</returns>
        public string GetCssValue(string propertyName)
        {
            return "Mock CSS Value";
        }

        /// <summary>
        /// Gets the value of a JavaScript property of this element.
        /// </summary>
        /// <param name="propertyName">The name JavaScript the JavaScript property to get the value of.</param>
        /// <returns>
        /// The JavaScript property's current value. Returns a <see langword="null" /> if the
        /// value is not set or the property does not exist.
        /// </returns>
        public string GetProperty(string propertyName)
        {
            return "mockJavaScriptProperty";
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// </summary>
        /// <param name="text">The text to type into the element.</param>
        /// <exception cref="ElementNotVisibleException">Thrown when element is not displayed (i.e. negative element).</exception>
        /// <exception cref="InvalidElementStateException">Thrown when text="throw new InvalidElementStateException();"</exception>
        public void SendKeys(string text)
        {
            if (!Displayed)
            {
                throw new ElementNotVisibleException();
            }
            if (IsInvalidState)
            {
                throw new InvalidElementStateException();
            }
            value = text;
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            // mock method - should not do anything
        }

        /// <summary>
        /// Gets a <see cref="Screenshot"/> object representing the image of the page on the screen.
        /// </summary>
        /// <returns>A <see cref="Screenshot"/> object containing the image.</returns>
        public Screenshot GetScreenshot() => new MockScreenshot(string.Empty);
        #endregion

        #region *** factory      ***
        /// <summary>
        /// Factor an <see cref="MockWebElement"/> instance based on a given locator.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        public static IWebElement GetElement(MockWebDriver parent, By by)
        {
            return Get(parent, by);
        }

        /// <summary>
        /// Factor a collection of <see cref="MockWebElement"/> instances based on a given locator.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        public static ReadOnlyCollection<IWebElement> GetElements(MockWebDriver parent, By by)
        {
            // collect elements
            var elements = new List<IWebElement>
            {
                Get(parent, by),
                Get(parent, by)
            };

            // return collection
            return new ReadOnlyCollection<IWebElement>(elements.Where(i => i != null).ToList());
        }

        /// <summary>
        /// Gets a positive 'DIV' element (displayed, enabled and selected).
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Positive)]
        public static IWebElement GetPositive(MockWebDriver parent) => Positive(parent);

        /// <summary>
        /// Gets a negative 'DIV' element (not displayed, not enabled and not selected).
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Negative)]
        public static IWebElement GetNegative(MockWebDriver parent) => Negative(parent);

        /// <summary>
        /// Gets a null reference for this <see cref="IWebElement"/> instance.
        /// </summary>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Null)]
        public static IWebElement GetNull() => null;

        /// <summary>
        /// Throws a <see cref="StaleElementReferenceException"/> when calling this method.
        /// </summary>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Stale)]
        public static IWebElement GetStale()
            => throw new StaleElementReferenceException("Mock: Stale Element Reference Exception");

        /// <summary>
        /// Throws a <see cref="NoSuchElementException"/> when calling this method.
        /// </summary>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.None)]
        public static IWebElement GetNoSuchElement()
            => throw new NoSuchElementException("Mock: No Such Element Exception");

        /// <summary>
        /// Throws a <see cref="WebDriverException"/> when calling this method.
        /// </summary>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Exception)]
        public static IWebElement GetException()
            => throw new WebDriverException("Mock: Web Driver Exception");

        /// <summary>
        /// Gets a random element with 90% chance of getting a positive element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.RandomPositive)]
        public static IWebElement GetRandomPositive(MockWebDriver parent) => RandomElement(parent, 90);

        /// <summary>
        /// Gets a random element with 90% chance of getting a negative element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.RandomNegative)]
        public static IWebElement GetRandomNegative(MockWebDriver parent) => RandomElement(parent, 10);

        /// <summary>
        /// Gets a random element with 90% chance of getting an element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.RandomExists)]
        public static IWebElement GetRandomExists(MockWebDriver parent)
        {
            // fetch elements >> return first or null
            return RandomElements(parent, 90).FirstOrDefault();
        }

        /// <summary>
        /// Gets a random element with 1% chance of getting an element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.RandomNotExists)]
        public static IWebElement GetRandomNotExists(MockWebDriver parent)
        {
            // fetch elements >> return first or null
            return RandomElements(parent, 1).FirstOrDefault();
        }

        /// <summary>
        /// Gets a mechanism to find an exists mock element with 10% success rate.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Focused)]
        public static IWebElement GetFocused(MockWebDriver parent) => Positive(parent);

        /// <summary>
        /// Gets an <see cref="IWebElement"/> which will throw <see cref="InvalidElementStateException"/> when
        /// sending keys into.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.InvalidElementState)]
        public static IWebElement GetInvalidState(MockWebDriver parent)
        {
            // get a positive element
            var element = Positive(parent);

            // set element invalid state to true
            ((MockWebElement)element).IsInvalidState = true;

            // return invalid state element
            return element;
        }

        /// <summary>
        /// Provides a convenience method for manipulating selections of options in an HTML <select> element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.SelectElement)]
        public static IWebElement GetSelectElement(MockWebDriver parent) => new MockWebElement(parent, tagName: "select");

        /// <summary>
        /// Gets an element with <option> tag.
        /// </summary>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        [Description(MockLocators.Option)]
        public static IWebElement GetOptions(MockWebDriver parent) => new MockWebElement(parent, tagName: "option");

        /// <summary>
        /// Gets a random element with a configurable chance of getting a positive element.
        /// </summary>
        /// <param name="parent">Driver in use.</param>
        /// <param name="positiveRatio">The chance % of getting a positive element.</param>
        /// <returns>An interface through which the user controls elements on the page.</returns>
        public static IWebElement GetRandom(MockWebDriver parent, int positiveRatio)
        {
            return RandomElement(parent, positiveRatio);
        }

        // gets a random element (positive or negative).
        private static IWebElement RandomElement(MockWebDriver parent, int positiveRatio)
        {
            // get score
            var score = 0;
            lock (random)
            {
                score = random.Next(0, 100);
            }

            // factoring
            return (score <= positiveRatio) ? Positive(parent) : Negative(parent);
        }

        // gets a random element (positive or negative).
        private static ReadOnlyCollection<IWebElement> RandomElements(MockWebDriver parent, int existsRatio)
        {
            // get score
            var score = 0;
            lock (random)
            {
                score = random.Next(0, 100);
            }

            // factoring
            return (score <= existsRatio)
                ? new ReadOnlyCollection<IWebElement>(new List<IWebElement> { Positive(parent) })
                : new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        // gets a positive 'DIV' element
        private static IWebElement Positive(MockWebDriver parent) => new MockWebElement(parent);

        // gets a negative 'DIV' element
        private static IWebElement Negative(MockWebDriver parent)
            => new MockWebElement(parent, tagName: "div", text: "Mock: Negative Element", enabled: false, selected: false, displayed: false);

        // factor a MockWebElement instance
        private static IWebElement Get(MockWebDriver parent, By by)
        {
            // get the 'by' value from this locator
            var byValue = GetLocatorValue(by);

            // get factoring method
            const BindingFlags flags = BindingFlags.Static | BindingFlags.Public;
            var method = typeof(MockWebElement).GetMethodByDescription(byValue, flags);

            // default
            if (method == default)
            {
                throw new NoSuchElementException();
            }

            // factor
            try
            {
                return method.GetParameters().Length == 1
                    ? (IWebElement)method.Invoke(null, new object[] { parent })
                    : (IWebElement)method.Invoke(null, null);
            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }

        // get the 'by' value from this locator
        private static string GetLocatorValue(By by) => typeof(By)
            .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(p => string.Equals(p.Name, "description", StringComparison.CurrentCultureIgnoreCase))
            .GetValue(by)
            .ToString()
            .ToLower();
        #endregion
    }
}