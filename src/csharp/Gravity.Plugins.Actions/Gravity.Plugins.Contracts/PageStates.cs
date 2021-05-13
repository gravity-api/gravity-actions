/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// A list of conditions constants.
    /// </summary>
    /// <remarks>You can use conditions which are not listed here, if they are available.</remarks>
    public static class PageStates
    {
        /// <summary>
        /// Fully loaded.
        /// </summary>
        public const string Complete = "complete";

        /// <summary>
        /// Always <see cref="false"/>.
        /// </summary>
        public const string False = "false";

        /// <summary>
        /// Has loaded enough and the user can interact with it.
        /// </summary>
        public const string Interactive = "interactive";

        /// <summary>
        /// Has been loaded.
        /// </summary>
        public const string Loaded = "loaded";

        /// <summary>
        /// Is loading.
        /// </summary>
        public const string Loading = "loading";

        /// <summary>
        /// Has not started loading yet.
        /// </summary>
        public const string Uninitialized = "uninitialized";
    }
}
