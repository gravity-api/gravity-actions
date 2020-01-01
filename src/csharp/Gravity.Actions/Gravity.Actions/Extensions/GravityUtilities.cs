/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Gravity.Services.DataContracts;
using Gravity.Services.DataContracts.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gravity.Services.ActionPlugins.Extensions
{
    public static class GravityUtilities
    {
        /// <summary>
        /// Reflect an ActionFactory instance from Gravity.Core.
        /// </summary>
        /// <param name="webDriver"><see cref="IWebDriver"/> implementation to execute actions against.</param>
        /// <param name="webAutomation"><see cref="WebAutomation"/> data transfer object to execute.</param>
        /// <param name="types">Types in which to search for plug-in components.</param>
        /// <returns>Execution interface of this ActionFactory</returns>
        public static ICanExecute GetActionFactory(IWebDriver webDriver, WebAutomation webAutomation, IEnumerable<Type> types)
        {
            // setup
            const string AssemblyName = "Gravity.Services.Comet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            const string ClassName = "Gravity.Services.Comet.Engine.Core.ActionFactory";

            // get type
            var assembly = Assembly.Load(AssemblyName);
            var type = assembly.GetType(ClassName);

            // create
            return (ICanExecute)Activator.CreateInstance(type, new object[] { webDriver, webAutomation, types });
        }
    }
}
