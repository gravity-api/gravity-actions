/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * online resources
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Actions.Contracts
{
    /// <summary>
    /// Available mobile native plugins under Gravity.Plugins.Actions.dll
    /// </summary>
    public static partial class PluginsList
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
