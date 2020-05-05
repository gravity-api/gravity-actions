/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Gravity.Plugins.Extensions;
using Gravity.Plugins.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.extract_from_dom.json",
        Name = Contracts.PluginsList.ExtractFromDom)]
    public class ExtractFromDom : WebDriverActionPlugin
    {
        // members
        private readonly MacroFactory macroFactory;

        #region *** arguments    ***
        /// <summary>
        /// A list of <see cref="ExtractionRule"/> to execute. This is a zero-based index based on
        /// <see cref="WebAutomation.Extractions"/> collection.
        /// </summary>
        public const string ExtractionsKey = "extractions";
        #endregion

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExtractFromDom(WebAutomation automation, IWebDriver driver)
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
            var eList = arguments.ContainsKey(ExtractionsKey) ? arguments[ExtractionsKey].Split(',') : Array.Empty<string>();
            var extrctions = Automation.GetExtractionRules(extractions: eList);

            for (int i = 0; i < extrctions.Count(); i++)
            {
                DoExtraction(extraction: extrctions.ElementAt(i), key: $"{i}_{WebDriver.GetSession()}");
            }
        }

        #region *** Data Extraction        ***
        private void DoExtraction(ExtractionRule extraction, string key)
        {
            // setup
            var onElements = GetRootElements(extraction);
            var results = new List<Entity>();

            // extract from source
            for (int i = 0; i < onElements.Count(); i++)
            {
                if (onElements.ElementAt(i).IsStale())
                {
                    onElements = GetRootElements(extraction);
                }
                var entity = DoContentEntriesFromDom(extraction, element: onElements.ElementAt(i), i);
                results.Add(entity);
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
            if (extraction.DataSource != default && !extraction.DataSource.WritePerEntity)
            {
                onExtraction.Populate(extraction.DataSource);
            }
        }
        #endregion

        #region *** Data Extraction Source ***
        private Entity DoContentEntriesFromDom(ExtractionRule extraction, IWebElement element, int i)
        {
            // setup
            var entity = new Entity()
            {
                Content = new Dictionary<string, object>()
            };
            entity.Content["EntityIndex"] = i;

            // extract
            foreach (var entry in extraction.OnElements)
            {
                var contentEntry = DoContentEntryFromDom(entry, element);
                entity.Content[contentEntry.Key] = contentEntry.Value;
                ExecuteSubActions(actions: entry.Actions, element);
            }

            // populate
            if (extraction.DataSource != default && extraction.DataSource.WritePerEntity)
            {
                entity.Populate(extraction.DataSource);
            }

            // result
            return entity;
        }

        private KeyValuePair<string, object> DoContentEntryFromDom(ContentEntry entry, IWebElement element)
        {
            // setup
            var onElement = element;
            var onEntry = macroFactory.Get(entry);

            // if not self, take from element or from page
            if (!string.IsNullOrEmpty(onEntry.OnElement))
            {
                onElement = onEntry.OnElement.IsXpath(isRelative: true)
                    ? element.FindElement(By.XPath(onEntry.OnElement))
                    : WebDriver.GetElement(By.XPath(onEntry.OnElement));
            }

            // exit conditions
            if (onElement == default)
            {
                return new KeyValuePair<string, object>(key: onEntry.Key, value: string.Empty);
            }

            // get value, take text or attribute
            var value = string.IsNullOrEmpty(onEntry.OnAttribute)
                ? onElement.Text
                : GetAttributeValue(element: onElement, attribute: onEntry.OnAttribute);

            // normalization (before and after regular expression)
            value = ValueFactory(onEntry, value);
            value = Regex.Match(input: value, pattern: onEntry.RegularExpression).Value;
            value = ValueFactory(onEntry, value);

            // result
            return new KeyValuePair<string, object>(key: onEntry.Key, value);
        }

        private string ValueFactory(ContentEntry entry, string value)
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

        private void ExecuteSubActions(IEnumerable<ActionRule> actions, IWebElement element)
        {
            // exit conditions
            if (!actions.Any())
            {
                return;
            }

            // iterate
            Executor ??= new AutomationExecutor(Automation);
            foreach (var action in actions)
            {
                Executor.PluginFactory.ConstructorParameters = new object[] { Automation, WebDriver };
                Executor.Execute(automation: Automation, action, parameters: new object[] { element });
            }
        }
        #endregion

        #region *** HTML/Elements Cache    ***
        private IEnumerable<IWebElement> GetRootElements(ExtractionRule extraction)
        {
            return WebDriver.GetElements(By.XPath(extraction.OnRootElements));
        }
        #endregion

        #region *** Extraction Rules       ***
        private string GetAttributeValue(IWebElement element, string attribute)
        {
            // special
            var attributeMethod = this.GetSpecialAttributeMethod<IWebElement>(attribute);

            // value
            return attributeMethod != default
                ? (string)attributeMethod.Invoke(this, new[] { element })
                : element.GetAttribute(attributeName: attribute);
        }
        #endregion

#pragma warning disable IDE0051
        #region *** Special Attributes     ***
        [Description("html")]
        private string Html(IWebElement element) => element.GetSource();
        #endregion
#pragma warning restore
    }
}