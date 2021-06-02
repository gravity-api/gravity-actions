/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Utilities
{
    /// <summary>
    /// A collection of assertion methods.
    /// </summary>
    public class ConditionsRepository : ConditionsBase
    {
        // constants
        private const StringComparison Compare = StringComparison.OrdinalIgnoreCase;

        // members: state
        private readonly OperatorsFactory operatorsFactory;

        /// <summary>
        /// Creates a new instance of ConditionsRepository.
        /// </summary>
        /// <param name="driver">The IWebDriver (session) for using with the repository.</param>
        /// <param name="types">A collection of <see cref="Type"/> to use with the repository.</param>
        public ConditionsRepository(IWebDriver driver, IEnumerable<Type> types)
            : base(driver, types)
        {
            operatorsFactory = new OperatorsFactory(types);
        }

        #region *** Alerts      ***
        /// <summary>
        /// An expectation for checking if alert is present on this session.
        /// </summary>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.AlertExists)]
        public IDictionary<string, object> HasAlert() => AssertState(() =>
        {
            // setup
            var actual = Driver.HasAlert();

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Exists,
                [AssertProperties.Actual] = actual ? Conditions.Exists : Conditions.NotExists,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking if alert is not present on this session.
        /// </summary>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.NoAlert)]
        public IDictionary<string, object> HasNoAlert() => AssertState(() =>
        {
            // setup
            var actual = !Driver.HasAlert();

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Exists,
                [AssertProperties.Actual] = actual ? Conditions.Exists : Conditions.NotExists,
                [AssertProperties.Operator] = Operators.Equal
            };
        });
        #endregion

        #region *** Element     ***
        /// <summary>
        /// An expectation for checking that an element is currently has the focus.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Active)]
        public IDictionary<string, object> ElementActive(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = this.ConditionalGetElement(actionRule, element) == Driver.SwitchTo().ActiveElement();

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Exists,
                [AssertProperties.Actual] = actual ? Conditions.Exists : Conditions.NotExists,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page.
        /// This does not necessarily mean that the element is visible.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Exists)]
        public IDictionary<string, object> ElementExists(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = this.ConditionalGetElement(actionRule, element) != null;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Exists,
                [AssertProperties.Actual] = actual ? Conditions.Exists : Conditions.NotExists,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is not present on the DOM of a page.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.NotExists)]
        public IDictionary<string, object> ElementNotExists(ActionRule actionRule, IWebElement element)
        {
            // setup
            var actual = false;
            try
            {
                actual = this.ConditionalGetElement(actionRule, element) == null;
            }
            catch (Exception e) when (e is NotFoundException)
            {
                actual = true;
            }
            catch (Exception e) when (e != null)
            {
                // ignore - keep default false
            }

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Actual] = actual ? Conditions.NotExists : Conditions.Exists,
                [AssertProperties.Expected] = Conditions.Exists,
                [AssertProperties.Operator] = Operators.Equal
            };
        }

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and visible.
        /// Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Visible)]
        public IDictionary<string, object> ElementVisible(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = this.ConditionalGetElement(actionRule, element).Displayed;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Visible,
                [AssertProperties.Actual] = actual ? Conditions.Visible : Conditions.Hidden,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and is not visible.
        /// Invisibility means that the element is not displayed and also has a height and width that is equal 0.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Hidden)]
        public IDictionary<string, object> ElementHidden(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = !this.ConditionalGetElement(actionRule, element).Displayed;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Hidden,
                [AssertProperties.Actual] = actual ? Conditions.Hidden : Conditions.Visible,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is stale on the DOM of a page.
        /// Staleness means that the element was deleted from the DOM or the DOM refreshed.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Stale)]
        public IDictionary<string, object> ElementStale(ActionRule actionRule, IWebElement element)
        {
            // setup
            var actual = false;
            try
            {
                _ = this.ConditionalGetElement(actionRule, element).Text;
            }
            catch (Exception e) when (e is StaleElementReferenceException)
            {
                actual = true;
            }
            catch (Exception e) when (e != null)
            {
                // ignore - keep default false
            }

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Actual] = actual ? Conditions.Stale : Conditions.NotStale,
                [AssertProperties.Expected] = Conditions.Stale,
                [AssertProperties.Operator] = Operators.Equal
            };
        }

        /// <summary>
        /// An expectation for checking if an element is visible and enabled such that you can click it.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Enabled)]
        public IDictionary<string, object> ElementEnabled(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = this.ConditionalGetElement(actionRule, element).Enabled;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Enabled,
                [AssertProperties.Actual] = actual ? Conditions.Enabled : Conditions.Disabled,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking if an element is not visible and not enabled such that you can click it.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Disabled)]
        public IDictionary<string, object> ElementDisabled(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = !this.ConditionalGetElement(actionRule, element).Enabled;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Disabled,
                [AssertProperties.Actual] = actual ? Conditions.Disabled : Conditions.Enabled,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page, visible and selected.
        /// Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Selected)]
        public IDictionary<string, object> ElementSelected(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = this.ConditionalGetElement(actionRule, element).Selected;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.Selected,
                [AssertProperties.Actual] = actual ? Conditions.Selected : Conditions.NotSelected,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page and not selected.
        /// Visibility means that the element is not only displayed but also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.NotSelected)]
        public IDictionary<string, object> ElementNotSelected(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var actual = !this.ConditionalGetElement(actionRule, element).Selected;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = actual,
                [AssertProperties.Expected] = Conditions.NotSelected,
                [AssertProperties.Actual] = actual ? Conditions.NotSelected : Conditions.Selected,
                [AssertProperties.Operator] = Operators.Equal
            };
        });

        /// <summary>
        /// An expectation for the given element's attribute to match a pattern.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Attribute)]
        public IDictionary<string, object> ElementAttribute(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var _element = this.ConditionalGetElement(actionRule, element);
            var input = actionRule.OnAttribute == "value" ? _element.GetValue() : _element.GetAttribute(actionRule.OnAttribute);
            var actual = Regex.Match(input, pattern: actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// An expectation for the given element's text to match a pattern.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Text)]
        public IDictionary<string, object> ElementText(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var input = this.ConditionalGetElement(actionRule, element).Text;
            var actual = Regex.Match(input, pattern: actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// An expectation for the given elements count to be evaluated.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Count)]
        public IDictionary<string, object> ElementsCount(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var actual = $"{this.ConditionalGetElements(actionRule, element).Count}";
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// Assert that length of a given string satisfy a condition.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <param name="element">A WebElement under which to find the WebElement (if any).</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.TextLength)]
        public IDictionary<string, object> TextLength(ActionRule actionRule, IWebElement element) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var onElement = this.ConditionalGetElement(actionRule, element);
            var text = string.IsNullOrEmpty(actionRule.OnAttribute)
                ? onElement.Text
                : onElement.GetAttribute(actionRule.OnAttribute);
            text = Regex.Match(text, actionRule.RegularExpression, RegexOptions.Singleline).Value;
            var actual = $"{text.Length}";
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });
        #endregion

        #region *** Driver      ***
        /// <summary>
        /// An expectation for checking that the current WebDriver follows the evaluation rules.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Driver)]
        public IDictionary<string, object> DriverType(ActionRule actionRule) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var actual = Regex.Match(Driver.GetType().FullName, actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// An expectation for checking that the current Page.Url follows the evaluation rules.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Url)]
        public IDictionary<string, object> PageUrl(ActionRule actionRule) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var actual = Regex.Match(input: Driver.Url, pattern: actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// An expectation for checking that the current Page.Title follows the evaluation rules.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Title)]
        public IDictionary<string, object> PageTitle(ActionRule actionRule) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var actual = Regex.Match(input: Driver.Title, pattern: actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });

        /// <summary>
        /// An expectation for checking that the current Windows.Count follows the evaluation rules.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.WindowsCount)]
        public IDictionary<string, object> DriverWindowsCount(ActionRule actionRule) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var actual = $"{Driver.WindowHandles.Count}";
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });
        #endregion

        #region *** Environment ***
        /// <summary>
        /// An expectation for checking that the provided parameter follows the evaluation rules.
        /// </summary>
        /// <param name="actionRule">The ActionRule by which to find the WebElement.</param>
        /// <returns>Assertion parameters.</returns>
        [AssertMethod(Conditions.Parameter)]
        public IDictionary<string, object> ApplicationParameter(ActionRule actionRule) => AssertState(() =>
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var input = EnvironmentContext.ApplicationParams.Get(actionRule.OnElement, string.Empty);
            var actual = Regex.Match(input, pattern: actionRule.RegularExpression).Value;
            var _operator = GetOperator(operatorsFactory, arguments);

            // get operator method
            var expected = arguments.FirstOrDefault(i => i.Key.Equals(_operator, Compare)).Value;

            // invoke
            var evaluation = operatorsFactory.Factor(arguments, new object[] { actual, expected }).Result;

            // compose
            return new Dictionary<string, object>
            {
                [AssertProperties.Evaluation] = evaluation,
                [AssertProperties.Expected] = expected,
                [AssertProperties.Actual] = actual,
                [AssertProperties.Operator] = _operator
            };
        });
        #endregion

        // Utilities
        // conditions execution wrapper
        private static IDictionary<string, object> AssertState(Func<IDictionary<string, object>> factory)
        {
            try
            {
                return factory.Invoke();
            }
            catch (Exception e) when (e != null)
            {
                return new Dictionary<string, object>
                {
                    [AssertProperties.Evaluation] = false,
                    [AssertProperties.Actual] = $"{e}"
                };
            }
        }

        // parse operator from the domain by given arguments
        private static string GetOperator(OperatorsFactory factory, IDictionary<string, string> arguments)
        {
            return factory
                .Operators
                .FirstOrDefault(i => arguments.Keys.Select(i => i.ToUpper()).Contains(i.ToUpper()));
        }
    }
}