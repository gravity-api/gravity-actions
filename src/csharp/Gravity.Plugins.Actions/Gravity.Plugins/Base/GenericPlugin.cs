/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-02-03
 *    - modify: refactoring
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using System;

namespace Gravity.Plugins.Base
{
    public abstract class GenericPlugin : Plugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        protected GenericPlugin(WebAutomation automation)
            : this(automation, new EnvironmentContext())
        { }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="automation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        /// <param name="environment">Environment under this context.</param>
        protected GenericPlugin(WebAutomation automation, EnvironmentContext environment)
            : base(automation, environment)
        { }
        #endregion

        #region *** plugins      ***
        /// <summary>
        /// Override to implement action execution based on <see cref="Plugin"/> resources.
        /// </summary>
        public virtual void OnPerform()
        {
            Console.WriteLine(
                $"Invoke-Plugin -Name {GetType().Name} = NotImplemented");
        }

        /// <summary>
        /// Override to implement action execution based on <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public virtual void OnPerform(ActionRule action)
        {
            Console.WriteLine(
                $"Invoke-Plugin -Name {GetType().Name} -Action {action.Action} = NotImplemented");
        }

        /// <summary>
        /// Performs an action based on <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public void Perform(ActionRule action)
        {
            // trace log
            Console.WriteLine("Invoke-Plugin -Name {0} = Start", GetType().Name);

            // execute sequence
            if (action == default)
            {
                OnPerform();
            }
            else
            {
                OnPerform(action);
            }

            // information log
            Console.WriteLine("Invoke-Plugin -Name {0} = Ok", GetType().Name);
        }
        #endregion
    }
}
