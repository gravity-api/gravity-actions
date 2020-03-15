/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ExtractDataTests : ActionTests
    {
        [TestMethod]
        public void ExtractDataCreate() => ValidateAction<ExtractData>();

        [TestMethod]
        public void ExtractDataDocumentation()
            => ValidateActionDocumentation<ExtractData>(WebPlugins.ExtractData);

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
            => ValidateActionDocumentation<ExtractData>(WebPlugins.ExtractData, "extract_data.json");

        [TestMethod]
        public void ExtractFromSource()
        {
            // setup
            var extraction = new ExtractionRule
            {
                PageSource = true,
                RootElementToExtractFrom = "//positive",
                ElementsToExtract = new[]
                {
                    new ContentEntry { Key = "data" }
                }
            };
            WebAutomation.Extractions = new[] { extraction };

            // execute
            var plugin = ExecuteAction<ExtractData>();
            var a = "";
        }
    }
}
