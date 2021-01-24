/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class PluginUtilities
    {
        /// <summary>
        /// Gets an assertion if the action described under this element and/or action rule is
        /// a flat action (non element action)
        /// </summary>
        /// <param name="actionRule"><see cref="ActionRule"/> to assert.</param>
        /// <returns>True if this is a flat action (no element); False if not.</returns>
        public static bool IsFlatAction(ActionRule actionRule)
        {
            return DoIsFlatAction(actionRule, element: default);
        }

        /// <summary>
        /// Gets an assertion if the action described under this element and/or action rule is
        /// a flat action (non element action)
        /// </summary>
        /// <param name="actionRule"><see cref="ActionRule"/> to assert.</param>
        /// <param name="element"><see cref="IWebElement"/> to assert.</param>
        /// <returns>True if this is a flat action (no element); False if not.</returns>
        public static bool IsFlatAction(ActionRule actionRule, IWebElement element)
        {
            return DoIsFlatAction(actionRule, element);
        }

        // assert if action is flat
        private static bool DoIsFlatAction(ActionRule actionRule, IWebElement element)
        {
            // setup conditions
            var isElement = element != default;
            var isFromAction = !string.IsNullOrEmpty(actionRule.OnElement);

            // return assertion
            return !(isElement || isFromAction);
        }
    }
}