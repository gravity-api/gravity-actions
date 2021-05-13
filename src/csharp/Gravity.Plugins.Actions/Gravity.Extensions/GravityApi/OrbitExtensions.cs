/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Extensions
{
    /// <summary>
    /// Gravity extensions for OrbitRequest and OrbitResponse objects.
    /// </summary>
    public static class OrbitExtensions
    {
        /// <summary>
        /// Flatten all <see cref="OrbitResponse.Extractions"/> into a list of entities entries.
        /// </summary>
        /// <param name="orbitResponse">OrbitResponse to flatten.</param>
        /// <returns>A collection of entities entries.</returns>
        public static IDictionary<string, object> ToEntries(this OrbitResponse orbitResponse) => orbitResponse
            .Extractions
            .SelectMany(e => e.Entities.SelectMany(c => c.Content))
            .ToDictionary(e => e.Key, e => e.Value);

        /// <summary>
        /// Gets the first value from <see cref="Entity.EntityContentEntries"/> by it's key, null if not found.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to search.</param>
        /// <param name="key">The key to search by.</param>
        /// <returns>The value found or null.</returns>
        public static object GetByKey(this Entity entity, string key) => entity
            .Content
            .First(e => e.Key == key)
            .Value;

        /// <summary>
        /// Gets a collection of screenshot files from OrbitResponse if any.
        /// </summary>
        /// <param name="orbitResponse">OrbitResponse to get data from.</param>
        /// <returns>A collection of screenshot files.</returns>
        public static IEnumerable<string> GetScreenshots(this OrbitResponse orbitResponse)
        {
            // constants
            const string Key = "screenshot";
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase;

            // collect
            var entities = orbitResponse.Extractions.SelectMany(e => e.Entities);

            var fromEntities = entities
                .SelectMany(e => e.Content)
                .Where(e => e.Key.Equals(Key, COMPARE)).Select(e => $"{e.Value}");

            var fromExceptions = orbitResponse
                .OrbitRequest
                .Exceptions
                .Where(i => !string.IsNullOrEmpty(i.Screenshot)).Select(i => i.Screenshot);

            // results
            return fromEntities.Concat(fromExceptions);
        }

        /// <summary>
        /// Gets <see cref="bool.TrueString"/> if no assertion results or if all assertions are <see cref="bool.TrueString"/>.
        /// </summary>
        /// <param name="orbitResponse">OrbitResponse to get data from.</param>
        /// <returns><see cref="bool.TrueString"/> if no assertion results or if all assertions are <see cref="bool.TrueString"/></returns>
        /// <remarks>This method evaluates the <see cref="Extraction"/> collection gathered by Assert action.</remarks>
        public static bool Assert(this OrbitResponse orbitResponse)
        {
            // constants
            const string Key = "assertion";
            const string False = "false";
            const StringComparison COMPARE = StringComparison.OrdinalIgnoreCase;

            // get all entries
            var entries = orbitResponse.ToEntries();

            // setup conditions
            var isAlwaysTrue = !entries.Any(e => e.Key.Equals(Key, COMPARE));
            var isFalse = !isAlwaysTrue && entries.Any(e => e.Key.Equals(Key, COMPARE) && $"{e.Value}".Equals(False, COMPARE));

            // assert
            return !isFalse;
        }

        /// <summary>
        /// Gets collection of assertions entities from OrbitResponse.
        /// </summary>
        /// <param name="orbitResponse">OrbitResponse to get data from.</param>
        /// <returns>A collection of assertions entities.</returns>
        public static IEnumerable<Entity> GetAssertions(this OrbitResponse orbitResponse)
        {
            const string Key = "assertion";

            // setup conditions
            var allNumbers = orbitResponse.Extractions.All(i => Regex.IsMatch(input: i.Key, @"^\s+$"));

            // return sorted
            var byNumbers = orbitResponse?
                .Extractions
                .OrderBy(e => long.Parse(e.Key))
                .SelectMany(e => e.Entities)
                .Where(e => e.Content.Any(i => i.Key == Key));

            var byString = orbitResponse?
                .Extractions
                .OrderBy(e => e.Key)
                .SelectMany(e => e.Entities)
                .Where(e => e.Content.Any(i => i.Key == Key));

            // return sorted
            return allNumbers ? byNumbers : byString;
        }
    }
}