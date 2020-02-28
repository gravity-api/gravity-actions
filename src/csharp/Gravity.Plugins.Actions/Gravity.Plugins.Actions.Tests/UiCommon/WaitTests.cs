/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class WaitTests : ActionTests
    {
        public WaitTests()
        {
            WebDriver = null;
        }

        public TestContext Context { get; set; }

        [TestMethod]
        public void WaitCreate()
        {
            ValidateAction<Wait>();
        }

        [TestMethod]
        public void WaitDocumentation()
        {
            ValidateActionDocumentation<Wait>(CommonPlugins.Wait);
        }

        [TestMethod]
        public void WaitDocumentationResourceFile()
        {
            ValidateActionDocumentation<Wait>(CommonPlugins.Wait, "Wait.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'1000'}")]
        public void WaitMilliseconds(string actionRule)
        {
            // execute 
            ExecuteAction<Wait>(actionRule);

            // assertion
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