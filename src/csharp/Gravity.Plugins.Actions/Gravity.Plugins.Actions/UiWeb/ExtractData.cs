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
using Gravity.Plugins.Extensions;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

        #region *** Data Extraction         ***
        private void DoExtraction(ExtractionRule extractionRule, string key)
        {
            // setup
            var webElements = GetRootElements(extractionRule);
            var domElements = CacheRootElements(extractionRule, isFromSource: extractionRule.PageSource);
            var results = new List<Entity>();

            // extract from source
            if (extractionRule.PageSource)
            {
                for (int i = 0; i < domElements.Count(); i++)
                {
                    results.Add(DoContentEntriesFromSource(
                        extractionRule, domElement: domElements.ElementAt(i), i));
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

        #region *** Data Extraction Source  ***
        private Entity DoContentEntriesFromSource(ExtractionRule extractionRule, HtmlNode domElement, int index)
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
                var contentEntry = DoContentEntryFromSource(entry, domElement);
                entity.EntityContent[contentEntry.Key] = contentEntry.Value;
            }

            // result
            return entity;
        }

        private KeyValuePair<string, object> DoContentEntryFromSource(ContentEntry entry, HtmlNode domElement)
        {
            // setup
            var htmlNode = domElement;

            // if not self, take from element or from page
            if (!string.IsNullOrEmpty(entry.ElementToActOn))
            {
                htmlNode = entry.ElementToActOn.IsXpath(isRelative: true)
                    ? domElement.SelectSingleNode(entry.ElementToActOn)
                    : domElement.OwnerDocument.DocumentNode.SelectSingleNode(entry.ElementToActOn);
            }

            // exit conditions
            if(htmlNode == default)
            {
                return new KeyValuePair<string, object>(key: entry.Key, value: string.Empty);
            }

            // get value, take text or attribute
            var value = string.IsNullOrEmpty(entry.ElementAttributeToActOn)
                ? htmlNode.InnerText
                : GetAttributeValue(element: htmlNode, attribute: entry.ElementAttributeToActOn);

            // result
            return new KeyValuePair<string, object>(
                key: entry.Key,
                value: Regex.Match(input: value, pattern: entry.RegularExpression).Value);
        }
        #endregion

        #region *** Data Extraction Element ***
        #endregion

        #region *** HTML/Elements Cache     ***
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

        #region *** Extraction Rules        ***
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

        private string GetAttributeValue(IWebElement element, string attribute)
        {
            // special
            var attributeMethod = GetSpecialAttributeMethod<IWebElement>(attribute);

            // value
            return attributeMethod != default
                ? (string)attributeMethod.Invoke(this, new[] { element })
                : element.GetAttribute(attributeName: attribute);
        }

        private string GetAttributeValue(HtmlNode element, string attribute)
        {
            // special
            var attributeMethod = GetSpecialAttributeMethod<HtmlNode>(attribute);

            // value
            return attributeMethod != default
                ? (string)attributeMethod.Invoke(this, new[] { element })
                : element.GetAttributeValue(name: attribute, def: string.Empty);
        }
        #endregion

#pragma warning disable IDE0051
        #region *** Special Attributes      ***
        [Description("html")]
        private string Html(IWebElement element) => element.GetSource();

        [Description("html")]
        private string Html(HtmlNode element) => element.OuterHtml;

        private MethodInfo GetSpecialAttributeMethod<T>(string attribute)
        {
            // get methods
            var methods = this.GetType().GetMethodsByDescription(regex: attribute);

            // exit conditions
            if (!methods.Any())
            {
                return default;
            }

            // find method by element type
            return methods
                .FirstOrDefault(i => i.GetParameters().First(p => p.Name == "element").ParameterType == typeof(T));
        }
        #endregion
    }
#pragma warning restore
}