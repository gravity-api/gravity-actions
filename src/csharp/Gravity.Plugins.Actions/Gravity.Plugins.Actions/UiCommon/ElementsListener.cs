/*
 * CHANGE LOG - keep only last 5 threads
 *
 * 2019-01-11
 *    - modify: override action-name using action constant
 *    
 * 2019-01-04
 *    - modify: change ERR constant to WRN
 *    
 * 2019-01-03
 *    - modify: improve XML comments
 *    - modify: change to JSON resource
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Gravity.Extensions;
using Gravity.Plugins.Utilities.Selenium;

using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.ElementsListener.json",
        Name = GravityPlugins.ElementsListener)]
    public class ElementsListener : WebDriverActionPlugin
    {
        // constants: arguments
        public const string Interval = "interval";
        public const string ListenerTimeout = "timeout";

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ElementsListener(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Listens to an element appearance in the DOM. Use this method to send and actions into an
        /// unexpected element. Sample, listen to a "Close" button of an unexpected pop-up banner which might block
        /// the user interface and send a "Click" action to it when found.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <remarks>Only works with action which overrides <see cref="ActionPlugin.OnPerform(IWebElement, ActionRule)"/>.</remarks>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        // execute action routine
        private void DoAction(ActionRule action)
        {
            // setup: values
            var arguments = CliFactory.Parse(action.Argument);
            var timoutValue = arguments.ContainsKey(ListenerTimeout)
                ? arguments[ListenerTimeout]
                : $"{Automation.EngineConfiguration.LoadTimeout}";
            var intervalValue = arguments.ContainsKey(Interval)
                ? arguments[Interval]
                : "500";

            // setup: parameters
            var timout = GetMilliseconds(timoutValue);
            var interval = GetMilliseconds(intervalValue);

            // setup: actions
            action.Actions = !action.Actions.Any()
                ? new[] { GetDefaultActionRule(action) }
                : action.Actions;
            action.Context[Rule.ExecuteSubActions] = false;

            // setup: listener data
            var dto = new ListenerDto
            {
                ActionRule = action,
                Executor = Executor,
                ListenerInterval = interval,
                Timeout = timout,
                Automation = Automation
            };

            // start listener
            Extensions.Listener(WebDriver, dto);
        }

        private static int GetMilliseconds(string argument)
        {
            // setup conditions
            var isArgument = int.TryParse(argument, out int argumentOut);

            // factory
            return isArgument ? argumentOut : (int)argument.ToTimeSpan().TotalMilliseconds;
        }

        private static ActionRule GetDefaultActionRule(ActionRule action) => new()
        {
            Action = GravityPlugins.Click,
            OnElement = action.OnElement,
            OnAttribute = action.OnAttribute,
            Locator = action.Locator,
            RegularExpression = action.RegularExpression
        };

        // contract to pass information into elements listener
        private class ListenerDto
        {
            /// <summary>
            /// <see cref="AutomationExecutor"/> instance to use for executing actions routine.
            /// </summary>
            public AutomationExecutor Executor { get; set; }

            /// <summary>
            /// This <see cref="ElementsListener"/> <see cref="Plugins.Contracts.ActionRule"/>
            /// </summary>
            public ActionRule ActionRule { get; set; }

            /// <summary>
            /// The interval time between each listener survey.
            /// </summary>
            public int ListenerInterval { get; set; }

            /// <summary>
            /// The timeout for the listener to expire.
            /// If not specified, <see cref="EngineConfiguration.SearchTimeout"/> will be used.
            /// </summary>
            public int Timeout { get; set; }

            /// <summary>
            /// Gets or sets the WebAutomation instance used by this <see cref="ListenerDto"/>.
            /// </summary>
            public WebAutomation Automation { get; set; }
        }

        // extensions for attaching child process onto this IWebDriver instance
        private static class Extensions
        {
            public static void Listener(IWebDriver d, ListenerDto dto) => Task.Run(() =>
            {
                var by = new ByFactory(Plugin.Types)
                    .Get(locator: dto.ActionRule.Locator, locatorValue: dto.ActionRule.OnElement);

                // execute listener
                var expire = 0;
                while (d != null && expire <= dto.Timeout)
                {
                    // get elements
                    var elements = GetElements(driver: d, by).Count;

                    // execute heartbeat
                    DoListenerHeartbeat(dto, elements);

                    // set expiration time
                    expire += dto.ListenerInterval;
                }
            });

            // get elements > silence all exceptions for heartbeat
            private static IReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, By by)
            {
                try
                {
                    return driver.FindElements(by);
                }
                catch (Exception e) when (e != null)
                {
                    return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
                }
            }

            // executes a single listener heartbeat
            private static void DoListenerHeartbeat(ListenerDto dto, int elements)
            {
                // execute
                try
                {
                    for (int i = 0; i < elements; i++)
                    {
                        foreach (var action in dto.ActionRule.Actions)
                        {
                            dto.Executor.Execute(automation: dto.Automation, action, parameters: null);
                        }
                    }
                }
                catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
                {
                    // ignore exceptions
                }
                finally
                {
                    Thread.Sleep(dto.ListenerInterval);
                }
            }
        }
    }
}