/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Gravity.Plugins.Utilities;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.extract_from_source.json",
        Name = WebPlugins.ExtractFromSource)]
    public class ExtractFromSource : WebDriverActionPlugin
    {
        // members
        private readonly MacroFactory macroFactory;

        #region *** arguments    ***
        /// <summary>
        /// A list of <see cref="ExtractionRule"/> to execute. This is a zero-based index based on
        /// <see cref="WebAutomation.Extractions"/> collection.
        /// </summary>
        public const string Extractions = "extractions";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExtractFromSource(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        {
            macroFactory = new MacroFactory(Types);
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
            // setup
            var arguments = CliFactory.Parse(actionRule.Argument);
            var eList = arguments.ContainsKey(Extractions) ? arguments[Extractions].Split(',') : Array.Empty<string>();
            var extrctions = WebAutomation.GetExtractionRules(extractions: eList).Where(i => i.PageSource);

            for (int i = 0; i < extrctions.Count(); i++)
            {
                DoExtraction(extractionRule: extrctions.ElementAt(i), key: $"{i}_{WebDriver.GetSession()}");
            }
        }

        #region *** Data Extraction         ***
        private void DoExtraction(ExtractionRule extractionRule, string key)
        {
            // setup
            var onElements = GetRootElements(extractionRule, isFromSource: extractionRule.PageSource);
            var results = new List<Entity>();

            // extract from source
            for (int i = 0; i < onElements.Count(); i++)
            {
                results.Add(DoContentEntriesFromSource(
                    extractionRule, onElement: onElements.ElementAt(i), i));
            }

            // create extraction
            var extraction = new Extraction()
            {
                Entities = results,
                Key = key
            }
            .GetDefault($"{WebDriver.GetSession()}");

            // apply
            ExtractionResults.Add(extraction);

            // populate
            if(extractionRule.DataSource != default && !extractionRule.DataSource.WritePerEntity)
            {
                extraction.Populate(extractionRule.DataSource);
            }
        }
        #endregion

        #region *** Data Extraction Source  ***
        private Entity DoContentEntriesFromSource(ExtractionRule extractionRule, HtmlNode onElement, int index)
        {
            // setup
            var entity = new Entity()
            {
                EntityContent = new Dictionary<string, object>()
            };
            entity.EntityContent["entity_index"] = index;

            // extract
            foreach (var entry in extractionRule.ElementsToExtract)
            {
                var contentEntry = DoContentEntryFromSource(entry, onElement);
                entity.EntityContent[contentEntry.Key] = contentEntry.Value;
            }

            // populate
            if (extractionRule.DataSource != default && extractionRule.DataSource.WritePerEntity)
            {
                entity.Populate(extractionRule.DataSource);
            }

            // result
            return entity;
        }

        private KeyValuePair<string, object> DoContentEntryFromSource(ContentEntry entry, HtmlNode onElement)
        {
            // setup
            var htmlNode = onElement;
            var onEntry = macroFactory.Get(entry);

            // if not self, take from element or from page
            if (!string.IsNullOrEmpty(onEntry.ElementToActOn))
            {
                htmlNode = onEntry.ElementToActOn.IsXpath(isRelative: true)
                    ? onElement.SelectSingleNode(onEntry.ElementToActOn)
                    : onElement.OwnerDocument.DocumentNode.SelectSingleNode(onEntry.ElementToActOn);
            }

            // exit conditions
            if (htmlNode == default)
            {
                return new KeyValuePair<string, object>(key: onEntry.Key, value: string.Empty);
            }

            // get value, take text or attribute
            var value = string.IsNullOrEmpty(onEntry.ElementAttributeToActOn)
                ? htmlNode.InnerText
                : GetAttributeValue(element: htmlNode, attribute: onEntry.ElementAttributeToActOn);

            // result
            return new KeyValuePair<string, object>(
                key: onEntry.Key,
                value: Regex.Match(input: value, pattern: onEntry.RegularExpression).Value);
        }
        #endregion

        #region *** HTML/Elements Cache     ***
        private IEnumerable<HtmlNode> GetRootElements(ExtractionRule extractionRule, bool isFromSource)
        {
            // setup
            var body = isFromSource ? WebDriver.PageSource : WebDriver.GetElement(By.XPath("//body")).GetSource();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(body);

            // result
            return htmlDocument.DocumentNode.SelectNodes(extractionRule.RootElementToExtractFrom);
        }
        #endregion

        #region *** Extraction Rules        ***
        private string GetAttributeValue(HtmlNode element, string attribute)
        {
            // special
            var attributeMethod = this.GetSpecialAttributeMethod<HtmlNode>(attribute);

            // value
            return attributeMethod != default
                ? (string)attributeMethod.Invoke(this, new[] { element })
                : element.GetAttributeValue(name: attribute, def: string.Empty);
        }
        #endregion

#pragma warning disable IDE0051
        #region *** Special Attributes      ***
        [Description("html")]
        private string Html(HtmlNode element) => element.OuterHtml;
        #endregion
#pragma warning restore
    }
}