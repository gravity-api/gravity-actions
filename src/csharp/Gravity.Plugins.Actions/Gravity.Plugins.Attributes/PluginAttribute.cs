﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Attributes.Extensions;
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Gravity.Plugins.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
    public sealed class PluginAttribute: Attribute, IAttributeable, IExampleable
    {
        // members: state
        private readonly Assembly assembly;

        #region *** constructors ***
        /// <summary>
        /// Creates a new instance of <see cref="PluginAttribute"/>.
        /// </summary>
        public PluginAttribute() { }

        /// <summary>
        /// Creates a new instance of <see cref="PluginAttribute"/>.
        /// </summary>
        /// <param name="assembly">Assembly name to load. Must be the assembly name as retrieved from the <see cref="Assembly.FullName"/> property.</param>
        /// <param name="resource">Embedded resource to populate by (use the folders structure as namespace).</param>
        public PluginAttribute(string assembly, string resource)
        {
            // load the assembly with the embedded resource
            this.assembly = Assembly.Load(new AssemblyName(assembly));

            // populate actions meta-data
            Populate(resource);
        }
        #endregion

        #region *** properties   ***
        /// <summary>
        /// Gets or sets a collection of values that can be used as an argument for the Plugin.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IDictionary<string, object> Enum { get; set; }

        /// <summary>
        /// ![Mandatory] Gets or sets the <see cref="Plugin"/> name. Used to identify the <see cref="Plugin"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a literal name for the attribute.
        /// </summary>
        public string Literal { get; set; }

        /// <summary>
        /// ![Mandatory] Gets or sets the <see cref="Plugin"/> type (i.e. Macro, Action, Composed, etc.).
        /// </summary>
        public string PluginType { get; set; }

        /// <summary>
        /// Gets or sets a collection of alternate keywords which can be used to identify the Plugin.
        /// </summary>
        public IEnumerable<string> Aliases { get; set; }

        /// <summary>
        /// Gets or sets an application (name or address) on which the examples of the Plugin can be tested.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public string TestOn { get; set; }

        /// <summary>
        /// Gets or sets the implementation examples of the Plugin.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IEnumerable<PluginExample> Examples { get; set; }

        /// <summary>
        /// Gets or sets a short description about the Plugin.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets a full description about the Plugin.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Plugin execution scopes (i.e. [mobile-native, mobile-web, web]).
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IEnumerable<string> Scope { get; set; }

        /// <summary>
        /// Gets or sets the properties list supported by the Plugin (key: action rule property, value: description).
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IDictionary<string, object> Properties { get; set; }

        /// <summary>
        /// Gets or sets the arguments list supported by the Plugin (key: name, value: description).
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IDictionary<string, object> CliArguments { get; set; }

        /// <summary>
        /// Gets or sets the W3C WebDriver Protocol endpoints information (key: end point, value: description) - if applicable.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IDictionary<string, object> Protocol { get; set; }

        /// <summary>
        /// Gets a unique identifier for this System.Attribute.
        /// </summary>
        [JsonIgnore]
        public override object TypeId => base.TypeId;
        #endregion

        #region *** populate     ***
        /// <summary>
        /// Populate this <see cref="PluginAttribute"/> from provided resources. used for official gravity actions/macros
        /// </summary>
        /// <param name="resource">resource to load KB information from</param>
        private void Populate(string resource)
        {
            // deserialize JSON meta-data into an object
            var pluginAtribute = assembly.GetEmbeddedPluginManifest(resource);

            // exit conditions
            if (pluginAtribute == default)
            {
                return;
            }

            // load properties
            var (Source, Target) = GetProperties(pluginAtribute);

            // iterate properties & set values
            foreach (var sourceProperty in Source)
            {
                // get target property
                var targetProperty = Target.FirstOrDefault(i => CloneCompliant(sourceProperty, i));

                // set value
                targetProperty.SetValue(this, sourceProperty.GetValue(pluginAtribute));
            }
        }

        // get source and target properties collections
        private (IEnumerable<PropertyInfo> Source, IEnumerable<PropertyInfo> Target) GetProperties(PluginAttribute pluginAtribute)
        {
            // constants
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public;

            // source properties
            var properties = pluginAtribute.GetType().GetProperties(Flags) as IEnumerable<PropertyInfo>;
            var source = properties.Where(p => p.GetSetMethod() != null);

            // target properties
            var target = GetType().GetProperties(Flags);

            // tuple
            return (Source: source, Target: target);
        }

        // copy property value from source to target if the property have the same name & type
        private static bool CloneCompliant(PropertyInfo source, PropertyInfo target)
        {
            // set compliance
            var typeCompliant = source.Name.Equals(target.Name);
            var nameCompliant = source.PropertyType == target.PropertyType;

            // compliant
            return typeCompliant && nameCompliant;
        }
        #endregion
    }
}