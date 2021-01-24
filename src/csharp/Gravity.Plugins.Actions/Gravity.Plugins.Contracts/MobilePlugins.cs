/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Available mobile native plugins under Gravity.Plugins.Actions.dll
    /// </summary>
    [DataContract]
    public static class MobilePlugins
    {
        [DataMember]
        public const string HideKeyboard = "HideKeyboard";

        [DataMember]
        public const string LongSwipe = "LongSwipe";

        [DataMember]
        public const string SetGeoLocation = "SetGeoLocation";

        [DataMember]
        public const string Swipe = "Swipe";
    }
}
