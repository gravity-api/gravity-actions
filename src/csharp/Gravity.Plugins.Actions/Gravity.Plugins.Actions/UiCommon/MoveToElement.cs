/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using OpenQA.Selenium;

using System;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.move_to_element.json",
        Name = Contracts.PluginsList.MoveToElement)]
    public class MoveToElement : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public MoveToElement(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Moves the mouse to the specified element. This action will trigger [mouseover] event.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Moves the mouse to the specified element. This action will trigger [mouseover] event.
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
            // constants
            const string fallbackScript =
                "var rect = arguments[0].getBoundingClientRect(); " +
                "window.scroll(rect.left, rect.top);";

            // get element
            var onElement = this.ConditionalGetElement(element, action);

            // get actions
            var actions = new OpenQA.Selenium.Interactions.Actions(WebDriver);

            // move to element
            try
            {
                actions.MoveToElement(onElement).Build().Perform();
            }
            catch (Exception e) when (e is WebDriverException)
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript(script: fallbackScript, args: element);
            }
        }
    }
}