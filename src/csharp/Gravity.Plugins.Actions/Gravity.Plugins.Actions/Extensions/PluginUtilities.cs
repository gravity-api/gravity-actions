/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
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
            return AssertFlatAction(default, actionRule);
        }

        /// <summary>
        /// Gets an assertion if the action described under this element and/or action rule is
        /// a flat action (non element action)
        /// </summary>
        /// <param name="webElement"><see cref="IWebElement"/> to assert.</param>
        /// <param name="actionRule"><see cref="ActionRule"/> to assert.</param>
        /// <returns>True if this is a flat action (no element); False if not.</returns>
        public static bool IsFlatAction(IWebElement webElement, ActionRule actionRule)
        {
            return AssertFlatAction(webElement, actionRule);
        }

        // assert if action is flat
        private static bool AssertFlatAction(IWebElement webElement, ActionRule actionRule)
        {
            // setup conditions
            var isElement = webElement != default;
            var isFromAction = !string.IsNullOrEmpty(actionRule.ElementToActOn);

            // return assertion
            return !(isElement || isFromAction);
        }
    }
}