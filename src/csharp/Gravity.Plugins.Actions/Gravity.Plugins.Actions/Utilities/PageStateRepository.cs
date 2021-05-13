/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.Utilities
{
    /// <summary>
    /// A collection of page state assertion methods.
    /// </summary>
    public class PageStateRepository : PageStateBase
    {
        public PageStateRepository(IWebDriver driver, IEnumerable<Type> types)
            : base(driver, types)
        { }

        #region *** Web Pages ***
        /// <summary>
        /// An expectation for checking if page state is complete.
        /// </summary>
        /// <returns>True if complete; False if not.</returns>
        [PageStateMethod(PageStates.Complete)]
        public bool StateComplete()
            => AssertWebPageState(Driver, expectedState: PageStates.Complete);

        /// <summary>
        /// An expectation that will always be false.
        /// </summary>
        /// <returns>False.</returns>
        [PageStateMethod(PageStates.False)]
        public bool StateFalse()
            => AssertWebPageState(Driver, expectedState: PageStates.False);

        /// <summary>
        /// An expectation for checking if page state is interactive.
        /// </summary>
        /// <returns>True if interactive; False if not.</returns>
        [PageStateMethod(PageStates.Interactive)]
        public bool StateInteractive()
            => AssertWebPageState(Driver, expectedState: PageStates.Interactive);

        /// <summary>
        /// An expectation for checking if page state is loaded.
        /// </summary>
        /// <returns>True if loaded; False if not.</returns>
        [PageStateMethod(PageStates.Loaded)]
        public bool StateLoaded()
            => AssertWebPageState(Driver, expectedState: PageStates.Loaded);

        /// <summary>
        /// An expectation for checking if page state is loading.
        /// </summary>
        /// <returns>True if loading; False if not.</returns>
        [PageStateMethod(PageStates.Loading)]
        public bool StateLoading()
            => AssertWebPageState(Driver, expectedState: PageStates.Loading);

        /// <summary>
        /// An expectation for checking if page state is uninitialized.
        /// </summary>
        /// <returns>True if uninitialized; False if not.</returns>
        [PageStateMethod(PageStates.Uninitialized)]
        public bool StateUninitialized()
            => AssertWebPageState(Driver, expectedState: PageStates.Uninitialized);

        private static bool AssertWebPageState(IWebDriver driver, string expectedState)
        {
            try
            {
                // setup
                const StringComparison Comparison = StringComparison.OrdinalIgnoreCase;
                const string Src = "return document.readyState;";

                // execute
                var actualState = $"{((IJavaScriptExecutor)driver).ExecuteScript(Src)}";

                // assert
                return actualState.Equals(expectedState, Comparison);
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }
        #endregion
    }
}