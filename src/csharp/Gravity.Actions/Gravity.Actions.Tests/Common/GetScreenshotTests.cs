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
    public class GetScreenshotTests : ActionTests
    {
        [TestMethod]
        public void GetScreenshotCreateNoTypes()
        {
            ValidateAction<GetScreenshot>();
        }

        [TestMethod]
        public void GetScreenshotCreateTypes()
        {
            ValidateAction<GetScreenshot>(Types);
        }

        [TestMethod]
        public void GetScreenshotDocumentationNoTypes()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot);
        }

        [TestMethod]
        public void GetScreenshotDocumentationTypes()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot, Types);
        }

        [TestMethod]
        public void GetScreenshotDocumentationResourceFile()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot, Types, "get-screenshot.json");
        }
    }
}
