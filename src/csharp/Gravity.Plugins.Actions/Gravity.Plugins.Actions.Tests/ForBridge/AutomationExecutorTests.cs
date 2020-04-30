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
            var automation = new WebAutomation();

            var actions = new[]
            {
                new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                {
                    new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                    {
                        new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                        {
                            new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                            {
                                new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                                {
                                    new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", Actions = new[]
                                    {
                                        new ActionRule { ActionType = "GenericAction", Argument="{{Prop}}_{{Number}}", }
                                    } }
                                } }
                            } }
                        } }
                    } }
                } }
            };

            //var dataSource = new DataSource
            //{
            //    Type = "JSON",
            //    Source = JsonConvert.SerializeObject(new[]
            //    {
            //        new { Prop = "Prop1", Number = 1 },
            //        new { Prop = "Prop2", Number = 2 }
            //    })
            //};
            //automation.DataSource = dataSource;
            automation.Actions = actions;
            automation.EngineConfiguration.MaxParallelExecution = 5;

            var actual = new AutomationExecutor(automation).Execute();
            Assert.IsTrue(actual.All(i => i.Value.Extractions.Count() == 7));
        }
    }
}