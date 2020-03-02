﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 * https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll
 * https://developer.mozilla.org/en-US/docs/Web/API/Element/scroll
 * https://developer.mozilla.org/en-US/docs/Web/API/ScrollToOptions/behavior
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.scroll.json",
        Name = WebPlugins.Scroll)]
    public class Scroll : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// The pixel along the horizontal axis of the document/element that you want displayed in the upper left.
        /// </summary>
        public const string Left = "left";

        /// <summary>
        /// The pixel along the vertical axis of the document/element that you want displayed in the upper left.
        /// </summary>
        public const string Top = "top";

        /// <summary>
        /// Specifies whether the scrolling should animate smoothly, or happen instantly in a single jump.
        /// Available values: [smooth, auto].
        /// </summary>
        public const string Behavior = "behavior";
        #endregion

        // members: state
        private readonly string left = "0";
        private readonly string top = "0";
        private readonly string behavior = "auto";

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Scroll(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Scrolls the window to a particular place in the document.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Scrolls the element to a particular set of coordinates inside a given element.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // executes Refresh routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup
            var arguments = GetArguments(actionRule);
            var scriptFormat =
                $"on.scroll({{top: {arguments[Top]}, left: {arguments[Left]}, behavior: {arguments[Behavior]}}})";

            element = this.ConditionalGetElement(element, actionRule);
            var script = element == default
                ? scriptFormat.Replace("on", "window")
                : scriptFormat.Replace("on", "arguments[0]");

            // execute action
            if(element == default)
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript(script);
            }
            else
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript(script, element);
            }
        }

        private IDictionary<string, string> GetArguments(ActionRule actionRule)
        {
            // default
            if (int.TryParse(actionRule.Argument, out int yOut))
            {
                return new Dictionary<string, string>
                {
                    [Top] = $"{yOut}",
                    [Left] = left,
                    [Behavior] = behavior
                };
            }

            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);

            // X
            if (!arguments.ContainsKey(Left))
            {
                arguments[Left] = left;
            }
            // Y
            if (!arguments.ContainsKey(Top))
            {
                arguments[Top] = top;
            }
            // Behavior
            if (!arguments.ContainsKey(Behavior))
            {
                arguments[Behavior] = behavior;
            }

            // result
            return arguments;
        }
    }
}