/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using ActionType constant
 *    - modify: code cleaning
 *    
 * 2019-12-28
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 */
using Gravity.Drivers.Selenium;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.register-parameter.json",
        Name = ActionType.RegisterParameter)]
    public class RegisterParameter : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public RegisterParameter(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public RegisterParameter(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoRegisterParameter(actionRule, () =>
            {
                // get locator
                var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

                // get element
                return WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout));
            });
        }

        /// <summary>
        /// Saves a parameter under session parameters collection. This action supports
        /// elements, attributes, regular expression and macros.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoRegisterParameter(actionRule, () =>
            {
                // get locator
                var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

                // get element
                return IsAbsoluteXPath(actionRule)
                    ? WebDriver.GetElement(by, TimeSpan.FromMilliseconds(ElementSearchTimeout))
                    : webElement.FindElement(by);
            });
        }

        // executes RegisterParameter routine
        private void DoRegisterParameter(ActionRule actionRule, Func<IWebElement> elementFactory)
        {
            var result = string.Empty;
            try
            {
                // get element
                var element = elementFactory.Invoke();

                // get parameter value
                result = GetTextOrAttribute(element, actionRule);
            }
            catch (Exception e) when (e is NoSuchElementException ||e is WebDriverTimeoutException)
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
                AutomationEnvironment.SessionParams[actionRule.Argument] = result;
            }
        }

        // get text value from element inner-text or specified attribute
        private static string GetTextOrAttribute(IWebElement webElement, ActionRule actionRule)
        {
            // exit conditions
            if (webElement == null)
            {
                return string.Empty;
            }

            // text conditions
            if (string.IsNullOrEmpty(actionRule.ElementAttributeToActOn))
            {
                return Regex.Match(webElement.Text, actionRule.RegularExpression).Value;
            }

            // get from element attribute
            var attributeValue = webElement.GetAttribute(actionRule.ElementAttributeToActOn);
            return Regex.Match(attributeValue, actionRule.RegularExpression).Value;
        }

        // handles register-parameter errors
        private static void ErrorHandle(ActionRule actionRule)
        {
            // exit conditions
            if (string.IsNullOrEmpty(actionRule.Argument))
            {
                return;
            }

            // save empty value
            AutomationEnvironment.SessionParams[actionRule.Argument] = string.Empty;
        }
    }
}