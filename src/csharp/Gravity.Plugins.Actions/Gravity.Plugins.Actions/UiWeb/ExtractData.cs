/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.extract_data.json",
        Name = WebPlugins.ExtractData)]
    public class ExtractData : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// A list of <see cref="ExtractionRule"/> to execute. This is a zero-based index based on
        /// <see cref="WebAutomation.Extractions"/> collection.
        /// </summary>
        public const string Extractions = "extractions";
        #endregion

        // members: state
        private string mainWindowHandle;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExtractData(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        {
            mainWindowHandle = driver.GetCurrentHandle();
        }
        #endregion

        /// <summary>
        /// Executes <see cref="ExtractionRule"/> collection under this <see cref="Plugin.WebAutomation"/>.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(actionRule);
        }

        /// <summary>
        /// Executes <see cref="ExtractionRule"/> collection under this <see cref="Plugin.WebAutomation"/>.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(actionRule);
        }

        // executes action routine
        private void DoAction(ActionRule actionRule)
        {
            var extrctions = GetExtractionRules(actionRule);
            for (int i = 0; i < extrctions.Count(); i++)
            {
                DoExtraction(extractionRule: extrctions.ElementAt(i), key: $"{i}_{WebDriver.GetSession()}");
            }
        }

        #region *** Data Extraction        ***
        private void DoExtraction(ExtractionRule extractionRule, string key)
        {
            // setup
            var rootElements = GetRootElements(extractionRule);
            var cachedElements = CacheRootElements(extractionRule, isFromSource: extractionRule.PageSource);
            var results = new List<Entity>();

            // extract from source
            if (extractionRule.PageSource)
            {
                for (int i = 0; i < cachedElements.Count(); i++)
                {
                    results.Add(DoContentEntriesFromSource(
                        extractionRule, cachedElement: cachedElements.ElementAt(i), i));
                }
            }

            // extract from element (w/o actions)
            // TODO: from element

            // apply
            ExtractionResults.Add(new Extraction()
            {
                Entities = results,
                Key = key
            }
            .GetDefault($"{WebDriver.GetSession()}"));
        }
        #endregion

        #region *** Data Extraction Source ***
        private Entity DoContentEntriesFromSource(ExtractionRule extractionRule, HtmlNode cachedElement, int index)
        {
            // setup
            var entity = new Entity()
            {
                EntityContent = new Dictionary<string, object>()
            };
            entity.EntityContent[$"entity_index_{WebDriver.GetSession()}"] = index;

            // extract
            foreach (var entry in extractionRule.ElementsToExtract)
            {
                var contentEntry = DoContentEntryFromSource(entry, cachedElement);
                entity.EntityContent[contentEntry.Key] = contentEntry.Value;
            }

            // result
            return entity;
        }

        private static KeyValuePair<string, object> DoContentEntryFromSource(ContentEntry entry, HtmlNode cachedElement)
        {
            // setup
            var htmlNode = cachedElement;

            // if not self, take from element or from page
            if (!string.IsNullOrEmpty(entry.ElementToActOn))
            {
                htmlNode = entry.ElementToActOn.IsXpath(isRelative: true)
                    ? cachedElement.SelectSingleNode(entry.ElementToActOn)
                    : cachedElement.OwnerDocument.DocumentNode.SelectSingleNode(entry.ElementToActOn);
            }

            // get value, take text or attribute
            var value = string.IsNullOrEmpty(entry.ElementAttributeToActOn)
                ? htmlNode.InnerText
                : htmlNode.GetAttributeValue(name: entry.ElementAttributeToActOn, def: string.Empty);

            // result
            return new KeyValuePair<string, object>(
                key: entry.Key,
                value: Regex.Match(input: value, pattern: entry.RegularExpression).Value);
        }
        #endregion

        #region *** HTML/Elements Cache    ***
        private IEnumerable<HtmlNode> CacheRootElements(ExtractionRule extractionRule, bool isFromSource)
        {
            // setup
            var body = isFromSource ? WebDriver.PageSource : WebDriver.GetElement(By.XPath("//body")).GetSource();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(body);

            // result
            return htmlDocument.DocumentNode.SelectNodes(extractionRule.RootElementToExtractFrom);
        }

        private IEnumerable<IWebElement> GetRootElements(ExtractionRule extractionRule)
        {
            // setup
            var by = By.XPath(extractionRule.RootElementToExtractFrom);

            // result
            return WebDriver.GetElements(by);
        }
        #endregion

        #region *** Extraction Rules       ***
        private IEnumerable<ExtractionRule> GetExtractionRules(ActionRule actionRule)
        {
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var extractions = arguments.ContainsKey(Extractions)
                ? arguments[Extractions].Split(',')
                : Array.Empty<string>();

            // exit conditions
            if(extractions.Length == 0)
            {
                return WebAutomation.Extractions;
            }

            // build extractions list
            var extractionsList = new List<ExtractionRule>();
            foreach (var extraction in extractions)
            {
                var isExtraction = int.TryParse(extraction, out int extractionOut);
                var isRange = extractionOut <= WebAutomation.Extractions.Count() - 1;
                var isValidExtraction = isExtraction && isRange;

                if (isValidExtraction)
                {
                    extractionsList.Add(WebAutomation.Extractions.ElementAt(extractionOut));
                }
            }
            return extractionsList;
        }
        #endregion
    }
}