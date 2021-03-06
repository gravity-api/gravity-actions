﻿/*
 * CHANGE LOG
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
 * 
 * work items
 * TODO: change name to be ActionType constant when available
 */
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Gravity.Services.ActionPlugins.Web
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.elements-listener.json",
        Name = "ElementsListener")]
    public class ElementsListener : ActionPlugin
    {
        // constants: arguments
        public const string Interval = "interval";
        public const string ListenerTimout = "timeout";
        public const string ActionToPerform = "action";
        public const string Arguments = "args";

        // members: state
        private IDictionary<string, string> arguments;
        private string childActionArgument;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public ElementsListener(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public ElementsListener(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        {
            ActionFactory ??= GravityUtilities.GetActionFactory(webDriver, webAutomation, types);
        }

        /// <summary>
        /// Listens to an element appearance in the DOM. Use this method to send and action into an 
        /// unexpected element. Sample, listen to a "Close" button of an unexpected pop-up banner which might block
        /// the user interface and send a "Click" action to it when found.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        /// <remarks>Only works with action which overrides <see cref="ActionPlugin.OnPerform(IWebElement, ActionRule)"/>.</remarks>
        public override void OnPerform(ActionRule actionRule)
        {
            DoListener(actionRule);
        }

        // executes a child process with elements listener
        private void DoListener(ActionRule actionRule)
        {
            // get arguments
            ProcessArguments(actionRule.Argument);

            // setup
            var interval = (int)GetTimeSapnFromArgument(Interval).TotalMilliseconds;
            var expiration = (int)GetTimeSapnFromArgument(ListenerTimout).TotalMilliseconds;
            var by = ByFactory.Get(actionRule.Locator, actionRule.ElementToActOn);

            // publish action rule to execute on the found elements
            var childActionRule = new ActionRule
            {
                ActionType = arguments[ActionToPerform],
                Argument = childActionArgument,
                Actions = actionRule.Actions
            };

            // execute listener
            var expire = 0;
            while (WebDriver != null && expire <= expiration)
            {
                // execute heartbeat
                DoListenerHeartbeat(childActionRule, by, interval);

                // set expiration time
                expire += interval;
            }
        }

        // executes a single listener heartbeat
        private void DoListenerHeartbeat(ActionRule actionRule, By by, int interval)
        {
            try
            {
                // find all the elements match the locator send action to them
                var elements = WebDriver?.FindElements(by);
                if (elements?.Count > 0)
                {
                    foreach (var element in elements)
                    {
                        ActionFactory.Execute(actionRule, element);
                    }
                }
            }
            catch (Exception e) when (e is NoSuchElementException || e is StaleElementReferenceException)
            {
                Logger.LogDebug("No elements found, ElementsListener is still running.");
            }
            finally
            {
                Thread.Sleep(interval);
            }
        }

        // process arguments integration for this action
        private void ProcessArguments(string cli)
        {
            // parse arguments
            arguments = new CliFactory(cli).Parse();

            // set defaults: interval
            arguments[Interval] = !arguments.ContainsKey(Interval)
                ? $"{ElementSearchTimeout}"
                : arguments[Interval];

            // set defaults: action
            if (!arguments.ContainsKey(ActionToPerform))
            {
                arguments[ActionToPerform] = "Click";
            }

            // set defaults: action
            arguments[ListenerTimout] = !arguments.ContainsKey(ListenerTimout)
                ? $"{PageLoadTimeout}"
                : arguments[ListenerTimout];

            // set defaults: arguments
            if (!arguments.ContainsKey(Arguments))
            {
                arguments[Arguments] = string.Empty;
            }
            childActionArgument = GetChildActionArguments();
        }

        // parse interval value
        private TimeSpan GetTimeSapnFromArgument(string argument)
        {
            var interval = TimeSpan.FromMilliseconds(0);
            if (uint.TryParse(arguments[argument], out uint intOut))
            {
                return TimeSpan.FromMilliseconds(intOut);
            }
            else if (TimeSpan.TryParse(arguments[argument], out TimeSpan timeSpanOut))
            {
                return timeSpanOut;
            }
            return interval;
        }

        // gets the argument CLI for the child action of this listener
        private string GetChildActionArguments()
        {
            // default
            if (arguments[Arguments].IsJson())
            {
                return arguments[Arguments];
            }

            // complex arguments
            var args = JsonConvert.DeserializeObject<Dictionary<string, string>>(arguments[Arguments]);
            const string command = "{{$ [arguments]}}";
            if (args == null)
            {
                return string.Empty;
            }
            var argumentsChain = string.Join(" ", args.Select(i => $"--{i.Key}:{i.Value}"));
            return command.Replace("[arguments]", argumentsChain);
        }
    }
}