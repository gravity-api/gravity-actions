/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Framework;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    [DoNotParallelize]
    public class ExtractFromDomTests : ActionTests
    {
        // members state
        private static string connectionString;
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        // properties
        public TestContext TestContext { get; set; }

        #region *** tests: life cycle    ***
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            connectionString =
                $"{context.Properties["Data.ConnectionString"]}".Replace("[catalog]", "ExtractFromDomTests");
        }

        [ClassCleanup]
        public static void Dispose()
        {
            // data files
            if (Directory.Exists("Data"))
            {
                Directory.Delete(path: "Data", true);
            }

            // database
            DropDatabase(connectionString);
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void ExtractDataCreate() => AssertPlugin<ExtractFromDom>();

        [TestMethod]
        public void ExtractDataDocumentation()
        {
            AssertDocumentation<ExtractFromDom>(
                pluginName: GravityPlugin.ExtractFromDom);
        }

        [TestMethod]
        public void ExtractDataDocumentationResourceFile()
        {
            AssertDocumentation<ExtractFromDom>(
                pluginName: GravityPlugin.ExtractFromDom,
                resource: "ExtractFromDom.json");
        }
        #endregion

        #region *** extract from DOM     ***
        // 0: extracts inner text of all root elements and apply a pattern on it
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"regularExpression\":\"Positive Element\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"html\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"class\"," +
            @"           ""regularExpression"":""\\d+""," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onAttribute\":\"class\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./negative[1]\"," +
            "            \"regularExpression\":\"Negative Element\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./negative[1]\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./negative[1]\"," +
            "            \"onAttribute\":\"html\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./negative[1]\"," +
            "            \"onAttribute\":\"class\"," +
            @"           ""regularExpression"":""\\d+""," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"./negative[1]\"," +
            "            \"onAttribute\":\"class\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"//negative[1]\"," +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"onElement\":\"//negative[1]\"," +
            "            \"onAttribute\":\"class\"," +
            "            \"key\":\"data\"" +
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
        [Ignore(message: "MSTest Bug. Not loading settings. Consider migration to NUnit")]
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"," +
            "        \"repository\":\"[Data.Repository]\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"repository\":\"[Data.Repository]\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        [ExpectedException(typeof(ArgumentException))]
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
            "    \"dataProvider\": {" +
            "        \"type\":\"SQLServer\"," +
            "        \"source\":\"[Data.ConnectionString]\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
            "        }" +
            "    ]" +
            "}")]
        [ExpectedException(typeof(ArgumentException))]
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].csv\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].csv\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"CSV\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].json\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].json\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"JSON\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].xml\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"data/extract_from_dom/[File.Name].xml\"," +
            "        \"writePerEntity\":true" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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
            "    \"dataProvider\": {" +
            "        \"type\":\"XML\"," +
            "        \"source\":\"\"" +
            "    }," +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"" +
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

        #region *** extract with actions ***
        [DataTestMethod]
        [DataRow("" +
            "{" +
            "    \"onRootElements\":\"//positive\"," +
            "    \"onElements\": [" +
            "        {" +
            "            \"key\":\"data\"," +
            "            \"actions\": [" +
            "                {" +
            "                    \"action\":\"Click\"," +
            "                    \"onElement\":\".//positive\"" +
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
        #endregion

        #region *** utilities            ***
        // executes extraction rule and validates counts and data
        private bool DoExtract(string extractionRule, string expected)
        {
            // setup
            SetExtractionRules(extractionRule);

            // execute
            var plugin = ExecuteAction<ExtractFromDom>();

            // setup conditions
            var isCount = plugin.Extractions.First().Entities.Count() == 2;
            var isData = plugin.Extractions
                .First()
                .Entities
                .All(i => Regex.IsMatch($"{i.Content["data"]}", expected));

            // assertion
            return isCount && isData;
        }

        // set extraction rule for currently running web automation
        private void SetExtractionRules(string extractionRule)
        {
            // setup
            var rule = JsonSerializer.Deserialize<ExtractionRule>(extractionRule, options);

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

        // executes extraction rule and validates against data source
        private bool DoDataExtract(string extractionRule)
        {
            // setup
            SetExtractionRules(extractionRule);
            var dataSource = Automation.Extractions.ElementAt(0).DataProvider;

            // execute
            var plugin = ExecuteAction<ExtractFromDom>();

            // results
            var expected = plugin.Extractions.First().ToDataTable();
            var actual = new DataProvidersFactory(PluginUtilities.Types).From(dataSource, Array.Empty<object>());

            // comparing
            var sExpected = new string(JsonSerializer.Serialize(expected.ToDictionary(), options).OrderBy(i => i).ToArray());
            var sActual = new string(JsonSerializer.Serialize(actual.ToDictionary(), options).OrderBy(i => i).ToArray());

            // assertion
            return sExpected.Equals(sActual, StringComparison.Ordinal);
        }
        #endregion
    }
}
#pragma warning restore S4144