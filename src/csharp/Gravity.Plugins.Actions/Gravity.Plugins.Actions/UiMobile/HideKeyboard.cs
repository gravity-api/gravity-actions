/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;

namespace Gravity.Plugins.Actions.UiMobile
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.HideKeyboard.json",
        Name = GravityPlugins.HideKeyboard)]
    public class HideKeyboard : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public HideKeyboard(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction();
        }

        /// <summary>
        /// Hide soft keyboard.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction();
        }

        // execute action routine
        private void DoAction()
        {
            if (!(WebDriver is IHidesKeyboard))
            {
                return;
            }
            ((IHidesKeyboard)WebDriver).HideKeyboard();
        }
    }
}