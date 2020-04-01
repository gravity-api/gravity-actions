/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    [DoNotParallelize]
    public class ExtractFromDomTests : ActionTests
    {
        // members state
        private static string connectionString;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            connectionString =
                $"{context.Properties["Data.ConnectionString"]}".Replace("[catalog]", "ExtractFromDomTests");
        }

        [ClassCleanup]
        public static void Dispose()
        {
            // database
            DropDatabase(connectionString);

            // data files
            if (Directory.Exists("Data"))
            {
                Directory.Delete(path: "Data", true);
            }
        }

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

        // 0: extracts inner text of the given element under all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./negative[1]'," +
            "            'regularExpression':'Negative Element'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^Negative Element$")]
        public void ExtractFromDomElementTextPattern(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./negative[1]'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^Mock: Negative Element$")]
        public void ExtractFromDomElementText(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./negative[1]'," +
            "            'elementAttributeToActOn':'html'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "mock element inner-text")]
        public void ExtractFromDomElementOuterHtml(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./negative[1]'," +
            "            'elementAttributeToActOn':'class'," +
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

        // 0: extracts a value from a given attribute of the given element under all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'./negative[1]'," +
            "            'elementAttributeToActOn':'class'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^mock attribute value \d+$")]
        public void ExtractFromDomElementAttribute(string extractionRule, string expected)
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'//negative[1]'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", "^Mock: Negative Element$")]
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
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'elementToActOn':'//negative[1]'," +
            "            'elementAttributeToActOn':'class'," +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}", @"^mock attribute value \d+$")]
        public void ExtractFromDomElementAbsoluteAttribute(string extractionRule, string expected)
        {
            // execute
            var actual = DoExtract(extractionRule, expected);

            // assertion
            Assert.IsTrue(actual);
        }
        #endregion

        #region *** extract into SQL     ***
        // 0: extracts inner text of all root elements and save it to SQL Server.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'SQLServer'," +
            "        'source':'[Data.ConnectionString]'," +
            "        'repository':'[Data.Repository]'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToSqlServer(string extractionRule)
        {
            // setup
            extractionRule =
                SetSqlDataSource(extractionRule, repository: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to SQL Server.
        //    the saving will be done when the content entry execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'SQLServer'," +
            "        'source':'[Data.ConnectionString]'," +
            "        'repository':'[Data.Repository]'," +
            "        'writePerEntity':true" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToSqlServerPerEntity(string extractionRule)
        {
            // setup
            extractionRule =
                SetSqlDataSource(extractionRule, repository: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to SQL Server.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'SQLServer'," +
            "        'source':'[Data.ConnectionString]'," +
            "        'repository':'[Data.Repository]'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToSqlServerNoSource(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[Data.Repository]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsFalse(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to SQL Server.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'SQLServer'," +
            "        'source':'[Data.ConnectionString]'," +
            "        'repository':'[Data.Repository]'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToSqlServerNoRepository(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[Data.ConnectionString]", newValue: $"{TestContext.Properties["Data.ConnectionString"]}");

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsFalse(isExtract);
        }
        #endregion

        #region *** extract into CSV     ***
        // 0: extracts inner text of all root elements and save it to a CSV file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'CSV'," +
            "        'source':'data/extract_from_dom/[File.Name].csv'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToCsv(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a CSV file.
        //    the saving will be done when the content entry execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'CSV'," +
            "        'source':'data/extract_from_dom/[File.Name].csv'," +
            "        'writePerEntity':true" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToCsvPerEntity(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a CSV file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'CSV'," +
            "        'source':''" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToCsvNoSource(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsFalse(isExtract);
        }
        #endregion

        #region *** extract into JSON    ***
        // 0: extracts inner text of all root elements and save it to a JSON file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'JSON'," +
            "        'source':'data/extract_from_dom/[File.Name].json'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToJson(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a JSON file.
        //    the saving will be done when the content entry execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'JSON'," +
            "        'source':'data/extract_from_dom/[File.Name].json'," +
            "        'writePerEntity':true" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToJsonPerEntity(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a JSON file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'JSON'," +
            "        'source':''" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToJsonNoSource(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsFalse(isExtract);
        }
        #endregion

        #region *** extract into XML     ***
        // 0: extracts inner text of all root elements and save it to a XML file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'XML'," +
            "        'source':'data/extract_from_dom/[File.Name].xml'" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToXml(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a XML file.
        //    the saving will be done when the content entry execution completed.
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'XML'," +
            "        'source':'data/extract_from_dom/[File.Name].xml'," +
            "        'writePerEntity':true" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToXmlPerEntity(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsTrue(isExtract);
        }

        // 0: extracts inner text of all root elements and save it to a XML file.
        //    the saving will be done when the extraction rule execution completed.
        [DataTestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow("" +
            "{" +
            "    'dataSource': {" +
            "        'type':'XML'," +
            "        'source':''" +
            "    }," +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromDomSaveToXmlNoSource(string extractionRule)
        {
            // setup
            extractionRule = extractionRule
                .Replace(oldValue: "[File.Name]", newValue: MethodBase.GetCurrentMethod().Name);

            // execute
            var isExtract = DoDataExtract(extractionRule);

            // assertion
            Assert.IsFalse(isExtract);
        }
        #endregion

        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    'rootElementToExtractFrom':'//positive'," +
            "    'elementsToExtract': [" +
            "        {" +
            "            'key':'data'," +
            "            'actions': [" +
            "                {" +
            "                    'actionType':'Click'," +
            "                    'elementToActOn':'.//positive'" +
            "                }" +
            "            ]" +
            "        }" +
            "    ]" +
            "}")]
        public void SubActions(string extractionRule)
        {
            // execute
            var isExtract = DoExtract(extractionRule, "");

            // assertion
            Assert.IsTrue(isExtract);
        }

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

        // replace placeholder for extraction rules data source
        private string SetSqlDataSource(string extractionRule, string repository)
        {
            return extractionRule
                .Replace(oldValue: "[Data.ConnectionString]", newValue: connectionString)
                .Replace(oldValue: "[Data.Repository]", newValue: repository);
        }

        // executes extraction rule and validates against data source
        private bool DoDataExtract(string extractionRule)
        {
            // setup
            SetExtractionRules(extractionRule);
            var dataSource = WebAutomation.Extractions.ElementAt(0).DataSource;

            // execute
            var plugin = ExecuteAction<ExtractFromDom>();

            // results
            var expected = plugin.ExtractionResults.First().ToDataTable();
            var actual = new DataTable().Load(dataSource);

            // comparing
            var sExpected = new string(JsonConvert.SerializeObject(expected).OrderBy(i => i).ToArray());
            var sActual = new string(JsonConvert.SerializeObject(actual).OrderBy(i => i).ToArray());

            // assertion
            return sExpected.Equals(sActual, StringComparison.Ordinal);
        }
    }
}
#pragma warning restore S4144