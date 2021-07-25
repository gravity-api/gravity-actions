/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// A list of all supported parameter scopes.
    /// </summary>
    public static class ParameterScopes
    {
        public const string Application = "application";
        public const string Session = "session";
        public const string Machine = "machine";
        public const string Process = "process";
        public const string User = "user";
    }
}