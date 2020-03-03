/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Extensions;
using OpenQA.Selenium;
using System;
using System.ComponentModel;

namespace Gravity.Plugins.Actions.Components
{
    public class PageStateFactory
    {
        #region *** constants    ***
        /// <summary>
        /// Fully loaded.
        /// </summary>
        public const string Complete = "complete";

        /// <summary>
        /// Has loaded enough and the user can interact with it.
        /// </summary>
        public const string Interactive = "interactive";

        /// <summary>
        /// Has been loaded.
        /// </summary>
        public const string Loaded = "loaded";

        /// <summary>
        /// Is loading.
        /// </summary>
        public const string Loading = "loading";

        /// <summary>
        /// Has not started loading yet.
        /// </summary>
        public const string Uninitialized = "uninitialized";

        /// <summary>
        /// Always <see cref="false"/>.
        /// </summary>
        public const string False = "false";
        #endregion

        #region *** constructors ***
        #endregion

        #region *** factor       ***
        /// <summary>
        /// Executes a page state method by the provided name.
        /// </summary>
        /// <param name="name">The name of the state method to execute.</param>
        /// <param name="parameters">Parameters collection of the state method to execute.</param>
        /// <returns>Element state validation.</returns>
        public bool Factor(string name, object[] parameters)
        {
            // get state method
            var method = GetType().GetMethodByDescription(name);

            if (method == null)
            {
                throw new InvalidOperationException($"Method [{name}] was not found under [{nameof(WebDriverStateFactory)}].");
            }

            // execute state method
            return (bool)method.Invoke(obj: this, parameters);
        }
        #endregion

#pragma warning disable IDE0051
        #region *** repository   ***
        [Description(Complete)]
        private bool StateComplete(IWebDriver driver)
            => CompareState(driver, expectedState: Complete);

        [Description(Interactive)]
        private bool StateInteractive(IWebDriver driver)
            => CompareState(driver, expectedState: Interactive);

        [Description(Loaded)]
        private bool StateLoaded(IWebDriver driver)
            => CompareState(driver, expectedState: Loaded);

        [Description(Loading)]
        private bool StateLoading(IWebDriver driver)
            => CompareState(driver, expectedState: Loading);

        [Description(Uninitialized)]
        private bool StateUninitialized(IWebDriver driver)
            => CompareState(driver, expectedState: Uninitialized);

        [Description(False)]
        private bool StateFalse(IWebDriver driver)
            => CompareState(driver, expectedState: "false");

        private static bool CompareState(IWebDriver driver, string expectedState)
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
#pragma warning restore IDE0051
    }
}