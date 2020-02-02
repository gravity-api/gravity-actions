using System.Runtime.Serialization;

namespace Gravity.Plugins.Actions.Contracts
{
    /// <summary>
    /// Available action plugins under Gravity.Plugins.Actions.dll
    /// </summary>
    [DataContract]
    public static class ActionPlugins
    {
        [DataMember]
        public const string Click = "Click";

        [DataMember]
        public const string CloseAllChildWindows = "CloseAllChildWindows";

        [DataMember]
        public const string CloseBrowser = "CloseBrowser";

        [DataMember]
        public const string CloseWindow = "CloseWindow";

        [DataMember]
        public const string ContextClick = "ContextClick";

        [DataMember]
        public const string DoubleClick = "DoubleClick";

        [DataMember]
        public const string ElementsListener = "ElementsListener";

        [DataMember]
        public const string ExecuteScript = "ExecuteScript";

        [DataMember]
        public const string GetScreenshot = "GetScreenshot";

        [DataMember]
        public const string HideKeyboard = "HideKeyboard";

        [DataMember]
        public const string Keyboard = "Keyboard";

        [DataMember]
        public const string LongSwipe = "LongSwipe";

        [DataMember]
        public const string NavigateBack = "NavigateBack";

        [DataMember]
        public const string NavigateForward = "NavigateForward";

        [DataMember]
        public const string Refresh = "Refresh";

        [DataMember]
        public const string RegisterParameter = "RegisterParameter";

        [DataMember]
        public const string Repeat = "Repeat";

        [DataMember]
        public const string SelectFromComboBox = "SelectFromComboBox";

        [DataMember]
        public const string SendKeys = "SendKeys";

        [DataMember]
        public const string SetGeoLocation = "SetGeoLocation";

        [DataMember]
        public const string SubmitForm = "SubmitForm";

        [DataMember]
        public const string SwitchToAlert = "SwitchToAlert";

        [DataMember]
        public const string TryClick = "TryClick";

        [DataMember]
        public const string Wait = "Wait";
    }
}