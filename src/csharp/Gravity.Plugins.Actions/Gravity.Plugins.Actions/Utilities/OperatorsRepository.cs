/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Utilities
{
    /// <summary>
    /// A collection of Operators methods.
    /// </summary>
    public class OperatorsRepository : OperatorsBase
    {
        /// <summary>
        /// Creates a new instance of OperatorsRepository.
        /// </summary>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public OperatorsRepository(IEnumerable<Type> types)
            : base(types)
        { }

        /// <summary>
        /// Compares two values to be equal or not.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>True if equal; False if not.</returns>
        [OperatorMethod(Operators.Equal)]
        public static bool Eqaul(string actual, string expected)
        {
            return actual.Equals(expected, StringComparison.Ordinal);
        }

        /// <summary>
        /// Compares two values to be not equal.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>False if equal; True if not.</returns>
        [OperatorMethod(Operators.NotEqual)]
        public static bool NotEqaul(string actual, string expected)
        {
            return !actual.Equals(expected, StringComparison.Ordinal);
        }

        /// <summary>
        /// Check a string for a regular-expression-based match.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>True if match; False if not.</returns>
        [OperatorMethod(Operators.Match)]
        public static bool Match(string actual, string expected)
        {
            return Regex.IsMatch(input: actual, pattern: expected);
        }

        /// <summary>
        /// Check a string for a regular-expression-based match.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>False if match; True if not.</returns>
        [OperatorMethod(Operators.NotMatch)]
        public static bool NotMatch(string actual, string expected)
        {
            return !Regex.IsMatch(input: actual, pattern: expected);
        }

        /// <summary>
        /// Compares first value to be greater than second one.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>False if greater; True if not.</returns>
        [OperatorMethod(Operators.GreaterThan)]
        public static bool GreaterThan(string actual, string expected)
        {
            // setup
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // get
            return isActual && isExpected && (actualOut > expectedOut);
        }

        /// <summary>
        /// Compares first value to be less than second one.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>True if lower; False if not.</returns>
        [OperatorMethod(Operators.LowerThan)]
        public static bool LowerThan(string actual, string expected)
        {
            // setup
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // get
            return isActual && isExpected && (actualOut < expectedOut);
        }

        /// <summary>
        /// Compares first value to be greater than or equals to second one.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>True if greater or equal; False if not.</returns>
        [OperatorMethod(Operators.GreaterOrEqualThan)]
        public static bool GreaterOrEqualThan(string actual, string expected)
        {
            // setup
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // get
            return isActual && isExpected && (actualOut >= expectedOut);
        }

        /// <summary>
        /// Compares first value to be less than or equals to second one.
        /// </summary>
        /// <param name="actual">The actual (first) value.</param>
        /// <param name="expected">The expected (second) value.</param>
        /// <returns>True if lower or equal; False if not.</returns>
        [OperatorMethod(Operators.LowerOrEqualThan)]
        public static bool LowerOrEqualThan(string actual, string expected)
        {
            // setup
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // get
            return isActual && isExpected && (actualOut <= expectedOut);
        }
    }
}