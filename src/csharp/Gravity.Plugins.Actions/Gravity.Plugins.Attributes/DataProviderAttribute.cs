﻿/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gravity.Plugins.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class DataProviderAttribute : Attribute, IAttributeable, IExampleable
    {
        /// <summary>
        /// Creates a new instance of <see cref="Attribute"/>.
        /// </summary>
        /// <param name="name">The assertion name that will be used to find and execute the data provider method.</param>
        public DataProviderAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the data provider name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets a literal name for the attribute.
        /// </summary>
        public string Literal { get; set; }

        /// <summary>
        /// Gets or sets the description of the DataProvider.
        /// </summary>
        public string Description { get; set; } = "TBD";

        /// <summary>
        /// Gets or sets the implementation examples of this <see cref="Plugin"/>.
        /// </summary>
        /// <remarks>For knowledge base purposes.</remarks>
        public IEnumerable<PluginExample> Examples { get; set; }

        /// <summary>
        /// Gets a unique identifier for this System.Attribute.
        /// </summary>
        [JsonIgnore]
        public override object TypeId => base.TypeId;
    }
}