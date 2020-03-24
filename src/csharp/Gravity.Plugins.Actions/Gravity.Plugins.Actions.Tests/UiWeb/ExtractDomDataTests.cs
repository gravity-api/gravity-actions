using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ExtractDomDataTests : ActionTests
    {
        [TestMethod]
        public void ExtractDataCreate() => ValidateAction<ExtractFromDom>();

        [TestMethod]
        public void ExtractDataDocumentation()
            => ValidateActionDocumentation<ExtractFromDom>(WebPlugins.ExtractDomData);

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
            => ValidateActionDocumentation<ExtractFromDom>(WebPlugins.ExtractDomData, "extract_dom_data.json");
    }
}