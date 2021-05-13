/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Graivty.IntegrationTests.Converters;
using Graivty.IntegrationTests.Extensions;
using Gravity.Plugins.Contracts;
using Gravity.Plugins.Engine;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NUnit.Framework;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;

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
        private ConcurrentBag<Context> environments;
        private int attempts = TestContext.Parameters.Get(name: "Integration.NumberOfAttempts", defaultValue: 1);
        private readonly int attemptsInterval = TestContext.Parameters.Get(name: "Integration.AttemptsInterval", defaultValue: 15000);

        #region *** Test: Properties    ***
        /// <summary>
        /// Gets or sets the application under test for this <see cref="TestCase"/>
        /// </summary>
        public virtual string ApplicationUnderTest { get; set; } = UiControlsPage;

        /// <summary>
        /// Gets or sets a value indicating is this is a web test.
        /// </summary>
        public virtual bool IsWebTest { get; set; } = true;

        /// <summary>
        /// Gets the Json Options used by the test instance.
        /// </summary>
        public static JsonSerializerOptions SerializerOptions => GetJsonSerializerOptions();

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            // setup
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            // build
            options.Converters.Add(new ExceptionConverter());

            // get
            return options;
        }
        #endregion

        #region *** Test: Environments  ***
        /// <summary>
        /// Apply environment(s) to the current <see cref="TestCase"/> context.
        /// </summary>
        /// <param name="environments">Applied environment(s).</param>
        /// <returns>Self reference.</returns>
        public TestCase AddEnvironments(params Context[] environments)
        {
            // setup
            this.environments ??= new ConcurrentBag<Context>();

            // append environments
            foreach (var environment in environments)
            {
                DoAddEnvironment(environment);
            }

            // complete pipe
            return this;
        }

        // apply an environment to the current context.
        private void DoAddEnvironment(Context environment)
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
        private bool ExecuteTestCase(Context environment)
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
        private bool ExecuteIteration(Context environment)
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
                Thread.Sleep(attemptsInterval);
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
        private void Preconditions(Context environment)
        {
            // user
            OnPreconditions(environment);
        }

        // executes explicit cleanup
        private void Cleanup(Context environment)
        {
            try
            {
                // environment log
                TestContext.WriteLine(JsonSerializer.Serialize(environment, SerializerOptions));

                // user
                OnCleanup(environment);
            }
            catch (Exception e) when (e != null)
            {
                TestContext.WriteLine($"{e}");
            }
        }

        /// <summary>
        /// Automation test to execute against a single applied <see cref="Context"/>.
        /// </summary>
        /// <param name="environment">Applied <see cref="Context"/>.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public bool AutomationTest(Context environment)
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
        /// Executes WebAutomation sequence with a given <see cref="Context"/> context.
        /// </summary>
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <returns>A Collection of OrbitResponse.</returns>
        public IEnumerable<OrbitResponse> ExecuteAutomation(Context environment)
        {
            // execute
            var automation = GetAutomation(environment);
            var results = new AutomationExecutor(automation).Execute();
            var responses = results.Select(i => i.Value);

            // add sessions to environment
            environment.TestParams["sessions"] = results.Select(i => i.Key);

            // results
            TestContext.WriteLine(JsonSerializer.Serialize(responses, SerializerOptions));
            return responses;
        }

        // gets a web automation instance based on provided environment.
        private WebAutomation GetAutomation(Context environment)
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
        private static IDictionary<string, object> GetDriverParams(Context environment)
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
        private static IDictionary<string, object> GetCapabilities(Context environment)
        {
            // setup: from user
            var fromUser = (IDictionary<string, object>)environment.TestParams["capabilities"];

            // set selenium capabilities
            var capabilities = fromUser
                .Where(i => !i.Key.Equals("bstack:options", StringComparison.OrdinalIgnoreCase))
                .ToDictionary(i => i.Key, i => i.Value);

            // exit conditions
            if (!fromUser.ContainsKey("bstack:options"))
            {
                return fromUser;
            }

            // setup: from settings
            capabilities["resolution"] = "1920x1080";
            capabilities["project"] = $"{environment.SystemParams["Project.Name"]}";
            capabilities["build"] = $"{environment.SystemParams["Build.Number"]}";
            capabilities["name"] = GetTestName();
            capabilities["browserstack.ie.enablePopups"] = true;
            var options = ((JsonElement)fromUser["bstack:options"]).ToString();

            // TODO: validate for true value
            foreach (var capability in JsonSerializer.Deserialize<IDictionary<string, object>>(options))
            {
                capabilities[capability.Key] = capability.Value;
            }
            return capabilities;
        }

        // gets test name from description attribute
        private static string GetTestName()
        {
            // setup
            var method = new StackFrame(9).GetMethod();
            var description =
                method.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            // result
            return description == null ? method.Name : ((DescriptionAttribute)description).Description;
        }
        #endregion

        #region *** Plugins: Testing    ***
        /// <summary>
        /// Implements assertion logics for this <see cref="AutomationTest(Context)"/>
        /// </summary>
        /// <param name="environment">Applied <see cref="Context"/>.</param>
        /// <param name="responses">WebAutomation results after execution completed.</param>
        /// <returns><see cref="true"/> if pass; <see cref="false"/> if not.</returns>
        public virtual bool OnAfterAutomation(Context environment, IEnumerable<OrbitResponse> responses)
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
        public virtual void OnPreconditions(Context environment)
        {
            // Take not action
        }

        /// <summary>
        /// Implements cleanup for this <see cref="TestCase"/>.
        /// </summary>
        /// <param name="environment">Applied environment.</param>
        public virtual void OnCleanup(Context environment)
        {
            // Take no action
        }
        #endregion

        #region *** Plugins: Automation ***
        /// <summary>
        /// Apply actions into the default collection of <see cref="ActionRule"/>.
        /// </summary>
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <returns>A new collection of <see cref="ActionRule"/></returns>
        public virtual IEnumerable<ActionRule> OnActions(Context environment)
        {
            return Array.Empty<ActionRule>();
        }

        /// <summary>
        /// Gets or sets this request <see cref="Authentication"/> object.
        /// </summary>
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <returns>A new <see cref="Authentication"/> object.</returns>
        public virtual Authentication OnAuthentication(Context environment)
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
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <returns>A new <see cref="EngineConfiguration"/> object.</returns>
        public virtual EngineConfiguration OnConfiguration(Context environment)
        {
            // setup
            _ = int.TryParse($"{environment.SystemParams["Integration.LoadTimeout"]}", out int loadOut);
            _ = int.TryParse($"{environment.SystemParams["Integration.SearchTimeout"]}", out int searchOut);

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
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <param name="driverParams">Default <see cref="WebAutomation.DriverParams"/>.</param>
        /// <returns>Updated <see cref="WebAutomation.DriverParams"/>.</returns>
        public virtual IDictionary<string, object> OnDriver(Context environment, IDictionary<string, object> driverParams)
        {
            return driverParams;
        }

        /// <summary>
        /// Gets or sets a collection of ExtractionRule for this WebAutomation object.
        /// </summary>
        /// <param name="environment"><see cref="Context"/> to use.</param>
        /// <returns>A collection of ExtractionRule.</returns>
        public virtual IEnumerable<ExtractionRule> OnExtractions(Context environment)
        {
            return Array.Empty<ExtractionRule>();
        }

        /// <summary>
        /// Gets or sets this WebAutomation object.
        /// </summary>
        /// <param name="automation">This WebAutomation object.</param>
        /// <returns>Updated WebAutomation object.</returns>
        public virtual void OnAutomation(WebAutomation automation)
        {
            // Take no action.
        }
        #endregion
    }
}