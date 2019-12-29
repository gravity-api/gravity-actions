using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class RepeatTests : ActionTests
    {
        [TestMethod]
        public void T()
        {
            var ar = new ActionRule
            {
                ActionType = ActionType.REPEAT,
                Argument = "3",
                Actions = new[]
                {
                    new ActionRule { ActionType = ActionType.CLICK, ElementToActOn = "//positive" },
                    new ActionRule { ActionType = ActionType.EXECUTE_SCRIPT, Argument = "" }
                }
            };
            var json = JsonConvert.SerializeObject(ar);
            ExecuteAction<Repeat>(json);

            Assert.IsTrue(true);
        }
    }
}
