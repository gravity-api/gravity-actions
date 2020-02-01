/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Common;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Common
{
    [TestClass]
    public class WaitTests : ActionTests
    {
        public TestContext Context { get; set; }

        [TestMethod]
        public void WaitCreateNoTypes()
        {
            ValidateAction<Wait>();
        }

        [TestMethod]
        public void WaitCreateTypes()
        {
            ValidateAction<Wait>(Types);
        }

        [TestMethod]
        public void WaitDocumentationNoTypes()
        {
            ValidateActionDocumentation<Wait>(ActionType.Wait);
        }

        [TestMethod]
        public void WaitDocumentationTypes()
        {
            ValidateActionDocumentation<Wait>(ActionType.Wait, Types);
        }

        [TestMethod]
        public void WaitDocumentationResourceFile()
        {
            ValidateActionDocumentation<Wait>(ActionType.Wait, Types, "Wait.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'1000'}")]
        public void WaitMilliseconds(string actionRule)
        {
            // execute 
            ExecuteAction<Wait>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'00:00:01'}")]
        public void WaitTimespan(string actionRule)
        {
            // execute 
            ExecuteAction<Wait>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NotTime'}")]
        public void WaitInvalid(string actionRule)
        {
            // execute 
            ExecuteAction<Wait>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }
    }
}
#pragma warning restore S4144