/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Gravity.Plugins.Actions.Extensions
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

        /// <summary>
        /// Attempts to create a <see cref="TimeSpan"/> object from the given string. If the string is
        /// an integer, it will be considered as milliseconds.
        /// </summary>
        /// <param name="str">The <see cref="string"/> from which to parse a new <see cref="TimeSpan"/>.</param>
        /// <returns>New <see cref="TimeSpan"/> instance.</returns>
        public static TimeSpan AsTimeSpan(this string str)
        {
            var isNumber = double.TryParse(str, out double numberOut);
            var isTimeSp = TimeSpan.TryParse(str, out TimeSpan timespanOut);

            // number handling
            if (isNumber)
            {
                return TimeSpan.FromMilliseconds(numberOut);
            }

            // timespan handling
            if (isTimeSp)
            {
                return timespanOut;
            }

            // default timespan
            return default;
        }
    }
}