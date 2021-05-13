/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
namespace Gravity.Plugins.Attributes
{
    public interface IAttributeable
    {
        /// <summary>
        /// Gets the assertion name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets a literal name for the attribute.
        /// </summary>
        string Literal { get; set; }

        /// <summary>
        /// Gets or sets the description of the attribute.
        /// </summary>
        string Description { get; set; }
    }
}