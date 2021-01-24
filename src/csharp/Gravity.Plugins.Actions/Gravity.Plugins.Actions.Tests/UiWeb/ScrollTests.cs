/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;

#pragma warning disable S4144
namespace Gravity.UnitTests.UiWeb
{
    [TestClass]
    public class ScrollTests : ActionTests
    {
        #region *** tests: documentation ***
        [TestMethod]
        public void ScrollCreate()
        {
            AssertPlugin<Scroll>();
        }

        [TestMethod]
        public void ScrollDocumentation()
        {
            AssertDocumentation<Scroll>(pluginName: PluginsList.Scroll);
        }

        [TestMethod]
        public void ScrollDocumentationResourceFile()
        {
            AssertDocumentation<Scroll>(
                pluginName: PluginsList.Scroll,
                resource: "scroll.json");
        }
        #endregion

        #region *** tests: OnDriver      ***
        [DataTestMethod]
        [DataRow("{'argument':'1000'}")]
        [DataRow("{'argument':'{{$ --top:1000}}'}")]
        public void ScrollWindowTop(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --left:1000}}'}")]
        public void ScrollWindowLeft(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == 1000);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500}}'}")]
        public void ScrollWindowTopLeft(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == 1000);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == 500);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:auto}}'}")]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:smooth}}'}")]
        public void ScrollWindowTopLeftBehavior(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == 1000);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == 500);
        }

        [TestMethod]
        public void ScrollWindowNoArgument()
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>();

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'argument':'1000','onElement':'//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000}}','onElement':'//positive'}")]
        public void ScrollElementTop(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;

            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --left:1000}}','onElement':'//positive'}")]
        public void ScrollElementLeft(string actionRule)
        {
            // expected
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500}}','onElement':'//positive'}")]
        public void ScrollElementTopLeft(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:auto}}','onElement':'//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:smooth}}','onElement':'//positive'}")]
        public void ScrollElementTopLeftBehavior(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'//positive'}")]
        [DataRow("{'onElement':'//negative'}")]
        public void ScrollElementNoArgument(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverTimeoutException))]
        [DataRow("{'onElement':'//null'}")]
        [DataRow("{'onElement':'//none'}")]
        [DataRow("{'onElement':'//stale'}")]
        [DataRow("{'onElement':'//exception'}")]
        public void ScrollElementTimout(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(true);
        }
        #endregion

        #region *** tests: OnElement     ***
        [DataTestMethod]
        [DataRow("{'argument':'1000','onElement':'.//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000}}','onElement':'.//positive'}")]
        public void ScrollNestedElementTop(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --left:1000}}','onElement':'.//positive'}")]
        public void ScrollNestedElementLeft(string actionRule)
        {
            // expected
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500}}','onElement':'.//positive'}")]
        public void ScrollNestedElementTopLeft(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:auto}}','onElement':'.//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:smooth}}','onElement':'.//positive'}")]
        public void ScrollNestedElementTopLeftBehavior(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//positive'}")]
        [DataRow("{'onElement':'.//negative'}")]
        public void ScrollNestedElementNoArgument(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod]
        [DataRow("{'onElement':'.//null'}")]
        public void ScrollNestedElementNull(string actionRule)
        {
            // expected
            var y = WebDriver.Manage().Window.Position.Y;
            var x = WebDriver.Manage().Window.Position.X;

            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(WebDriver.Manage().Window.Position.Y == y);
            Assert.IsTrue(WebDriver.Manage().Window.Position.X == x);
        }

        [DataTestMethod, ExpectedException(typeof(NoSuchElementException))]
        [DataRow("{'onElement':'.//none'}")]
        public void ScrollNestedElementNone(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'onElement':'.//stale'}")]
        public void ScrollNestedElementStale(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'onElement':'.//exception'}")]
        public void ScrollNestedElementException(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }
        #endregion
    }
}
#pragma warning restore S4144
