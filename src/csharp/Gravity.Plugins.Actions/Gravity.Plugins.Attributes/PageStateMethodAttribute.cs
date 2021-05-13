/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;

namespace Gravity.Plugins.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class PageStateMethodAttribute: Attribute, IAttributeable
    {
        /// <summary>
        /// Creates a new instance of <see cref="Attribute"/>.
        /// </summary>
        /// <param name="name">The assertion name that will be used to find and execute the page state method.</param>
        public PageStateMethodAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the state name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a literal name for the attribute.
        /// </summary>
        public string Literal { get; set; }

        /// <summary>
        /// Gets or sets the description of the page state.
        /// </summary>
        public string Description { get; set; } = "TBD";
    }
}
