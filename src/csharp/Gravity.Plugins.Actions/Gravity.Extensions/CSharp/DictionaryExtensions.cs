/*
 * CHANGE LOG - keep only last 5 threads
 */
using System.Collections.Generic;

namespace Gravity.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IDictionary{TKey, TValue}"/> object.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Add or replace keys/values on source <see cref="IDictionary{TKey, TValue}"/> from a target <see cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
        /// <param name="to">Target <see cref="IDictionary{TKey, TValue}"/>.</param>
        /// <param name="from">Source <see cref="IDictionary{TKey, TValue}"/>.</param>
        /// <returns>Updated <see cref="IDictionary{TKey, TValue}"/>.</returns>
        /// <remarks>Can be used for merging dictionaries.</remarks>
        public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> to, IDictionary<TKey, TValue> from)
        {
            // exit conditions
            if (from == null || from?.Keys.Count == 0)
            {
                return to;
            }

            // iterate
            foreach (var item in from)
            {
                to[item.Key] = item.Value;
            }

            // results
            return to;
        }

        /// <summary>
        /// Gets a value from a <see cref="IDictionary{TKey, TValue}"/> if exists or default value if not.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <see cref="IDictionary{TKey, TValue}"/>.</typeparam>
        /// <param name="dictionary">The <see cref="IDictionary{TKey, TValue}"/> to get value from.</param>
        /// <param name="key">Key by which to get value.</param>
        /// <param name="altValue">Value to return if not found</param>
        /// <returns>A value of the request type, or default value if not found.</returns>
        public static TValue GetIfExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue altValue = default)
        {
            // exit conditions
            if (!dictionary.ContainsKey(key))
            {
                return altValue;
            }
            return dictionary[key];
        }
    }
}