/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.switch-to-frame.json",
        Name = WebPlugins.SwitchToFrame)]
    public class SwitchToFrame: WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SwitchToFrame(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Select a frame, changing web-driver context to the new selected frame.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule, element: default);
        }

        /// <summary>
        /// Select a frame, changing web-driver context to the new selected frame.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule, element);
        }

        // execute action routine
        private void DoAction(ActionRule actionRule, IWebElement element)
        {
            // setup compliance
            var isNumric = int.TryParse(actionRule.Argument, out int argumentOut);
            var isElement = !string.IsNullOrEmpty(actionRule.ElementToActOn);

            // from element
            if (isElement)
            {
                SwitchFromElement(actionRule, element);
                return;
            }

            // from index
            if (isNumric)
            {
                WebDriver.SwitchTo().Frame(argumentOut);
                return;
            }

            // from name
            WebDriver.SwitchTo().Frame(actionRule.Argument);
        }

        // switch to frame based on element
        private void SwitchFromElement(ActionRule actionRule, IWebElement element)
        {
            // execute action
            var onElement = this.ConditionalGetElement(element, actionRule);

            // switch
            WebDriver.SwitchTo().Frame(onElement);
        }
    }
}
