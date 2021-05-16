/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Contracts;
using Gravity.UnitTests.Base;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium.Mock;
using OpenQA.Selenium;

using System.IO;
using System;
using System.Linq;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiCommon
{
    [TestClass]
    [DoNotParallelize]
    public class GetScreenshotTests : ActionTests
    {
        #region *** constants            ***
        private const string OutputDir = "GetScreenshot";
        #endregion

        #region *** tests: life cycle    ***
        [TestCleanup]
        public void Cleanup()
        {
            if (!Directory.Exists(OutputDir))
            {
                return;
            }
            Directory.Delete(path: OutputDir, recursive: true);
        }
        #endregion

        #region *** tests: documentation ***
        [TestMethod]
        public void GetScreenshotCreate()
        {
            AssertPlugin<GetScreenshot>();
        }

        [TestMethod]
        public void GetScreenshotDocumentation()
        {
            AssertDocumentation<GetScreenshot>(
                pluginName: GravityPlugin.GetScreenshot);
        }

        [TestMethod]
        public void GetScreenshotDocumentationResourceFile()
        {
            AssertDocumentation<GetScreenshot>(
                pluginName: GravityPlugin.GetScreenshot,
                resource: "GetScreenshot.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-a.tiff\"}", "image-a.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-a.gif\"}", "image-a.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-a.bmp\"}", "image-a.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-a.png\"}", "image-a.png")]
        public void GetScreenshotDriverPositive(string actionRule, string expected)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/{expected}"));
            Assert.IsTrue(screenshot.Contains(expected));
        }

        [DataTestMethod]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\"//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.bmp\",\"onElement\":\"//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.gif\",\"onElement\":\"//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.tiff\",\"onElement\":\"//positive\"}", "image-b.png")]
        public void GetScreenshotOnElementPositive(string actionRule, string expected)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion (no assertion here)
            Assert.IsTrue(File.Exists($"{OutputDir}/{expected}"));
            Assert.IsTrue(screenshot.Contains(expected));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\"//none\"}")]
        public void GetScreenshotOnElementNoElement(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: default);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\"//null\"}")]
        public void GetScreenshotOnElementNull(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: default);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\"//stale\"}")]
        public void GetScreenshotOnElementStale(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: default);

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\"//negative\"}")]
        public void GetScreenshotOnElementNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\".//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.bmp\",\"onElement\":\".//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.gif\",\"onElement\":\".//positive\"}", "image-b.png")]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.tiff\",\"onElement\":\".//positive\"}", "image-b.png")]
        public void GetScreenshotElementPositive(string actionRule, string expected)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/{expected}"));
            Assert.IsTrue(screenshot.Contains(expected));
        }

        [DataTestMethod, ExpectedException(typeof(NullReferenceException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\".//null\"}")]
        public void GetScreenshotElementNull(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\".//negative\"}")]
        public void GetScreenshotElementNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\".//stale\"}")]
        public void GetScreenshotElementStale(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{\"action\":\"GetScreenshot\",\"argument\":\"" + OutputDir + "/image-b.png\",\"onElement\":\".//none\"}")]
        public void GetScreenshotElementNone(string actionRule)
        {
            // execute
            GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion (no assertion here)
            Assert.IsTrue(true);
        }
        #endregion

        #region *** utilities            ***
        // gets a screenshot plugin result
        private string GetScreenshot(string actionRule, By by)
        {
            // execute
            if (by != default)
            {
                ExecuteAction<GetScreenshot>(by, actionRule);
            }
            var plugin = ExecuteAction<GetScreenshot>(actionRule);

            // get results
            return plugin
                .Extractions
                .ToArray()[0]
                .Entities
                .ElementAt(0)
                .Content["screenshot"]
                .ToString();
        }
        #endregion
    }
}
#pragma warning restore