/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-02-03
 *    - modify: refactoring
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Utilities;
using Gravity.Plugins.Utilities.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Base
{
    public abstract class WebDriverMacroPlugin : Plugin
    {
        #region *** constants    ***
        /// <summary>
        /// Reference for <see cref="ActionRule.Locator"/> macro parameter.
        /// </summary>
        public const string Locator = "locator";

        /// <summary>
        /// Reference for <see cref="Rule.OnElement"/> macro parameter.
        /// </summary>
        public const string Element = "element";

        /// <summary>
        /// Reference for <see cref="Rule.RegularExpression"/> macro parameter.
        /// </summary>
        public const string Regex = "regex";

        /// <summary>
        /// Reference for <see cref="Rule.OnAttribute"/> macro parameter.
        /// </summary>
        public const string Attribute = "attribute";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        protected WebDriverMacroPlugin(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation)
        {
            WebDriver = driver;
            ByFactory ??= new ByFactory(Types);
        }
        #endregion

        #region *** properties   ***
        /// <summary>
        /// Gets or sets the <see cref="IWebDriver"/> implementation of this <see cref="WebDriverActionPlugin"/>.
        /// </summary>
        public IWebDriver WebDriver { get; set; }

        /// <summary>
        /// Gets a Selenium locator factory instance.
        /// </summary>
        public ByFactory ByFactory { get; set; }

        /// <summary>
        /// Gets the command arguments collection of this <see cref="WebDriverMacroPlugin"/>.
        /// </summary>
        public IDictionary<string, string> Arguments { get; private set; }
        #endregion

        #region *** plugins      ***
        /// <summary>
        /// Override to implement action execution based on macro command line.
        /// </summary>
        public virtual string OnPerform()
        {
            // action log
            Console.WriteLine(
                $"No implementation for this macro [{nameof(OnPerform)}] method.");

            // result
            return string.Empty;
        }

        /// <summary>
        /// Performs a macro execution based on macro command line.
        /// </summary>
        /// <param name="cli">Macro command line integration phrase provided by the user.</param>
        public string Perform(string cli)
        {
            // trace log
            Console.WriteLine("Executing ---Selenium Macro [{0}]--- started", cli);

            // exit conditions
            if (string.IsNullOrEmpty(cli))
            {
                return "null_or_empty_macro_cli";
            }

            // setup
            Arguments = CliFactory.Parse(cli);

            // get result
            var result = OnPerform();

            // information log
            Console.WriteLine(
                "Executing ---Selenium Macro [{0}]--- completed with [{1}] result", cli, result);

            // result
            return result;
        }
        #endregion
    }
}