using Gravity.Plugins.Engine;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Plugins.UnitTests.Engine
{
    [TestClass]
    public class AutomationExecutorTests
    {
        [TestMethod]
        public void A()
        {
            var automation = new WebAutomation
            {
                Actions = new[]
                {
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" },
                    new ActionRule { ActionType = "GenericAction" }
                }
            };

            var actual = new AutomationExecutor(automation).Execute();
            Assert.IsTrue(actual.Extractions.Length == 7);
        }
    }
}