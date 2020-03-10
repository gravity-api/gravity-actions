/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.UiCommon;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using Gravity.Plugins.Actions.Contracts;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.Linq;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiCommon
{
    [TestClass]
    public class GetScreenshotTests : ActionTests
    {
        // members: constants
        private const string OutputDir = "GetScreenshot";

        [TestMethod]
        public void GetScreenshotCreate()
        {
            ValidateAction<GetScreenshot>();
        }

        [TestMethod]
        public void GetScreenshotDocumentation()
        {
            ValidateActionDocumentation<GetScreenshot>(CommonPlugins.GetScreenshot);
        }

        [TestMethod]
        public void GetScreenshotDocumentationResourceFile()
        {
            ValidateActionDocumentation<GetScreenshot>(
                CommonPlugins.GetScreenshot, "get-screenshot.json");
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.png'}")]
        public void GetScreenshotDriverPositivePng(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositivePng(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.bmp'}")]
        public void GetScreenshotDriverPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.gif'}")]
        public void GetScreenshotDriverPositiveGif(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveGif(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.tiff'}")]
        public void GetScreenshotDriverPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//null'}")]
        public void GetScreenshotElementToActOnNull(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//negative'}")]
        public void GetScreenshotElementToActOnNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//stale'}")]
        public void GetScreenshotElementToActOnStale(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//none'}")]
        public void GetScreenshotElementToActOnNone(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositivePng(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveGif(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNull(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Null());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Negative());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementStale(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Stale());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNone(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.None());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (!Directory.Exists(OutputDir))
            {
                return;
            }
            Directory.Delete(path: OutputDir, recursive: true);
        }

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
                .ExtractionResults
                .ToArray()[0]
                .Entities.ElementAt(0)
                .EntityContent["screenshot"];
        }
    }
}
#pragma warning restore