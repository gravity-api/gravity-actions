namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Defines the interface through which the user can manipulate JavaScript alerts.
    /// </summary>
    /// <seealso cref="IAlert" />
    public class MockAlert : IAlert
    {
        private readonly MockWebDriver driver;

        /// <summary>
        /// Creates new instance of this MockAlert object.
        /// </summary>
        /// <param name="driver">Parent driver under which this alert exists.</param>
        public MockAlert(MockWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Gets the text of the alert.
        /// </summary>
        public string Text => "mock alert text.";

        /// <summary>
        /// Accepts the alert.
        /// </summary>
        public void Accept()
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Dismisses the alert.
        /// </summary>
        public void Dismiss()
        {
            // setup conditions
            var hasKey = driver.Capabilities.ContainsKey(MockCapabilities.HasAlert);
            var hasAlert = hasKey && (bool)driver.Capabilities[MockCapabilities.HasAlert];

            // dismiss
            if (hasAlert)
            {
                driver.Capabilities[MockCapabilities.HasAlert] = false;
            }
        }

        /// <summary>
        /// Sends keys to the alert.
        /// </summary>
        /// <param name="keysToSend">The keystrokes to send.</param>
        public void SendKeys(string keysToSend)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Sets the user name and password in an alert prompting for credentials.
        /// </summary>
        /// <param name="userName">The user name to set.</param>
        /// <param name="password">The password to set.</param>
        public void SetAuthenticationCredentials(string userName, string password)
        {
            // Method intentionally left empty.
        }
    }
}
