/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Utilities.Selenium;
using Gravity.Services.DataContracts;
using Gravity.Plugins.Actions.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.Components
{
    public class ElementStateFactory
    {
        #region *** constants    ***
        /// <summary>
        /// Assert that <see cref="IWebElement"/> exists in the DOM.
        /// </summary>
        public const string Exists = "exists";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> exists in the DOM and its visible state is <see cref="true"/>.
        /// </summary>
        public const string Visible = "visible";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> exists in the DOM and its visible state is <see cref="false"/>.
        /// </summary>
        public const string Hidden = "hidden";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> is not exists in the DOM.
        /// </summary>
        public const string NotExists = "not_exists";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> state is stale (i.e. modified on run time).
        /// </summary>
        public const string Stale = "stale";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> exists in the DOM, is visible state is <see cref="true"/> and it is intractable.
        /// </summary>
        public const string Enabled = "enabled";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> selected state is <see cref="true"/>.
        /// </summary>
        public const string Selected = "selected";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> attribute from <see cref="Rule.ElementAttributeToActOn"/> match <see cref="Rule.RegularExpression"/>.
        /// </summary>
        public const string AttributeMatch = "attribute";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> text match <see cref="Rule.RegularExpression"/>.
        /// </summary>
        public const string TextMatch = "text";
        #endregion        

        // members: state
        private readonly IWebDriver driver;
        private readonly ByFactory byFactory;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of <see cref="ElementStateFactory"/> (with 15sec default timeout).
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ElementStateFactory(IWebDriver driver)
            : this(driver, Misc.GetTypes()) { }

        /// <summary>
        /// Creates a new instance of <see cref="ElementStateFactory"/> (with 15sec default timeout).
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        /// <param name="types">A collection of <see cref="Type"/> under which to search for <see cref="StateMethodAttribute"/> methods.</param>
        public ElementStateFactory(IWebDriver driver, IEnumerable<Type> types)
        {
            this.driver = driver;
            byFactory = new ByFactory(types);
        }
        #endregion

        #region *** factor       ***
        /// <summary>
        /// Executes an element state method by the provided name.
        /// </summary>
        /// <param name="name">The name of the state method to execute.</param>
        /// <param name="parameters">Parameters collection of the state method to execute.</param>
        /// <returns>Element state validation.</returns>
        public bool Factor(string name, object[] parameters)
        {
            // get state method
            var method = GetType().GetMethodByDescription(name);

            if(method == null)
            {
                throw new InvalidOperationException($"Method [{name}] was not found under [{nameof(ElementStateFactory)}].");
            }

            // execute state method
            return (bool)method.Invoke(obj: this, parameters);
        }
        #endregion

#pragma warning disable IDE0051
        #region *** repository   ***
        [Description(Exists)]
        private bool ElementExists(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return ConditionalGetElement(actionRule, element) != null;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(Visible)]
        private bool ElementVisible(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return ConditionalGetElement(actionRule, element).Displayed;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(Hidden)]
        private bool ElementHidden(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return !ConditionalGetElement(actionRule, element).Displayed;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(NotExists)]
        private bool ElementNotExists(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return ConditionalGetElement(actionRule, element) == null;
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return true;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(Stale)]
        private bool ElementStale(ActionRule actionRule, IWebElement element)
        {
            try
            {
                _ = ConditionalGetElement(actionRule, element).Text;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                return true;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
            return false;
        }

        [Description(Enabled)]
        private bool ElementEnabled(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return ConditionalGetElement(actionRule, element).Enabled;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(Selected)]
        private bool ElementSelected(ActionRule actionRule, IWebElement element)
        {
            try
            {
                return ConditionalGetElement(actionRule, element).Selected;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(AttributeMatch)]
        private bool ElementAttributeMatch(ActionRule actionRule, IWebElement element)
        {
            try
            {
                // get attribute
                var attribute = ConditionalGetElement(actionRule, element)
                    .GetAttribute(actionRule.ElementAttributeToActOn);

                // results
                return Regex.IsMatch(attribute, actionRule.RegularExpression);
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        [Description(TextMatch)]
        private bool ElementTextMatch(ActionRule actionRule, IWebElement element)
        {
            try
            {
                // get text
                var text = ConditionalGetElement(actionRule, element).Text;

                // results
                return Regex.IsMatch(text, actionRule.RegularExpression);
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        // gets an element by action rule and element
        private IWebElement ConditionalGetElement(ActionRule actionRule, IWebElement element)
        {
            return element != default
                ? element.FindElementByActionRule(byFactory, actionRule)
                : driver.FindElementByActionRule(byFactory, actionRule);
        }
        #endregion
#pragma warning restore IDE0051
    }
}