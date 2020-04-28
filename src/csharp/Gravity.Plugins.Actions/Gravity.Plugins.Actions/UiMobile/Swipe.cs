/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 * 
 * work items
 * https://github.com/gravity-api/gravity-actions/issues/19
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.UiMobile
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.swipe.json",
        Name = MobilePlugins.Swipe)]
    public class Swipe : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// The source [x,y] coordinates or element locator value to swipe from.
        /// </summary>
        public const string Source = "source";

        /// <summary>
        /// The target [x,y] coordinates or element locator value to swipe to.
        /// </summary>
        public const string Target = "target";
        #endregion

        // members: state
        private TouchAction actions;
        private IDictionary<string, string> arguments;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Swipe(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Swipes the screen by a given coordinates or elements.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Swipes the screen by a given coordinates or elements.
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
            // exit conditions
            if (!(WebDriver is IPerformsTouchActions))
            {
                return;
            }

            // set action
            actions = new TouchAction((IPerformsTouchActions)WebDriver);

            // setup
            LoadArguments(action);
            var sCoordinates = TryGetCoordinates(arguments[Source]);
            var tCoordinates = TryGetCoordinates(arguments[Target]);

            // get objects
            var source = GetArgument(element, action, arguments[Source], sCoordinates);
            var target = GetArgument(element, action, arguments[Target], tCoordinates);

            // execute
            DoSource(source);
            DoTarget(target);
            actions.Perform();
        }

        // loads source & target arguments (set defaults and normalize)
        private void LoadArguments(ActionRule action)
        {
            // get arguments
            arguments = CliFactory.Parse(action.Argument);

            // setup conditions
            var isSource = arguments.ContainsKey(Source);
            var isTarget = arguments.ContainsKey(Target);
            var isElement = !string.IsNullOrEmpty(action.OnElement);

            // arguments factory
            if (isSource && isTarget && isElement)
            {
                return;
            }
            if (isSource && isTarget && !isElement)
            {
                return;
            }
            if (!isSource && isTarget && isElement)
            {
                arguments[Source] = action.OnElement;
            }
            if (isSource && !isTarget && isElement)
            {
                arguments[Target] = action.OnElement;
            }
            if (isSource && !isTarget && !isElement)
            {
                arguments[Target] = "0,0";
            }
            if (!isSource && isTarget && !isElement)
            {
                arguments[Source] = "0,0";
            }
            if (!isSource && !isTarget && isElement)
            {
                arguments[Source] = action.OnElement;
                arguments[Target] = action.OnElement;
            }
            if (!isSource && !isTarget && !isElement)
            {
                arguments[Source] = "0,0";
                arguments[Target] = "0,0";
            }
        }

        // gets a source or target object for actions chain
        private object GetArgument(IWebElement element, ActionRule action, string onElement, double[] coordinates)
        {
            // coordinates argument
            if (coordinates.Length == 2)
            {
                return coordinates;
            }
            // set timeout & locator
            var timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.ElementSearchingTimeout);
            var by = ByFactory.Get(action.Locator, locatorValue: onElement);

            // get element argument
            return element != default ? element.FindElement(by) : WebDriver.GetElement(by, timeout);
        }

        // executes source actions
        private void DoSource(object source)
        {
            // web element
            if (source is IWebElement element)
            {
                actions.Press(element);
                return;
            }

            // coordinates
            var coordinates = source as double[];
            actions.Press(coordinates[0], coordinates[1]);
        }

        // executes target actions
        private void DoTarget(object target)
        {
            // web element
            if (target is IWebElement element)
            {
                actions.MoveTo(element);
                return;
            }

            // coordinates
            var coordinates = target as double[];
            actions.MoveTo(coordinates[0], coordinates[1]);
        }

        // UTILITIES
        // check if arguments value is coordinates
        private double[] TryGetCoordinates(string argument)
        {
            // constants
            const string Message = "No coordinates were found. Attempt to swipe by element(s).";

            // compliance
            var factors = argument.Split(',');
            var isDoubleFactor = factors.Length == 2;

            // exit conditions
            if (!isDoubleFactor)
            {
                Logger.LogInformation(Message, argument);
                return Array.Empty<double>();
            }

            // compliance
            double.TryParse(factors[0], out double xOut);
            double.TryParse(factors[1], out double yOut);

            // result
            return new[] { xOut, yOut };
        }
    }
}