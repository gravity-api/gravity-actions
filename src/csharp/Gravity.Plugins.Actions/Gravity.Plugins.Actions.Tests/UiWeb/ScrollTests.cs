/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiWeb;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Mock;
using System;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiWeb
{
    [TestClass]
    public class ScrollTests : ActionTests
    {
        [TestMethod]
        public void ScrollCreate() => ValidateAction<Scroll>();

        [TestMethod]
        public void ScrollDocumentation()
            => ValidateActionDocumentation<Scroll>(WebPlugins.Scroll);

        [TestMethod]
        public void ScrollDocumentationResourceFile()
            => ValidateActionDocumentation<Scroll>(WebPlugins.Scroll, "scroll.json");

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
        [DataRow("{'argument':'1000','elementToActOn':'//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000}}','elementToActOn':'//positive'}")]
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
        [DataRow("{'argument':'{{$ --left:1000}}','elementToActOn':'//positive'}")]
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
        [DataRow("{'argument':'{{$ --top:1000 --left:500}}','elementToActOn':'//positive'}")]
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
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:auto}}','elementToActOn':'//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:smooth}}','elementToActOn':'//positive'}")]
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
        [DataRow("{'elementToActOn':'//positive'}")]
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
        [DataRow("{'elementToActOn':'//null'}")]
        [DataRow("{'elementToActOn':'//none'}")]
        [DataRow("{'elementToActOn':'//stale'}")]
        public void ScrollElementTimout(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'//exception'}")]
        public void ScrollElementException(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod]
        [DataRow("{'argument':'1000','elementToActOn':'.//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000}}','elementToActOn':'.//positive'}")]
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
        [DataRow("{'argument':'{{$ --left:1000}}','elementToActOn':'.//positive'}")]
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
        [DataRow("{'argument':'{{$ --top:1000 --left:500}}','elementToActOn':'.//positive'}")]
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
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:auto}}','elementToActOn':'.//positive'}")]
        [DataRow("{'argument':'{{$ --top:1000 --left:500, --behavior:smooth}}','elementToActOn':'.//positive'}")]
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
        [DataRow("{'elementToActOn':'.//positive'}")]
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
        [DataRow("{'elementToActOn':'.//null'}")]
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
        [DataRow("{'elementToActOn':'.//none'}")]
        public void ScrollNestedElementNone(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(StaleElementReferenceException))]
        [DataRow("{'elementToActOn':'.//stale'}")]
        public void ScrollNestedElementStale(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }

        [DataTestMethod, ExpectedException(typeof(WebDriverException))]
        [DataRow("{'elementToActOn':'.//exception'}")]
        public void ScrollNestedElementException(string actionRule)
        {
            // execute
            ExecuteAction<Scroll>(MockBy.Positive(), actionRule);

            // assertion
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144
