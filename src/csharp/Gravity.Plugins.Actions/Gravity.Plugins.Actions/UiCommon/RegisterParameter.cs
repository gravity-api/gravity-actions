/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-04-03
 *    - modify: add support for literal and CLI
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * 2019-12-28
 *    - modify: add constructor to override base class types
 *    
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 *    - modify: code cleaning
 *    
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.RegisterParameter.json",
        Name = GravityPlugin.RegisterParameter)]
    public class RegisterParameter : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// Parameter key under which to save value. If exists, it will be overwritten.
        /// </summary>
        public const string Key = "key";

        /// <summary>
        /// Parameter value to save. Can be a literal string or <see cref="WebDriverMacroPlugin"/>.
        /// </summary>
        public const string Value = "value";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public RegisterParameter(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // load arguments
            var arguments = CliFactory.Parse(action.Argument);

            // exit conditions
            if (TryGetFromCli(arguments))
            {
                return;
            }

            // by name
            var key = arguments.ContainsKey(Key) ? arguments[Key] : action.Argument;
            var result = string.Empty;
            try
            {
                // get element
                var onElement = this.ConditionalGetElement(element, action);

                // get parameter value
                result = GetTextOrAttribute(action, element: onElement);
            }
            catch (Exception e) when (e is NoSuchElementException || e is WebDriverTimeoutException || e is StaleElementReferenceException)
            {
                result = Regex.Match(action.OnElement, action.RegularExpression).Value;
            }
            catch (Exception)
            {
                ErrorHandle(action);
                throw;
            }
            finally
            {
                // save the value
                EnvironmentContext.ApplicationParams[key] = result;
            }
        }

        // get text value from element inner-text or specified attribute
        private static string GetTextOrAttribute(ActionRule action, IWebElement element)
        {
            // exit conditions
            if (element == null)
            {
                return string.Empty;
            }

            // text conditions
            if (string.IsNullOrEmpty(action.OnAttribute))
            {
                return Regex.Match(element.Text, action.RegularExpression).Value;
            }

            // get from element attribute
            var attributeValue = element.GetAttribute(action.OnAttribute);
            return Regex.Match(attributeValue, action.RegularExpression).Value;
        }

        // handles register_parameter errors
        private void ErrorHandle(ActionRule action)
        {
            // exit conditions
            if (string.IsNullOrEmpty(action.Argument))
            {
                return;
            }

            // save empty value
            Environment.SessionParams[action.Argument] = string.Empty;
        }

        private static bool TryGetFromCli(IDictionary<string, string> arguments)
        {
            // setup conditions
            var isKey = arguments.ContainsKey(Key);
            var isValue = arguments.ContainsKey(Value);

            // by CLI
            if (isKey && isValue)
            {
                EnvironmentContext.ApplicationParams[arguments[Key]] = arguments[Value];
                return true;
            }
            if (!isKey && isValue)
            {
                throw new ArgumentException(
                    "You must provide a [key] to application argument {{$ --key:my_parameter --value:1}}");
            }

            // only key or no key provided
            return false;
        }
    }
}