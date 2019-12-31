/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Common;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Services.ActionPlugins.Tests.Common
{
    [TestClass]
    public class SendKeysTest : ActionTests
    {
        [TestMethod]
        public void SendKeysCreateNoTypes()
        {
            ValidateAction<SendKeys>();
        }

        [TestMethod]
        public void SendKeysCreateTypes()
        {
            ValidateAction<SendKeys>(Types);
        }

        [TestMethod]
        public void SendKeysDocumentationNoTypes()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS);
        }

        [TestMethod]
        public void SendKeysDocumentationTypes()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS, Types);
        }

        [TestMethod]
        public void SendKeysDocumentationResourceFile()
        {
            ValidateActionDocumentation<SendKeys>(ActionType.SEND_KEYS, Types, "send-keys.json");
        }
    }
}