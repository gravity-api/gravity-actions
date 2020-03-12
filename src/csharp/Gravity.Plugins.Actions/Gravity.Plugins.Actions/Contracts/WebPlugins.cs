/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using System.Runtime.Serialization;

namespace Gravity.Plugins.Actions.Contracts
{
    /// <summary>
    /// Available web plugins under Gravity.Plugins.Actions.dll
    /// </summary>
    [DataContract]
    public static class WebPlugins
    {
        [DataMember]
        public const string CloseAllChildWindows = "CloseAllChildWindows";

        [DataMember]
        public const string CloseWindow = "CloseWindow";

        [DataMember]
        public const string ContextClick = "ContextClick";

        [DataMember]
        public const string ElementsListener = "ElementsListener";

        [DataMember]
        public const string GoToUrl = "GoToUrl";

        [DataMember]
        public const string Keyboard = "Keyboard";

        [DataMember]
        public const string NavigateBack = "NavigateBack";

        [DataMember]
        public const string NavigateForward = "NavigateForward";

        [DataMember]
        public const string Refresh = "Refresh";

        [DataMember]
        public const string Scroll = "Scroll";

        [DataMember]
        public const string SelectFromComboBox = "SelectFromComboBox";

        [DataMember]
        public const string SubmitForm = "SubmitForm";

        [DataMember]
        public const string SwitchToAlert = "SwitchToAlert";

        [DataMember]
        public const string SwitchToDefaultContent = "SwitchToDefaultContent";

        [DataMember]
        public const string SwitchToFrame = "SwitchToFrame";

        [DataMember]
        public const string SwitchToWindow = "SwitchToWindow";

        [DataMember]
        public const string TryClick = "TryClick";

        [DataMember]
        public const string UploadFile = "UploadFile";

        [DataMember]
        public const string WaitForPage = "WaitForPage";

        [DataMember]
        public const string WaitForUrl = "WaitForUrl";
    }
}