/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Gravity.Services.ActionPlugins.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Return a value indicates if this string is a valid, able to compile JSON.
        /// </summary>
        /// <param name="str">This string instance on which to perform validation.</param>
        /// <returns>True if this string is a valid JSON, False if not.</returns>
        public static bool IsJson(this string str)
        {
            // process string
            str = str.Trim();

            // setup conditions
            var isObj = str.StartsWith("{") && str.EndsWith("}");
            var isArr = str.StartsWith("[") && str.EndsWith("]");

            // parse
            if (isObj && isArr)
            {
                try
                {
                    JToken.Parse(str);
                    return true;
                }
                catch (Exception e) when (e is JsonReaderException)
                {
                    return false;
                }
            }
            return false;
        }
    }
}