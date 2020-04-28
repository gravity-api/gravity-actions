/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gravity.Plugins.Actions.UiCommon;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class ElementsListenerTests : ActionTests
    {
        [TestMethod]
        public void ElementsListenerCreate()
        {
            AssertPlugin<ElementsListener>();
        }

        [TestMethod]
        public void ElementsListenerDocumentation()
        {
            AssertDocumentation<ElementsListener>(CommonPlugins.ElementsListener);
        }

        [TestMethod]
        public void ElementsListenerDocumentationResourceFile()
        {
            AssertDocumentation<ElementsListener>(
                CommonPlugins.ElementsListener, "elements_listener.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','onElement':'//positive'}")]
        public void ElementsListenerClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','onElement':'//null'}")]
        public void ElementsListenerClickNull(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','onElement':'//stale'}")]
        public void ElementsListenerClickStale(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','onElement':'//none'}")]
        public void ElementsListenerClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','onElement':'//negative'}")]
        public void ElementsListenerClickNegative(string actionRule)
        {
            // execute
            var plugin = ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        public void ElementsListenerClickNoArguments(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'argument':'{{$ --interval:500 --timeout:30000}}'," +
            "    'onElement':'//positive'," +
            "    'actions': [" +
            "        {" +
            "            'actionType':'SendKeys'," +
            "            'argument':'foo bar'," +
            "            'onElement':'//positive'" +
            "        }" +
            "    ]" +
            "}")]
        public void ElementsListenerSendKeysPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144