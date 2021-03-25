/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Utilities;

using HtmlAgilityPack;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiWeb
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.ExtractFromSource.json",
        Name = PluginsList.ExtractFromSource)]
    public class ExtractFromSource : WebDriverActionPlugin
    {
        // members
        private readonly MacroFactory macroFactory;

        #region *** arguments    ***
        /// <summary>
        /// A list of <see cref="ExtractionRule"/> to execute. This is a zero-based index based on
        /// <see cref="WebAutomation.Extractions"/> collection.
        /// </summary>
        public const string ExtractionsArgument = "extractions";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExtractFromSource(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            macroFactory = new MacroFactory(Types);
        }
        #endregion

        /// <summary>
        /// Executes <see cref="ExtractionRule"/> collection under this <see cref="Plugin.Automation"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Executes <see cref="ExtractionRule"/> collection under this <see cref="Plugin.Automation"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action);
        }

        // execute action routine
        private void DoAction(ActionRule action)
        {
            // setup
            var arguments = CliFactory.Parse(action.Argument);
            var extractions = arguments.ContainsKey(ExtractionsArgument)
                ? arguments[ExtractionsArgument].Split(',')
                : Array.Empty<string>();
            var onExtrctions = Automation.GetExtractionRules(extractions);

            for (int i = 0; i < onExtrctions.Count(); i++)
            {
                DoExtraction(extraction: onExtrctions.ElementAt(i), key: $"{i}_{WebDriver.GetSession()}");
            }
        }

        #region *** Data Extraction         ***
        private void DoExtraction(ExtractionRule extraction, string key)
        {
            // setup
            var onElements = GetRootElements(extraction, isFromSource: extraction.PageSource);
            var results = new List<Entity>();

            // extract from source
            for (int i = 0; i < onElements.Count(); i++)
            {
                results.Add(DoContentEntriesFromSource(
                    extraction, element: onElements.ElementAt(i), i));
            }

            // create extraction
            var onExtraction = new Extraction()
            {
                Entities = results,
                Key = key
            }
            .GetDefault($"{WebDriver.GetSession()}");

            // apply
            Extractions.Add(onExtraction);

            // populate
            if (extraction.DataSource?.WritePerEntity == false)
            {
                onExtraction.Populate(extraction.DataSource);
            }
        }
        #endregion

        #region *** Data Extraction Source  ***
        private Entity DoContentEntriesFromSource(ExtractionRule extraction, HtmlNode element, int index)
        {
            // setup
            var entity = new Entity()
            {
                Content = new Dictionary<string, object>()
            };
            entity.Content["entityIndex"] = index;

            // extract
            foreach (var entry in extraction.OnElements)
            {
                var contentEntry = DoContentEntryFromSource(entry, element);
                entity.Content[contentEntry.Key] = contentEntry.Value;
            }

            // populate
            if (extraction.DataSource?.WritePerEntity == true)
            {
                entity.Populate(extraction.DataSource);
            }

            // result
            return entity;
        }

        private KeyValuePair<string, object> DoContentEntryFromSource(ContentEntry entry, HtmlNode element)
        {
            // setup
            var htmlNode = element;
            var onEntry = macroFactory.Get(entry);

            // if not self, take from element or from page
            if (!string.IsNullOrEmpty(onEntry.OnElement))
            {
                htmlNode = onEntry.OnElement.IsXpath(isRelative: true)
                    ? element.SelectSingleNode(onEntry.OnElement)
                    : element.OwnerDocument.DocumentNode.SelectSingleNode(onEntry.OnElement);
            }

            // exit conditions
            if (htmlNode == default)
            {
                return new KeyValuePair<string, object>(key: onEntry.Key, value: string.Empty);
            }

            // get value, take text or attribute
            var value = string.IsNullOrEmpty(onEntry.OnAttribute)
                ? htmlNode.InnerText
                : GetAttributeValue(element: htmlNode, attribute: onEntry.OnAttribute);

            // normalization (before and after regular expression)
            value = ValueFactory(onEntry, value);
            value = Regex.Match(input: value, pattern: onEntry.RegularExpression).Value;
            value = ValueFactory(onEntry, value);

            // result
            return new KeyValuePair<string, object>(key: onEntry.Key, value);
        }

        private static string ValueFactory(ContentEntry entry, string value)
        {
            // message configuration
            if (entry.Trim)
            {
                value = value.Trim();
            }
            if (entry.ClearLinesBreak)
            {
                value = Regex.Replace(input: value, pattern: @"(\r\n|\r|\n)", " ");
            }

            // results
            return value;
        }
        #endregion

        #region *** HTML/Elements Cache     ***
        private IEnumerable<HtmlNode> GetRootElements(ExtractionRule extraction, bool isFromSource)
        {
            // setup
            var body = isFromSource ? WebDriver.PageSource : WebDriver.GetElement(By.XPath("//body")).GetSource();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(body);

            // result
            return htmlDocument.DocumentNode.SelectNodes(extraction.OnRootElements);
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

        #region *** Special Attributes      ***
        [Description("html")]
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Used by reflection, must be non-static.")]
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by reflection, must be private.")]
        private string Html(HtmlNode element) => element.OuterHtml;
        #endregion
    }
}