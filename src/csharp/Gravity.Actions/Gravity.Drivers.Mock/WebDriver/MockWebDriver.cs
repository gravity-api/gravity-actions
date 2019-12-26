using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gravity.Drivers.Mock.WebDriver
{
    /// <summary>
    /// Defines the interface through which the user controls the browser.
    /// </summary>
    public class MockWebDriver : IWebDriver, IJavaScriptExecutor, IHasSessionId, IActionExecutor, IHasInputDevices
    {
        public MockWebDriver() : this(".") { }

        public MockWebDriver(string driverBinaries)
            : this(driverBinaries, new Dictionary<string, object>())
        { }

        public MockWebDriver(string driverBinaries, IDictionary<string, object> capabilities)
        {
            SetChildWindows(capabilities);

            CurrentWindowHandle = WindowHandles[0];
            SessionId = new SessionId($"mock-session{Guid.NewGuid()}");
            DriverBinaries = driverBinaries;
            Capabilities = capabilities;
        }

        /// <summary>
        /// Gets or sets the URL the browser is currently displaying.
        /// </summary>
        public string Url { get; set; } = "http://mockgravityapiurl.com/";

        /// <summary>
        /// Gets the title of the current browser window.
        /// </summary>
        public string Title => "Mock Gravity API Page Title";

        /// <summary>
        /// Gets the source of the page last loaded by the browser.
        /// </summary>
        public string PageSource => new StringBuilder()
            .Append("<html>")
            .Append("   <head>".Trim())
            .Append("       <body class=\"mockClass\">".Trim())
            .Append("           <div id=\"mockDiv\">mock div text</div>".Trim())
            .Append("           <positive>mock div text 1</positive>".Trim())
            .Append("           <positive>mock div text 2</positive>".Trim())
            .Append("           <positive>mock div text 3</positive>".Trim())
            .Append("       </body>".Trim())
            .Append("   </head>".Trim())
            .Append("</html>")
            .ToString();

        /// <summary>
        /// Gets the current window handle, which is an opaque handle to this window that
        /// uniquely identifies it within this driver instance.
        /// </summary>
        public string CurrentWindowHandle { get; set; }

        /// <summary>
        /// Get the current driver binaries location.
        /// </summary>
        public string DriverBinaries { get; }

        /// <summary>
        /// Gets the window handles of open browser windows.
        /// </summary>
        public ReadOnlyCollection<string> WindowHandles { get; private set; }

        /// <summary>
        /// Gets the session ID of the current session.
        /// </summary>
        public SessionId SessionId { get; }

        public IKeyboard Keyboard => new MockKeyboard();

        public IMouse Mouse => new MockMouse();

        public bool IsActionExecutor => true;

        public IDictionary<string, object> Capabilities { get; }

        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open.
        /// </summary>
        public void Close()
        {
            // exception conditions
            var isKey = Capabilities.ContainsKey(MockCapabilities.ThrowOnClose);
            var isException = isKey && (bool)Capabilities[MockCapabilities.ThrowOnClose];
            if (isException)
            {
                throw new WebDriverException();
            }

            // exit conditions
            if (WindowHandles.Count == 0)
            {
                return;
            }

            // remove current windows
            var windowHandles = WindowHandles.ToList();
            windowHandles.Remove(CurrentWindowHandle);
            WindowHandles = new ReadOnlyCollection<string>(windowHandles);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
            WindowHandles = new ReadOnlyCollection<string>(new List<string>());
        }

        /// <summary>
        /// Executes JavaScript asynchronously in the context of the currently selected frame
        /// or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        public object ExecuteAsyncScript(string script, params object[] args) => ExecuteScript(script, args);

        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window.
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>The value returned by the script.</returns>
        public object ExecuteScript(string script, params object[] args)
        {
            // for outer HTML
            if (script == "return arguments[0].outerHTML;")
            {
                return
                    "<div mock-attribute=\"mock attribute value\">mock element inner-text" +
                    "   <div mock-attribute=\"mock attribute value\">mock element nested inner-text</div>" +
                    "   <positive mock-attribute=\"mock attribute value\">mock element nested inner-text</positive>" +
                    "   <positive mock-attribute=\"mock attribute value\">mock element nested inner-text</positive>" +
                    "   <positive mock-attribute=\"mock attribute value\">mock element nested inner-text</positive>" +
                    "</div>";
            }

            // for scrip macro
            if (script == "script-macro")
            {
                return "some text and number 777";
            }

            // for action rule
            if(script?.Length == 0 || script == "console.log('unit testing');")
            {
                return string.Empty;
            }

            // for element
            var isArgs = args.Length == 1;
            var isElement = isArgs && args[0].GetType() == typeof(MockWebElement);
            var isSrc = script == "arguments[0].checked=false;";
            if (isElement && isSrc)
            {
                return string.Empty;
            }

            // for ready state
            if(script == "return document.readyState;")
            {
                return "complete";
            }

            // invalid script
            throw new WebDriverException();
        }

        /// <summary>
        /// Finds the first OpenQA.Selenium.IWebElement using the given method.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>The first matching OpenQA.Selenium.IWebElement on the current context.</returns>
        public IWebElement FindElement(By by)
        {
            return ElementFactory(by);
        }

        /// <summary>
        /// Finds all OpenQA.Selenium.IWebElement within the current context using the given
        /// mechanism.
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns> A System.Collections.ObjectModel.ReadOnlyCollection`1 of all OpenQA.Selenium.IWebElement
        /// matching the current criteria, or an empty list if nothing matches.</returns>
        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            var value = typeof(By)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => string.Equals(p.Name, "description", StringComparison.CurrentCultureIgnoreCase))
                .GetValue(by)
                .ToString()
                .ToLower();
            //
            // set default elements value
            var defaultElements = new ReadOnlyCollection<IWebElement>(new List<IWebElement>
            {
                new MockWebElement("div", "Mock: Positive Element", true, true, true),
                new MockWebElement("div", "Mock: Negative Element", false, false, false)
            });
            //
            // switch cases
            if (value.Contains("positive"))
            {
                defaultElements = new ReadOnlyCollection<IWebElement>(new List<IWebElement>
                {
                    new MockWebElement("div", "Mock: Positive Element", true, true, true),
                    new MockWebElement("div", "Mock: Negative Element", true, true, true)
                });
            }
            if (value.Contains("negative"))
            {
                defaultElements = new ReadOnlyCollection<IWebElement>(new List<IWebElement>
                {
                    new MockWebElement("div", "Mock: Positive Element", false, false, false),
                    new MockWebElement("div", "Mock: Negative Element", false, false, false)
                });
            }
            if (value.Contains("none"))
            {
                throw new NoSuchElementException("Mock: No Such Element Exception");
            }
            return defaultElements;
        }

        /// <summary>
        /// Instructs the driver to change its settings.
        /// </summary>
        /// <returns> An OpenQA.Selenium.IOptions object allowing the user to change the settings of
        /// the driver.</returns>
        public IOptions Manage()
        {
            return new MockOptions();
        }

        /// <summary>
        /// Instructs the driver to navigate the browser to another location.
        /// </summary>
        /// <returns>
        /// An <see cref="INavigation" /> object allowing the user to access
        /// the browser's history and to navigate to a given URL.
        /// </returns>
        public INavigation Navigate()
        {
            return new MockNavigation();
        }

        /// <summary>
        /// Quits this driver, closing every associated window.
        /// </summary>
        public void Quit()
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Instructs the driver to send future commands to a different frame or window.
        /// </summary>
        /// <returns>
        /// An <see cref="T:OpenQA.Selenium.ITargetLocator" /> object which can be used to select
        /// a frame or window.
        /// </returns>
        public ITargetLocator SwitchTo()
        {
            return new MockTargetLocator(this);
        }

        public void PerformActions(IList<ActionSequence> actionSequenceList)
        {
            // mock method - should not do anything
        }

        public void ResetInputState()
        {
            // mock method - should not do anything
        }

        public static IWebElement ElementFactory(By by)
        {
            // get 'by' information
            var value = typeof(By)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => string.Equals(p.Name, "description", StringComparison.CurrentCultureIgnoreCase))
                .GetValue(by)
                .ToString()
                .ToLower();
            //
            // set default element value
            var defaultElement = new MockWebElement("div", "Mock: Positive Element", true, true, true);
            //
            // switch cases
            if (value.Contains("positive"))
            {
                return defaultElement;
            }
            if (value.Contains("negative"))
            {
                defaultElement = new MockWebElement("div", "Mock: Negative Element", false, false, false);
            }
            if (value.Contains("none"))
            {
                throw new NoSuchElementException("Mock: No Such Element Exception");
            }
            if (value.Contains("stale"))
            {
                throw new StaleElementReferenceException("Mock: Stale Element Reference Exception");
            }
            return defaultElement;
        }

        private void SetChildWindows(IDictionary<string, object> capabilities)
        {
            // normalize number of child windows
            int windows = 0;
            if (capabilities.ContainsKey(MockCapabilities.ChildWindows))
            {
                int.TryParse($"{capabilities[MockCapabilities.ChildWindows]}", out windows);
            }

            // setup window handles
            var windowHandles = new List<string>
            {
                $"window-{Guid.NewGuid()}"
            };

            for (int i = 0; i < windows; i++)
            {
                windowHandles.Add($"window-{Guid.NewGuid()}");
            }

            WindowHandles = new ReadOnlyCollection<string>(windowHandles);
        }
    }
}