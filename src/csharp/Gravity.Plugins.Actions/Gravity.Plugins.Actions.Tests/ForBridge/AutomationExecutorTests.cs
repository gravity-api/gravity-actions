using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            Assert.IsTrue(actual.ExtractionResults.Count() == 7);
        }
    }
}