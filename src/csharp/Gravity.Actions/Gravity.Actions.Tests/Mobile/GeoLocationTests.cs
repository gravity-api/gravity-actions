/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.ActionPlugins.Mobile;
using Gravity.Services.ActionPlugins.Tests.Base;
using Gravity.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable S4144
namespace Gravity.Services.ActionPlugins.Tests.Mobile
{
    [TestClass]
    public class GeoLocationTests : ActionTests
    {
        [TestMethod]
        public void GeoLocationCreateNoTypes()
        {
            ValidateAction<GeoLocation>();
        }

        [TestMethod]
        public void GeoLocationCreateTypes()
        {
            ValidateAction<GeoLocation>(Types);
        }

        [TestMethod]
        public void GeoLocationDocumentationNoTypes()
        {
            ValidateActionDocumentation<GeoLocation>(ActionType.GEO_LOCATION);
        }

        [TestMethod]
        public void GeoLocationDocumentationTypes()
        {
            ValidateActionDocumentation<GeoLocation>(ActionType.GEO_LOCATION, Types);
        }

        [TestMethod]
        public void GeoLocationDocumentationResourceFile()
        {
            ValidateActionDocumentation<GeoLocation>(ActionType.GEO_LOCATION, Types, "geo-location.json");
        }
    }
}
#pragma warning restore S4144