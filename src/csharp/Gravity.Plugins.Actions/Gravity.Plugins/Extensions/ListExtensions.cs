/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Gravity.Plugins.Extensions
{
    /// <summary>
    /// <see cref="List{T}" /> extensions package.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Attempts to merge this <see cref="List{T}"/> instance with the given collection.
        /// </summary>
        /// <typeparam name="T">Generic list type.</typeparam>
        /// <param name="list">This <see cref="List{T}"/> instance.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> to try and append into this <see cref="List{T}"/> instance.</param>
        /// <returns><see cref="true"/> is successful, <see cref="false"/> if not.</returns>
        public static bool TryAddRange<T>(this List<T> list, IEnumerable<T> collection)
        {
            if (collection?.Any() != true)
            {
                return false;
            }
            list.AddRange(collection);
            return true;
        }

        /// <summary>
        /// Attempts to merge this <see cref="ConcurrentBag{T}"/> instance with the given collection.
        /// </summary>
        /// <typeparam name="T">Generic list type.</typeparam>
        /// <param name="list">This <see cref="ConcurrentBag{T}"/> instance.</param>
        /// <param name="collection"><see cref="IEnumerable{T}"/> to try and append into this <see cref="ConcurrentBag{T}"/> instance.</param>
        public static void AddRange<T>(this ConcurrentBag<T> list, IEnumerable<T> collection)
        {
            if (collection?.Any() != true)
            {
                return;
            }
            foreach (var item in collection)
            {
                list.Add(item);
            }
        }
    }
}
