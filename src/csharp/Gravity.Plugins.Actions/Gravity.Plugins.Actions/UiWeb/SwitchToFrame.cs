/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.SwitchToFrame.json",
        Name = PluginsList.SwitchToFrame)]
    public class SwitchToFrame : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SwitchToFrame(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Select a frame, changing web-driver context to the new selected frame.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Select a frame, changing web-driver context to the new selected frame.
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
            // setup compliance
            var isNumric = int.TryParse(action.Argument, out int argumentOut);
            var isElement = !string.IsNullOrEmpty(action.OnElement);

            // from element
            if (isElement)
            {
                SwitchFromElement(action, element);
                return;
            }

            // from index
            if (isNumric)
            {
                WebDriver.SwitchTo().Frame(argumentOut);
                return;
            }

            // from name
            WebDriver.SwitchTo().Frame(action.Argument);
        }

        // switch to frame based on element
        private void SwitchFromElement(ActionRule action, IWebElement element)
        {
            // execute action
            var onElement = this.ConditionalGetElement(element, action);

            // switch
            WebDriver.SwitchTo().Frame(onElement);
        }
    }
}