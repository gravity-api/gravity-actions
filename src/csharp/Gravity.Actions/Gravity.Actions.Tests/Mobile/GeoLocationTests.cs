﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Drivers.Mock.WebDriver;
using Gravity.Services.ActionPlugins.Mobile;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Mobile
{
    [TestClass]
    public class GeoLocationTests : ActionTests
    {
        [TestMethod]
        public void GeoLocationCreateNoTypes()
        {
            ValidateAction<SetGeoLocation>();
        }

        [TestMethod]
        public void GeoLocationCreateTypes()
        {
            ValidateAction<SetGeoLocation>(Types);
        }

        [TestMethod]
        public void GeoLocationDocumentationNoTypes()
        {
            ValidateActionDocumentation<SetGeoLocation>(ActionType.SetGeoLocation);
        }

        [TestMethod]
        public void GeoLocationDocumentationTypes()
        {
            ValidateActionDocumentation<SetGeoLocation>(ActionType.SetGeoLocation, Types);
        }

        [TestMethod]
        public void GeoLocationDocumentationResourceFile()
        {
            ValidateActionDocumentation<SetGeoLocation>(ActionType.SetGeoLocation, Types, "set-geo-location.json");
        }

        [DataTestMethod]
        [DataRow("{'argument':'{{$ --lat:5.5}}'}")]
        public void GeoLocationLatitudePositive(string actionRule)
        {
            // set new mock driver for mobile device
            WebDriver = new MockAppiumDriver<IWebElement>();

            // execute
            ExecuteAction<SetGeoLocation>(actionRule);

            // assertion (no assertion here, expected is no exception)
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

            // assertion (no assertion here, expected is no exception)
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

            // assertion (no assertion here, expected is no exception)
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

            // assertion (no assertion here, expected is no exception)
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

            // assertion (no assertion here, expected is no exception)
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

            // assertion (no assertion here, expected is no exception)
            var isLat = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Latitude == 7.5;
            var isLon = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Longitude == 5.5;
            var isAlt = ((MockAppiumDriver<IWebElement>)WebDriver).Location.Altitude == 6.5;

            Assert.IsTrue(isLat && isLon && isAlt);
        }
    }
}
#pragma warning restore S4144