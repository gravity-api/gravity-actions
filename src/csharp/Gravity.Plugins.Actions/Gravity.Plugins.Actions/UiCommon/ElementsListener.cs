﻿/*
 * CHANGE LOG - keep only last 5 threads
 *
 * 2019-01-11
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-01-04
 *    - modify: change ERR constant to WRN
 *    
 * 2019-01-03
 *    - modify: improve XML comments
 *    - modify: change to JSON resource
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Base;
using OpenQA.Selenium;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using System.Linq;
using System.Threading;
using System;
using System.Threading.Tasks;
using Gravity.Plugins.Engine;
using Gravity.Plugins.Utilities.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.elements_listener.json",
        Name = CommonPlugins.ElementsListener)]
    public class ElementsListener : WebDriverActionPlugin
    {
        // constants: arguments
        public const string Interval = "interval";
        public const string ListenerTimeout = "timeout";

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        public ElementsListener(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Listens to an element appearance in the DOM. Use this method to send and actions into an
        /// unexpected element. Sample, listen to a "Close" button of an unexpected pop-up banner which might block
        /// the user interface and send a "Click" action to it when found.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <remarks>Only works with action which overrides <see cref="ActionPlugin.OnPerform(IWebElement, ActionRule)"/>.</remarks>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule)
        {
            // setup: values
            var arguments = CliFactory.Parse(actionRule.Argument);
            var timoutValue = arguments.ContainsKey(ListenerTimeout)
                ? arguments[ListenerTimeout]
                : $"{WebAutomation.EngineConfiguration.PageLoadTimeout}";
            var intervalValue = arguments.ContainsKey(Interval)
                ? arguments[Interval]
                : "500";

            // setup: parameters
            var timout = GetMilliseconds(timoutValue);
            var interval = GetMilliseconds(intervalValue);

            // setup: actions
            actionRule.Actions = !actionRule.Actions.Any()
                ? new[] { GetDefaultActionRule(actionRule) }
                : actionRule.Actions;
            Executor.ExecuteSubActions = false;

            // setup: listener data
            var dto = new ListenerDto
            {
                ActionRule = actionRule,
                Executor = Executor,
                Interval = interval,
                Timeout = timout
            };

            // start listener
            WebDriver.Listener(dto);
        }

        private int GetMilliseconds(string argument)
        {
            // setup conditions
            var isArgument = int.TryParse(argument, out int argumentOut);

            // factory
            return isArgument ? argumentOut : (int)argument.AsTimeSpan().TotalMilliseconds;
        }

        private ActionRule GetDefaultActionRule(ActionRule actionRule) => new ActionRule
        {
            ActionType = CommonPlugins.Click,
            ElementToActOn = actionRule.ElementToActOn,
            ElementAttributeToActOn = actionRule.ElementAttributeToActOn,
            Locator = actionRule.Locator,
            RegularExpression = actionRule.RegularExpression
        };
    }

    // contract to pass information into elements listener
    internal class ListenerDto
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
        public int Interval { get; set; }

        /// <summary>
        /// The timeout for the listener to expire.
        /// If not specified, <see cref="EngineConfiguration.ElementSearchingTimeout"/> will be used.
        /// </summary>
        public int Timeout { get; set; }
    }

    // extensions for attaching child process onto this IWebDriver instance
    internal static class Extensions
    {
        public static void Listener(this IWebDriver d, ListenerDto dto) => Task.Run(() =>
        {
            var by = new ByFactory(Plugin.Types)
                .Get(locator: dto.ActionRule.Locator, locatorValue: dto.ActionRule.ElementToActOn);

            // execute listener
            var expire = 0;
            while (d != null && expire <= dto.Timeout)
            {
                // get elements
                var elements = GetElements(driver: d, by).Count;

                // execute heartbeat
                DoListenerHeartbeat(dto, elements);

                // set expiration time
                expire += dto.Interval;
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
                        dto.Executor.Execute(action, parameters: null);
                    }
                }
            }
            catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
            {
                // ignore exceptions
            }
            finally
            {
                Thread.Sleep(dto.Interval);
            }
        }
    }
}