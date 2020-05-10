/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Graivty.IntegrationTests.Extensions;
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Assert = NUnit.Framework.Assert;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;
using TestContext = NUnit.Framework.TestContext;

namespace Gravity.IntegrationTests.Base
{
    [DeploymentItem("Resources/license.lcn")]
    public abstract class TestCase
    {
        // constants
        public static readonly string HomePage = $"{TestContext.Parameters["Integration.ApplicationUnderTest"]}";
        public static readonly string UiControlsPage = HomePage + "uicontrols/";
        public static readonly string CoursesPage = HomePage + "course/";
        public static readonly string StudentsPage = HomePage + "student/";

        // members: state
        private ConcurrentBag<AutomationEnvironment> environments;
        private int attempts =
            TestContext.Parameters.Get(name: "Integration.NumberOfAttempts", defaultValue: 1);

        #region *** Test: Properties    ***
        /// <summary>
        /// Gets or sets the application under test for this <see cref="TestCase"/>
        /// </summary>
        public virtual string ApplicationUnderTest { get; set; } = UiControlsPage;

        /// <summary>
        /// Gets or sets a value indicating is this is a web test.
        /// </summary>
        public virtual bool IsWebTest { get; set; } = true;
        #endregion

        #region *** Test: Environments  ***
        /// <summary>
        /// Apply environment(s) to the current <see cref="TestCase"/> context.
        /// </summary>
        /// <param name="environments">Applied environment(s).</param>
        /// <returns>Self reference.</returns>
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

        // apply an environment to the current context.
        private void DoAddEnvironment(AutomationEnvironment environment)
        {
            // setup
            environment.SystemParams ??= new Dictionary<string, object>();
            environment.TestParams ??= new Dictionary<string, object>();

            // add new environment
            environments.Add(environment);
        }
        #endregion

        #region *** Test: Execution     ***
        /// <summary>
        /// Executes a <see cref="TestCase"/> against each applied environment.
        /// </summary>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
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
                if (actual)
                {
                    return actual;
                }
            }

            // test failed
            return false;
        }

        // executes test-case against a single applied environment
        private bool ExecuteTestCase(AutomationEnvironment environment)
        {
            // extract number of retires
            attempts = environment.SystemParams.ContainsKey("attempts")
                ? (int)environment.SystemParams["attempts"]
                : attempts;

            // execute test-case
            for (int i = 1; i <= attempts; i++)
            {
                var actual = ExecuteIteration(environment);
                if (actual)
                {
                    return actual;
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
                // 1. explicit preconditions
                Preconditions(environment);

                // 2. execute test case > get actual
                environment.TestParams["actual"] = AutomationTest(environment);

                // 3. log
                var message = $"TestCase [{GetType().Name}] completed with result [{environment.TestParams["actual"]}].";
                TestContext.WriteLine(message);
            }
            catch (Exception e) when (e is NotImplementedException || e is InconclusiveException)
            {
                // log
                var p = environment.TestParams;
                var message = $"Was unable to conclude results on [{p["driver"]}]";

                // skip test
                Assert.Inconclusive(message);
            }
            catch (Exception e) when (e != null)
            {
                TestContext.WriteLine($"Failed to execute [{GetType().Name}] iteration; Reason [{e}]");
            }
            finally
            {
                // 4. cleanup
                Cleanup(environment);
            }

            // setup conditions
            var isKey = environment.TestParams.ContainsKey("actual");

            // test iteration results
            return isKey && (bool)environment.TestParams["actual"];
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

        /// <summary>
        /// Automation test to execute against a single applied <see cref="AutomationEnvironment"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public bool AutomationTest(AutomationEnvironment environment)
        {
            // execute
            var responses = ExecuteAutomation(environment);

            // update results
            bool actual = OnAfterAutomation(environment, responses);

            // is inconclusive
            if (!actual)
            {
                responses.AssertInconclusive();
            }

            // user plugin
            return actual;
        }
        #endregion

        #region *** Test: Automation    ***
        /// <summary>
        /// Executes <see cref="WebAutomation"/> sequence with a given <see cref="AutomationEnvironment"/> context.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns>A Collection of <see cref="OrbitResponse"/>.</returns>
        public IEnumerable<OrbitResponse> ExecuteAutomation(AutomationEnvironment environment)
        {
            // execute
            var automation = GetAutomation(environment);
            var results = new AutomationExecutor(automation).Execute();
            var responses = results.Select(i => i.Value);

            // add sessions to environment
            environment.TestParams["sessions"] = results.Select(i => i.Key);

            // results
            TestContext.WriteLine(JsonConvert.SerializeObject(responses, Formatting.Indented));
            return responses;
        }

        // gets a web automation instance based on provided environment.
        private WebAutomation GetAutomation(AutomationEnvironment environment)
        {
            var authentication = OnAuthentication(environment);
            var configuration = OnConfiguration(environment);
            var extractions = OnExtractions(environment);

            // setup: actions
            var actions = OnActions(environment).ToArray();
            var actionsList = new List<ActionRule>();
            if (IsWebTest)
            {
                actionsList.Add(new ActionRule { Action = PluginsList.GoToUrl, Argument = ApplicationUnderTest });
            }
            actionsList.AddRange(actions);
            actionsList.Add(new ActionRule { Action = PluginsList.CloseBrowser });

            // setup: driver parameters
            var driverParams = GetDriverParams(environment);
            driverParams = OnDriver(environment, driverParams);

            // setup: automation
            var automation = new WebAutomation
            {
                Actions = actionsList,
                Authentication = authentication,
                EngineConfiguration = configuration,
                DriverParams = driverParams,
                Extractions = extractions
            };

            // results
            OnAutomation(automation);
            return automation;
        }

        // gets driver parameters (with browserstack.com capabilities)
        private IDictionary<string, object> GetDriverParams(AutomationEnvironment environment)
        {
            // setup
            var driverParams = new Dictionary<string, object>
            {
                ["driver"] = $"{environment.TestParams["driver"]}",
                ["driverBinaries"] = $"{TestContext.Parameters["Grid.Endpoint"]}"
            };

            // apply capabilities
            var capabilities = GetCapabilities(environment);

            // apply
            driverParams.Add(key: "capabilities", value: capabilities);

            // result
            return driverParams;
        }

        // gets driver capabilities collection
        private IDictionary<string, object> GetCapabilities(AutomationEnvironment environment)
        {
            // setup: from user
            var fromUser = (IDictionary<string, object>)environment.TestParams["capabilities"];

            // exit conditions
            if (!fromUser.ContainsKey("bstack:options"))
            {
                return fromUser;
            }

            // setup: from settings
            var capabilities = new Dictionary<string, object>
            {
                ["resolution"] = "1920x1080",
                ["project"] = $"{environment.SystemParams["Project.Name"]}",
                ["build"] = $"{environment.SystemParams["Build.Number"]}",
                ["name"] = GetTestName(),
                ["browserstack.ie.enablePopups"] = true
            };
            foreach (var capability in ((JObject)fromUser["bstack:options"]).ToObject<IDictionary<string, object>>())
            {
                capabilities[capability.Key] = capability.Value;
            }
            return capabilities;
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
        #endregion

        #region *** Plugins: Testing    ***
        /// <summary>
        /// Implements assertion logics for this <see cref="AutomationTest(AutomationEnvironment)"/>
        /// </summary>
        /// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        /// <param name="responses"><see cref="WebAutomation"/> results after execution completed.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public virtual bool OnAfterAutomation(AutomationEnvironment environment, IEnumerable<OrbitResponse> responses)
        {
            // setup
            var isNegative = environment.TestParams.ContainsKey("negative") && (bool)environment.TestParams["negative"];

            // assertion
            var actual = responses.Assert();
            return isNegative ? !actual : actual;
        }

        /// <summary>
        /// Implements preconditions for this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied environment.</param>
        public virtual void OnPreconditions(AutomationEnvironment environment)
        {
            // Take not action
        }

        /// <summary>
        /// Implements cleanup for this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied environment.</param>
        public virtual void OnCleanup(AutomationEnvironment environment)
        {
            // Take no action
        }
        #endregion

        #region *** Plugins: Automation ***
        /// <summary>
        /// Apply actions into the default collection of <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns>A new collection of <see cref="ActionRule"/></returns>
        public virtual IEnumerable<ActionRule> OnActions(AutomationEnvironment environment)
        {
            return Array.Empty<ActionRule>();
        }

        /// <summary>
        /// Gets or sets this request <see cref="Authentication"/> object.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns>A new <see cref="Authentication"/> object.</returns>
        public virtual Authentication OnAuthentication(AutomationEnvironment environment)
        {
            // setup
            var userName = $"{environment.SystemParams["Gravity.UserName"]}";
            var password = $"{environment.SystemParams["Gravity.Password"]}";

            // results
            return new Authentication
            {
                Password = password,
                UserName = userName
            };
        }

        /// <summary>
        /// Gets or sets this request <see cref="EngineConfiguration"/> object.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns>A new <see cref="EngineConfiguration"/> object.</returns>
        public virtual EngineConfiguration OnConfiguration(AutomationEnvironment environment)
        {
            // setup
            int.TryParse($"{environment.SystemParams["Integration.LoadTimeout"]}", out int loadOut);
            int.TryParse($"{environment.SystemParams["Integration.SearchTimeout"]}", out int searchOut);

            // results
            return new EngineConfiguration
            {
                LoadTimeout = loadOut,
                SearchTimeout = searchOut
            };
        }

        /// <summary>
        /// Gets or sets this request <see cref="WebAutomation.DriverParams"/> object.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <param name="driverParams">Default <see cref="WebAutomation.DriverParams"/>.</param>
        /// <returns>Updated <see cref="WebAutomation.DriverParams"/>.</returns>
        public virtual IDictionary<string, object> OnDriver(AutomationEnvironment environment, IDictionary<string, object> driverParams)
        {
            return driverParams;
        }

        /// <summary>
        /// Gets or sets a collection of <see cref="ExtractionRule"/> for this <see cref="WebAutomation"/> object.
        /// </summary>
        /// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        /// <returns>A collection of <see cref="ExtractionRule"/>.</returns>
        public virtual IEnumerable<ExtractionRule> OnExtractions(AutomationEnvironment environment)
        {
            return Array.Empty<ExtractionRule>();
        }

        /// <summary>
        /// Gets or sets this <see cref="WebAutomation"/> object.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object.</param>
        /// <returns>Updated <see cref="WebAutomation"/> object.</returns>
        public virtual void OnAutomation(WebAutomation automation)
        {
            // Take no action.
        }
        #endregion

        #region *** automation     ***
        ///// <summary>
        ///// Executes <see cref="WebAutomation"/> sequence with a given <see cref="AutomationEnvironment"/> context.
        ///// </summary>
        ///// <param name="webAutomation"><see cref="WebAutomation"/> to execute.</param>
        ///// <param name="environment"><see cref="AutomationEnvironment"/> to use.</param>
        ///// <returns><see cref="OrbitResponse"/> instance.</returns>
        //public static IEnumerable<OrbitResponse> ExecuteWebAutomation(WebAutomation webAutomation, AutomationEnvironment environment)
        //{
        //    // execute
        //    var results = new AutomationExecutor(webAutomation).Execute();
        //    var responses = results.Select(i => i.Value);

        //    // add sessions to environment
        //    environment.TestParams["sessions"] = results.Select(i => i.Key);

        //    // results
        //    TestContext.WriteLine(JsonConvert.SerializeObject(responses, Formatting.Indented));
        //    return responses;
        //}

        ///// <summary>
        ///// Gets a <see cref="WebAutomation"/> instance based on driver and capabilities.
        ///// </summary>
        ///// <param name="driver"><see cref="Driver"/> to use with this <see cref="WebAutomation"/></param>
        ///// <param name="capabilities">Capabilities collection for this <see cref="Driver"/></param>
        ///// <returns><see cref="WebAutomation"/> instance.</returns>
        //public WebAutomation GetWebAutomation(string driver, IDictionary<string, object> capabilities)
        //{
        //    // shortcuts
        //    int.TryParse($"{TestContext.Parameters["Integration.PageTimeout"]}", out int pageOut);
        //    int.TryParse($"{TestContext.Parameters["Integration.ElementTimeout"]}", out int elementOut);

        //    // setup
        //    var pageLoadTimeout = pageOut != 0 ? pageOut : 60000;
        //    var elementSearchingTimeout = elementOut != 0 ? elementOut : 15000;

        //    // configuration
        //    var configuration = new EngineConfiguration
        //    {
        //        LoadTimeout = pageLoadTimeout,
        //        SearchTimeout = elementSearchingTimeout
        //    };

        //    // authentication
        //    var u = TestContext.Parameters.Get("Gravity.UserName", string.Empty);
        //    var p = TestContext.Parameters.Get("Gravity.Password", string.Empty);
        //    var authentication = new Authentication
        //    {
        //        UserName = u,
        //        Password = p
        //    };

        //    // driver parameters
        //    var testName = GetTestName();
        //    var driverParams = GetDriverParams(driver, capabilities, testName);

        //    // result
        //    return new WebAutomation
        //    {
        //        Authentication = authentication,
        //        DriverParams = driverParams,
        //        EngineConfiguration = configuration
        //    };
        //}

        //// gets test name from description attribute
        //private string GetTestName()
        //{
        //    // setup
        //    var method = new StackFrame(6).GetMethod();
        //    var description =
        //        method.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

        //    // result
        //    return description == null ? method.Name : ((DescriptionAttribute)description).Description;
        //}

        ///// <summary>
        ///// Gets driver parameters (with browserstack.com capabilities)
        ///// </summary>
        ///// <param name="capabilities">Current capabilities collection</param>
        //public virtual void OnDriverParams(IDictionary<string, object> capabilities)
        //{

        //}

        //// gets driver parameters (with browserstack.com capabilities)
        //private IDictionary<string, object> GetDriverParams(
        //    string driver,
        //    IDictionary<string, object> capabilities,
        //    string testName)
        //{
        //    // setup
        //    var driverParams = new Dictionary<string, object>
        //    {
        //        ["driver"] = driver,
        //        ["driverBinaries"] = $"{TestContext.Parameters["Grid.Endpoint"]}"
        //    };
        //    var isLegacy = TestContext.Parameters.Get<bool>("Grid.Legacy", true);

        //    // apply capabilities
        //    capabilities = isLegacy
        //        ? SetBrowserStackLegacyCapabilities(capabilities, testName)
        //        : SetBrowserStackCapabilities(capabilities, testName);

        //    // plugin
        //    OnDriverParams(capabilities);

        //    // apply
        //    driverParams.Add(key: "capabilities", value: capabilities);

        //    // result
        //    return driverParams;
        //}

        //private IDictionary<string, object> SetBrowserStackLegacyCapabilities(
        //    IDictionary<string, object> capabilities,
        //    string testName)
        //{
        //    // exit conditions
        //    if (!capabilities.ContainsKey("bstack:options"))
        //    {
        //        return capabilities;
        //    }

        //    // add capabilities
        //    var _capabilities = new Dictionary<string, object>
        //    {
        //        ["resolution"] = "1920x1080",
        //        ["project"] = $"{TestContext.Parameters["Project.Name"]}",
        //        ["build"] = $"{TestContext.Parameters["Build.Number"]}",
        //        ["name"] = testName,
        //        ["browserstack.ie.enablePopups"] = true,
        //        ["browserstack.selenium_version"] = "3.141.59"
        //    };
        //    foreach (var capability in ((JObject)capabilities["bstack:options"]).ToObject<IDictionary<string, object>>())
        //    {
        //        _capabilities[capability.Key] = capability.Value;
        //    }
        //    capabilities.Remove("bstack:options");

        //    foreach (var capability in _capabilities)
        //    {
        //        capabilities[capability.Key] = capability.Value;
        //    }
        //    return capabilities;
        //}

        //private IDictionary<string, object> SetBrowserStackCapabilities(
        //    IDictionary<string, object> capabilities,
        //    string testName)
        //{
        //    // exit conditions
        //    if (!capabilities.ContainsKey("bstack:options"))
        //    {
        //        return capabilities;
        //    }

        //    // add capabilities
        //    var _capabilities = new Dictionary<string, object>
        //    {
        //        ["resolution"] = "1920x1080",
        //        ["project"] = $"{TestContext.Parameters["Project.Name"]}",
        //        ["build"] = $"{TestContext.Parameters["Build.Number"]}",
        //        ["name"] = testName,
        //        ["browserstack.ie.enablePopups"] = true
        //    };
        //    foreach (var capability in ((JObject)capabilities["bstack:options"]).ToObject<IDictionary<string, object>>())
        //    {
        //        _capabilities[capability.Key] = capability.Value;
        //    }

        //    // apply
        //    capabilities["bstack:options"] = _capabilities;
        //    return capabilities;
        //}

        ///// <summary>
        ///// Apply actions and extractions to the given <see cref="WebAutomation"/>.
        ///// This (will automatically add GoToUrl & CloseBrowser).
        ///// </summary>
        ///// <param name="webAutomation"><see cref="WebAutomation"/> to append to.</param>
        ///// <param name="actions">A collection of <see cref="ActionRule"/> to append.</param>
        ///// <param name="extractions">A collection of <see cref="ExtractionRule"/> to append.</param>
        ///// <returns>Updated <see cref="WebAutomation"/> instance.</returns>
        //public static WebAutomation AddWebActions(
        //    WebAutomation webAutomation,
        //    IEnumerable<ActionRule> actions,
        //    IEnumerable<ExtractionRule> extractions)
        //{
        //    return DoAddWebActions(
        //        webAutomation,
        //        actions,
        //        extractions,
        //        applicationUnderTest: HomePage);
        //}

        ///// <summary>
        ///// Apply actions and extractions to the given <see cref="WebAutomation"/>.
        ///// This (will automatically add GoToUrl & CloseBrowser).
        ///// </summary>
        ///// <param name="webAutomation"><see cref="WebAutomation"/> to append to.</param>
        ///// <param name="actions">A collection of <see cref="ActionRule"/> to append.</param>
        ///// <param name="extractions">A collection of <see cref="ExtractionRule"/> to append.</param>
        ///// <returns>Updated <see cref="WebAutomation"/> instance.</returns>
        //public static WebAutomation AddWebActions(
        //    WebAutomation webAutomation,
        //    IEnumerable<ActionRule> actions,
        //    IEnumerable<ExtractionRule> extractions,
        //    string applicationUnderTest)
        //{
        //    return DoAddWebActions(webAutomation, actions, extractions, applicationUnderTest);
        //}

        //private static WebAutomation DoAddWebActions(
        //    WebAutomation webAutomation,
        //    IEnumerable<ActionRule> actions,
        //    IEnumerable<ExtractionRule> extractions,
        //    string applicationUnderTest)
        //{
        //    // setup
        //    var onActions = new List<ActionRule>
        //    {
        //        new ActionRule { Action = PluginsList.GoToUrl, Argument = applicationUnderTest }
        //    };

        //    // append
        //    foreach (var action in actions)
        //    {
        //        onActions.Add(action);
        //    }
        //    onActions.Add(new ActionRule { Action = PluginsList.CloseBrowser });

        //    // apply
        //    webAutomation.Actions = onActions;
        //    webAutomation.Extractions = extractions;

        //    // results
        //    return webAutomation;
        //}

        ///// <summary>
        ///// Gets the actual results extracted by this <see cref="WebAutomation"/>.
        ///// </summary>
        ///// <param name="response"><see cref="OrbitResponse"/> from which to extract results</param>
        ///// <returns>Actual results.</returns>
        //public static string GetActual(OrbitResponse response)
        //    => DoGetActual<string>(response, key: "actual");

        ///// <summary>
        ///// Gets the actual results extracted by this <see cref="WebAutomation"/>.
        ///// </summary>
        ///// <param name="response"><see cref="OrbitResponse"/> from which to extract results</param>
        ///// <param name="key">The key to get the actual result from.</param>
        ///// <returns>Actual results.</returns>
        //public static T GetActual<T>(OrbitResponse response, string key) => DoGetActual<T>(response, key);

        //private static T DoGetActual<T>(OrbitResponse response, string key) => (T)response
        //    .Extractions
        //    .SelectMany(i => i.Entities)
        //    .SelectMany(i => i.Content)
        //    .First(i => i.Key == key)
        //    .Value;

        //public static bool GetAssertions(IEnumerable<OrbitResponse> responses)
        //{
        //    if (!responses.SelectMany(i => i.Extractions).Any())
        //    {
        //        return false;
        //    }

        //    return responses
        //        .SelectMany(i => i.Extractions)
        //        .SelectMany(i => i.Entities)
        //        .SelectMany(i => i.Content)
        //        .Where(i => i.Key == "evaluation")
        //        .All(i => (bool)i.Value);
        //}

        //public static void AssertInconclusive(IEnumerable<OrbitResponse> responses)
        //{
        //    var isEvaluation = responses
        //        .SelectMany(i => i.Extractions)
        //        .SelectMany(i => i.Entities)
        //        .Any(i => i.Content.ContainsKey("evaluation"));

        //    // exit condition
        //    if (isEvaluation)
        //    {
        //        return;
        //    }

        //    // throw
        //    var exceptions = responses.SelectMany(i => i.OrbitRequest.Exceptions).Select(i => i.Exception.Message);
        //    var message = JsonConvert.SerializeObject(exceptions);
        //    throw new AssertInconclusiveException(message);
        //}

        ///// <summary>
        ///// Gets a driver full name.
        ///// </summary>
        ///// <param name="driver">Driver type to get full name by.</param>
        ///// <returns>Driver full name</returns>
        //public static string GetDriverFullName(string driver) => driver switch
        //{
        //    Driver.Android => "AndroidDriver",
        //    Driver.Chrome => "RemoteWebDriver",
        //    Driver.Edge => "RemoteWebDriver",
        //    Driver.Firefox => "RemoteWebDriver",
        //    Driver.InternetExplorer => "RemoteWebDriver",
        //    Driver.iOS => "iOS.IOSDriver",
        //    Driver.Mock => "MockWebDriver",
        //    Driver.Safari => "RemoteWebDriver",
        //    _ => null
        //};
        //#endregion

        //#region *** setup          ***
        ///// <summary>
        ///// apply environment(s) to the current test-case context
        ///// </summary>
        ///// <param name="environments">applied environment(s)</param>
        ///// <returns>update test-case context</returns>
        //public TestCase AddEnvironments(params AutomationEnvironment[] environments)
        //{
        //    // setup
        //    this.environments ??= new ConcurrentBag<AutomationEnvironment>();

        //    // append environments
        //    foreach (var environment in environments)
        //    {
        //        DoAddEnvironment(environment);
        //    }

        //    // complete pipe
        //    return this;
        //}

        ///// <summary>
        ///// apply environment(s) to the current test-case context
        ///// </summary>
        ///// <param name="json">applied environment(s)</param>
        ///// <returns>update test-case context</returns>
        //public TestCase AddEnvironments(string json)
        //{
        //    // read file if exists
        //    if (File.Exists(json))
        //    {
        //        json = File.ReadAllText(json);
        //    }

        //    // setup
        //    var environmentsUnderTest = JsonConvert.DeserializeObject<AutomationEnvironment[]>(json);
        //    environments ??= new ConcurrentBag<AutomationEnvironment>();

        //    // append environments
        //    foreach (var environment in environmentsUnderTest)
        //    {
        //        DoAddEnvironment(environment);
        //    }

        //    // complete pipe
        //    return this;
        //}

        //private void DoAddEnvironment(AutomationEnvironment environment)
        //{
        //    // setup
        //    environment.SystemParams ??= new Dictionary<string, object>();
        //    environment.TestParams ??= new Dictionary<string, object>();

        //    // add new environment
        //    environments.Add(environment);
        //}

        //public TestCase Attempts(int numberOfAttempts)
        //{
        //    // set
        //    attempts = numberOfAttempts;

        //    // result
        //    return this;
        //}
        //#endregion

        //#region *** execution      ***
        ///// <summary>
        ///// Implements preconditions for this <see cref="TestCase"/>.
        ///// </summary>
        ///// <param name="environment">Applied environment.</param>
        //public virtual void OnPreconditions(AutomationEnvironment environment)
        //{
        //    TestContext.WriteLine($"no preconditions implementation for [{GetType().Name}]");
        //}

        ///// <summary>
        ///// Implements cleanup for this <see cref="TestCase"/>.
        ///// </summary>
        ///// <param name="environment">Applied environment.</param>
        //public virtual void OnCleanup(AutomationEnvironment environment)
        //{
        //    TestContext.WriteLine($"no cleanup implementation for [{GetType().Name}]");
        //}

        ///// <summary>
        ///// Automation test to execute against a single applied <see cref="AutomationEnvironment"/>.
        ///// </summary>
        ///// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        ///// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        //public virtual bool AutomationTest(AutomationEnvironment environment)
        //{
        //    // setup
        //    var driver = $"{environment.TestParams["driver"]}";
        //    var capabilities = (IDictionary<string, object>)environment.TestParams["capabilities"];

        //    // web automation
        //    var actions = GetActions(environment);
        //    var extractions = GetExtractions(environment);
        //    var automation = GetWebAutomation(driver, capabilities);
        //    automation = AddWebActions(automation, actions, extractions, ApplicationUnderTest);

        //    // plugin
        //    BeforeExecute(automation);

        //    // execute
        //    var responses = ExecuteWebAutomation(automation, environment);

        //    // update results
        //    bool actual = OnAutomationTest(environment, responses);

        //    // is inconclusive
        //    if (!actual)
        //    {
        //        AssertInconclusive(responses);
        //    }

        //    // user plugin
        //    return actual;
        //}

        ///// <summary>
        ///// Implements logic to <see cref="WebAutomation"/> object, before executing.
        ///// </summary>
        ///// <param name="automation">This <see cref="WebAutomation"/> object.</param>
        //public virtual void BeforeExecute(WebAutomation automation)
        //{
        //    TestContext.WriteLine($"no before_execute implementation for [{GetType().Name}]");
        //}

        ///// <summary>
        ///// Implements assertion logics for this <see cref="AutomationTest(AutomationEnvironment)"/>
        ///// </summary>
        ///// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        ///// <param name="responses"><see cref="WebAutomation"/> results after execution completed.</param>
        ///// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        //public virtual bool OnAutomationTest(AutomationEnvironment environment, IEnumerable< OrbitResponse> responses)
        //{
        //    // setup
        //    var isNegative = environment.TestParams.ContainsKey("negative") && (bool)environment.TestParams["negative"];

        //    // assertion
        //    var actual = GetAssertions(responses);
        //    return isNegative ? !actual : actual;
        //}

        ///// <summary>
        ///// Gets a collection of <see cref="ActionRule"/> to execute under this <see cref="TestCase"/>.
        ///// </summary>
        ///// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        ///// <returns>A collection of <see cref="ActionRule"/> to execute</returns>
        //public virtual IEnumerable<ActionRule> GetActions(AutomationEnvironment environment)
        //    => Array.Empty<ActionRule>();

        ///// <summary>
        ///// Gets a collection of <see cref="ExtractionRule"/> to execute under this <see cref="TestCase"/>.
        ///// </summary>
        ///// <param name="environment">Applied <see cref="AutomationEnvironment"/>.</param>
        ///// <returns>A collection of <see cref="ActionRule"/> to execute</returns>
        //public virtual IEnumerable<ExtractionRule> GetExtractions(AutomationEnvironment environment)
        //    => Array.Empty<ExtractionRule>();

        ///// <summary>
        ///// executes test-case against each applied environment
        ///// </summary>
        ///// <returns>true if pass; false if not</returns>
        //public bool Execute()
        //{
        //    // no environments conditions
        //    if (environments == null)
        //    {
        //        return ExecuteTestCase(environment: default);
        //    }

        //    // execute test-case for all environments
        //    foreach (var environment in environments)
        //    {
        //        var actual = ExecuteTestCase(environment);
        //        if (actual)
        //        {
        //            return actual;
        //        }
        //    }

        //    // test failed
        //    return false;
        //}

        //// executes test-case against a single applied environment
        //private bool ExecuteTestCase(AutomationEnvironment environment)
        //{
        //    // extract number of retires
        //    attempts = environment.SystemParams.ContainsKey("attempts")
        //        ? (int)environment.SystemParams["attempts"]
        //        : attempts;

        //    // single execution conditions
        //    if (attempts == 1)
        //    {
        //        return ExecuteIteration(environment);
        //    }

        //    // execute test-case
        //    for (int i = 0; i <= attempts; i++)
        //    {
        //        var actual = ExecuteIteration(environment);
        //        if (actual)
        //        {
        //            return actual;
        //        }
        //    }

        //    // complete pipeline
        //    return false;
        //}

        //// executes test-case iteration against a single applied environment
        //private bool ExecuteIteration(AutomationEnvironment environment)
        //{
        //    try
        //    {
        //        // 1. explicit preconditions
        //        Preconditions(environment);

        //        // 2. execute test case > get actual
        //        environment.TestParams["actual"] = AutomationTest(environment);

        //        // 3. log
        //        var message = $"TestCase [{GetType().Name}] completed with result [{environment.TestParams["actual"]}].";
        //        TestContext.WriteLine(message);
        //    }
        //    catch (Exception e) when (e is NotImplementedException || e is AssertInconclusiveException)
        //    {
        //        var p = environment.TestParams;
        //        var message = $"Was unable to conclude results on [{p["driver"]}]";

        //        Assert.Inconclusive(message);
        //    }
        //    catch (Exception e) when (e != null)
        //    {
        //        TestContext.WriteLine($"Failed to execute [{GetType().Name}] iteration; Reason [{e}]");
        //    }
        //    finally
        //    {
        //        // 4. cleanup
        //        Cleanup(environment);
        //    }

        //    // setup conditions
        //    var isKey = environment.TestParams.ContainsKey("actual");

        //    // test iteration results
        //    return isKey && (bool)environment.TestParams["actual"];
        //}

        //// executes explicit preconditions
        //private void Preconditions(AutomationEnvironment environment)
        //{
        //    // user
        //    OnPreconditions(environment);
        //}

        //// executes explicit cleanup
        //private void Cleanup(AutomationEnvironment environment)
        //{
        //    try
        //    {
        //        // environment log
        //        TestContext.WriteLine(JsonConvert.SerializeObject(environment, Formatting.Indented));

        //        // user
        //        OnCleanup(environment);
        //    }
        //    catch (Exception e) when (e != null)
        //    {
        //        TestContext.WriteLine($"{e}");
        //    }
        //}
        #endregion
    }
}