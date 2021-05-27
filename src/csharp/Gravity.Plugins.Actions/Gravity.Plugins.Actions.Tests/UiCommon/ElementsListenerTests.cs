/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gravity.Plugins.Actions.UiCommon;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    public class ElementsListenerTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void ElementsListenerCreate()
        {
            AssertPlugin<ElementsListener>();
        }

        [TestMethod]
        public void ElementsListenerDocumentation()
        {
            AssertDocumentation<ElementsListener>(
                pluginName: GravityPlugins.ElementsListener);
        }

        [TestMethod]
        public void ElementsListenerDocumentationResourceFile()
        {
            AssertDocumentation<ElementsListener>(
                pluginName: GravityPlugins.ElementsListener,
                resource: "ElementsListener.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --interval:500 --timeout:30000}}\",\"onElement\":\"//positive\"}")]
        public void ElementsListenerClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"argument\":\"{{$ --interval:500 --timeout:30000}}\",\"onElement\":\"//null\"}")]
        [DataRow("{\"argument\":\"{{$ --interval:500 --timeout:30000}}\",\"onElement\":\"//stale\"}")]
        [DataRow("{\"argument\":\"{{$ --interval:500 --timeout:30000}}\",\"onElement\":\"//none\"}")]
        [DataRow("{\"argument\":\"{{$ --interval:500 --timeout:30000}}\",\"onElement\":\"//negative\"}")]
        public void ElementsListenerClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"onElement\":\"//positive\"}")]
        public void ElementsListenerClickNoArguments(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"argument\":\"{{$ --interval:500 --timeout:30000}}\"," +
            "    \"onElement\":\"//positive\"," +
            "    \"actions\": [" +
            "        {" +
            "            \"action\":\"SendKeys\"," +
            "            \"argument\":\"foo bar\"," +
            "            \"onElement\":\"//positive\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ElementsListenerSendKeysPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144