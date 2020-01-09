/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * 2019-02-19
 *    - modify: improve XML comments
 *    - modify: override action-name using ActionType constant
 *    
 * 2019-12-31
 *    - modify: add constructor to override base class types
 * 
 * on-line resources
 * http://appium.io/docs/en/writing-running-appium/android/android-shell/
 * 
 * notes
 * change to driver casting for Location implementation to an interface casting when available (DoGeoLocation)
 * 
 * work items
 * TODO: use IHasLocation interface when available (DoGeoLocation)
 */
using Gravity.Services.ActionPlugins.Extensions;
using Gravity.Services.Comet.Engine.Attributes;
using Gravity.Services.Comet.Engine.Core;
using Gravity.Services.Comet.Engine.Extensions;
using Gravity.Services.Comet.Engine.Plugins;
using Gravity.Services.DataContracts;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;

namespace Gravity.Services.ActionPlugins.Mobile
{
    [Action(
        assmebly: "Gravity.Services.ActionPlugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Services.ActionPlugins.Documentation.set-geo-location.json",
        Name = ActionType.SetGeoLocation)]
    public class SetGeoLocation : ActionPlugin
    {
        // constants: arguments
        public const string Latitude = "lat";
        public const string Longitude = "lon";
        public const string Altitude = "alt";

        // members: state
        private IDictionary<string, string> arguments;

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        public SetGeoLocation(IWebDriver webDriver, WebAutomation webAutomation)
            : this(webDriver, webAutomation, Utilities.GetTypes())
        { }

        /// <summary>
        /// Creates a new instance of this plug-in.
        /// </summary>
        /// <param name="webDriver">WebDriver implementation by which to execute the action.</param>
        /// <param name="webAutomation">This WebAutomation object (the original object sent by the user).</param>
        /// <param name="types">Types from which to load plug-ins repositories.</param>
        public SetGeoLocation(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
            : base(webDriver, webAutomation, types)
        { }

        /// <summary>
        /// Sets the current GEO location.
        /// </summary>
        /// <param name="actionRule">This ActionRule instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule actionRule)
        {
            DoGeoLocation(actionRule);
        }

        /// <summary>
        /// Sets the current GEO location.
        /// </summary>
        /// <param name="webElement">This WebElement instance on which to perform the action (provided by the extraction rule).</param>
        /// <param name="actionRule">This ActionRule instance (the original object send by the user).</param>
        public override void OnPerform(IWebElement webElement, ActionRule actionRule)
        {
            DoGeoLocation(actionRule);
        }

        // sets the current GEO location
        private void DoGeoLocation(ActionRule actionRule)
        {
            // constants: messages
            const string Warn = "Action [GeoLocation] was skipped. This action is not supported by [{0}] driver.";

            // exit conditions
            if (!WebDriver.IsAppiumDriver())
            {
                Logger.LogWarning(string.Format(Warn, WebDriver.GetType().FullName));
                return;
            }

            // load CLI arguments
            ProcessCli(actionRule);

            // set location property
            var locationProperty = WebDriver.GetType().GetProperty("Location");
            locationProperty.SetValue(WebDriver, GetLocation());
        }

        // process CLI command for default arguments values
        private void ProcessCli(ActionRule actionRule)
        {
            // get arguments
            arguments = new CliFactory(actionRule.Argument).Parse();

            // argument: Latitude
            if (!arguments.ContainsKey(Latitude))
            {
                arguments[Latitude] = "0";
            }

            // argument: Longitude
            if (!arguments.ContainsKey(Longitude))
            {
                arguments[Longitude] = "0";
            }

            // argument: Longitude
            if (!arguments.ContainsKey(Altitude))
            {
                arguments[Altitude] = "0";
            }
        }

        //  gets a new location based on arguments
        private Location GetLocation()
        {
            // parse arguments
            double.TryParse(arguments[Latitude], out double latitude);
            double.TryParse(arguments[Longitude], out double longitude);
            double.TryParse(arguments[Altitude], out double altitude);

            // set new property value
            return new Location { Altitude = altitude, Longitude = longitude, Latitude = latitude };
        }
    }
}