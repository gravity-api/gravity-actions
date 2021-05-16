/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text.Json;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    [DoNotParallelize]
    public class ExtractFromSourceTests : ActionTests
    {
        #region *** tests: constants     ***
        private static string connectionString;
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
        #endregion

        // members
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        #region *** tests: properties    ***
        public TestContext TestContext { get; set; }
        #endregion

        #region *** tests: life cycle    ***
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            // data files
            if (Directory.Exists("Data"))
            {
                Directory.Delete(path: "Data", true);
            }

            connectionString =
                $"{context.Properties["Data.ConnectionString"]}".Replace("[catalog]", "ExtractFromSourceTests");
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

        [TestInitialize]
        public void TestSetup()
        {
            WebDriver.PageSource = PageSource;
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void ExtractDataCreate()
        {
            AssertPlugin<ExtractFromSource>();
        }

        [TestMethod]
        public void ExtractDataDocumentation()
        {
            AssertDocumentation<ExtractFromSource>(
                pluginName: GravityPlugin.ExtractFromSource);
        }

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
        {
            AssertDocumentation<ExtractFromSource>(
                pluginName: GravityPlugin.ExtractFromSource,
                resource: "ExtractFromSource.json");
        }
        #endregion

        #region *** extract from source  ***
        // 0: extracts inner text of all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"regularExpression\":\"mock div\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"mock_attribute\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"mock_attribute\"," +
            @"           ""regularExpression"":""\\d+""," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./span[1]\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./span[1]\"," +
            @"           ""regularExpression"":""child div \\d""," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./span[1]\"," +
            "            \"onAttribute\":\"id\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./span[1]\"," +
            "            \"onAttribute\":\"id\"," +
            @"           ""regularExpression"":""\\d+""," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"html\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./span[1]\"," +
            "            \"onAttribute\":\"html\"," +
            "            \"key\":\"data\"" +
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
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"//p[1]\"," +
            "            \"key\":\"data\"" +
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

        // 0: extracts attribute value of the given absolute element for all root elements
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//div\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"//p[1]\"," +
            "            \"onAttribute\":\"id\"," +
            "            \"key\":\"data\"" +
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

        // 0: extracts inner text of all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"pageSource\":false," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"regularExpression\":\"mock element nested inner\"," +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}", "^mock element nested inner$")]
        public void ExtractFromSourcePageSourceFalse(string extractionRule, string expected)
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
        [Ignore(message: "MSTest Bug. Not loading settings. Consider migration to NUnit")]
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"," +
            "        \"repository\":\"[Data.Repository]\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToSqlServer(string extractionRule)
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
        [Ignore(message: "MSTest Bug. Not loading settings. Consider migration to NUnit")]
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"," +
            "        \"repository\":\"[Data.Repository]\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToSqlServerPerEntity(string extractionRule)
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
        [ExpectedException(typeof(ArgumentException))]
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"," +
            "        \"repository\":\"[Data.Repository]\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToSqlServerNoSource(string extractionRule)
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
        [Ignore(message: "MSTest Bug. Not loading settings. Consider migration to NUnit")]
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"," +
            "        \"repository\":\"[Data.Repository]\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToSqlServerNoRepository(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].csv\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToCsv(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].csv\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToCsvPerEntity(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToCsvNoSource(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].json\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToJson(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].json\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToJsonPerEntity(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToJsonNoSource(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].xml\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToXml(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"data/extract_from_source/[File.Name].xml\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToXmlPerEntity(string extractionRule)
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"pageSource\":true," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        public void ExtractFromSourceSaveToXmlNoSource(string extractionRule)
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

        #region *** tests: utilities     ***
        // executes extraction rule and validates counts and data
        private bool DoExtract(string extractionRule, string expected)
        {
            // setup
            SetExtractionRules(extractionRule);

            // execute
            var plugin = ExecuteAction<ExtractFromSource>();

            // setup conditions
            var isCount = plugin.Extractions.First().Entities.Count() == 3;
            var isData = plugin.Extractions
                .First()
                .Entities
                .All(i => Regex.IsMatch($"{i.Content["data"]}", expected));

            // assertion
            return isCount && isData;
        }

        // executes extraction rule and validates against data source
        private bool DoDataExtract(string extractionRule)
        {
            // setup
            SetExtractionRules(extractionRule);
            var dataProvider = Automation.Extractions.ElementAt(0).DataProvider;

            // execute
            var plugin = ExecuteAction<ExtractFromSource>();

            // results
            var expected = plugin.Extractions.First().ToDataTable().ToDictionary();
            var actual = new DataProvidersFactory(Plugin.Types).From(dataProvider, Array.Empty<object>()).ToDictionary();

            // comparing
            var sExpected = new string(JsonSerializer.Serialize(expected, serializerOptions).OrderBy(i => i).ToArray());
            var sActual = new string(JsonSerializer.Serialize(actual, serializerOptions).OrderBy(i => i).ToArray());

            // assertion
            return sExpected.Equals(sActual, StringComparison.Ordinal);
        }

        // set extraction rule for currently running web automation
        private void SetExtractionRules(string extractionRule)
        {
            // setup
            var rule = JsonSerializer.Deserialize<ExtractionRule>(extractionRule, serializerOptions);

            // apply
            Automation.Extractions = new[] { rule };
        }

        // replace placeholder for extraction rules data source
        private static string SetSqlDataSource(string extractionRule, string repository)
        {
            return extractionRule
                .Replace(oldValue: "[Data.ConnectionString]", newValue: connectionString)
                .Replace(oldValue: "[Data.Repository]", newValue: repository);
        }
        #endregion
    }
}
#pragma warning restore
