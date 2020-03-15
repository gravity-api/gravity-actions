/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ConcurrentBag{T}"/>.
        /// </summary>
        /// <typeparam name="T">The object type of this <see cref="ConcurrentBag{T}"/>.</typeparam>
        /// <param name="bag">the <see cref="ConcurrentBag{T}"/> to add elements to.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ConcurrentBag{T}"/>.</param>
        public static void AddRange<T>(this ConcurrentBag<T> bag, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                bag.Add(item);
            }
        }
    }
}