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
using Gravity.Drivers.Selenium;
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Common
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.get-screenshot.json",
        Name = ActionType.GetScreenshot)]
    public class GetScreenshot : ActionPlugin
    {
        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public GetScreenshot(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public GetScreenshot(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoAction(webElement: default, actionRule, TimeSpan.FromMilliseconds(ElementSearchTimeout));
        }

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoAction(webElement, actionRule, TimeSpan.FromMilliseconds(ElementSearchTimeout));
        }

        // execute action routine
        private void DoAction(IWebElement webElement, ActionRule actionRule, TimeSpan timeout)
        {
            // get format > get file
            var format = GetFormat(actionRule.Argument);
            var file = GetFile(format, actionRule.Argument);

            // take from driver
            if (webElement == default && string.IsNullOrEmpty(actionRule.ElementToActOn))
            {
                ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(fileName: file, format);
            }
            // take from element
            else
            {
                var element = webElement != default
                    ? webElement.GetElementByActionRule(ByFactory, actionRule, timeout)
                    : WebDriver.GetElementByActionRule(ByFactory, actionRule, timeout);

                ((ITakesScreenshot)element).GetScreenshot().SaveAsFile(fileName: file, format);
            }

            // add file to extraction results
            AddToExtraction(file);
        }

        // get image format factory
        private static ScreenshotImageFormat GetFormat(string file) => (Path.GetExtension(file).ToUpper()) switch
        {
            ".BMP" => ScreenshotImageFormat.Png,
            ".GIF" => ScreenshotImageFormat.Png,
            ".JPEG" => ScreenshotImageFormat.Png,
            ".TIFF" => ScreenshotImageFormat.Png,
            _ => ScreenshotImageFormat.Png,
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
            var imageEntity = new Entity { EntityContentEntries = imageEntry };

            // create an extraction entity
            var imageExtraction = new Extraction().GetDefault(WebDriver?.GetSession()?.ToString());
            imageExtraction.Entities = new[] { imageEntity };

            // add to extractions collection
            ExtractionResults.Add(imageExtraction);
        }
    }
}
#pragma warning restore