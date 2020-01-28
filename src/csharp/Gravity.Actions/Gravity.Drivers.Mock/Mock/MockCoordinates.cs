using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Provides location of the element using various frames of reference.
    /// </summary>
    public class MockCoordinates : ICoordinates
    {
        /// <summary>
        /// Gets the location of an element in absolute screen coordinates.
        /// </summary>
        public Point LocationOnScreen => new Point(1, 1);

        /// <summary>
        /// Gets the location of an element relative to the origin of the view port.
        /// </summary>
        public Point LocationInViewport => new Point(2, 2);

        /// <summary>
        /// Gets the location of an element's position within the HTML DOM.
        /// </summary>
        public Point LocationInDom => new Point(3, 3);

        /// <summary>
        /// Gets a locator providing a user-defined location for this element.
        /// </summary>
        public object AuxiliaryLocator => new Point(4, 4);
    }
}
