/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using NUnit.Framework;
using System.Collections.Generic;

namespace Gravity.Plugins.Actions.IntegrationTests.Base
{
    public static class Provider
    {
        #region *** constants      ***
        // Windows
        public const string Windows10LatestBrowser = "{'os':'Windows','os_version':'10'}";
        public const string Windows7LatestBrowser = "{'os':'Windows','os_version':'7'}";
        public const string Windows7IE10 = "{'os':'Windows','os_version':'7','browser_version':'10.0'}";

        // OSX: OSXMojave
        public const string OSXMojaveSafari = "{'os':'OS X','os_version':'Mojave','browser_version':'12.1'}";
        public const string OSXMojaveLatestBrowser = "{'os':'OS X','os_version':'Mojave'}";

        // OSX: Catalina
        public const string OSXCatalinaSafari = "{'os':'OS X','os_version':'Catalina','browser_version':'13.0'}";
        public const string OSXCatalinaLatestBrowser = "{'os':'OS X','os_version':'Catalina'}";

        // Android
        public const string AndroidChrome = "" +
            "{" +
            "    'browserName':'Chrome'," +
            "    'deviceName':'gravity_api_test'," +
            "    'platformVersion':'9.0'," +
            "    'os_version':'9.0'," +
            "    'device':'Samsung Galaxy S10 Plus'," +
            "    'real_mobile':'true'" +
            "}";

        // iOS
        public const string iPhoneChrome = "" +
            "{" +
            "    'browserName':'Chrome'," +
            "    'deviceName':'gravity_api_test'," +
            "    'platformVersion':'13'," +
            "    'os_version':'13'," +
            "    'device':'iPhone 11 Pro'," +
            "    'real_mobile':'true'" +
            "}";
        public const string iPhoneSafari = "" +
            "{" +
            "    'browserName':'Safari'," +
            "    'deviceName':'gravity_api_test'," +
            "    'platformVersion':'13'," +
            "    'os_version':'13'," +
            "    'device':'iPhone 11 Pro'," +
            "    'real_mobile':'true'" +
            "}";
        #endregion

        /// <summary>
        /// Gets an <see cref="AutomationEnvironment"/> instance.
        /// </summary>
        /// <param name="driver">Driver type.</param>
        /// <param name="capabilities">Driver capabilities.</param>
        /// <returns>New <see cref="AutomationEnvironment"/> instance.</returns>
        public static AutomationEnvironment Get(string driver, string capabilities)
        {
            // setup
            var environment = new AutomationEnvironment
            {
                SystemParams = new Dictionary<string, object>(),
                TestParams = new Dictionary<string, object>()
            };

            // load system parameters
            foreach (var name in TestContext.Parameters.Names)
            {
                environment.SystemParams[name] = TestContext.Parameters[name];
            }

            // load test parameters
            environment.TestParams["driver"] = driver;
            environment.TestParams["capabilities"] = capabilities;

            // results
            return environment;
        }
    }
}
