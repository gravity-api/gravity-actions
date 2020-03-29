/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class ExtractFromDomTests : ActionTests
    {
        [TestMethod]
        public void ExtractDataCreate() => ValidateAction<ExtractFromDom>();

        [TestMethod]
        public void ExtractDataDocumentation()
            => ValidateActionDocumentation<ExtractFromDom>(CommonPlugins.ExtractFromDom);

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
            => ValidateActionDocumentation<ExtractFromDom>(CommonPlugins.ExtractFromDom, "extract_from_dom.json");

        #region *** extract from DOM     ***
        // 0: extracts inner text of all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'regularExpression':'Positive Element'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^Positive Element$")]
        public void ExtractFromDomSelfTextPattern(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts inner text of all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^Mock: Positive Element$")]
        public void ExtractFromDomSelfText(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'html'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "mock element inner-text")]
        public void ExtractFromDomSelfOuterHtml(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'class'," +
            @"           'regularExpression':'\\d+'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^\d+$")]
        public void ExtractFromDomSelfAttributePattern(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementAttributeToActOn':'class'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^mock attribute value \d+$")]
        public void ExtractFromDomSelfAttribute(string extractionRule, string expected)
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
        public void ExtractFromDomElementText(string extractionRule, string expected)
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
        public void ExtractFromDomElementTextPattern(string extractionRule, string expected)
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
        public void ExtractFromDomElementAttribute(string extractionRule, string expected)
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
        public void ExtractFromDomElementAttributePattern(string extractionRule, string expected)
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
        public void ExtractFromDomElementOuterHtml(string extractionRule, string expected)
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
        public void ExtractFromDomElementAbsoluteText(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }

        // 0: extracts attribute value of the given absolute element for all root elements
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
        public void ExtractFromDomElementAbsoluteAttribute(string extractionRule, string expected)
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
            var plugin = ExecuteAction<ExtractFromDom>();

            // setup conditions
            var isCount = plugin.ExtractionResults.First().Entities.Count() == 2;
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
#pragma warning restore S4144