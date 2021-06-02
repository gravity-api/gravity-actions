/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Gravity.Plugins.Utilities;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.ExtractFromDom.json",
        Name = GravityPlugins.ExtractFromDom)]
    public class ExtractFromDom : WebDriverActionPlugin
    {
        // members
        private readonly MacroFactory macroFactory;
        private readonly ExtractionSegmentsFactory segmentsFactory;
        private readonly DataProvidersFactory providersFactory;

        #region *** arguments       ***
        /// <summary>
        /// A list of ExtractionRule to execute. This is a zero-based index based on
        /// <see cref="WebAutomation.Extractions"/> collection.
        /// </summary>
        public const string ExtractionsKey = "extractions";
        #endregion

        #region *** constructors    ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public ExtractFromDom(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        {
            macroFactory = new MacroFactory(Types);
            segmentsFactory = new ExtractionSegmentsFactory(driver, Types);
            providersFactory = new DataProvidersFactory(Types);
        }
        #endregion

        /// <summary>
        /// Executes ExtractionRule collection under this <see cref="Plugin.Automation"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            InvokeAction(action);
        }

        /// <summary>
        /// Executes ExtractionRule collection under this <see cref="Plugin.Automation"/>.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            InvokeAction(action);
        }

        // execute action routine
        private void InvokeAction(ActionRule action)
        {
            // setup
            var arguments = CliFactory.Parse(action.Argument);
            var extractionsList = arguments.ContainsKey(ExtractionsKey)
                ? arguments[ExtractionsKey].Split(',')
                : Array.Empty<string>();
            var extrctions = Automation.GetExtractionRules(extractions: extractionsList);

            for (int i = 0; i < extrctions.Count(); i++)
            {
                DoExtraction(extraction: extrctions.ElementAt(i), key: $"{i}_{WebDriver.GetSession()}");
            }
        }

        #region *** Data Extraction ***
        private void DoExtraction(ExtractionRule extraction, string key)
        {
            // setup
            var onElements = WebDriver.GetElements(By.XPath(extraction.OnRootElements)).ToList();
            var results = new List<Entity>();

            // extract from source
            for (int i = 0; i < onElements.Count; i++)
            {
                if (onElements[i].IsStale())
                {
                    onElements = WebDriver.GetElements(By.XPath(extraction.OnRootElements)).ToList();
                }
                var entity = DoContentEntriesFromDom(extraction, element: onElements[i], i);
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
            if (extraction.DataProvider?.WritePerEntity == false)
            {
                providersFactory.To(extraction.DataProvider, new[] { onExtraction });
            }
        }
        #endregion

        #region *** Data Source     ***
        private Entity DoContentEntriesFromDom(ExtractionRule extraction, IWebElement element, int i)
        {
            // setup
            var entity = new Entity()
            {
                Content = new Dictionary<string, object>()
            };
            entity.Content["entityIndex"] = i;

            // extract
            foreach (var entry in extraction.OnElements)
            {
                var contentEntry = DoContentEntryFromDom(entry, element);
                entity.Content[contentEntry.Key] = contentEntry.Value;
                ExecuteSubActions(actions: entry.Actions, element);
            }

            // populate
            if (extraction.DataProvider?.WritePerEntity == true)
            {
                var onExtraction = new Extraction { Entities = new[] { entity } };
                providersFactory.To(extraction.DataProvider, new[] { onExtraction });
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
                : onElement.GetAttribute(onEntry.OnAttribute);

            if (segmentsFactory.IsSegment(onEntry))
            {
                value = segmentsFactory.Factor(onEntry, new object[] { onElement, onEntry.OnAttribute });
            }

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
                value = value.RemoveLines();
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
    }
}