/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using Gravity.Plugins.Contracts;
using System;
using System.Collections.Generic;

namespace Gravity.Plugins.Utilities
{
    public class MacroFactory
    {
        // constants
        private const string MacroName = @"(?<={{[$])[^\s,}]*";
        private const string MacroCli = @"{{[$]\w+(\s{1}.*)?}}";

        // members: state
        private IEnumerable<Type> types;

        /// <summary>
        /// Creates a new instance of <see cref="MacroFactory"/> object.
        /// </summary>
        /// <param name="types">A collection of <see cref="Type"/> under which to search for macro <see cref="Base.Plugin"/>.</param>
        public MacroFactory(IEnumerable<Type> types)
        {
            this.types = types;
        }

        public string Get(ActionRule actionRule)
        {
            return "macro place holder";
        }

        public string Get(string macroCli)
        {
            return "macro place holder";
        }

        public T Get<T>(T obj)
        {
            return obj;
        }
    }
}
