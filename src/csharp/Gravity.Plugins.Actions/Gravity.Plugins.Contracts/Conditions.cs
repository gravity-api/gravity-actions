/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using OpenQA.Selenium;

using System;

namespace Gravity.Plugins.Contracts
{
    /// <summary>
    /// A list of conditions constants.
    /// </summary>
    /// <remarks>You can use conditions which are not listed here, if they are available.</remarks>
    public static class Conditions
    {
        /// <summary>
        /// Assert that IWebElement is active element (focused).
        /// </summary>
        public const string Active = "active";

        /// <summary>
        /// Assert that <see cref="IAlert"/> exists.
        /// </summary>
        public const string AlertExists = "alert_exists";

        /// <summary>
        /// Assert that IWebElement attribute from <see cref="Rule.OnAttribute"/> meets a condition.
        /// </summary>
        public const string Attribute = "attribute";

        /// <summary>
        /// Assert that count of the given elements (total) meets a condition.
        /// </summary>
        public const string Count = "count";

        /// <summary>
        /// Assert that IWebElement exists in the DOM, it is not intractable.
        /// </summary>
        public const string Disabled = "disabled";

        /// <summary>
        /// Assert that IWebDriver <see cref="Type.FullName"/> meets a condition.
        /// </summary>
        public const string Driver = "driver";

        /// <summary>
        /// Assert that IWebElement exists in the DOM, is visible state is <see cref="true"/> and it is intractable.
        /// </summary>
        public const string Enabled = "enabled";

        /// <summary>
        /// Assert that IWebElement exists in the DOM.
        /// </summary>
        public const string Exists = "exists";

        /// <summary>
        /// Assert that IWebElement exists in the DOM and its visible state is <see cref="false"/>.
        /// </summary>
        public const string Hidden = "hidden";

        /// <summary>
        /// Assert that on-screen mobile keyboard is open.
        /// </summary>
        public const string HasKeyboard = "keyboard_visible";

        /// <summary>
        /// Assert that on-screen mobile keyboard is close.
        /// </summary>
        public const string NoKeyboard = "keyboard_hidden";

        /// <summary>
        /// Assert that <see cref="IAlert"/> does not exists.
        /// </summary>
        public const string NoAlert = "no_alert";

        /// <summary>
        /// Assert that IWebElement is not exists in the DOM.
        /// </summary>
        public const string NotExists = "not_exists";

        /// <summary>
        /// Assert that IWebElement selected state is <see cref="false"/>.
        /// </summary>
        public const string NotSelected = "not_selected";

        /// <summary>
        /// Assert that IWebElement state is not stale (i.e. modified on run time).
        /// </summary>
        public const string NotStale = "not_stale";

        /// <summary>
        /// Assert that <see cref="EnvironmentContext.ApplicationParams"/> parameter meets a condition.
        /// </summary>
        public const string Parameter = "parameter";

        /// <summary>
        /// Assert that IWebElement selected state is <see cref="true"/>.
        /// </summary>
        public const string Selected = "selected";

        /// <summary>
        /// Assert that IWebElement state is stale (i.e. modified on run time).
        /// </summary>
        public const string Stale = "stale";

        /// <summary>
        /// Assert that <see cref="IWebDriver.Title"/> meets a condition.
        /// </summary>
        public const string Title = "title";

        /// <summary>
        /// Assert that <see cref="IWebElement.Text"/> meets a condition.
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// Assert that length of a given string satisfy a condition.
        /// </summary>
        public const string TextLength = "text_length";

        /// <summary>
        /// Assert that <see cref="IWebDriver.Url"/> meets a condition.
        /// </summary>
        public const string Url = "url";

        /// <summary>
        /// Assert that IWebElement exists in the DOM and its visible state is <see cref="true"/>.
        /// </summary>
        public const string Visible = "visible";

        /// <summary>
        /// Assert that <see cref="IWebDriver.WindowHandles"/> count meets a condition.
        /// </summary>
        public const string WindowsCount = "windows_count";
    }
}