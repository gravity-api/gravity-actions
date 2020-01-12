/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class ElementsListenerTests : ActionTests
    {
        [TestMethod]
        public void ElementsListenerCreateNoTypes()
        {
            ValidateAction<ElementsListener>();
        }

        [TestMethod]
        public void ElementsListenerCreateTypes()
        {
            ValidateAction<ElementsListener>(Types);
        }

        [TestMethod]
        public void ElementsListenerDocumentationNoTypes()
        {
            ValidateActionDocumentation<ElementsListener>("ElementsListener");
        }

        [TestMethod]
        public void ElementsListenerDocumentationTypes()
        {
            ValidateActionDocumentation<ElementsListener>("ElementsListener", Types);
        }

        [TestMethod]
        public void ElementsListenerDocumentationResourceFile()
        {
            ValidateActionDocumentation<ElementsListener>(
                "ElementsListener", Types, "elements-listener.json");
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
    }
}
#pragma warning restore S4144