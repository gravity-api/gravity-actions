/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class WaitTests : ActionTests
    {
        #region *** tests: constructors  ***
        public WaitTests()
        {
            WebDriver = null;
        }
        #endregion

        #region *** tests: properties    ***
        public TestContext Context { get; set; }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void WaitCreate()
        {
            AssertPlugin<Wait>();
        }

        [TestMethod]
        public void WaitDocumentation()
        {
            AssertDocumentation<Wait>(pluginName: PluginsList.Wait);
        }

        [TestMethod]
        public void WaitDocumentationResourceFile()
        {
            AssertDocumentation<Wait>(
                pluginName: PluginsList.Wait,
                resource: "Wait.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
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

            // assertion (no assertion here)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds > 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'NotTime'}")]
        public void WaitInvalid(string actionRule)
        {
            // execute 
            ExecuteAction<Wait>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(Stopwatch.Elapsed.TotalMilliseconds < 1000);
        }
        #endregion
    }
}
#pragma warning restore S4144