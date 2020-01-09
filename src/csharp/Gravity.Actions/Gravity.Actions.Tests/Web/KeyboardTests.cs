/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.ActionPlugins.Web;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Web
{
    [TestClass]
    public class KeyboardTests : ActionTests
    {
        [TestMethod]
        public void KeyboardCreateNoTypes()
        {
            ValidateAction<Keyboard>();
        }

        [TestMethod]
        public void KeyboardCreateTypes()
        {
            ValidateAction<Keyboard>(Types);
        }

        [TestMethod]
        public void KeyboardDocumentationNoTypes()
        {
            ValidateActionDocumentation<Keyboard>(ActionType.Keyboard);
        }

        [TestMethod]
        public void KeyboardDocumentationTypes()
        {
            ValidateActionDocumentation<Keyboard>(ActionType.Keyboard, Types);
        }

        [TestMethod]
        public void KeyboardDocumentationResourceFile()
        {
            ValidateActionDocumentation<Keyboard>(
                ActionType.Keyboard, Types, "Keyboard.json");
        }
    }
}
#pragma warning restore S4144