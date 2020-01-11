/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
#pragma warning restore S4144