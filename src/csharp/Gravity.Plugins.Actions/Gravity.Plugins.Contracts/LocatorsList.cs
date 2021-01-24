/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Runtime.Serialization;

#pragma warning disable
namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// Describes a contract for sending gravity <see cref="LocatorsList"/> to Gravity Service.
    /// </summary>
    [DataContract]
    public static partial class LocatorsList
    {
        [DataMember]
        public const string Bindings = "Bindings";

        [DataMember]
        public const string ClassName = "ClassName";

        [DataMember]
        public const string CssSelector = "CssSelector";

        [DataMember]
        public const string Id = "Id";

        [DataMember]
        public const string LinkText = "LinkText";

        [DataMember]
        public const string Model = "Model";

        [DataMember]
        public const string Name = "Name";

        [DataMember]
        public const string PartialLinkText = "PartialLinkText";

        [DataMember]
        public const string TagName = "TagName";

        [DataMember]
        public const string Xpath = "Xpath";
    }
}