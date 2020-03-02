﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Plugins.Actions.Contracts;
using Gravity.Plugins.Actions.UiMobile;
using Gravity.Plugins.Actions.UnitTests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Mock;

#pragma warning disable S4144
namespace Gravity.Plugins.Actions.UnitTests.UiMobile
{
    [TestClass]
    public class GeoLocationTests : ActionTests
    {
        [TestMethod]
        public void GeoLocationCreate()
        {
            ValidateAction<SetGeoLocation>();
        }

        [TestMethod]
        public void GeoLocationDocumentation()
        {
            ValidateActionDocumentation<SetGeoLocation>(MobilePlugins.SetGeoLocation);
        }

        [TestMethod]
        public void GeoLocationDocumentationResourceFile()
        {
            ValidateActionDocumentation<SetGeoLocation>(MobilePlugins.SetGeoLocation, "set-geo-location.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --lat:5.5}}'}")]
        public void GeoLocationLatitudePositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 5.5;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 0.0;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 0.0;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --lon:5.5}}'}")]
        public void GeoLocationLongitudePositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 0.0;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 5.5;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 0.0;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --alt:5.5}}'}")]
        public void GeoLocationAltitudePositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 0.0;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 0.0;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 5.5;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [DataTestMethod]
        [DataRow("{'argument':''}")]
        public void GeoLocationAltitudeNoArguments(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 0.0;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 0.0;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 0.0;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --lon:5.5 --alt:6.5 --lat:NotNumber}}'}")]
        public void GeoLocationAltitudeInvalid(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 0.0;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 5.5;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 6.5;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --lon:5.5 --alt:6.5 --lat:7.5}}'}")]
        public void GeoLocationAll(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 7.5;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 5.5;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 6.5;

            Assert.IsTrue(isLat && isLon && isAlt);
        }

        [TestMethod]
        public void GeoLocationNoIHasLocation()
        {
            // execute
            ExecuteAction<SetGeoLocation>();

            // assertion (no assertion here, expected is no exception)
            Assert.IsTrue(true);
        }
    }
}
#pragma warning restore S4144