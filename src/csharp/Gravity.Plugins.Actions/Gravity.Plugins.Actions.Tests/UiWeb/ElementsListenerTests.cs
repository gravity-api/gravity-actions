/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Actions.UiWeb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ElementsListenerTests : ActionTests
    {
        [TestMethod]
        public void ElementsListenerCreate()
        {
            ValidateAction<ElementsListener>();
        }

        [TestMethod]
        public void ElementsListenerDocumentation()
        {
            ValidateActionDocumentation<ElementsListener>(WebPlugins.ElementsListener);
        }

        [TestMethod]
        public void ElementsListenerDocumentationResourceFile()
        {
            ValidateActionDocumentation<ElementsListener>(
                WebPlugins.ElementsListener, "elements_listener.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','elementToActOn':'//positive'}")]
        public void ElementsListenerClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','elementToActOn':'//null'}")]
        public void ElementsListenerClickNull(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','ElementToActOn':'//stale'}")]
        public void ElementsListenerClickStale(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','elementToActOn':'//none'}")]
        public void ElementsListenerClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --interval:500 --timeout:30000}}','elementToActOn':'//negative'}")]
        public void ElementsListenerClickNegative(string actionRule)
        {
            // execute
            var plugin = ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'ElementToActOn':'//positive'}")]
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
            "    'elementToActOn':'//positive'," +
            "    'actions': [" +
            "        {" +
            "            'actionType':'SendKeys'," +
            "            'argument':'foo bar'," +
            "            'elementToActOn':'//positive'" +
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