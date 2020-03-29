/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Actions.Contracts
{
    /// <summary>
    /// Available common plugins under Gravity.Plugins.Actions.dll
    /// </summary>
    [DataContract]
    public static class CommonPlugins
    {
        [DataMember]
        public const string Assert = "Assert";

        [DataMember]
        public const string Click = "Click";

        [DataMember]
        public const string CloseBrowser = "CloseBrowser";

        [DataMember]
        public const string Condition = "Condition";

        [DataMember]
        public const string DoubleClick = "DoubleClick";

        [DataMember]
        public const string ExecuteScript = "ExecuteScript";

        [DataMember]
        public const string ExtractFromDom = "ExtractFromDom";

        [DataMember]
        public const string GetScreenshot = "GetScreenshot";

        [DataMember]
        public const string MoveToElement = "MoveToElement";

        [DataMember]
        public const string RegisterParameter = "RegisterParameter";

        [DataMember]
        public const string Repeat = "Repeat";

        [DataMember]
        public const string SendKeys = "SendKeys";

        [DataMember]
        public const string TrySendKeys = "TrySendKeys";

        [DataMember]
        public const string Wait = "Wait";

        [DataMember]
        public const string WaitForElement = "WaitForElement";
    }
}