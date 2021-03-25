// TODO: move to Gravity.Core
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class SelectExtensions
    {
        /// <summary>
        /// Select the option by the index, as determined by the "index" attribute of the
        /// element.
        /// </summary>
        /// <param name="selectElement">This <see cref="SelectElement"/>.</param>
        /// <param name="index">The value of the index attribute of the option to be selected.</param>
        public static void JsSelectByIndex(this SelectElement selectElement, int index)
        {
            // constants
            var script = $"options[{index}].selected = true;";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
        }

        /// <summary>
        /// Select all options by the text displayed.
        /// </summary>
        /// <param name="selectElement">This <see cref="SelectElement"/>.</param>
        /// <param name="text">The text of the option to be selected.</param>
        public static void JsSelectByText(this SelectElement selectElement, string text)
        {
            // constants
            var script =
                "var options = arguments[0].getElementsByTagName(\"option\");" +
                "" +
                "for(i = 0; i < options.length; i++) {" +
                $"   if(options[i].innerText !== \"{text}\") {{" +
                "       continue;" +
                "    }" +
                "    options[i].selected = true;" +
                "    break;" +
                "}";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
        }

        /// <summary>
        /// Select an option by the value.
        /// </summary>
        /// <param name="selectElement"></param>
        /// <param name="value">The value of the option to be selected.</param>
        public static void JsSelectByValue(this SelectElement selectElement, string value)
        {
            // constants
            var script =
                "var options = arguments[0].getElementsByTagName(\"option\");" +
                "" +
                "for(i = 0; i < options.length; i++) {" +
                $"   if(options[i].getAttribute(\"value\") !== \"{value}\") {{" +
                "       continue;" +
                "    }" +
                "    options[i].selected = true;" +
                "    break;" +
                "}";

            // web element to act on
            var onElement = selectElement.WrappedElement;
            var onDriver = (IWrapsDriver)onElement;

            // execute
            ((IJavaScriptExecutor)onDriver).ExecuteScript(script, onElement);
        }
    }
}