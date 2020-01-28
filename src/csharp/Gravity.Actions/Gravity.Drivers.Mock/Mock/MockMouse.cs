using OpenQA.Selenium.Interactions.Internal;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Provides methods representing basic mouse actions.
    /// </summary>
    public class MockMouse : IMouse
    {
        /// <summary>
        /// Clicks at a set of coordinates using the primary mouse button.
        /// </summary>
        /// <param name="where">An OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to click.</param>
        public void Click(ICoordinates where)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Clicks at a set of coordinates using the secondary mouse button.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to click.</param>
        public void ContextClick(ICoordinates where)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Double-clicks at a set of coordinates.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to double-click.</param>
        public void DoubleClick(ICoordinates where)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Presses the primary mouse button at a set of coordinates.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to press 
        /// the mouse button down.</param>
        public void MouseDown(ICoordinates where)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Moves the mouse to the specified set of coordinates.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to move 
        /// the mouse to.</param>
        public void MouseMove(ICoordinates where)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Moves the mouse to the specified set of coordinates.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to click.</param>
        /// <param name="offsetX">A horizontal offset from the coordinates specified in where.</param>
        /// <param name="offsetY">A vertical offset from the coordinates specified in where.</param>
        public void MouseMove(ICoordinates where, int offsetX, int offsetY)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Releases the primary mouse button at a set of coordinates.
        /// </summary>
        /// <param name="where">A OpenQA.Selenium.Interactions.Internal.ICoordinates describing where to release 
        /// the mouse button.</param>
        public void MouseUp(ICoordinates where)
        {
            // Method intentionally left empty.
        }
    }
}