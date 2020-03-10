/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Utilities.Selenium;
using Gravity.Plugins.Actions.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using Gravity.Plugins.Utilities;
using System.Collections.ObjectModel;
using Gravity.Plugins.Contracts;

namespace Gravity.Plugins.Actions.Components
{
    public class ConditionsFactory
    {
        #region *** constants    ***
        internal static class StateProperties
        {
            public const string Evaluation = "evaluation";
            public const string Actual = "actual";
            public const string Expected = "expected";
            public const string Operator = "operator";
        }

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
        /// Assert that <see cref="IWebElement"/> exists in the DOM, it is not intractable.
        /// </summary>
        public const string Disabled = "disabled";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> selected state is <see cref="true"/>.
        /// </summary>
        public const string Selected = "selected";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> selected state is <see cref="false"/>.
        /// </summary>
        public const string NotSelected = "not_selected";

        /// <summary>
        /// Assert that <see cref="IWebElement"/> attribute from <see cref="Rule.ElementAttributeToActOn"/> meets a condition.
        /// </summary>
        public const string Attribute = "attribute";

        /// <summary>
        /// Assert that <see cref="IWebElement.Text"/> meets a condition.
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// Assert that <see cref="IWebDriver"/> <see cref="Type.FullName"/> meets a condition.
        /// </summary>
        public const string Driver = "driver";

        /// <summary>
        /// Assert that count of the given elements (total) meets a condition.
        /// </summary>
        public const string Count = "count";

        /// <summary>
        /// Assert that <see cref="IWebDriver.Url"/> meets a condition.
        /// </summary>
        public const string Url = "url";

        /// <summary>
        /// Assert that <see cref="IWebDriver.Title"/> meets a condition.
        /// </summary>
        public const string Title = "title";

        /// <summary>
        /// Assert that <see cref="IWebDriver.WindowHandles"/> count meets a condition.
        /// </summary>
        public const string WindowsCount = "windows_count";
        #endregion        

        // members: state
        private readonly IWebDriver driver;
        private readonly ByFactory byFactory;
        private readonly CliFactory cliFactory;
        private IDictionary<string, string> arguments;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of <see cref="ConditionsFactory"/> (with 15sec default timeout).
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ConditionsFactory(IWebDriver driver)
            : this(driver, Misc.GetTypes()) { }

        /// <summary>
        /// Creates a new instance of <see cref="ConditionsFactory"/> (with 15sec default timeout).
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        /// <param name="types">A collection of <see cref="Type"/> under which to search for <see cref="StateMethodAttribute"/> methods.</param>
        public ConditionsFactory(IWebDriver driver, IEnumerable<Type> types)
        {
            this.driver = driver;
            byFactory = new ByFactory(types);
            cliFactory = new CliFactory();
        }
        #endregion

        #region *** factor       ***
        /// <summary>
        /// Executes an element state method by the provided name.
        /// </summary>
        /// <param name="conditionCli">The condition expression to execute.</param>
        /// <param name="parameters">Parameters collection of the state method to execute.</param>
        /// <returns>Element state validation.</returns>
        public IDictionary<string, object> Factor(string conditionCli, object[] parameters)
        {
            // get conditions
            arguments = GetArguments(conditionCli);

            // get state method
            var method = GetType().GetMethodByDescription(arguments["until"]);

            if(method == null)
            {
                throw new InvalidOperationException($"Method [{conditionCli}] was not found under [{nameof(ConditionsFactory)}].");
            }

            // normalize parameters
            parameters = parameters.Take(method.GetParameters().Length).ToArray();

            // execute state method
            return (Dictionary<string, object>)method.Invoke(obj: this, parameters);
        }

        /// <summary>
        /// Gets an arguments collection based on conditional CLI.
        /// </summary>
        /// <param name="cli">CLI to factor arguments from.</param>
        /// <returns>Arguments collection</returns>
        public IDictionary<string, string> GetArguments(string cli)
        {
            // constants
            const string Until = "until";
            const string OperatorRegex = "^eq$|^ne$|^gt$|^ge$|^lt$|^le$|^match$|^notmatch$";

            // get conditions
            var args = cliFactory.Parse(cli);

            // argument: until
            if (!args.ContainsKey(Until))
            {
                args[Until] = args
                    .FirstOrDefault(i => string.IsNullOrEmpty(i.Value)).Key ?? string.Empty;
            }

            // argument: operator
            var @operator = args.FirstOrDefault(i => Regex.IsMatch(i.Key, OperatorRegex));
            if(@operator.Key == null)
            {
                args[StateProperties.Operator] = "match";
                args[StateProperties.Expected] = ".*";
            }
            else
            {
                args[StateProperties.Operator] = @operator.Key;
                args[StateProperties.Expected] = @operator.Value;
            }

            // result
            return args;
        }
        #endregion

#pragma warning disable IDE0051
        #region *** repository   ***
        [Description(Exists)]
        private IDictionary<string, object> ElementExists(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element) != null;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Exists,
                [StateProperties.Actual] = actual ? Exists : NotExists,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(Visible)]
        private IDictionary<string, object> ElementVisible(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element).Displayed;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Visible,
                [StateProperties.Actual] = actual ? Visible : Hidden,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(Hidden)]
        private IDictionary<string, object> ElementHidden(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = !ConditionalGetElement(actionRule, element).Displayed;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Hidden,
                [StateProperties.Actual] = actual ? Hidden : Visible,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(NotExists)]
        private IDictionary<string, object> ElementNotExists(ActionRule actionRule, IWebElement element)
        {
            // get actual
            var actual = false;
            try
            {
                actual = ConditionalGetElement(actionRule, element) == null;
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
                [StateProperties.Evaluation] = actual,
                [StateProperties.Actual] = actual ? NotExists : Exists,
                [StateProperties.Expected] = Exists,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        }

        [Description(Stale)]
        private IDictionary<string, object> ElementStale(ActionRule actionRule, IWebElement element)
        {
            // get actual
            var actual = false;
            try
            {
                _ = ConditionalGetElement(actionRule, element).Text;
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
                [StateProperties.Evaluation] = actual,
                [StateProperties.Actual] = actual ? Stale : "not_stale",
                [StateProperties.Expected] = Stale,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        }

        [Description(Enabled)]
        private IDictionary<string, object> ElementEnabled(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element).Enabled;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Enabled,
                [StateProperties.Actual] = actual ? Enabled : Disabled,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(Disabled)]
        private IDictionary<string, object> ElementDisabled(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = !ConditionalGetElement(actionRule, element).Enabled;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Disabled,
                [StateProperties.Actual] = actual ? Disabled : Enabled,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(Selected)]
        private IDictionary<string, object> ElementSelected(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element).Selected;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = Selected,
                [StateProperties.Actual] = actual ? Selected : NotSelected,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(NotSelected)]
        private IDictionary<string, object> ElementNotSelected(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = !ConditionalGetElement(actionRule, element).Selected;

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = actual,
                [StateProperties.Expected] = NotSelected,
                [StateProperties.Actual] = actual ? NotSelected : Selected,
                [StateProperties.Operator] = Contracts.OperatorType.Equal
            };
        });

        [Description(Attribute)]
        private IDictionary<string, object> ElementAttribute(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element)
                .GetAttribute(attributeName: actionRule.ElementAttributeToActOn);

            // get operator method
            var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

            // invoke
            var evaluation = (bool)method.Invoke(this, new object[] { actual, arguments[StateProperties.Expected] });

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = evaluation,
                [StateProperties.Expected] = arguments[StateProperties.Expected],
                [StateProperties.Actual] = actual,
                [StateProperties.Operator] = arguments[StateProperties.Operator]
            };
        });

        [Description(Text)]
        private IDictionary<string, object> ElementText(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElement(actionRule, element).Text;

            // get operator method
            var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

            // invoke
            var evaluation = (bool)method.Invoke(this, new object[] { actual, arguments[StateProperties.Expected] });

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = evaluation,
                [StateProperties.Expected] = arguments[StateProperties.Expected],
                [StateProperties.Actual] = actual,
                [StateProperties.Operator] = arguments[StateProperties.Operator]
            };
        });

        [Description(Driver)]
        private IDictionary<string, object> DriverType()
            => AssertState(() =>
        {
            // get actual
            var actual = driver.GetType().FullName;

            // get operator method
            var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

            // invoke
            var evaluation = (bool)method.Invoke(this, new object[] { actual, arguments[StateProperties.Expected] });

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = evaluation,
                [StateProperties.Expected] = arguments[StateProperties.Expected],
                [StateProperties.Actual] = actual,
                [StateProperties.Operator] = arguments[StateProperties.Operator]
            };
        });

        [Description(Count)]
        private IDictionary<string, object> ElementsCount(ActionRule actionRule, IWebElement element)
            => AssertState(() =>
        {
            // get actual
            var actual = ConditionalGetElements(actionRule, element).Count;

            // get operator method
            var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

            // invoke
            var evaluation = (bool)method.Invoke(this, new object[] { $"{actual}", arguments[StateProperties.Expected] });

            // compose
            return new Dictionary<string, object>
            {
                [StateProperties.Evaluation] = evaluation,
                [StateProperties.Expected] = arguments[StateProperties.Expected],
                [StateProperties.Actual] = actual,
                [StateProperties.Operator] = arguments[StateProperties.Operator]
            };
        });

        [Description(Url)]
        private IDictionary<string, object> PageUrl()
            => AssertState(() =>
            {
                // get actual
                var actual = driver.Url;

                // get operator method
                var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

                // invoke
                var evaluation = (bool)method.Invoke(this, new object[] { actual, arguments[StateProperties.Expected] });

                // compose
                return new Dictionary<string, object>
                {
                    [StateProperties.Evaluation] = evaluation,
                    [StateProperties.Expected] = arguments[StateProperties.Expected],
                    [StateProperties.Actual] = actual,
                    [StateProperties.Operator] = arguments[StateProperties.Operator]
                };
            });

        [Description(Title)]
        private IDictionary<string, object> PageTitle()
            => AssertState(() =>
            {
                // get actual
                var actual = driver.Title;

                // get operator method
                var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

                // invoke
                var evaluation = (bool)method.Invoke(this, new object[] { actual, arguments[StateProperties.Expected] });

                // compose
                return new Dictionary<string, object>
                {
                    [StateProperties.Evaluation] = evaluation,
                    [StateProperties.Expected] = arguments[StateProperties.Expected],
                    [StateProperties.Actual] = actual,
                    [StateProperties.Operator] = arguments[StateProperties.Operator]
                };
            });

        [Description(WindowsCount)]
        private IDictionary<string, object> DriverWindowsCount()
            => AssertState(() =>
            {
                // get actual
                var actual = driver.WindowHandles.Count;

                // get operator method
                var method = GetType().GetMethodByDescription(arguments[StateProperties.Operator]);

                // invoke
                var evaluation = (bool)method.Invoke(this, new object[] { $"{actual}", arguments[StateProperties.Expected] });

                // compose
                return new Dictionary<string, object>
                {
                    [StateProperties.Evaluation] = evaluation,
                    [StateProperties.Expected] = arguments[StateProperties.Expected],
                    [StateProperties.Actual] = actual,
                    [StateProperties.Operator] = arguments[StateProperties.Operator]
                };
            });

        // gets an element by action rule and element
        private IWebElement ConditionalGetElement(ActionRule actionRule, IWebElement element)
        {
            return element != default
                ? element.FindElementByActionRule(byFactory, actionRule)
                : driver.FindElementByActionRule(byFactory, actionRule);
        }

        private ReadOnlyCollection<IWebElement> ConditionalGetElements(ActionRule actionRule, IWebElement element)
        {
            return element != default
                ? element.FindElementsByActionRule(byFactory, actionRule)
                : driver.FindElementsByActionRule(byFactory, actionRule);
        }

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
                    [StateProperties.Evaluation] = false,
                    [StateProperties.Actual] = $"{e}"
                };
            }
        }
        #endregion

        #region *** operators    ***
        [Description(Contracts.OperatorType.Equal)]
        private bool Eqaul(string actual, string expected)
        {
            return actual.Equals(expected, StringComparison.Ordinal);
        }

        [Description(Contracts.OperatorType.NotEqual)]
        private bool NotEqaul(string actual, string expected)
        {
            return !actual.Equals(expected, StringComparison.Ordinal);
        }

        [Description(Contracts.OperatorType.Match)]
        private bool Match(string actual, string expected)
        {
            return Regex.IsMatch(input: actual, pattern: expected);
        }

        [Description(Contracts.OperatorType.NotMatch)]
        private bool NotMatch(string actual, string expected)
        {
            return !Regex.IsMatch(input: actual, pattern: expected);
        }

        [Description(Contracts.OperatorType.GreaterThan)]
        private bool GreaterThan(string actual, string expected)
        {
            // get as numbers
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // result
            return isActual && isExpected && (actualOut > expectedOut);
        }

        [Description(Contracts.OperatorType.LowerThan)]
        private bool LowerThan(string actual, string expected)
        {
            // get as numbers
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // result
            return isActual && isExpected && (actualOut < expectedOut);
        }

        [Description(Contracts.OperatorType.GreaterOrEqualThan)]
        private bool GreaterOrEqualThan(string actual, string expected)
        {
            // get as numbers
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // result
            return isActual && isExpected && (actualOut >= expectedOut);
        }

        [Description(Contracts.OperatorType.LowerOrEqualThan)]
        private bool LowerOrEqualThan(string actual, string expected)
        {
            // get as numbers
            var isActual = double.TryParse(actual, out double actualOut);
            var isExpected = double.TryParse(expected, out double expectedOut);

            // result
            return isActual && isExpected && (actualOut <= expectedOut);
        }
        #endregion
#pragma warning restore IDE0051
    }
}