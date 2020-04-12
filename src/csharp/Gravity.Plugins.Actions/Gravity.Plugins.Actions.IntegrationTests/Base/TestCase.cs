/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

using TestContext = NUnit.Framework.TestContext;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;
using Gravity.Abstraction.Contracts;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Gravity.Plugins.Actions.IntegrationTests.Base
{
    [DeploymentItem("Resources/license.lcn")]
    public abstract class TestCase
    {
        // constants
        public const string UiControlsPage = "https://gravitymvctestapplication.azurewebsites.net/uicontrols/";
        public const string CoursesPage = "https://gravitymvctestapplication.azurewebsites.net/course/";
        public static readonly string HomePage = $"{TestContext.Parameters["Integration.ApplicationUnderTest"]}";

        // members: state
        private static readonly HttpClient browserStackClient = new HttpClient();
        private ConcurrentBag<AutomationEnvironment> environments;
        private int attempts =
            TestContext.Parameters.Get(name: "Integration.NumberOfAttempts", defaultValue: 1);

        /// <summary>
        /// Gets or sets the application under test for this <see cref="TestCase"/>
        /// </summary>
        public virtual string ApplicationUnderTest { get; set; } = UiControlsPage;

        #region *** automation     ***
        /// <summary>
        /// Executes <see cref="WebAutomation"/> sequence with a given <see cref="AutomationEnvironment"/> context.
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> to execute.</param>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns><see cref="OrbitResponse"/> instance.</returns>
        public static OrbitResponse ExecuteWebAutomation(WebAutomation webAutomation, AutomationEnvironment environment)
        {
            // execute
            var response = new AutomationExecutor(webAutomation).Execute().GetResponse();

            // add sessions to environment
            environment.TestParams["sessions"] = response.Extractions.Select(i => i.OrbitSession.SessionsId);

            // results
            return response;
        }

        /// <summary>
        /// Gets a <see cref="WebAutomation"/> instance based on driver and capabilities.
        /// </summary>
        /// <param name="driver"><see cref="Driver"/> to use with this <see cref="WebAutomation"/></param>
        /// <param name="capabilities">Capabilities collection for this <see cref="Driver"/></param>
        /// <returns><see cref="WebAutomation"/> instance.</returns>
        public WebAutomation GetWebAutomation(string driver, IDictionary<string, object> capabilities)
        {
            // shortcuts
            int.TryParse($"{TestContext.Parameters["Integration.PageTimeout"]}", out int pageOut);
            int.TryParse($"{TestContext.Parameters["Integration.ElementTimeout"]}", out int elementOut);

            // setup
            var pageLoadTimeout = pageOut != 0 ? pageOut : 60000;
            var elementSearchingTimeout = elementOut != 0 ? elementOut : 15000;

            // configuration
            var configuration = new EngineConfiguration
            {
                PageLoadTimeout = pageLoadTimeout,
                ElementSearchingTimeout = elementSearchingTimeout
            };

            // driver parameters
            var testName = GetTestName();
            var driverParams = GetDriverParams(driver, capabilities, testName);

            // result
            return new WebAutomation
            {
                DriverParams = driverParams,
                EngineConfiguration = configuration
            };
        }

        // gets test name from description attribute
        private string GetTestName()
        {
            // setup
            var method = new StackFrame(6).GetMethod();
            var description =
                method.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            // result
            return description == null ? method.Name : ((DescriptionAttribute)description).Description;
        }

        // gets driver parameters (with browserstack.com capabilities)
        private IDictionary<string, object> GetDriverParams(
            string driver,
            IDictionary<string, object> capabilities,
            string testName)
        {
            // setup
            var driverParams = new Dictionary<string, object>
            {
                ["driver"] = driver,
                ["driverBinaries"] = $"{TestContext.Parameters["Grid.Endpoint"]}"
            };
            var isLegacy = TestContext.Parameters.Get<bool>("Grid.Legacy", true);

            // apply capabilities
            capabilities = isLegacy
                ? SetBrowserStackLegacyCapabilities(capabilities, testName)
                : SetBrowserStackCapabilities(capabilities, testName);
            driverParams.Add(key: "capabilities", value: capabilities);

            // result
            return driverParams;
        }

        private IDictionary<string, object> SetBrowserStackLegacyCapabilities(
            IDictionary<string, object> capabilities,
            string testName)
        {
            // exit conditions
            if (!capabilities.ContainsKey("bstack:options"))
            {
                return capabilities;
            }

            // add capabilities
            var _capabilities = new Dictionary<string, object>
            {
                ["resolution"] = "1920x1080",
                ["project"] = $"{TestContext.Parameters["Project.Name"]}",
                ["build"] = $"{TestContext.Parameters["Build.Number"]}",
                ["name"] = testName,
                ["browserstack.ie.enablePopups"] = true
            };
            foreach (var capability in ((JObject)capabilities["bstack:options"]).ToObject<IDictionary<string, object>>())
            {
                _capabilities[capability.Key] = capability.Value;
            }
            capabilities.Remove("bstack:options");

            foreach (var capability in _capabilities)
            {
                capabilities[capability.Key] = capability.Value;
            }
            return capabilities;
        }

        private IDictionary<string, object> SetBrowserStackCapabilities(
            IDictionary<string, object> capabilities,
            string testName)
        {
            // exit conditions
            if (!capabilities.ContainsKey("bstack:options"))
            {
                return capabilities;
            }

            // add capabilities
            var _capabilities = new Dictionary<string, object>
            {
                ["resolution"] = "1920x1080",
                ["project"] = $"{TestContext.Parameters["Project.Name"]}",
                ["build"] = $"{TestContext.Parameters["Build.Number"]}",
                ["name"] = testName,
                ["browserstack.ie.enablePopups"] = true
            };
            foreach (var capability in ((JObject)capabilities["bstack:options"]).ToObject<IDictionary<string, object>>())
            {
                _capabilities[capability.Key] = capability.Value;
            }

            // apply
            capabilities["bstack:options"] = _capabilities;
            return capabilities;
        }

        /// <summary>
        /// Apply actions and extractions to the given <see cref="WebAutomation"/>.
        /// This (will automatically add GoToUrl & CloseBrowser).
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> to append to.</param>
        /// <param name="actions">A collection of <see cref="ActionRule"/> to append.</param>
        /// <param name="extractions">A collection of <see cref="ExtractionRule"/> to append.</param>
        /// <returns>Updated <see cref="WebAutomation"/> instance.</returns>
        public static WebAutomation AddWebActions(
            WebAutomation webAutomation,
            IEnumerable<ActionRule> actions,
            IEnumerable<ExtractionRule> extractions)
        {
            return DoAddWebActions(
                webAutomation,
                actions,
                extractions,
                applicationUnderTest: HomePage);
        }

        /// <summary>
        /// Apply actions and extractions to the given <see cref="WebAutomation"/>.
        /// This (will automatically add GoToUrl & CloseBrowser).
        /// </summary>
        /// <param name="webAutomation"><see cref="WebAutomation"/> to append to.</param>
        /// <param name="actions">A collection of <see cref="ActionRule"/> to append.</param>
        /// <param name="extractions">A collection of <see cref="ExtractionRule"/> to append.</param>
        /// <returns>Updated <see cref="WebAutomation"/> instance.</returns>
        public static WebAutomation AddWebActions(
            WebAutomation webAutomation,
            IEnumerable<ActionRule> actions,
            IEnumerable<ExtractionRule> extractions,
            string applicationUnderTest)
        {
            return DoAddWebActions(webAutomation, actions, extractions, applicationUnderTest);
        }

        private static WebAutomation DoAddWebActions(
            WebAutomation webAutomation,
            IEnumerable<ActionRule> actions,
            IEnumerable<ExtractionRule> extractions,
            string applicationUnderTest)
        {
            // setup
            var _actions = new List<ActionRule>
            {
                new ActionRule { ActionType = WebPlugins.GoToUrl, Argument = applicationUnderTest }
            };

            // append
            foreach (var action in actions)
            {
                _actions.Add(action);
            }
            _actions.Add(new ActionRule { ActionType = CommonPlugins.CloseBrowser });

            // apply
            webAutomation.Actions = _actions;
            webAutomation.Extractions = extractions;

            // results
            return webAutomation;
        }

        /// <summary>
        /// Gets the actual results extracted by this <see cref="WebAutomation"/>.
        /// </summary>
        /// <param name="response"><see cref="OrbitResponse"/> from which to extract results</param>
        /// <returns>Actual results.</returns>
        public static string GetActual(OrbitResponse response)
            => DoGetActual<string>(response, key: "actual");

        /// <summary>
        /// Gets the actual results extracted by this <see cref="WebAutomation"/>.
        /// </summary>
        /// <param name="response"><see cref="OrbitResponse"/> from which to extract results</param>
        /// <param name="key">The key to get the actual result from.</param>
        /// <returns>Actual results.</returns>
        public static T GetActual<T>(OrbitResponse response, string key) => DoGetActual<T>(response, key);

        private static T DoGetActual<T>(OrbitResponse response, string key) => (T)response
            .Extractions
            .SelectMany(i => i.Entities)
            .SelectMany(i => i.EntityContent)
            .First(i => i.Key == key)
            .Value;

        public static bool GetAssertions(OrbitResponse response)
        {
            return response
                .Extractions
                .SelectMany(i => i.Entities)
                .SelectMany(i => i.EntityContent)
                .Where(i => i.Key == "evaluation")
                .All(i => (bool)i.Value);
        }

        /// <summary>
        /// Gets a driver full name.
        /// </summary>
        /// <param name="driver">Driver type to get full name by.</param>
        /// <returns>Driver full name</returns>
        public static string GetDriverFullName(string driver) => driver switch
        {
            Driver.Android => "AndroidDriver",
            Driver.Chrome => "RemoteWebDriver",
            Driver.Edge => "RemoteWebDriver",
            Driver.Firefox => "RemoteWebDriver",
            Driver.InternetExplorer => "RemoteWebDriver",
            Driver.iOS => "iOS.IOSDriver",
            Driver.Mock => "MockWebDriver",
            Driver.Safari => "RemoteWebDriver",
            _ => null
        };
        #endregion

        #region *** setup          ***
        /// <summary>
        /// apply environment(s) to the current test-case context
        /// </summary>
        /// <param name="environments">applied environment(s)</param>
        /// <returns>update test-case context</returns>
        public TestCase AddEnvironments(params AutomationEnvironment[] environments)
        {
            // setup
            this.environments ??= new ConcurrentBag<AutomationEnvironment>();

            // append environments
            foreach (var environment in environments)
            {
                DoAddEnvironment(environment);
            }

            // complete pipe
            return this;
        }

        /// <summary>
        /// apply environment(s) to the current test-case context
        /// </summary>
        /// <param name="json">applied environment(s)</param>
        /// <returns>update test-case context</returns>
        public TestCase AddEnvironments(string json)
        {
            // read file if exists
            if (File.Exists(json))
            {
                json = File.ReadAllText(json);
            }

            // setup
            var environmentsUnderTest = JsonConvert.DeserializeObject<AutomationEnvironment[]>(json);
            environments ??= new ConcurrentBag<AutomationEnvironment>();

            // append environments
            foreach (var environment in environmentsUnderTest)
            {
                DoAddEnvironment(environment);
            }

            // complete pipe
            return this;
        }

        private void DoAddEnvironment(AutomationEnvironment environment)
        {
            // setup
            environment.SystemParams ??= new Dictionary<string, object>();
            environment.TestParams ??= new Dictionary<string, object>();

            // add new environment
            environments.Add(environment);
        }

        public TestCase Attempts(int numberOfAttempts)
        {
            // set
            attempts = numberOfAttempts;

            // result
            return this;
        }
        #endregion

        #region *** execution      ***
        /// <summary>
        /// Implements preconditions for this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied environment.</param>
        public virtual void OnPreconditions(AutomationEnvironment environment)
        {
            TestContext.WriteLine($"no preconditions implementation for [{GetType().Name}]");
        }

        /// <summary>
        /// Implements cleanup for this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied environment.</param>
        public virtual void OnCleanup(AutomationEnvironment environment)
        {
            TestContext.WriteLine($"no cleanup implementation for [{GetType().Name}]");
        }

        /// <summary>
        /// Automation test to execute against a single applied <see cref="AutomationEnvironment"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public virtual bool AutomationTest(AutomationEnvironment environment)
        {
            // setup
            var driver = $"{environment.TestParams["driver"]}";
            var capabilities = (IDictionary<string, object>)environment.TestParams["capabilities"];
            var isNegative = environment.TestParams.ContainsKey("negative") && (bool)environment.TestParams["negative"];

            // web automation
            var actions = GetActions(environment);
            var extractions = GetExtractions(environment);
            var webAutomation = GetWebAutomation(driver, capabilities);
            webAutomation = AddWebActions(
                webAutomation, actions, extractions, ApplicationUnderTest);

            // execute
            var response = ExecuteWebAutomation(webAutomation, environment);
            var actual = GetAssertions(response);

            // assertion
            return isNegative ? !actual : actual;
        }

        /// <summary>
        /// Gets a collection of <see cref="ActionRule"/> to execute under this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <returns>A collection of <see cref="ActionRule"/> to execute</returns>
        public virtual IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
            => Array.Empty<ActionRule>();

        /// <summary>
        /// Gets a collection of <see cref="ExtractionRule"/> to execute under this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <returns>A collection of <see cref="ActionRule"/> to execute</returns>
        public virtual IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
            => Array.Empty<ExtractionRule>();

        /// <summary>
        /// executes test-case against each applied environment
        /// </summary>
        /// <returns>true if pass; false if not</returns>
        public bool Execute()
        {
            // no environments conditions
            if (environments == null)
            {
                return ExecuteTestCase(environment: default);
            }

            // execute test-case for all environments
            foreach (var environment in environments)
            {
                var actual = ExecuteTestCase(environment);
                if (actual) return actual;
            }
            return false;
        }

        // executes test-case against a single applied environment
        private bool ExecuteTestCase(AutomationEnvironment environment)
        {
            // extract number of retires
            attempts = environment.SystemParams.ContainsKey("attempts")
                ? (int)environment.SystemParams["attempts"]
                : attempts;

            // single execution conditions
            if (attempts == 1)
            {
                return ExecuteIteration(environment);
            }

            // execute test-case
            for (int i = 0; i <= attempts; i++)
            {
                var actual = ExecuteIteration(environment);
                if (actual)
                {
                    return actual;
                }
                if (i < attempts)
                {
                    UpdateBrowserStack(environment, isDelete: true);
                }
            }

            // complete pipeline
            return false;
        }

        // executes test-case iteration against a single applied environment
        private bool ExecuteIteration(AutomationEnvironment environment)
        {
            try
            {
                Preconditions(environment);
                environment.TestParams["actual"] = AutomationTest(environment);
                TestContext.WriteLine($"test-case [{GetType().Name}] completed with result [{environment.TestParams["actual"]}]");
            }
            catch (Exception e) when (e is NotImplementedException || e is AssertInconclusiveException)
            {
                TestContext.WriteLine($"test-case [{GetType().Name}] skipped", e);
                throw new AssertInconclusiveException(e.Message);
            }
            catch (Exception e) when (e != null)
            {
                TestContext.WriteLine($"failed to execute [{GetType().Name}] iteration; reason: {e}");
            }
            finally
            {
                Cleanup(environment);
            }
            return environment.TestParams.ContainsKey("actual") && (bool)environment.TestParams["actual"];
        }

        // executes explicit preconditions
        private void Preconditions(AutomationEnvironment environment)
        {
            // user
            OnPreconditions(environment);
        }

        // executes explicit cleanup
        private void Cleanup(AutomationEnvironment environment)
        {
            try
            {
                // common
                UpdateBrowserStack(environment, isDelete: false);

                // environment log
                TestContext.WriteLine(JsonConvert.SerializeObject(environment, Formatting.Indented));

                // user
                OnCleanup(environment);
            }
            catch (Exception e) when (e != null)
            {
                TestContext.WriteLine($"{e}");
            }
        }
        #endregion

        #region *** browser stack  ***
        /// <summary>
        /// Updates tests results on BrowserStack (if applicable)
        /// </summary>
        public void UpdateBrowserStack(AutomationEnvironment environment, bool isDelete)
        {
            // setup
            var isUpdateBrowserStack = TestContext.Parameters.Get("Grid.UpdateBrowserStack", false);
            var isBrowserStack = isUpdateBrowserStack && $"{TestContext.Parameters["Grid.Endpoint"]}".Contains("browserstack.com/wd/hub");
            var isSession = environment.TestParams.ContainsKey("sessions");
            var timeout = TestContext.Parameters.Get(name: "Grid.UpdateTimeout", defaultValue: 10000);

            // exit conditions
            if (!isBrowserStack || !isSession)
            {
                return;
            }

            // request body
            var actual = environment.TestParams.ContainsKey("actual") && (bool)environment.TestParams["actual"];
            var requestBody = new
            {
                Status = actual ? "passed" : "failed"
            };

            // update test outcome on 3rd party platform            
            foreach (var session in (IEnumerable<string>)environment.TestParams["sessions"])
            {
                var requestUri = "https://api.browserstack.com/automate/sessions/<session-id>.json"
                    .Replace("<session-id>", session);
                if (isDelete)
                {
                    Delete(requestUri, browserStackClient, timeout);
                }
                else
                {
                    Put(requestUri, requestBody, browserStackClient, timeout);
                }
            }
        }

        private void Put(string requestUri, object requestBody, HttpClient client, int timeout = 10000)
        {
            // setup
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Basic", parameter: $"{TestContext.Parameters["Grid.BasicAuthorization"]}");

            // create content
            var body = JsonConvert.SerializeObject(requestBody, settings);
            var stringContent = new StringContent(content: body, Encoding.UTF8, mediaType: "application/json");

            // send to server
            var interval = 0;
            while (interval < timeout)
            {
                var response = client.PutAsync(requestUri, stringContent).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }
                interval += 1000;
                Thread.Sleep(millisecondsTimeout: 1000);
            }
        }

        private void Delete(string requestUri, HttpClient client, int timeout = 10000)
        {
            // setup
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "Basic", parameter: $"{TestContext.Parameters["Grid.BasicAuthorization"]}");

            // send to server
            var interval = 0;
            while (interval < timeout)
            {
                var response = client.DeleteAsync(requestUri).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }
                interval += 1000;
                Thread.Sleep(millisecondsTimeout: 1000);
            }
        }
        #endregion
    }
}