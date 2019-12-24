using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium.Interactions.Internal;
using System;

#pragma warning disable RCS1163
namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Defines the interface through which the user controls elements on the page.
    /// </summary>
    public class MockWebElement : IWebElement, IWrapsDriver, ILocatable, IFindsByLinkText //, IFindsById, IFindsByName, IFindsByTagName, IFindsByClassName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, ITakesScreenshot
    {
        protected string m_TagName;
        protected string m_Text;
        protected bool m_Enabled;
        protected bool m_Selected;
        protected bool m_Displayed;
        protected Point m_Location;
        protected Size m_Size;

        internal MockWebElement(string tagName, string text, bool enabled, bool selected, bool displayed)
        {
            m_TagName = tagName;
            m_Text = text;
            m_Enabled = enabled;
            m_Selected = selected;
            m_Displayed = displayed;
            m_Location = new Point(1, 1);
            m_Size = new Size(10, 10);
        }

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        public string TagName => m_TagName;

        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, 
        /// and with other whitespace collapsed.
        /// </summary>
        public string Text => m_Text;

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled.
        /// </summary>
        public bool Enabled => m_Enabled;

        /// <summary>
        /// Gets a value indicating whether or not this element is selected.
        /// </summary>
        public bool Selected => m_Selected;

        /// <summary>
        /// Gets a System.Drawing.Point object containing the coordinates of the upper-left 
        /// corner of this element relative to the upper-left corner of the page.
        /// </summary>
        public Point Location => m_Location;

        /// <summary>
        /// Gets a OpenQA.Selenium.IWebElement.Size object containing the height and width 
        /// of this element.
        /// </summary>
        public Size Size => m_Size;

        /// <summary>
        /// Gets a value indicating whether or not this element is displayed.
        /// </summary>
        public bool Displayed => m_Displayed;

        /// <summary>
        /// Defines the interface through which the user controls the browser.
        /// </summary>
        public IWebDriver WrappedDriver => new MockWebDriver();

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
        /// Clears the content of this element.
        /// </summary>
        public void Clear()
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Finds the first OpenQA.Selenium.IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching OpenQA.Selenium.IWebElement on the current context.</returns>
        public IWebElement FindElement(By by)
        {
            return MockWebDriver.ElementFactory(by);
        }

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
        /// Finds all OpenQA.Selenium.IWebElement within the current context using the given
        /// mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns> A System.Collections.ObjectModel.ReadOnlyCollection`1 of all OpenQA.Selenium.IWebElement
        /// matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>
            {
                new MockWebElement("div", "Mock: Positive Element", true, true, true),
                new MockWebElement("div", "Mock: Negative Element", false, false, false)
            });
        }

        /// <summary>
        /// Finds all elements matching the specified link text.
        /// </summary>
        /// <param name="linkText">The link text to match.</param>
        /// <returns> A System.Collections.ObjectModel.ReadOnlyCollection`1 containing all OpenQA.Selenium.IWebElement 
        /// matching the criteria.</returns>
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
            return $"mock attribute value {new Random().Next(0, 1000)}";
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
        public void SendKeys(string text)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            // Method intentionally left empty.
        }
    }
}