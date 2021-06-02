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
using OpenQA.Selenium.Extensions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.SubmitForm.json",
        Name = GravityPlugins.SubmitForm)]
    public class SubmitForm : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SubmitForm(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action, element: default);
        }

        /// <summary>
        /// Clicks the mouse on the specified element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action, element);
        }

        // execute action routine
        private void InvokeAction(ActionRule action, IWebElement element)
        {
            // setup
            var _element = this.ConditionalGetElement(action, element);

            // setup conditions
            var isNumeric = int.TryParse(action.Argument, out int indexOut);
            var isElement = _element != default;

            // submit by element
            if (isElement)
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].submit();", _element);
                return;
            }

            // submit by index
            if (isNumeric)
            {
                WebDriver.SubmitForm(indexOut);
                return;
            }

            // submit by form id
            WebDriver.SubmitForm(action.Argument);
        }
    }
}