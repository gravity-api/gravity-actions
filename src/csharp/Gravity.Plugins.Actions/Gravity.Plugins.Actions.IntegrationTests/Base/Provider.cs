﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Gravity.IntegrationTests.Base
{
    public static class Provider
    {
        #region *** constants      ***
        // Windows
        public const string Windows10LatestBrowser = "{'bstack:options':{'os':'Windows','os_version':'10'}}";
        public const string Windows10Edge80 = "{'bstack:options':{'os':'Windows','os_version':'10'}}";
        public const string Windows7LatestBrowser = "{'bstack:options':{'os':'Windows','os_version':'7'}}";
        public const string Windows7IE10 = "{'bstack:options':{'os':'Windows','os_version':'7','browser_version':'10.0'}}";

        // OSX: OSXMojave
        public const string OSXMojaveSafari = "{'bstack:options':{'os':'OS X','os_version':'Mojave','browser_version':'12.1'}}";
        public const string OSXMojaveLatestBrowser = "{'bstack:options':{'os':'OS X','os_version':'Mojave'}}";

        // OSX: Catalina
        public const string OSXCatalinaSafari = "{'bstack:options':{'os':'OS X','os_version':'Catalina','browser_version':'13.0'}}";
        public const string OSXCatalinaLatestBrowser = "{'bstack:options':{'os':'OS X','os_version':'Catalina'}}";

        // Android
        public const string AndroidChrome = "" +
            "{" +
            "    'bstack:options': {" +
            "        'browserName':'Chrome'," +
            "        'deviceName':'gravity_api_test'," +
            "        'platformVersion':'9.0'," +
            "        'os_version':'9.0'," +
            "        'device':'Samsung Galaxy S10 Plus'," +
            "        'real_mobile':'true'" +
            "    }" +
            "}";

        // Android
        public const string AndroidNative = "" +
            "{" +
            "    'bstack:options': {" +
            "        'os_version':'10.0'," +
            "        'device':'Samsung Galaxy S20'," +
            "        'browserstack.debug':'true'," +
            "        'browserstack.console':'verbose'," +
            "        'real_mobile':'true'" +
            "    }" +
            "}";

        // iOS
        public const string iPhoneChrome = "" +
            "{" +
            "    'bstack:options': {" +
            "        'browserName':'Chrome'," +
            "        'deviceName':'gravity_api_test'," +
            "        'platformVersion':'13'," +
            "        'os_version':'13'," +
            "        'device':'iPhone 11 Pro'," +
            "        'real_mobile':'true'" +
            "    }" +
            "}";
        public const string iPhoneSafari = "" +
            "{" +
            "    'bstack:options': {" +
            "        'browserName':'Safari'," +
            "        'deviceName':'gravity_api_test'," +
            "        'platformVersion':'13'," +
            "        'os_version':'13'," +
            "        'device':'iPhone XS'," +
            "        'safariAllowPopups': true," +
            "        'real_mobile':'true'" +
            "    }" +
            "}";
        #endregion

        /// <summary>
        /// Gets an <see cref="Context"/> instance.
        /// </summary>
        /// <param name="driver">Driver type.</param>
        /// <param name="capabilities">Driver capabilities.</param>
        /// <returns>New <see cref="Context"/> instance.</returns>
        public static Context Get(string driver, string capabilities)
        {
            // setup
            var environment = new Context
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
            environment.TestParams["capabilities"]
                = JsonConvert.DeserializeObject<Dictionary<string, object>>(capabilities);

            // results
            return environment;
        }

        /// <summary>
        /// Gets an <see cref="Context"/> instance.
        /// </summary>
        /// <param name="driver">Driver type.</param>
        /// <param name="capabilities">Driver capabilities.</param>
        /// <param name="json">JSON object with additional test parameters</param>
        /// <returns>New <see cref="Context"/> instance.</returns>
        public static Context Get(string driver, string capabilities, string json)
        {
            // setup
            var environment = new Context
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
            environment.TestParams["capabilities"]
                = JsonConvert.DeserializeObject<Dictionary<string, object>>(capabilities);

            // add additional parameters
            foreach (var item in JsonConvert.DeserializeObject<Dictionary<string, object>>(json))
            {
                environment.TestParams[item.Key] = item.Value;
            }

            // results
            return environment;
        }

        /// <summary>
        /// Gets an <see cref="Context"/> instance.
        /// </summary>
        /// <param name="driver">Driver type.</param>
        /// <param name="capabilities">Driver capabilities.</param>
        /// <param name="json">JSON object with additional test parameters</param>
        /// <returns>New <see cref="Context"/> instance.</returns>
        public static IEnumerable Yield(string driver, string capabilities, string json)
        {
            yield return Get(driver, capabilities, json);
        }
    }
}