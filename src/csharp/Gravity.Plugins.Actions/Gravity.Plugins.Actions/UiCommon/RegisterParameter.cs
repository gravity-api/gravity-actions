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
 *    - modify: override ActionName using ActionType constant
 *    - modify: code cleaning
 *    
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.register-parameter.json",
        Name = CommonPlugins.RegisterParameter)]
    public class RegisterParameter : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public RegisterParameter(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // load arguments
            var arguments = CliFactory.Parse(actionRule.Argument);

            // exit conditions
            if (TryGetFromCli(arguments))
            {
                return;
            }

            // by name
            var key = arguments.ContainsKey("key") ? arguments["key"] : actionRule.Argument;
            var result = string.Empty;
            try
            {
                // get element
                var onElement = this.ConditionalGetElement(element, actionRule);

                // get parameter value
                result = GetTextOrAttribute(actionRule, element: onElement);
            }
            catch (Exception e) when (e is NoSuchElementException || e is WebDriverTimeoutException)
            {
                result = Regex.Match(actionRule.ElementToActOn, actionRule.RegularExpression).Value;
                throw;
            }
            catch (Exception)
            {
                ErrorHandle(actionRule);
                throw;
            }
            finally
            {
                // save the value
                EnvironmentContext.ApplicationParams[key] = result;
            }
        }

        // get text value from element inner-text or specified attribute
        private static string GetTextOrAttribute(ActionRule actionRule, IWebElement element)
        {
            // exit conditions
            if (element == null)
            {
                return string.Empty;
            }

            // text conditions
            if (string.IsNullOrEmpty(actionRule.ElementAttributeToActOn))
            {
                return Regex.Match(element.Text, actionRule.RegularExpression).Value;
            }

            // get from element attribute
            var attributeValue = element.GetAttribute(actionRule.ElementAttributeToActOn);
            return Regex.Match(attributeValue, actionRule.RegularExpression).Value;
        }

        // handles register-parameter errors
        private void ErrorHandle(ActionRule actionRule)
        {
            // exit conditions
            if (string.IsNullOrEmpty(actionRule.Argument))
            {
                return;
            }

            // save empty value
            Environment.SessionParams[actionRule.Argument] = string.Empty;
        }

        private static bool TryGetFromCli(IDictionary<string, string> arguments)
        {
            // setup conditions
            var isKey = arguments.ContainsKey("key");
            var isValue = arguments.ContainsKey("value");

            // by CLI
            if (isKey && isValue)
            {
                EnvironmentContext.ApplicationParams[arguments["key"]] = arguments["value"];
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