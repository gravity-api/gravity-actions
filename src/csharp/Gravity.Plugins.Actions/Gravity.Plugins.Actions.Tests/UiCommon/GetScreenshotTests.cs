/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
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
    [DoNotParallelize]
    public class GetScreenshotTests : ActionTests
    {
        #region *** constants            ***
        private const string OutputDir = "GetScreenshot";
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
                pluginName: CommonPlugins.GetScreenshot);
        }

        [TestMethod]
        public void GetScreenshotDocumentationResourceFile()
        {
            AssertDocumentation<GetScreenshot>(
                pluginName: CommonPlugins.GetScreenshot,
                resource: "get_screenshot.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.tiff'}", "image-a.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.gif'}", "image-a.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.bmp'}", "image-a.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.png'}", "image-a.png")]
        public void GetScreenshotDriverPositive(string actionRule, string expected)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/{expected}"));
            Assert.IsTrue(screenshot.Contains(expected));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}", "image-b.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','onElement':'//positive'}", "image-b.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','onElement':'//positive'}", "image-b.png")]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','onElement':'//positive'}", "image-b.png")]
        public void GetScreenshotonElementPositive(string actionRule, string expected)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/{expected}"));
            Assert.IsTrue(screenshot.Contains(expected));
        }
        #endregion






        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//null'}")]
        public void GetScreenshotonElementNull(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//negative'}")]
        public void GetScreenshotonElementNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//stale'}")]
        public void GetScreenshotonElementStale(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//none'}")]
        public void GetScreenshotonElementNone(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: default);

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}")]
        public void GetScreenshotElementPositivePng(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','onElement':'//positive'}")]
        public void GetScreenshotElementPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','onElement':'//positive'}")]
        public void GetScreenshotElementPositiveGif(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','onElement':'//positive'}")]
        public void GetScreenshotElementPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Positive());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}")]
        public void GetScreenshotElementNull(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Null());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}")]
        public void GetScreenshotElementNegative(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Negative());

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}")]
        public void GetScreenshotElementStale(string actionRule)
        {
            // execute
            var screenshot = GetScreenshot(actionRule, by: MockBy.Stale());

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','onElement':'//positive'}")]
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
                .Extractions
                .ToArray()[0]
                .Entities.ElementAt(0)
                .EntityContent["screenshot"]
                .ToString();
        }
    }
}
#pragma warning restore