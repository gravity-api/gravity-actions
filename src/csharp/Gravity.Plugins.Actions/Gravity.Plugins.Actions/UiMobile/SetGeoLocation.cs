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
 * online resources
 * http://appium.io/docs/en/writing-running-appium/android/android-shell/
 * 
 * work items
 * https://github.com/gravity-api/gravity-actions/issues/20
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.Extensions;
using Gravity.Plugins.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using Gravity.Plugins.Attributes;
using Gravity.Plugins.Contracts;

namespace Gravity.Plugins.Actions.UiMobile
{
    [Plugin(
        assembly: "Gravity.Plugins.Actions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
        resource: "Gravity.Plugins.Actions.Documentation.set_geo_location.json",
        Name = MobilePlugins.SetGeoLocation)]
    public class SetGeoLocation : WebDriverActionPlugin
    {
        #region *** arguments    ***
        /// <summary>
        /// The desired GEO location latitude.
        /// </summary>
        public const string Latitude = "lat";

        /// <summary>
        /// The desired GEO location longitude.
        /// </summary>
        public const string Longitude = "lon";

        /// <summary>
        /// The desired GEO location altitude (optional).
        /// </summary>
        public const string Altitude = "alt";
        #endregion

        // members: state
        private IDictionary<string, string> arguments;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of this plugin.
        /// </summary>
        /// <param name="automation">This <see cref="WebAutomation"/> object (the original object sent by the user).</param>
        /// <param name="driver"><see cref="IWebDriver"/> implementation by which to execute the action.</param>
        public SetGeoLocation(WebAutomation automation, IWebDriver driver)
            : base(automation, driver)
        { }
        #endregion

        /// <summary>
        /// Sets the current GEO location.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        public override void OnPerform(ActionRule action)
        {
            DoAction(action);
        }

        /// <summary>
        /// Sets the current GEO location.
        /// </summary>
        /// <param name="action">This <see cref="ActionRule"/> instance (the original object sent by the user).</param>
        /// <param name="element">This <see cref="IWebElement"/> instance on which to perform the action (provided by the extraction rule).</param>
        public override void OnPerform(ActionRule action, IWebElement element)
        {
            DoAction(action);
        }

        // sets the current GEO location
        private void DoAction(ActionRule action)
        {
            // exit conditions
            if (!WebDriver.IsAppiumDriver())
            {
                return;
            }

            // load CLI arguments
            ProcessCli(action);

            // set location property
            var locationProperty = WebDriver.GetType().GetProperty("Location");
            locationProperty.SetValue(WebDriver, GetLocation());
        }

        // process CLI command for default arguments values
        private void ProcessCli(ActionRule action)
        {
            // get arguments
            arguments = CliFactory.Parse(action.Argument);

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