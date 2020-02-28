/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Services.DataContracts;

namespace Gravity.Plugins.UnitTests.Mocks.Plugins
{
    public class GenericActionNoAttribute : GenericPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        public GenericActionNoAttribute(WebAutomation webAutomation)
            : this(webAutomation, new EnvironmentContext())
        { }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        /// <param name="environment">Environment under this context.</param>
        public GenericActionNoAttribute(WebAutomation webAutomation, EnvironmentContext environment)
            : base(webAutomation, environment)
        { }
        #endregion

        #region *** plugins      ***
        /// <summary>
        /// Override to implement action execution based on <see cref="Plugin"/> resources.
        /// </summary>
        public override void OnPerform()
        {
            Environment.SessionParams["OnPerform()"] = "completed";
        }

        /// <summary>
        /// Override to implement action execution based on <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            Environment.SessionParams["OnPerform(ActionRule)"] = "completed";
        }
        #endregion
    }
}