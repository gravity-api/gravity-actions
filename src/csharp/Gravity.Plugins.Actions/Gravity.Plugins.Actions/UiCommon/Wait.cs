/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-13
 *    - modify: add on-element event (action can now be executed on the element without searching for a child)
 *    - modify: use FindByActionRule/GetByActionRule methods to reduce code base and increase code usage
 * 
 * 2019-12-31
 *    - modify: add constructor to override base class types
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override ActionName using action constant
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using System.Threading;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.Wait.json",
        Name = GravityPlugin.Wait)]
    public class Wait : GenericPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation">WebAutomation data transfer object to execute.</param>
        public Wait(WebAutomation automation)
            : this(automation, new EnvironmentContext())
        { }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation">WebAutomation data transfer object to execute.</param>
        /// <param name="environment">Environment under this context.</param>
        public Wait(WebAutomation automation, EnvironmentContext environment)
            : base(automation, environment)
        { }
        #endregion

        /// <summary>
        /// Suspends the current thread for the specified amount of time.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        // executes Wait routine
        private static void DoAction(ActionRule action)
        {
            // setup
            var timeToWait = action.Argument.ToTimeSpan();

            // action
            Thread.Sleep(timeToWait);
        }
    }
}