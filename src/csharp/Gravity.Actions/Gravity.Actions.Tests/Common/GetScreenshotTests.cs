/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using OpenQA.Selenium.Mock;
using Gravity.Plugins.Actions.Common;
using Gravity.Plugins.Actions.UnitTests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.Common
{
    [TestClass]
    public class GetScreenshotTests : ActionTests
    {
        // members: constants
        private const string OutputDir = "GetScreenshot";

        [TestMethod]
        public void GetScreenshotCreateNoTypes()
        {
            ValidateAction<GetScreenshot>();
        }

        [TestMethod]
        public void GetScreenshotCreateTypes()
        {
            ValidateAction<GetScreenshot>(Types);
        }

        [TestMethod]
        public void GetScreenshotDocumentationNoTypes()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot);
        }

        [TestMethod]
        public void GetScreenshotDocumentationTypes()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot, Types);
        }

        [TestMethod]
        public void GetScreenshotDocumentationResourceFile()
        {
            ValidateActionDocumentation<GetScreenshot>(ActionType.GetScreenshot, Types, "get-screenshot.json");
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.png'}")]
        public void GetScreenshotDriverPositivePng(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositivePng(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.bmp'}")]
        public void GetScreenshotDriverPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.gif'}")]
        public void GetScreenshotDriverPositiveGif(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveGif(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-a.tiff'}")]
        public void GetScreenshotDriverPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion
            Assert.IsTrue(File.Exists($"{OutputDir}/image-a.png"));
            Assert.IsTrue(screenshot.Contains("image-a.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','elementToActOn':'//positive'}")]
        public void GetScreenshotElementToActOnPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//null'}")]
        public void GetScreenshotElementToActOnNull(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//negative'}")]
        public void GetScreenshotElementToActOnNegative(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//stale'}")]
        public void GetScreenshotElementToActOnStale(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//none'}")]
        public void GetScreenshotElementToActOnNone(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositivePng(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Positive(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.bmp','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveBmp(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Positive(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.gif','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveGif(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Positive(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.tiff','elementToActOn':'//positive'}")]
        public void GetScreenshotElementPositiveTiff(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Positive(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNull(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Null(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNegative(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Negative(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementStale(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.Stale(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(File.Exists($"{OutputDir}/image-b.png"));
            Assert.IsTrue(screenshot.Contains("image-b.png"));
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'actionType':'GetScreenshot','argument':'" + OutputDir + "/image-b.png','elementToActOn':'//positive'}")]
        public void GetScreenshotElementNone(string actionRule)
        {
            // execute
            var screenshot = ExecuteAction<GetScreenshot>(MockBy.None(), actionRule)
                .ExtractionResults[0]
                .Entities[0]
                .EntityContentEntries["screenshot"];

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
    }
}
#pragma warning restore