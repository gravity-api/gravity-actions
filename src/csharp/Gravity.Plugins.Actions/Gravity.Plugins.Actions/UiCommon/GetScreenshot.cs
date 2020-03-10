/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2020-01-20
 *    - modify: add constructor to override base class types
 * 
 * 2019-06-20
 *    -    fix: extraction returned without session information
 * 
 * 2019-01-12
 *    - modify: improve XML comments
 *    - modify: override action-name using ActionType constant
 *    
 * on-line resources
 */
using OpenQA.Selenium.Extensions;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Base;
using Gravity.Plugins.Contracts;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.get-screenshot.json",
        Name = CommonPlugins.GetScreenshot)]
    public class GetScreenshot : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="webAutomation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public GetScreenshot(WebAutomation webAutomation, IWebDriver driver)
            : base(webAutomation, driver)
        { }
        #endregion

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(element: default, actionRule);
        }

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="actionRule">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule actionRule, IWebElement element)
        {
            DoAction(element, actionRule);
        }

        // execute action routine
        private void DoAction(IWebElement element, ActionRule actionRule)
        {
            // get format > get file
            var format = GetFormat(actionRule.Argument);
            var file = GetFile(format, actionRule.Argument);

            // take from driver
            if (element == default && string.IsNullOrEmpty(actionRule.ElementToActOn))
            {
                ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(fileName: file, format);
            }
            // take from element
            else
            {
                var timeout = TimeSpan.FromMilliseconds(WebAutomation.EngineConfiguration.ElementSearchingTimeout);
                var e = element != default
                    ? element.GetElementByActionRule(ByFactory, actionRule, timeout)
                    : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

                ((ITakesScreenshot)e).GetScreenshot().SaveAsFile(fileName: file, format);
            }

            // add file to extraction results
            AddToExtraction(file);
        }

        // get image format factory
        private static ScreenshotImageFormat GetFormat(string file) => (Path.GetExtension(file).ToUpper()) switch
        {
            _ => ScreenshotImageFormat.Png
        };

        // get new file name
        private static string GetFile(ScreenshotImageFormat format, string file)
        {
            // get folder
            var folder = Path.GetDirectoryName(file);

            // extract file name
            var name = Path.GetFileNameWithoutExtension(file);

            // normalize format
            var nformat = $"{format}".ToLower();

            // return new file name
            return string.IsNullOrEmpty(folder)
                ? $"{name}.{nformat}"
                : CreatePath($@"{folder}\{name}.{nformat}");
        }

        // creates a path if not exists before saving the image file
        private static string CreatePath(string file)
        {
            var directory = Path.GetDirectoryName(file);
            Directory.CreateDirectory(directory);
            return file;
        }

        // adds the screen-shot entry to the current extractions results
        private void AddToExtraction(string file)
        {
            // setup
            var imageEntry = new Dictionary<string, string>
            {
                ["screenshot"] = file
            };
            var imageEntity = new Entity { EntityContent = imageEntry };

            // create an extraction entity
            var imageExtraction = new Extraction().GetDefault(WebDriver?.GetSession()?.ToString());
            imageExtraction.Entities = new[] { imageEntity };

            // add to extractions collection
            ExtractionResults.Add(imageExtraction);
        }
    }
}
#pragma warning restore