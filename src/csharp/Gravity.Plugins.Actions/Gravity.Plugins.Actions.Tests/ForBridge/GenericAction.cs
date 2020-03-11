/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using System.Collections.Generic;

namespace Gravity.Plugins.UnitTests.Mocks.Plugins
{
    [Plugin]
    public class GenericAction : GenericPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        public GenericAction(WebAutomation webAutomation)
            : this(webAutomation, new EnvironmentContext())
        { }

        /// <summary>
        /// Creates a new instance of this <see cref="Plugin"/>.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        /// <param name="environment">Environment under this context.</param>
        public GenericAction(WebAutomation webAutomation, EnvironmentContext environment)
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
            ExtractionResults.Add(Get("OnPerform()", "completed"));
        }

        /// <summary>
        /// Override to implement action execution based on <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            Environment.SessionParams["OnPerform(ActionRule)"] = "completed";
            ExtractionResults.Add(Get("OnPerform(ActionRule)", "completed"));
        }

        private Extraction Get(string key, string value)
        {
            return new Extraction
            {
                Entities = new[]
                {
                    new Entity
                    {
                        EntityContent = new Dictionary<string, object>
                        {
                            [key] = value
                        }
                    }
                }
            };
        }
        #endregion
    }
}