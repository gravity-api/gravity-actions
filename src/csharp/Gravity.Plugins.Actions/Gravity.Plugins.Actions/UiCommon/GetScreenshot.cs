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
 *    - modify: override action-name using action constant
 *    
 * RESOURCES
 */
using Gravity.Extensions;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Framework;
using Gravity.Plugins.Contracts;

using OpenQA.Selenium;
using OpenQA.Selenium.Extensions;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Gravity.Plugins.Actions.UiCommon
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Manifest.GetScreenshot.json",
        Name = GravityPlugins.GetScreenshot)]
    public class GetScreenshot : WebDriverActionPlugin
    {
        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public GetScreenshot(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action, element: default);
        }

        /// <summary>
        /// Saves the screen shot to a file, overwriting the file if it already exists.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action, element);
        }

        // execute action routine
        private void DoAction(ActionRule action, IWebElement element)
        {
            // get format > get file
            var format = GetFormat(action.Argument);
            var file = GetFile(format, action.Argument);

            // take from driver
            if (element == default && string.IsNullOrEmpty(action.OnElement))
            {
                ((ITakesScreenshot)WebDriver).GetScreenshot().SaveAsFile(fileName: file, format);
            }
            // take from element
            else
            {
                var timeout = TimeSpan.FromMilliseconds(Automation.EngineConfiguration.SearchTimeout);
                var e = element != default
                    ? element.GetElement(ByFactory, action, timeout)
                    : WebDriver.GetElement(ByFactory, action, timeout);

                ((ITakesScreenshot)e).GetScreenshot().SaveAsFile(fileName: file, format);
            }

            // add file to extraction results
            AddToExtraction(file);
        }

        // get image format factory
        [SuppressMessage("Major Code Smell", "S1172:Unused method parameters should be removed", Justification = "Warning false positive.")]
        [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Warning S1172 false positive.")]
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
            var imageEntry = new Dictionary<string, object>
            {
                ["screenshot"] = file
            };
            var imageEntity = new Entity { Content = imageEntry };

            // create an extraction entity
            var imageExtraction = new Extraction().GetDefault(WebDriver?.GetSession()?.ToString());
            imageExtraction.Entities = new[] { imageEntity };

            // add to extractions collection
            Extractions.Add(imageExtraction);
        }
    }
}