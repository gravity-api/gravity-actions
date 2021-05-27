/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 *    
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;

using System.Collections.Generic;
using System.Linq;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Keyboard.json",
        Name = GravityPlugins.Keyboard)]
    public class Keyboard : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public Keyboard(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Press a keyboard key on the provided element.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Press a keyboard key on the provided element.
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
            // on element action
            var onElement = this.ConditionalGetElement(element, action);

            // get keys sequence
            var keyes = new List<string>();
            foreach (var key in action.Argument.Split(',').Select(i => i.Trim()))
            {
                var k = GetKeyboardKey(key);
                if (string.IsNullOrEmpty(k))
                {
                    keyes.Add(key);
                    continue;
                }
                keyes.Add(k);
            }

            // execute action
            onElement.SendKeys(string.Concat(keyes));
        }
    }
}