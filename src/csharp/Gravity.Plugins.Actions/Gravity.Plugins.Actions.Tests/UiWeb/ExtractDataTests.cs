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
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ExtractDataTests : ActionTests
    {
        // members state
        private const string PageSource =
            "<html>" +
            "    <head>" +
            "        <title>mock page source title</title>" +
            "    </head>" +
            "    <body class=\"mockClass\">" +
            "        <p id=\"pageLevel1\">mock, page level paragraph, inner text</p>" +
            "        <div id=\"mockDiv1\">mock div text" +
            "            <span id=\"childDiv11\">child div 1 inner text</span>" +
            "            <span id=\"childDiv12\">child div 2 inner text</span>" +
            "            <span id=\"childDiv13\">child div 3 inner text</span>" +
            "        </div>" +
            "        <div id=\"mockDiv2\">mock div text" +
            "            <span id=\"childDiv21\">child div 1 inner text</span>" +
            "            <span id=\"childDiv22\">child div 2 inner text</span>" +
            "            <span id=\"childDiv23\">child div 3 inner text</span>" +
            "        </div>" +
            "        <div id=\"mockDiv3\">mock div text" +
            "            <span id=\"childDiv31\">child div 1 inner text</span>" +
            "            <span id=\"childDiv32\">child div 2 inner text</span>" +
            "            <span id=\"childDiv33\">child div 3 inner text</span>" +
            "        </div>" +
            "        <positive mock_attribute=\"attribute_1\">mock div text 1</positive>" +
            "        <positive mock_attribute=\"attribute_2\">mock div text 2</positive>" +
            "        <positive mock_attribute=\"attribute_3\">mock div text 3</positive>" +
            "    </body>" +
            "</html>";

        [TestInitialize]
        public void Setup()
        {
            WebDriver.PageSource = PageSource;
        }

        [TestMethod]
        public void ExtractDataCreate() => ValidateAction<ExtractData>();

        [TestMethod]
        public void ExtractDataDocumentation()
            => ValidateActionDocumentation<ExtractData>(WebPlugins.ExtractData);

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
            => ValidateActionDocumentation<ExtractData>(WebPlugins.ExtractData, "extract_data.json");

        #region *** extract from element ***
        #endregion

        #region *** extract with actions ***
        #endregion

        #region *** extract from source  ***
        // 0: extracts inner text of all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^mock div text \d+$")]
        public void ExtractFromSourceSelfText(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts inner text of all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'regularExpression':'mock div'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^mock div$")]
        public void ExtractFromSourceSelfTextPattern(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts a value from a given attribute, for all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'mock_attribute'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^attribute_\d+$")]
        public void ExtractFromSourceSelfAttribute(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts a value from a given attribute, for all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'mock_attribute'," +
            @"           'regularExpression':'\\d+'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^\d+$")]
        public void ExtractFromSourceSelfAttributePattern(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts inner text of the given element under all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./span[1]'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^child div 1 inner text$")]
        public void ExtractFromSourceElementText(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts inner text of the given element under all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./span[1]'," +
            @"           'regularExpression':'child div \\d'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^child div \d$")]
        public void ExtractFromSourceElementTextPattern(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts a value from a given attribute of the given element under all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./span[1]'," +
            "            'elementAttributeToActOn':'id'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^childDiv\d+$")]
        public void ExtractFromSourceElementAttribute(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts a value from a given attribute of the given element under all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./span[1]'," +
            "            'elementAttributeToActOn':'id'," +
            @"           'regularExpression':'\\d+'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^\d+$")]
        public void ExtractFromSourceElementAttributePattern(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts the outer HTML of all root elements.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'html'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "positive mock_attribute=")]
        public void ExtractFromSourceSelfOuterHtml(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts the outer HTML of the given element under all root elements.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./span[1]'," +
            "            'elementAttributeToActOn':'html'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "span id=")]
        public void ExtractFromSourceElementOuterHtml(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts inner text of the given absolute element for all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'//p[1]'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^mock, page level paragraph, inner text$")]
        public void ExtractFromSourceElementAbsoluteText(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'pageSource':true," +
            "    'rootElementToExtractFrom':'//div'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'//p[1]'," +
            "            'elementAttributeToActOn':'id'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"pageLevel\d+$")]
        public void ExtractFromSourceElementAbsoluteAttribute(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion

        // executes extraction rule and validates counts and data
        private bool DoExtract(string extractionRule, string expected)
        {
            // setup
            SetExtractionRules(extractionRule);

            // execute
            var plugin = ExecuteAction<ExtractData>();

            // setup conditions
            var isCount = plugin.ExtractionResults.First().Entities.Count() == 3;
            var isData = plugin.ExtractionResults
                .First()
                .Entities
                .All(i => Regex.IsMatch($"{i.EntityContent["data"]}", expected));

            // assertion
            return isCount && isData;
        }

        // set extraction rule for currently running web automation
        private void SetExtractionRules(string extractionRule)
        {
            // setup
            var rule = JsonConvert.DeserializeObject<ExtractionRule>(extractionRule);

            // apply
            WebAutomation.Extractions = new[] { rule };
        }
    }
}
#pragma warning restore
