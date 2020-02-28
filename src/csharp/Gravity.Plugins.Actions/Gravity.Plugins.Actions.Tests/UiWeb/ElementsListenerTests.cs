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
                WebPlugins.ElementsListener, "elements-listener.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --action:Click}}','ElementToActOn':'//positive'}")]
        public void ElementsListenerClickPositive(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --action:Click}}','ElementToActOn':'//null'}")]
        public void ElementsListenerClickNull(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --action:Click}}','ElementToActOn':'//stale'}")]
        public void ElementsListenerClickStale(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --action:Click}}','ElementToActOn':'//none'}")]
        public void ElementsListenerClickNoElement(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --action:Click}}','ElementToActOn':'//negative'}")]
        public void ElementsListenerClickNoNegative(string actionRule)
        {
            // execute
            ExecuteAction<ElementsListener>(actionRule);

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
        [DataRow("{'argument':'{{$ --action:SendKeys --args:{\"keys\":\"automation\"}}}','ElementToActOn':'//positive'}")]
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